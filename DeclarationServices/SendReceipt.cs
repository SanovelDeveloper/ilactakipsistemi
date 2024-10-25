using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQ;
using DeclarationServices.ReceiptService;
using Functions;
using System.Net;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

namespace DeclarationServices
{
  public class SendReceipt
  {
    public SendReceipt(int AUsrId, char AEnvironment, string AConnectionString)
    {
      Global.UsrId = AUsrId;
      Global.Environment = AEnvironment;
      Global.ConnectionString = AConnectionString;
      Global.Settings = new Settings(AEnvironment);
    }

    private class BReceiptNotification: ReceiptNotification
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

    public void Send(string OrderNumber, string AliciGLN)
    {
      using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 240000 })
      {
        try
        {
          List<Global.PackageCodes> PackageCodes = new List<Global.PackageCodes>();

          BReceiptNotification SBS = new BReceiptNotification() { Timeout = 1200000 };

          string sKullaniciAdi = "";
          string sSifre = "";

          if (Global.Environment == 'T' || AliciGLN == Global.Settings.Security.SanovelGLN)
          {
            sKullaniciAdi = Global.Settings.Security.SanovelUser;
            sSifre = Global.Settings.Security.SanovelPassword;
          }
          else if (AliciGLN == Global.Settings.Security.AsetGLN)
          {
            sKullaniciAdi = Global.Settings.Security.AsetUser;
            sSifre = Global.Settings.Security.AsetPassword;
          }
          else if (AliciGLN == Global.Settings.Security.AdilnaGLN)
          {
            sKullaniciAdi = Global.Settings.Security.AdilnaUser;
            sSifre = Global.Settings.Security.AdilnaPassword;
          }
          else if (AliciGLN == Global.Settings.Security.ArvenGLN)
          {          
            sKullaniciAdi = Global.Settings.Security.ArvenUser;
            sSifre = Global.Settings.Security.ArvenPassword;
          }

          if (Global.Environment == 'T')
            AliciGLN = Global.Settings.Security.SanovelGLN;

          SBS.PreAuthenticate = true;
          SBS.Credentials = new NetworkCredential(sKullaniciAdi, sSifre);
          if (Global.Settings.ProxyAddress != "")
            SBS.Proxy = new WebProxy(Global.Settings.ProxyAddress, Convert.ToInt32(Global.Settings.ProxyPort));

          ItsPlainRequest SBT = new ItsPlainRequest();

          var tShippingOrderDetails = lITS.Shipping_Order_Details_Browse_For_Receipt(OrderNumber).Where(p => p.package_id != null).ToList();

          if (tShippingOrderDetails.Count == 0) throw new Exception("Kayıt bulunamadı!");

          ArrayList alSBTU = new ArrayList();

          foreach (var ShippingPackages in tShippingOrderDetails)
          {
            PackageCodes.Add(new Global.PackageCodes((int)ShippingPackages.package_id, ShippingPackages.package_code));

            ItsPlainRequestPRODUCT SBTU = new ItsPlainRequestPRODUCT();
            SBTU.GTIN = ShippingPackages.gtin;
            SBTU.SN = ShippingPackages.package_code;
            SBTU.BN = ShippingPackages.batch_no;
            SBTU.XD = Convert.ToDateTime(ShippingPackages.expiry_date);
            alSBTU.Add(SBTU);
          }

          SBT.PRODUCTS = alSBTU.ToArray(typeof(ItsPlainRequestPRODUCT)) as ItsPlainRequestPRODUCT[];

          string sAnahtar = "MA" + OrderNumber;
          int iPMMID = lITS.Package_Movement_Master_Insert(sAnahtar, 
                                                           OrderNumber, 
                                                           'R', 
                                                           null, 
                                                           null, 
                                                           Global.UsrId, 
                                                           Global.Environment, 
                                                           (Global.UsrId == -1 ? true : false));

          string sDosyaAdi = String.Format("MalAlim-{0}-{1}-{2:yyyyMMddHHmmssff}.xml", OrderNumber, iPMMID, DateTime.Now);
          
          lITS.Package_Movement_Master_Update(iPMMID, 
                                              null, 
                                              sDosyaAdi, 
                                              null);

          XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(ItsPlainRequest));
          xmlSerializer1.Serialize(new StreamWriter(Global.Settings.Directory.Outgoing + @"\" + sDosyaAdi), SBT);

          ItsResponse SBC = SBS.sendReceiptNotification(SBT);

          if (SBC.NOTIFICATIONID != null && SBC.NOTIFICATIONID != "")
          {
            XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(ItsResponse));
            xmlSerializer2.Serialize(new StreamWriter(Global.Settings.Directory.Incoming + @"\" + sDosyaAdi), SBC);

            lITS.Package_Movement_Master_Update(iPMMID, 
                                                SBC.NOTIFICATIONID, 
                                                null, 
                                                sDosyaAdi);

            List<Global.Sonuclar> lSonuclar = new List<Global.Sonuclar>();

            for (int i = 0; i < SBC.PRODUCTS.Length; i++)
            {
              lSonuclar.Add(new Global.Sonuclar(SBC.PRODUCTS[i].UC, Global.AmbalajKodunaGoreIDDondur(PackageCodes, SBC.PRODUCTS[i].SN)));
            }
            lSonuclar.Sort();

            int k = 0;
            string sAmbalajIDleri = "";

            for (int i = 0; i < lSonuclar.Count; i++)
            {
              k++;
              sAmbalajIDleri += lSonuclar[i].AmbalajID + ",";

              if (k == 300 || i == lSonuclar.Count - 1 || lSonuclar[i].Sonuc != lSonuclar[i + 1].Sonuc)
              {
                lITS.Package_Movement_Detail_Batch_Insert(iPMMID, 
                                                          lSonuclar[i].Sonuc, 
                                                          sAmbalajIDleri);

                k = 0;
                sAmbalajIDleri = "";
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
