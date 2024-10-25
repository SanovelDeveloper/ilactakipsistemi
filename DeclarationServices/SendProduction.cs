using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using System.IO;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using LINQ;
using DeclarationServices.ProductionService;
using Functions;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System.Web.Script.Serialization;

namespace DeclarationServices
{
    public class SendProduction
    {
        public SendProduction(int AUsrId, char AEnvironment, string AConnectionString)
        {
            Global.UsrId = AUsrId;
            Global.Environment = AEnvironment;
            Global.ConnectionString = AConnectionString;
            Global.Settings = new Settings(AEnvironment);
        }
        public class Response
        {
            [JsonProperty("notificationid")]
            public string notificationid { get; set; }
            [JsonProperty("md")]
            public string md { get; set; }
            [JsonProperty("gtin")]
            public string gtin { get; set; }
            [JsonProperty("xd")]
            public string xd { get; set; }
            [JsonProperty("bn")]
            public string bn { get; set; }
            [JsonProperty("snresponselist")]
            public List<Snresponselist> snresponselist { get; set; }
        }

        public class Snresponselist
        {
            [JsonProperty("sn")]
            public string sn { get; set; }
            [JsonProperty("rc")]
            public string rc { get; set; }
        }
        private int iHareketParentID = 0;
        private int iBildirimiIcinCalisanThreadSayisi = 0;
        private bool bThreadCalisiyor = false;

        public int UretimBildirimineBasla(int KayitAdedi, string UretimEmriNo)
        {
            try
            {
                iHareketParentID = 0;
                int iDonguAdedi = (KayitAdedi / Global.Settings.DeclarationCount);
                if (Convert.ToDouble(KayitAdedi) / Convert.ToDouble(Global.Settings.DeclarationCount) != iDonguAdedi) iDonguAdedi++;
                iBildirimiIcinCalisanThreadSayisi = iDonguAdedi;

                bThreadCalisiyor = false;
                for (int i = 0; i < iDonguAdedi; i++)
                {
                    while (bThreadCalisiyor)
                        System.Windows.Forms.Application.DoEvents();

                    Thread thrUretim = new Thread(new ParameterizedThreadStart(UretimBildirimiGonderAsync));
                    thrUretim.Start(new Global.DeclarationParameters(UretimEmriNo, i, Global.Settings.DeclarationCount));
                    bThreadCalisiyor = true;
                }

                while (iBildirimiIcinCalisanThreadSayisi > 0)
                    System.Windows.Forms.Application.DoEvents();

                if (iBildirimiIcinCalisanThreadSayisi <= 0)
                {
                    return iHareketParentID;

                }
                else return -1;
            }
            catch
            {
                throw;
            }
        }

        private async void UretimBildirimiGonderAsync(object BP)
        {
            string sHata = "";
            string sGLNNumarasi = "";
            string sKullaniciAdi = "";
            string sSifre = "";
            string sOrderId = ((Global.DeclarationParameters)BP).OrderId;
            var PMMID = 0;

            using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
            {
                try
                {
                    string Url = Global.Settings.Services.Production;
                    string Anahtar = "UR" + sOrderId.ToString() + "_" + ((Global.DeclarationParameters)BP).SiraNumarasi.ToString();
                    string OrderID = sOrderId.ToString();
                    int iReturnValue = lITS.Package_Movement_Master_Insert(Anahtar, sOrderId, 'P', ((Global.DeclarationParameters)BP).SiraNumarasi > 1 ? (int?)iHareketParentID : null, null, Global.UsrId, Global.Environment, (Global.UsrId == -1 ? true : false)); /// @bilgehan G

                    //// int iReturnValue = 1111111; /// @bilgehan Test
                    PMMID = iReturnValue;
                    if (((Global.DeclarationParameters)BP).SiraNumarasi == 1)
                        iHareketParentID = PMMID;

                    string sDosyaAdi = "Uretim-" + PMMID.ToString() + "-" + Anahtar + "-" + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".xml";


                    Anahtar = "UR" + sOrderId.ToString() + "_" + PMMID.ToString();

                    lITS.Package_Movement_Master_Update(PMMID, null, sDosyaAdi, null); ////// @bilgehan G

                    var tOrderDetail = lITS.Order_Detail(sOrderId).ToList();
                    if (tOrderDetail.Count == 0) throw new Exception("Kayıt bulunamadı!");

                    var OrderDetail = tOrderDetail.First();

                    switch (OrderDetail.mmr_registered_to.ToString())
                    {
                        case "0":
                            sGLNNumarasi = Global.Settings.Security.SanovelGLN;
                            sKullaniciAdi = Global.Settings.Security.SanovelUser;
                            sSifre = Global.Settings.Security.SanovelPassword;
                            break;
                        case "1":
                            sGLNNumarasi = Global.Settings.Security.AsetGLN;
                            sKullaniciAdi = Global.Settings.Security.AsetUser;
                            sSifre = Global.Settings.Security.AsetPassword;
                            break;
                        case "2":
                            sGLNNumarasi = Global.Settings.Security.AdilnaGLN;
                            sKullaniciAdi = Global.Settings.Security.AdilnaUser;
                            sSifre = Global.Settings.Security.AdilnaPassword;
                            break;
                        case "3":
                            sGLNNumarasi = Global.Settings.Security.ArvenGLN;
                            sKullaniciAdi = Global.Settings.Security.ArvenUser;
                            sSifre = Global.Settings.Security.ArvenPassword;
                            break;
                    }


                    var tSendingPackages = lITS.Package_List_Browse_For_Sending(sOrderId, 'W', null, ((Global.DeclarationParameters)BP).KayitAdedi).ToList();
                    var sendlist = tSendingPackages.Select(i => new { i.pck_code }).ToList();

                    List<string> customlist = new List<string>();


                    foreach (var item in sendlist)
                    {
                        customlist.Add(item.pck_code);

                    }

                    #region Üretim bildirim xml oluşturma
                    URUNLER urunler = new URUNLER();
                    urunler.SN = customlist;
                    BELGE document = new BELGE();
                    document.DN = Anahtar; //Boş kabul ediliyor.
                    document.DD = Convert.ToDateTime(OrderDetail.start_date).ToString("yyyy-MM-dd"); //Boş kabul ediliyor.
                    UretimBildirimType prodDeclaration = new UretimBildirimType();
                    prodDeclaration.DT = "M";
                    prodDeclaration.MI = sGLNNumarasi;
                    prodDeclaration.PT = "PP";
                    prodDeclaration.GTIN = OrderDetail.mmr_gtin;
                    prodDeclaration.XD = Convert.ToDateTime(OrderDetail.expiry_date).ToString("yyyy-MM-dd");
                    prodDeclaration.BN = OrderDetail.ord_batch_no;
                    prodDeclaration.MD = Convert.ToDateTime(OrderDetail.start_date).ToString("yyyy-MM-dd");
                    prodDeclaration.URUNLER = urunler;
                    prodDeclaration.BELGE = document;
                    DosyaOlustur(prodDeclaration, sDosyaAdi);
                    #endregion



                    if (tSendingPackages.Count == 0) throw new Exception("Kayıt bulunamadı!");
                    ArrayList alUBTU = new ArrayList();
                    using (var client = new HttpClient())
                    {
                        var url = Global.Settings.Services.Token;
                        JObject oJsonObject = new JObject();
                        oJsonObject.Add("username", sKullaniciAdi);
                        oJsonObject.Add("password", sSifre);

                        var response = await client.PostAsync(url, new StringContent(oJsonObject.ToString(), Encoding.UTF8, "application/json"));

                        var responseBody = await response.Content.ReadAsStringAsync();
                        var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody)["token"].ToString();
                        var client2 = new HttpClient();
                        var url2 = Global.Settings.Services.Production;
                        client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        var data = new
                        {
                            dt = "M",
                            mi = sGLNNumarasi,
                            pt = "PP",
                            gtin = OrderDetail.mmr_gtin,
                            xd = Convert.ToDateTime(OrderDetail.expiry_date).ToString("yyyy-MM-dd"),
                            bn = OrderDetail.ord_batch_no,
                            md = Convert.ToDateTime(OrderDetail.start_date).ToString("yyyy-MM-dd"),
                            snlist = customlist
                        };

                        var requestdata = JsonConvert.SerializeObject(data);

                        var response2 = await client2.PostAsync(url2, new StringContent(requestdata, Encoding.UTF8, "application/json"));
                        var responseBody2 = await response2.Content.ReadAsStringAsync();

                        if (response2.IsSuccessStatusCode == false)
                        {
                            sHata = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody2)["fm"].ToString();

                        }


                        lITS.Package_Movement_Master_Update(PMMID, JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody2)["notificationid"].ToString(), null, sDosyaAdi);

                        var responseList = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody2)["snresponselist"];


                        var snlist = JObject.Parse(responseBody2)["snresponselist"].Select(el => new { SN = (string)el["sn"] }).ToList();
                        var rclist = JObject.Parse(responseBody2)["snresponselist"].Select(el => new { RC = (string)el["rc"] }).ToList();

                        List<Global.PackageCodes> PackageCodes = new List<Global.PackageCodes>();


                        var sendlist2 = tSendingPackages.Select(i => new { i.pck_id, i.pck_code }).ToList();

                        foreach (var SendingPackages in sendlist2)
                        {
                            PackageCodes.Add(new Global.PackageCodes((int)SendingPackages.pck_id, SendingPackages.pck_code));
                        }


                        List<Global.Sonuclar> lSonuclar = new List<Global.Sonuclar>();

                        for (int i = 0; i < snlist.Count; i++)
                        {
                            lSonuclar.Add(new Global.Sonuclar(rclist[i].RC, Global.AmbalajKodunaGoreIDDondur(PackageCodes, snlist[i].SN)));
                        }
                        lSonuclar.Sort();

                        int k = 0;
                        string sAmbalajIDleri = "";
                        for (int i = 0; i < lSonuclar.Count; i++)
                        {
                            k++;
                            sAmbalajIDleri += lSonuclar[i].AmbalajID + ",";
                            if (k == 999999 || i == lSonuclar.Count - 1 || lSonuclar[i].Sonuc != lSonuclar[i + 1].Sonuc)
                            {
                                lITS.Package_Movement_Detail_Batch_Insert(PMMID, lSonuclar[i].Sonuc, sAmbalajIDleri);

                                k = 0;
                                sAmbalajIDleri = "";
                            }
                        }

                        string check1 = "1. neden";


                    }

                }
                catch (Exception ex)
                {


                    try
                    {
                        if (sHata != "") sHata = "FC :: " + sHata;
                        else sHata = "EX :: " + ex.Message;
                    }
                    catch (Exception ex2)
                    {
                        sHata = "EX :: " + ex2.Message;
                    }
                    if (sHata != "")
                        lITS.ErrorInsert(PMMID, sHata);
                }
                finally
                {

                    bThreadCalisiyor = false;

                    iBildirimiIcinCalisanThreadSayisi--;
                }
                string check2 = "2. neden";
            }

        }

        public string DosyaOlustur(UretimBildirimType model, string sDosyaAdi)
        {
            string result = string.Empty;

            string sTempDir = Global.Settings.Directory.Outgoing;
            string sFullPath = sTempDir + @"\" + sDosyaAdi;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UretimBildirimType));

            StreamWriter streamWriter = new StreamWriter(sTempDir + @"\" + sDosyaAdi);

            xmlSerializer.Serialize(streamWriter, model);


            return result;
        }

        [XmlRoot(ElementName = "BELGE")]
        public class BELGE
        {

            [XmlElement(ElementName = "DD")]
            public string DD { get; set; }

            [XmlElement(ElementName = "DN")]
            public string DN { get; set; }
        }

        [XmlRoot(ElementName = "URUNLER")]
        public class URUNLER
        {

            [XmlElement(ElementName = "SN")]
            public List<string> SN { get; set; }
            public URUNLER()
            {

                SN = new List<string>();
            }

        }

        [XmlRoot(ElementName = "UretimBildirimType")]
        public class UretimBildirimType
        {

            [XmlElement(ElementName = "DT")]
            public string DT { get; set; }

            [XmlElement(ElementName = "MI")]
            public string MI { get; set; }

            [XmlElement(ElementName = "PT")]
            public string PT { get; set; }

            [XmlElement(ElementName = "MD")]
            public string MD { get; set; }

            [XmlElement(ElementName = "GTIN")]
            public string GTIN { get; set; }

            [XmlElement(ElementName = "XD")]
            public string XD { get; set; }

            [XmlElement(ElementName = "BN")]
            public string BN { get; set; }

            [XmlElement(ElementName = "BELGE")]
            public BELGE BELGE { get; set; }

            [XmlElement(ElementName = "URUNLER")]
            public URUNLER URUNLER { get; set; }
        }

        //public class UretimBildirimType
        //{

        //    public string DT { get; set; }
        //    public string MI { get; set; }
        //    public string PT { get; set; }
        //    public string MD { get; set; }
        //    public string GTIN { get; set; }
        //    public string XD { get; set; }
        //    public string BN { get; set; }
        //    public BELGE BELGE { get; set; }
        //    public URUNLER URUNLER { get; set; }
        //}
        //public class BELGE
        //{
        //    public string DD { get; set; }
        //    public string DN { get; set; }
        //}

        //public class URUNLER
        //{
        //    public List<string> SN { get; set; }

        //    public URUNLER()
        //    {
        //        SN = new List<string>();
        //    }

        //}
    }
}

