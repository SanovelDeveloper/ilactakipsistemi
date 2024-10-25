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
using DeclarationServices.PTSReceiverService;
using Functions;
using System.IO.Compression;
using System.Windows.Forms;

namespace DeclarationServices
{
    public class ReceivePTS
    {
        public ReceivePTS(int AUsrId, char AEnvironment, string AConnectionString)
        {
          Global.UsrId = AUsrId;
          Global.Environment = AEnvironment;
          Global.ConnectionString = AConnectionString;
          Global.Settings = new Settings(AEnvironment);
        }

        public void FolderExists(string path)
        {
            bool exists = System.IO.Directory.Exists(Application.StartupPath + "\\" + path);

            if (!exists)
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\" + path);
        }

        private class BPackageReceiverWebService : PackageReceiverWebService 
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
      
        public string Receive(int transferId,string source_gln,string destination_gln)
        {
            string TargetDir = "";
            using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
            {    
                BPackageReceiverWebService PTS = new BPackageReceiverWebService();
                PTS.Url = Global.Settings.Services.PTSReceive;
                PTS.Timeout = 600000;

                string sKullaniciAdi = "";
                string sSifre = "";
                string sGLNNumarasi = destination_gln;
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

                PTS.PreAuthenticate = true;
                PTS.Credentials = new NetworkCredential(sKullaniciAdi, sSifre);
                if (Global.Settings.ProxyAddress != "")
                    PTS.Proxy = new WebProxy(Global.Settings.ProxyAddress, Convert.ToInt32(Global.Settings.ProxyPort));

                receiveFileParametersType RFPT = new receiveFileParametersType();
                RFPT.transferId = transferId;
                RFPT.sourceGLN = source_gln;

                try
                {
                    string pathZip = "PTS\\ZIP\\";
                    string pathXml = "PTS\\XML\\";

                    FolderExists(pathZip);
                    FolderExists(pathXml);                    
                   
                    pathZip = pathZip + source_gln + "_" + transferId.ToString();
                    byte[] RFS = PTS.receiveFileStream(RFPT);
                    FileStream fsOutput = new FileStream(pathZip + ".zip", FileMode.Create);
                    fsOutput.Write(RFS, 0, RFS.Length);
                    fsOutput.Flush();

                    using (ZipFile zip = new ZipFile())
                    {
                        string ZipToUnpack = pathZip + ".zip";
                        TargetDir = pathXml;
                        using (ZipFile zip1 = ZipFile.Read(ZipToUnpack)) {
                            foreach (ZipEntry e in zip1) {
	                            e.Extract(TargetDir, ExtractExistingFileAction.OverwriteSilently);
                                TargetDir = TargetDir + e.FileName;                                
                            }
                        }
                     } 
                }
                catch (Exception ex)
                {
                    TargetDir = "";
                }
                finally
                {
                    RFPT = null;
                    PTS = null;
                }
                return TargetDir;
            }           
        }
    }
}
