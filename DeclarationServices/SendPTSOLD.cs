using DeclarationServices.PTSSendService;
using Functions;
using Ionic.Zip;
using LINQ;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DeclarationServices
{
    public class SendPTSOLD
    {
        public SendPTSOLD(int AUsrId, char AEnvironment, string AConnectionString)
        {
            Global.UsrId = AUsrId;
            Global.Environment = AEnvironment;
            Global.ConnectionString = AConnectionString;
            Global.Settings = new Settings(AEnvironment);
        }

        private class BPackageSenderWebService : PackageSenderWebService
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
        public ArrayList TasiyiciOlustur(string OrderNumber, string SSCC)
        {
            ArrayList alMainCarriers = new ArrayList();

            using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
            {
                try
                {
                    var tShippingOrderDetails = lITS.Shipping_Order_Details_Browse(OrderNumber).ToList();
                    var tCarriers = tShippingOrderDetails.Where(d => d.parent_sscc == SSCC).Select(d => new { d.package_sscc }).Distinct().ToList();

                    foreach (var C in tCarriers)
                    {
                        carrierType Carrier = new carrierType();
                        Carrier.carrierLabel = C.package_sscc;
                        if (tShippingOrderDetails.Where(d => d.package_sscc == C.package_sscc).First().gtin == null)
                            Carrier.containerType = "P";
                        else
                            Carrier.containerType = "C";

                        ArrayList alItems = new ArrayList();

                        var tPackages = tShippingOrderDetails.Where(d => d.package_sscc == C.package_sscc).ToList();
                        var tGTINs = tPackages.Select(d => new { d.gtin, d.batch_no, d.expiry_date, d.production_date }).Distinct().ToList();
                        foreach (var GTIN in tGTINs)
                        {
                            if (GTIN.gtin != null)
                            {
                                productListType Product = new productListType();
                                Product.GTIN = GTIN.gtin;
                                Product.lotNumber = GTIN.batch_no;
                                Product.expirationDate = Convert.ToDateTime(GTIN.expiry_date);
                                if (GTIN.production_date != null)
                                {
                                    Product.productionDate = Convert.ToDateTime(GTIN.production_date);
                                    Product.productionDateSpecified = true;
                                }
                                else
                                    Product.productionDateSpecified = false;

                                var tUniquePackages = tPackages.Where(d => d.gtin == GTIN.gtin && d.batch_no == GTIN.batch_no && d.expiry_date == GTIN.expiry_date).ToList();
                                ArrayList alCodes = new ArrayList();
                                foreach (var Package in tUniquePackages)
                                {
                                    alCodes.Add(Package.package_code);
                                }
                                Product.serialNumber = alCodes.ToArray(typeof(string)) as string[];

                                alItems.Add(Product);
                            }
                        }

                        if (tShippingOrderDetails.Where(d => d.parent_sscc == C.package_sscc).ToList().Count > 0)
                        {
                            ArrayList alCarriers = TasiyiciOlustur(OrderNumber, C.package_sscc);
                            foreach (var aCarrier in alCarriers)
                                alItems.Add(aCarrier);
                        }
                        Carrier.Items = alItems.ToArray(typeof(object)) as object[];
                        alMainCarriers.Add(Carrier);
                    }
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }

            return alMainCarriers;
        }

        public byte[] DosyaOlustur(string OrderNumber)
        {
            MemoryStream zipStream = new MemoryStream();

            using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
            {
                try
                {
                    var ShippingOrder = lITS.Shipping_Order_Browse(OrderNumber, null).First();

                    transfer PTSDosyasi = new transfer();

                    PTSDosyasi.sourceGLN = ShippingOrder.com_gln_number;
                    PTSDosyasi.destinationGLN = ShippingOrder.amr_gln_number;
                    PTSDosyasi.actionType = "S";
                    PTSDosyasi.shipTo = ShippingOrder.amr_branch_gln_number;
                    PTSDosyasi.documentNumber = ShippingOrder.sor_order_number;
                    PTSDosyasi.documentDate = Convert.ToDateTime(ShippingOrder.sor_invoice_date);
                    PTSDosyasi.documentDateSpecified = true;
                    PTSDosyasi.version = "1.3";

                    ArrayList alCarriers = TasiyiciOlustur(OrderNumber, null);

                    PTSDosyasi.carrier = alCarriers.ToArray(typeof(carrierType)) as carrierType[];

                    string sDosyaAdi = ShippingOrder.sor_order_number + "_" + DateTime.Now.ToString("yyyyMMddHHmmssff");
                    string sTempDir = Global.Settings.Directory.Temp;

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(transfer));
                    StreamWriter streamWriter = new StreamWriter(sTempDir + @"\" + sDosyaAdi + ".xml");
                    xmlSerializer.Serialize(streamWriter, PTSDosyasi);

                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AddFile(sTempDir + @"\" + sDosyaAdi + ".xml", "");
                        zip.CompressionMethod = CompressionMethod.Deflate;
                        zip.Save(zipStream);

                        FileStream zipSave = new FileStream(sTempDir + @"\" + sDosyaAdi + ".zip", FileMode.Create);
                        zipSave.Write(zipStream.GetBuffer(), 0, (int)zipStream.Length);
                        zipSave.Close();

                    }

                    if (streamWriter != null)
                        streamWriter.Close();

                    File.Delete(sTempDir + @"\" + sDosyaAdi + ".xml");
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }

            return zipStream.GetBuffer();
        }

        public string DosyaOlusturV2(string OrderNumber)
        {
            MemoryStream zipStream = new MemoryStream();
            string sFullPath = "";

            using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
            {
                try
                {
                    var ShippingOrder = lITS.Shipping_Order_Browse(OrderNumber, null).First();

                    transfer PTSDosyasi = new transfer();

                    PTSDosyasi.sourceGLN = ShippingOrder.com_gln_number;
                    PTSDosyasi.destinationGLN = ShippingOrder.amr_gln_number;
                    PTSDosyasi.actionType = "S";
                    PTSDosyasi.shipTo = ShippingOrder.amr_branch_gln_number;
                    PTSDosyasi.documentNumber = ShippingOrder.sor_order_number;
                    PTSDosyasi.documentDate = Convert.ToDateTime(ShippingOrder.sor_invoice_date);
                    PTSDosyasi.documentDateSpecified = true;
                    PTSDosyasi.version = "1.3";

                    ArrayList alCarriers = TasiyiciOlustur(OrderNumber, null);

                    PTSDosyasi.carrier = alCarriers.ToArray(typeof(carrierType)) as carrierType[];

                    string sDosyaAdi = ShippingOrder.sor_order_number + "_" + DateTime.Now.ToString("yyyyMMddHHmmssff");
                    string sTempDir = Global.Settings.Directory.Temp;
                    sFullPath = sTempDir + @"\" + sDosyaAdi;

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(transfer));
                    StreamWriter streamWriter = new StreamWriter(sTempDir + @"\" + sDosyaAdi + ".xml");
                    xmlSerializer.Serialize(streamWriter, PTSDosyasi);

                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AddFile(sTempDir + @"\" + sDosyaAdi + ".xml", "");
                        zip.CompressionMethod = CompressionMethod.Deflate;
                        zip.Save(zipStream);

                        FileStream zipSave = new FileStream(sTempDir + @"\" + sDosyaAdi + ".zip", FileMode.Create);
                        zipSave.Write(zipStream.GetBuffer(), 0, (int)zipStream.Length);
                        zipSave.Close();

                    }

                    if (streamWriter != null)
                        streamWriter.Close();


                    File.Delete(sTempDir + @"\" + sDosyaAdi + ".xml");
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }

            return sFullPath;
        }


        public int iPMMID = 0;

        public async Task GonderAsync(string OrderNumber)
        {
            using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
            {
                try
                {
                    BPackageSenderWebService PTS = new BPackageSenderWebService();
                    PTS.Url = Global.Settings.Services.PTSSend;
                    PTS.Timeout = 600000;
                    string Url = Global.Settings.Services.PTSSend;

                    var ShippingOrder = lITS.Shipping_Order_Browse(OrderNumber, null).First();

                    string sKullaniciAdi = "";
                    string sSifre = "";
                    string sGLNNumarasi = ShippingOrder.com_gln_number;
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


                    sendFileStreamParametersType SFS = new sendFileStreamParametersType();
                    sendFileParametersType SFP = new sendFileParametersType();

                    SFP.sourceGLN = ShippingOrder.com_gln_number;
                    if (Global.Environment == 'T')
                        SFP.destinationGLN = "8699724000018";
                    else
                        SFP.destinationGLN = ShippingOrder.amr_gln_number;
                    SFS.sendFileParameters = SFP;

                    string sFullPath = DosyaOlusturV2(OrderNumber);

                    string base64 = "";
                    using (FileStream fs = new FileStream(sFullPath + ".zip", FileMode.Open))
                    {
                        byte[] filebytes = new byte[fs.Length];
                        fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
                        base64 = Convert.ToBase64String(filebytes);
                    }

                    string sAnahtar = "PTS" + OrderNumber;
                    iPMMID = lITS.Package_Movement_Master_Insert(sAnahtar, OrderNumber, 'C', null, null, Global.UsrId, Global.Environment, (Global.UsrId == -1 ? true : false));
                    string sDosyaAdi = "PTS-" + OrderNumber + "-" + iPMMID.ToString() + "-" + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".xml";
                    lITS.Package_Movement_Master_Update(iPMMID, null, sDosyaAdi, null);

                    XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(sendFileStreamParametersType));
                    xmlSerializer1.Serialize(new StreamWriter(Global.Settings.Directory.Outgoing + @"\" + sDosyaAdi), SFS);

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
                        var url2 = Global.Settings.Services.PTSSend;
                        client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        var data = new
                        {
                            receiver = SFP.destinationGLN,
                            file = base64

                        };

                        var requestdata = JsonConvert.SerializeObject(data);

                        var response2 = await client2.PostAsync(url2, new StringContent(requestdata, Encoding.UTF8, "application/json"));
                        var responseBody2 = await response2.Content.ReadAsStringAsync();

                        string transferId = "";
                        transferId = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody2)["transferId"].ToString();

                        //sendFileResponseType SFR = PTS.sendFileStream(SFS);
                        if (transferId != null && transferId != "")
                        {
                            //XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(sendFileResponseType));
                            //xmlSerializer2.Serialize(new StreamWriter(Global.Settings.Directory.Incoming + @"\" + sDosyaAdi), SFR);
                            lITS.Package_Movement_Master_Update(iPMMID, transferId, null, sDosyaAdi);
                            lITS.Shipping_Order_Update_Transfer_Id(OrderNumber, Convert.ToInt64(transferId));
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
