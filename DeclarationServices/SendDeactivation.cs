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
using DeclarationServices.DeactivationService;
using Functions;
using Newtonsoft.Json;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
//using static Functions.Global;

namespace DeclarationServices
{
    public class SendDeactivation
    {
        public SendDeactivation(int AUsrId, char AEnvironment, string AConnectionString)
        {
            Global.UsrId = AUsrId;
            Global.Environment = AEnvironment;
            Global.ConnectionString = AConnectionString;
            Global.Settings = new Settings(AEnvironment);
        }

        private int iHareketParentID = 0;
        private int iBildirimiIcinCalisanThreadSayisi = 0;
        private bool bThreadCalisiyor = false;

        public int DeaktivasyonBildirimineBasla(int KayitAdedi, int TekSeferdeGonderilecekKayitAdedi, string UretimEmriNo)
        {
            try
            {
                iHareketParentID = 0;
                int iDonguAdedi = (KayitAdedi / TekSeferdeGonderilecekKayitAdedi);
                if (Convert.ToDouble(KayitAdedi) / Convert.ToDouble(TekSeferdeGonderilecekKayitAdedi) != iDonguAdedi) iDonguAdedi++;
                iBildirimiIcinCalisanThreadSayisi = iDonguAdedi;

                bThreadCalisiyor = false;
                for (int i = 0; i < iDonguAdedi; i++)
                {
                    while (bThreadCalisiyor)
                        System.Windows.Forms.Application.DoEvents();

                    Thread thrUretim = new Thread(new ParameterizedThreadStart(DeaktivasyonBildirimiGonder));
                    thrUretim.Start(new Global.DeclarationParameters(UretimEmriNo, i, TekSeferdeGonderilecekKayitAdedi));
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
            catch (Exception)
            {

                throw;
            }

        }


        private async void DeaktivasyonBildirimiGonder(object BP)
        {
            string sHata = "";
            string sGLNNumarasi = "";
            string sKullaniciAdi = "";
            string sSifre = "";
            string sOrderId = ((Global.DeclarationParameters)BP).OrderId;
            var PMMID = 0;

            using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 240000 })
            {
                try
                {
                    // Package_Movement_Master_Insert da 'T' ile Global.Environment değiştir: canlıya alırken

                    string Anahtar = "DA" + sOrderId.ToString() + "_" + ((Global.DeclarationParameters)BP).SiraNumarasi.ToString();
                    string OrderID = sOrderId.ToString();

                    int iReturnValue = lITS.Package_Movement_Master_Insert(Anahtar, sOrderId, 'D', ((Global.DeclarationParameters)BP).SiraNumarasi > 1 ? (int?)iHareketParentID : null, null, Global.UsrId, Global.Environment, (Global.UsrId == -1 ? true : false));

                    PMMID = iReturnValue;
                    if (((Global.DeclarationParameters)BP).SiraNumarasi == 1)
                        iHareketParentID = PMMID;

                    string sDosyaAdi = "Deaktivasyon-" + PMMID.ToString() + "-" + Anahtar + "-" + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".xml";

                    Anahtar = "DA" + sOrderId.ToString() + "_" + PMMID.ToString();

                    lITS.Package_Movement_Master_Update(PMMID, null, sDosyaAdi, null);

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

                    string sGTIN = OrderDetail.mmr_gtin;
                    //if (Global.Environment == 'T') sGTIN = "08680015802145";
                    string sXD = OrderDetail.expiry_date;
                    string sBN = OrderDetail.ord_batch_no; // Seri no


                    var tDeaktivationPackages = lITS.Package_List_Browse_For_Deaktivation(sOrderId, null, ((Global.DeclarationParameters)BP).KayitAdedi).ToList();

                    if (tDeaktivationPackages.Count == 0) throw new Exception("Kayıt bulunamadı!");

                    DeactivationDocument document = new DeactivationDocument();
                    document.dn = ""; //Boş kabul ediliyor.
                    document.dd = ""; //Boş kabul ediliyor.

                    List<DeactivationProduct> productList = new List<DeactivationProduct>();

                    foreach (var DeaktivationPackage in tDeaktivationPackages)
                    {
                        productList.Add(new DeactivationProduct()
                        {
                            gtin = sGTIN,
                            sn = DeaktivationPackage.pck_code,
                            bn = sBN,
                            xd = Convert.ToDateTime(sXD).ToString("yyyy-MM-dd")
                        });
                    }



                    // G de bu kısım kaldırılacak @bilgehan
                    //sGLNNumarasi = "8699536000015";
                    //sKullaniciAdi = "86995360000150000";
                    //sSifre = "823Jeqf@";


                    //if (Global.Environment == 'T') //@bilgehan bu kısmı test için düzenle
                    //    sGLNNumarasi = Global.Settings.Security.SanovelGLN;


                    using (var client = new HttpClient())
                    {
                        var url = Global.Settings.Services.Token; // @bilgehan Json Token Url G
                                                                  // var url = "https://itstest2.saglik.gov.tr/token/app/token/"; // @bilgehan Json Token Url T

                        JObject oJsonObject = new JObject();
                        oJsonObject.Add("username", sKullaniciAdi);
                        oJsonObject.Add("password", sSifre);

                        var response = await client.PostAsync(url, new StringContent(oJsonObject.ToString(), Encoding.UTF8, "application/json"));

                        var responseBody = await response.Content.ReadAsStringAsync();
                        var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody)["token"].ToString();
                        var clientDataPost = new HttpClient();
                        var urlDeactivation = Global.Settings.Services.Deactivation; // @bilgehan Json Deactivation Url G
                        //var urlDeactivation = "https://itstest2.saglik.gov.tr/common/app/deactivation/"; // @bilgehan Json Deactivation Url T
                        clientDataPost.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                        DeactivationModel model = new DeactivationModel();
                        model.dt = "D";
                        model.frGln = sGLNNumarasi;
                        model.ds = "10";
                        model.description = "Sistemden Çıkarma Sebebiyle deaktivasyon";
                        model.document = document;
                        model.productList = productList;


                        var requestdata = JsonConvert.SerializeObject(model);

                        var responseDeactivation = await clientDataPost.PostAsync(urlDeactivation, new StringContent(requestdata, Encoding.UTF8, "application/json"));
                        var responseDeactivationBody = await responseDeactivation.Content.ReadAsStringAsync();

                        if (responseDeactivation.IsSuccessStatusCode == false)
                        {
                            sHata = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseDeactivationBody)["fm"].ToString();
                            //fm/faultMessage and fc/faultCode
                            throw new Exception(sHata);
                        }


                        //string xmlPathTest = @"\\172.16.110.245\ITS_Files\Files\Deactive";

                        SaveDeactivationDataAsXML(model, sDosyaAdi, Global.Settings.Directory.Outgoing);  //Database de Deactive path yok. Global.Settings.Directory.Outgoing

                        string notificationId = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseDeactivationBody)["notificationid"].ToString();

                        lITS.Package_Movement_Master_Update(PMMID, notificationId, null, sDosyaAdi);

                        var responseList = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseDeactivationBody)["productList"];


                        var snlist = JObject.Parse(responseDeactivationBody)["productList"].Select(el => new { SN = (string)el["sn"] }).ToList();//Bildirime konu ürününün Sıra Numarası
                        var uclist = JObject.Parse(responseDeactivationBody)["productList"].Select(el => new { RC = (string)el["uc"] }).ToList(); //bildiriminin sağlıklı bir şekilde yapılıp yapılmadığını belirten onay kodunu barındırır.

                        List<Global.PackageCodes> PackageCodes = new List<Global.PackageCodes>();


                        var sendDeaktivationList = tDeaktivationPackages.Select(i => new { i.pck_id, i.pck_code }).ToList();
                        if (tDeaktivationPackages.Count == 0) throw new Exception("Kayıt bulunamadı!");

                        foreach (var DeaktivationPackages in sendDeaktivationList)
                        {
                            PackageCodes.Add(new Global.PackageCodes(DeaktivationPackages.pck_id, DeaktivationPackages.pck_code));
                        }


                        List<Global.Sonuclar> lSonuclar = new List<Global.Sonuclar>();

                        for (int i = 0; i < snlist.Count; i++)
                        {
                            lSonuclar.Add(new Global.Sonuclar(uclist[i].RC, Global.AmbalajKodunaGoreIDDondur(PackageCodes, snlist[i].SN)));
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
                                lITS.Package_Movement_Detail_Batch_Insert(PMMID, lSonuclar[i].Sonuc, sAmbalajIDleri); //@bilgehan G de aç

                                k = 0;
                                sAmbalajIDleri = "";
                            }
                        }


                        string message = "Bildirim Başarılı!";

                    }

                }
                catch (Exception ex)
                {
                    try
                    {
                        if (ex.Message != "") sHata = "FC :: " + ex.Message;
                        else sHata = "EX :: " + ex.Message;
                    }
                    catch (Exception ex2)
                    {
                        sHata = "EX :: " + ex2.Message;
                    }
                }
                finally
                {

                    bThreadCalisiyor = false;

                    iBildirimiIcinCalisanThreadSayisi--;
                }
            }
          
        }

        private void SaveDeactivationDataAsXML(DeactivationModel model, string sDosyaAdi, string pathXml)
        {
            try
            {

                XmlSerializer xmlSerializerModel = new XmlSerializer(typeof(DeactivationModel));

                xmlSerializerModel.Serialize(new StreamWriter(pathXml + @"\" + sDosyaAdi), model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
    #region Deactivation Model
    public class DeactivationModel
    {
        [JsonProperty("dt")]
        public string dt { get; set; }
        [JsonProperty("frGln")]
        public string frGln { get; set; }
        [JsonProperty("ds")]
        public string ds { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("document")]
        public DeactivationDocument document { get; set; }
        [JsonProperty("productList")]
        public List<DeactivationProduct> productList { get; set; }
    }
    public class DeactivationDocument
    {
        [JsonProperty("dd")]
        public string dd { get; set; }
        [JsonProperty("dn")]
        public string dn { get; set; }
    }

    public class DeactivationProduct
    {
        [JsonProperty("gtin")]
        public string gtin { get; set; }
        [JsonProperty("sn")]
        public string sn { get; set; }
        [JsonProperty("bn")]
        public string bn { get; set; }
        [JsonProperty("xd")]
        public string xd { get; set; }

    }

    #endregion
}

