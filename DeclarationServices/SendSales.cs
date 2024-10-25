using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Collections;
using LINQ;
using DeclarationServices.SalesService;
using Functions;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading;

namespace DeclarationServices
{
    public class SendSales
    {
        public SendSales(int AUsrId, char AEnvironment, string AConnectionString)
        {
            Global.UsrId = AUsrId;
            Global.Environment = AEnvironment;
            Global.ConnectionString = AConnectionString;
            Global.Settings = new Settings(AEnvironment);
        }

        public int iPMMID = 0;
        public async Task SendAsync(string OrderNumber, Int16 Type, string SaticiGLN, string AliciGLN)// type 1: satış 2: üretim
        {

            using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 480000 })
            {

                try
                {
                    //Global.Environment = 'T'; // @bilgehan testten sonra kaldır


                    List<Global.PackageCodes> PackageCodes = new List<Global.PackageCodes>();
                    string sKullaniciAdi = "";
                    string sSifre = "";
                    string sGLNNumarasi = "";
                    string TOGLN = "";
                    string XD = "";
                    string BN = "";
                    string SN = "";
                    string GTIN = "";

                    List<Shipping_Order_BrowseResult> tShippingOrder;
                    Shipping_Order_BrowseResult ShippingOrder;

                    if (Global.Environment == 'T')
                        TOGLN = "8680007800012";

                    if (Type == 1)
                    {
                        tShippingOrder = lITS.Shipping_Order_Browse(OrderNumber, null).ToList();

                        if (tShippingOrder.Count == 0)
                            throw new Exception("Satış kaydı bulunamadı!");


                        ShippingOrder = tShippingOrder.First();

                        sGLNNumarasi = ShippingOrder.com_gln_number;
                        TOGLN = ShippingOrder.amr_gln_number;
                    }
                    else
                    {
                        sGLNNumarasi = SaticiGLN;
                        TOGLN = AliciGLN;
                    }

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

                    var tShippingOrderDetails = lITS.Shipping_Order_Details_Browse(OrderNumber).Where(p => p.package_id != null).ToList();
                    //int count = tShippingOrderDetails.Count / 10000;
                    //int Mod = 0;

                    //int Sayi1 = tShippingOrderDetails.Count;
                    //int Sayi2 = 10000;

                    //Mod = Sayi1 % Sayi2;

                    //if (Mod > 0) count = count + 1;

                    //for (int t = 0; t <= count; t++)
                    //{

                    ////Test işlemi 
                    //sGLNNumarasi = "8699536000015";
                    //sKullaniciAdi = "86995360000150000";
                    //sSifre = "823Jeqf@";


                    List<ItsRequestPRODUCT> ıtsPRODUCTs = new List<ItsRequestPRODUCT>();

                    if (Type == 1)
                    {


                        if (tShippingOrderDetails.Count == 0) throw new Exception("Kayıt bulunamadı!");

                        foreach (var ShippingPackages in tShippingOrderDetails)
                        {
                            PackageCodes.Add(new Global.PackageCodes((int)ShippingPackages.package_id, ShippingPackages.package_code));

                            ItsRequestPRODUCT SBTU = new ItsRequestPRODUCT();
                            SBTU.gtin = ShippingPackages.gtin;
                            GTIN = ShippingPackages.gtin;
                            SBTU.sn = ShippingPackages.package_code;
                            SN = ShippingPackages.package_code;
                            SBTU.bn = ShippingPackages.batch_no;
                            BN = ShippingPackages.batch_no;
                            XD = Convert.ToDateTime(ShippingPackages.expiry_date).ToString("yyyy-MM-dd");
                            SBTU.xd = Convert.ToDateTime(ShippingPackages.expiry_date).ToString("yyyy-MM-dd");
                            // alSBTU.Add(SBTU);
                            ıtsPRODUCTs.Add(SBTU);

                        }
                    }
                    else if (Type == 2)
                    {
                        var tShippingOrderDetails2 = lITS.Shipping_Order_Details_Browse_For_Receipt(OrderNumber).Where(p => p.package_id != null).ToList();

                        if (tShippingOrderDetails2.Count == 0) throw new Exception("Kayıt bulunamadı!");

                        foreach (var ShippingPackages in tShippingOrderDetails2)
                        {
                            PackageCodes.Add(new Global.PackageCodes((int)ShippingPackages.package_id, ShippingPackages.package_code));

                            ItsRequestPRODUCT SBTU = new ItsRequestPRODUCT();
                            SBTU.gtin = ShippingPackages.gtin;
                            GTIN = ShippingPackages.gtin;
                            SBTU.sn = ShippingPackages.package_code;
                            SN = ShippingPackages.package_code;
                            SBTU.bn = ShippingPackages.batch_no;
                            BN = ShippingPackages.batch_no;
                            XD = Convert.ToDateTime(ShippingPackages.expiry_date).ToString("yyyy-MM-dd");
                            SBTU.xd = Convert.ToDateTime(ShippingPackages.expiry_date).ToString("yyyy-MM-dd");
                            // alSBTU.Add(SBTU);
                            ıtsPRODUCTs.Add(SBTU);

                        }
                    }

                    string sAnahtar = "SA" + OrderNumber;
                    int iPMMID = lITS.Package_Movement_Master_Insert(sAnahtar,
                                                                     OrderNumber,
                                                                     'S',
                                                                     null,
                                                                     null,
                                                                     Global.UsrId,
                                                                     Global.Environment,
                                                                     (Global.UsrId == -1 ? true : false));

                    string sDosyaAdi = String.Format("Satis-{0}-{1}-{2:yyyyMMddHHmmssff}.xml", OrderNumber, iPMMID, DateTime.Now);

                    lITS.Package_Movement_Master_Update(iPMMID,
                                                        null,
                                                        sDosyaAdi,
                                                        null);

                    int TotalRecords = ıtsPRODUCTs.Count;
                    var _SalesPageIndex = Global.Settings.Services.SalesPageIndex;//Tek seferde yapılacak bildirim sayısı dbden çekilecek
                    int PageSize = 1000;
                    if (!string.IsNullOrEmpty(_SalesPageIndex))
                    {
                        PageSize = Convert.ToInt32(_SalesPageIndex); // Tek seferde bildirimi yapılacak paket sayısı
                    }

                    double TotalPages = Math.Ceiling((double)TotalRecords / PageSize);


                    using (var client = new HttpClient())
                    {
                        var url = Global.Settings.Services.Token; // G
                                                                  
                        JObject oJsonObject = new JObject();
                        oJsonObject.Add("username", sKullaniciAdi);
                        oJsonObject.Add("password", sSifre);

                        var response = await client.PostAsync(url, new StringContent(oJsonObject.ToString(), Encoding.UTF8, "application/json"));

                        var responseBody = await response.Content.ReadAsStringAsync();
                        var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody)["token"].ToString();



                        var client2 = new HttpClient();

                        //using var client2 = new HttpClient();
                        client2.Timeout = TimeSpan.FromMinutes(100);
                        client2.DefaultRequestHeaders.Clear();
                        var url2 = Global.Settings.Services.Sales; // G
                        client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        var tasks = new List<Task<bool>>();
                        string notification_id = "";
                        for (int pageindex = 0; pageindex < TotalPages; pageindex++)
                        {
                            var _pageIndex = pageindex; // Closure için yerel kopya
                            int _currentLoopCount = pageindex + 1;
                            var _totalLoopCount = TotalPages;
                            tasks.Add(Task.Run(async () =>
                            {
                                try
                                {
                                    var alSBTU = new ArrayList();
                                    alSBTU.AddRange(ıtsPRODUCTs.Skip(_pageIndex * PageSize).Take(PageSize).ToList());

                                    var json = JsonConvert.SerializeObject(alSBTU);
                                    var data = new
                                    {
                                        togln = TOGLN,
                                        productList = alSBTU
                                    };

                                    var requestdata = JsonConvert.SerializeObject(data);

                                    var response2 = await client2.PostAsync(url2, new StringContent(requestdata, Encoding.UTF8, "application/json"));
                                    var responseBody2 = await response2.Content.ReadAsStringAsync();
                                   
                                    notification_id = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody2)["notificationid"].ToString();

                                    string LogMessage = Global.Environment + ": SendSales (Satış bildirimi) OrderNumber:" + OrderNumber + " pts_transfer_id: " + notification_id + ". Tamamlanan oran: " + _currentLoopCount + "/" + _totalLoopCount + ". Tek seferde" + PageSize + " adet satış bildirimi yapılıyor.";
                                    lITS.ErrorInsert(iPMMID, LogMessage);

                                    if (notification_id == null || notification_id == "")
                                    {

                                    }

                                    //if (notification_id != null && notification_id != "" && _currentLoopCount == TotalPages)
                                    //{

                                    //    lITS.Package_Movement_Master_Update(iPMMID,
                                    //                                        notification_id,
                                    //                                        null,
                                    //                                        sDosyaAdi);

                                    //}

                                    var responseList = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody2)["productList"];


                                    var gtinlist = JObject.Parse(responseBody2)["productList"].Select(el => new { gtin = (string)el["gtin"] }).ToList();
                                    var snlist = JObject.Parse(responseBody2)["productList"].Select(el => new { sn = (string)el["sn"] }).ToList();
                                    var uclist = JObject.Parse(responseBody2)["productList"].Select(el => new { uc = (string)el["uc"] }).ToList();


                                    List<Global.Sonuclar> lSonuclar = new List<Global.Sonuclar>();

                                    for (int i = 0; i < snlist.Count; i++)
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
                                        if (k == 999999 || i == lSonuclar.Count - 1 || lSonuclar[i].Sonuc != lSonuclar[i + 1].Sonuc)
                                        {
                                            lITS.Package_Movement_Detail_Batch_Insert(iPMMID,
                                                                                      lSonuclar[i].Sonuc,
                                                                                      sAmbalajIDleri);

                                            k = 0;
                                            sAmbalajIDleri = "";
                                        }
                                    }
                                 
                                    return true; 
                                }
                                catch (HttpRequestException ex)
                                {
                                    lITS.ErrorInsert(iPMMID, $"HttpRequestEx: {ex.Message}");
                                    return false; 
                                }
                                catch (TaskCanceledException ex)
                                {
                                    lITS.ErrorInsert(iPMMID, $"TimeoutEx: {ex.Message}");
                                    return false; 
                                }
                                catch (Exception ex)
                                {
                                    lITS.ErrorInsert(iPMMID, $"Ex: {ex.Message}");
                                    return false; 
                                }
                            }));
                        }
                        var taskResults = await Task.WhenAll(tasks);  

                     
                        bool allTasksSuccessful = taskResults.All(result => result == true);

                        if (allTasksSuccessful)
                        {
                            lITS.Package_Movement_Master_Update(iPMMID,
                                                                           notification_id,
                                                                           null,
                                                                           sDosyaAdi);
                            lITS.ErrorInsert(iPMMID, $"Satış Bildirimi Başarılı");

                        }
                        else
                        {
                            lITS.ErrorInsert(iPMMID, $"Ex:Satış bildirimi yapılamadı");
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
