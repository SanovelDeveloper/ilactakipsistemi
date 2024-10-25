using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Collections;
using LINQ;
using DeclarationServices.SalesCancelService;
using Functions;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DeclarationServices
{
    public class SendSalesCancel
    {
        public SendSalesCancel(int AUsrId, char AEnvironment, string AConnectionString)
        {
            Global.UsrId = AUsrId;
            Global.Environment = AEnvironment;
            Global.ConnectionString = AConnectionString;
            Global.Settings = new Settings(AEnvironment);
        }

        private class BUreticiSatisIptalReceiverService : DispatchCancellation
        {
            protected override System.Net.WebRequest GetWebRequest(Uri uri)
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
                request.KeepAlive = false;

                if (PreAuthenticate)
                {
                    NetworkCredential networkCredentials = Credentials.GetCredential(uri, "Basic");

                    if (networkCredentials != null)
                    {
                        byte[] credentialBuffer = new UTF8Encoding().GetBytes(networkCredentials.UserName + ":" + networkCredentials.Password);
                        request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
                    }
                }
                return request;
            }
        }
        public int iPMMID = 0;

        public async Task SendAsync(int CsmID)
        {
            using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
            {
                try
                {
                    List<Global.PackageCodes> PackageCodes = new List<Global.PackageCodes>();
                    BUreticiSatisIptalReceiverService SBS = new BUreticiSatisIptalReceiverService() { Url = Global.Settings.Services.CancelSales, Timeout = 600000 };
                    var tMaster = lITS.Cancelled_Sales_Master_Browse(CsmID).ToList();
                    if (tMaster.Count == 0) throw new Exception("Satış iptal kaydı bulunamadı!");
                    var Master = tMaster.First();

                    string sKullaniciAdi = "";
                    string sSifre = "";
                    string sGLNNumarasi = Master.com_gln_number;
                    if (Global.Environment == 'T' || sGLNNumarasi == Global.Settings.Security.SanovelGLN)
                    {
                        sKullaniciAdi = Global.Settings.Security.SanovelUser;
                        sSifre = Global.Settings.Security.SanovelPassword;
                    }
                    else if (sGLNNumarasi == Global.Settings.Security.AsetGLN)
                    {
                        sKullaniciAdi = Global.Settings.Security.AsetUser;
                        sSifre = Global.Settings.Security.AsetPassword;
                    }
                    else if (sGLNNumarasi == Global.Settings.Security.AdilnaGLN)
                    {
                        sKullaniciAdi = Global.Settings.Security.AdilnaUser;
                        sSifre = Global.Settings.Security.AdilnaPassword;
                    }
                    else if (sGLNNumarasi == Global.Settings.Security.ArvenGLN)
                    {
                        sKullaniciAdi = Global.Settings.Security.ArvenUser;
                        sSifre = Global.Settings.Security.ArvenPassword;
                    }

                    if (Global.Environment == 'T')
                        sGLNNumarasi = Global.Settings.Security.SanovelGLN;

                    ItsPlainRequest SBT = new ItsPlainRequest();

                    var tDetails = lITS.Cancelled_Sales_Detail_Browse(CsmID).ToList();

                    if (tDetails.Count == 0) throw new Exception("Satış iptal kaydı bulunamadı!");

                    ArrayList alSBTU = new ArrayList();

                    foreach (var Detail in tDetails)
                    {
                        PackageCodes.Add(new Global.PackageCodes((int)Detail.pck_id, Detail.pck_code));

                        ItsPlainRequestPRODUCT SBTU = new ItsPlainRequestPRODUCT();
                        SBTU.gtin = Detail.mmr_gtin;
                        SBTU.sn = Detail.pck_code;
                        SBTU.bn = Detail.ord_batch_no;

                        SBTU.xd = Detail.ord_expiry_date;
                        alSBTU.Add(SBTU);

                    }

                    SBT.PRODUCTS = alSBTU.ToArray(typeof(ItsPlainRequestPRODUCT)) as ItsPlainRequestPRODUCT[];

                    string sAnahtar = "SI" + Master.csm_document_number;
                    int iPMMID = lITS.Package_Movement_Master_Insert(sAnahtar, Master.csm_document_number, 'T', null, null, Global.UsrId, Global.Environment, (Global.UsrId == -1 ? true : false));
                    string sDosyaAdi = String.Format("SatisIptal-{0}-{1}-{2:yyyyMMddHHmmssff}.xml", Master.csm_document_number, iPMMID, DateTime.Now);
                    lITS.Package_Movement_Master_Update(iPMMID, null, sDosyaAdi, null);

                    XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(ItsPlainRequest));
                    xmlSerializer1.Serialize(new StreamWriter(Global.Settings.Directory.Outgoing + @"\" + sDosyaAdi), SBT);

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
                        var url2 = Global.Settings.Services.CancelSales;
                        client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        var json = JsonConvert.SerializeObject(alSBTU);
                        var data = new
                        {
                            productList = alSBTU
                        };

                        var requestdata = JsonConvert.SerializeObject(data);

                        var response2 = await client2.PostAsync(url2, new StringContent(requestdata, Encoding.UTF8, "application/json"));


                        var responseBody2 = await response2.Content.ReadAsStringAsync();

                        string notification_id;
                        notification_id = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody2)["notificationid"].ToString();



                        var responseList = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody2)["productList"];

                        var gtinlist = JObject.Parse(responseBody2)["productList"].Select(el => new { gtin = (string)el["gtin"] }).ToList();
                        var snlist = JObject.Parse(responseBody2)["productList"].Select(el => new { sn = (string)el["sn"] }).ToList();
                        var uclist = JObject.Parse(responseBody2)["productList"].Select(el => new { uc = (string)el["uc"] }).ToList();


                        //ItsResponse SBC = SBS.sendDispatchCancellation(SBT);
                        if (notification_id != null && notification_id != "")
                        {
                            //XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(ItsResponse));
                            //xmlSerializer2.Serialize(new StreamWriter(Global.Settings.Directory.Incoming + @"\" + sDosyaAdi), SBC);

                            lITS.Package_Movement_Master_Update(iPMMID, notification_id, null, sDosyaAdi);

                            List<Global.Sonuclar> lSonuclar = new List<Global.Sonuclar>();
                            for (int i = 0; i < gtinlist.Count; i++)
                            {
                                lSonuclar.Add(new Global.Sonuclar(uclist[i].uc, Global.AmbalajKodunaGoreIDDondur(PackageCodes, snlist[i].sn)));
                            }
                            lSonuclar.Sort();

                            int k = 0;
                            string sAmbalajIDleri = "";
                            for (int i = 0; i < lSonuclar.Count; i++)
                            {
                                k++;
                                sAmbalajIDleri += lSonuclar[i].AmbalajID + ",";
                                if (k == 999999999 || i == lSonuclar.Count - 1 || lSonuclar[i].Sonuc != lSonuclar[i + 1].Sonuc)
                                {
                                    lITS.Package_Movement_Detail_Batch_Insert(iPMMID, lSonuclar[i].Sonuc, sAmbalajIDleri);

                                    k = 0;
                                    sAmbalajIDleri = "";
                                }
                            }
                        }
                    }

                }
                catch (Exception Ex)
                {
                    if (iPMMID > 0)
                        lITS.ErrorInsert(iPMMID, Ex.Message);
                    throw Ex;
                }


            }
        }
    }
}
