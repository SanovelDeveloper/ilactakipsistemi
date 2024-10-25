using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ;
using DeclarationServices.ErrorCodes;
using Functions;
using System.Net;

namespace DeclarationServices
{
  public class GetErrorCodes
  {
    public GetErrorCodes(int AUsrId, char AEnvironment, string AConnectionString)
    {
      Global.UsrId = AUsrId;
      Global.Environment = AEnvironment;
      Global.ConnectionString = AConnectionString;
      Global.Settings = new Settings(AEnvironment);
    }

    private class BErrorCode : ErrorCode
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

    public void Get()
    {
      using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 120000 })
      {
        try
        {
          BErrorCode EC = new BErrorCode();
          EC.Url = "http://its.saglik.gov.tr/ReferenceServices/ErrorCode"; ;
          EC.Timeout = 600000;

          string sKullaniciAdi = Global.Settings.Security.SanovelUser;
          string sSifre = Global.Settings.Security.SanovelPassword;

          EC.PreAuthenticate = true;
          EC.Credentials = new NetworkCredential(sKullaniciAdi, sSifre);
          if (Global.Settings.ProxyAddress != "")
            EC.Proxy = new WebProxy(Global.Settings.ProxyAddress, Convert.ToInt32(Global.Settings.ProxyPort));

          errorCodeResponse ECR = EC.getErrorCodes(new errorCodeRequest());
          for (int i = 0; i < ECR.errorCodes.Length; i++)
          {
            lITS.Global_Error_List_Insert((ECR.errorCodes[i].type == "Hata Kodu" ? "FC" : "UC"), ECR.errorCodes[i].code, ECR.errorCodes[i].message, ECR.errorCodes[i].description);
          }          
          
        }
        catch (Exception Ex)
        {
          throw Ex;
        }
      }
    }

  }
}
