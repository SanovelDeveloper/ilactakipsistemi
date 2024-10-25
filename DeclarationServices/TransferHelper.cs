using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using Ionic.Zip;
using System.Net;
using LINQ;
using DeclarationServices.PTSTransferHelperService;
using Functions;
using System.IO.Compression;
using System.Data;
using System.Data.SqlClient;

namespace DeclarationServices
{  
    public class TransferHelper
    {
        public TransferHelper(int AUsrId, char AEnvironment, string AConnectionString)
        {
          Global.UsrId = AUsrId;
          Global.Environment = AEnvironment;
          Global.ConnectionString = AConnectionString;
          Global.Settings = new Settings(AEnvironment);
        }

        private class BPackageTransferHelperWebService : PackageTransferHelperWebService 
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
        
        public DataTable dtTransferBilgileri;

        public void TransferHelperBrowse(bool bAlinmislariGoster, int iGunSayisi)
        {
            using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
            {
                    var tCompanyList = lITS.Group_Company_Sales_Company_Browse().ToList();

                    BPackageTransferHelperWebService PTH = new BPackageTransferHelperWebService() { Url = Global.Settings.Services.PTSTransferHelper, Timeout = 600000 };

                    dtTransferBilgileri = new DataTable();
                    dtTransferBilgileri.Columns.Add("checked",typeof(Boolean));
                    dtTransferBilgileri.Columns.Add("transfer_id");
                    dtTransferBilgileri.Columns.Add("source_gln");
                    dtTransferBilgileri.Columns.Add("source");
                    dtTransferBilgileri.Columns.Add("transfer_date");
                    dtTransferBilgileri.Columns.Add("destination_gln");
                
                    foreach (var CompanyList in tCompanyList)
                    {
                        string sKullaniciAdi = "";
                        string sSifre = "";
                        string sGLNNumarasi = CompanyList.amr_gln_number.ToString();
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

                        PTH.PreAuthenticate = true;
                        PTH.Credentials = new NetworkCredential(sKullaniciAdi, sSifre);
                        if (Global.Settings.ProxyAddress != "")
                            PTH.Proxy = new WebProxy(Global.Settings.ProxyAddress, Convert.ToInt32(Global.Settings.ProxyPort));

                        receiveTransferDetailsParametersType RTDP = new receiveTransferDetailsParametersType();
                        RTDP.destinationGLN = sGLNNumarasi;
                        RTDP.bringNotReceivedTransferInfo = bAlinmislariGoster;
                        int GunSayisi = iGunSayisi * -1;
                        RTDP.startDate = DateTime.Now.AddDays(GunSayisi).Date;
                        RTDP.endDate = DateTime.Now.AddDays(1).Date;

                        receiveTransferDetailsResponseType RTDR = new receiveTransferDetailsResponseType();
                        try
                        {
                            RTDR = PTH.receiveTransferDetails(RTDP);
                            if (RTDR.transferDetails.transferDetail != null)
                            {
                                for (int i = 0; i < RTDR.transferDetails.transferDetail.Count(); i++)
                                {
                                    DataRow dr = dtTransferBilgileri.NewRow();
                                    dr[0] = false;
                                    dr[1] = RTDR.transferDetails.transferDetail[i].transferId.ToString();
                                    dr[2] = RTDR.transferDetails.transferDetail[i].sourceGLN.ToString();

                                    List<Account_Master_Browse_ByGLNResult> tList;
                                    tList = lITS.Account_Master_Browse_ByGLN(RTDR.transferDetails.transferDetail[i].sourceGLN.ToString()).ToList();
                                    if (tList.Count > 0)
                                    {
                                        dr[3] = tList.First().amr_account_name.ToString();
                                    }
                                    dr[4] = RTDR.transferDetails.transferDetail[i].transferDate.ToShortDateString();
                                    dr[5] = RTDR.transferDetails.transferDetail[i].destinationGLN.ToString();
                                    dtTransferBilgileri.Rows.Add(dr);
                                }
                            }
                        }
                        catch(Exception Ex)
                        {
                           
                        }
                        finally
                        {
                          RTDP = null;
                          RTDR = null;
                        }
                    }
                }
        }

    }
}
