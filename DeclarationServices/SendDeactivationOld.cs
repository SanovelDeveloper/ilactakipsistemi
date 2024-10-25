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

namespace DeclarationServices
{
  public class SendDeactivationOld
  {
    public SendDeactivationOld(int AUsrId, char AEnvironment, string AConnectionString)
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

    private class BDeaktivasyonBildirimReceiverService : DeaktivasyonBildirimReceiverService
    {
      public string Anahtar;
      public string OrderID;
      public int PMMID;
      public List<Global.PackageCodes> PackageCodes = new List<Global.PackageCodes>();

      protected override System.Net.WebRequest GetWebRequest(Uri uri)
      {
        HttpWebRequest request;
        request = (HttpWebRequest)base.GetWebRequest(uri);
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

    private void DeaktivasyonBildirimiTamamlandi(object sender, DeaktivasyonBildirCompletedEventArgs e)
    {
      string sHata = "";
      int iPMMID = ((BDeaktivasyonBildirimReceiverService)(sender)).PMMID;
      List<Global.PackageCodes> PackageCodes = ((BDeaktivasyonBildirimReceiverService)(sender)).PackageCodes;
      List<Global.Sonuclar> lSonuclar = new List<Global.Sonuclar>();

      using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 240000 })
      {
        try
        {
          string sDosyaAdi = "Deaktivasyon-" + iPMMID.ToString() + "-" + ((BDeaktivasyonBildirimReceiverService)(sender)).Anahtar + "-" + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".xml";

          XmlSerializer xmlSerializer = new XmlSerializer(typeof(DeaktivasyonBildirimCevapType));
          xmlSerializer.Serialize(new StreamWriter(Global.Settings.Directory.Incoming + @"\" + sDosyaAdi), e.Result);

          lITS.Package_Movement_Master_Update(iPMMID, e.Result.BILDIRIMID, null, sDosyaAdi);

          for (int i = 0; i < e.Result.URUNLER.Length; i++)
          {
            lSonuclar.Add(new Global.Sonuclar(e.Result.URUNLER[i].UC, Global.AmbalajKodunaGoreIDDondur(PackageCodes, e.Result.URUNLER[i].SN)));
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
              lITS.Package_Movement_Detail_Batch_Insert(iPMMID, lSonuclar[i].Sonuc, sAmbalajIDleri);

              k = 0;
              sAmbalajIDleri = "";
            }
          }

        }
        catch (Exception ex)
        {
          try
          {
            if (e.Error.Message != "") sHata = "FC :: " + e.Error.Message;
            else sHata = "EX :: " + ex.Message;
          }
          catch (Exception ex2)
          {
            sHata = "EX :: " + ex2.Message;
          }
          //throw;
        }

        if (sHata != "")
        {
          lITS.ErrorInsert(iPMMID, sHata);
        }
      }

      bThreadCalisiyor = false;

      iBildirimiIcinCalisanThreadSayisi--;
    }

    private void DeaktivasyonBildirimiGonder(object BP)
    {
      string sGLNNumarasi = "";
      string sKullaniciAdi = "";
      string sSifre = "";
      string sOrderId = ((Global.DeclarationParameters)BP).OrderId;

      using (var lITS = new ITSDataContext(Global.ConnectionString) { CommandTimeout = 240000 })
      {
        try
        {
          BDeaktivasyonBildirimReceiverService DRS = new BDeaktivasyonBildirimReceiverService();
          DRS.Url = Global.Settings.Services.Deactivation;

          DRS.DeaktivasyonBildirCompleted += new DeaktivasyonBildirCompletedEventHandler(DeaktivasyonBildirimiTamamlandi);
          DRS.Timeout = 15000;

          DRS.Anahtar = "DA" + sOrderId.ToString() + "_" + ((Global.DeclarationParameters)BP).SiraNumarasi.ToString();
          DRS.OrderID = sOrderId.ToString();

          int iReturnValue = lITS.Package_Movement_Master_Insert(DRS.Anahtar, sOrderId, 'D', ((Global.DeclarationParameters)BP).SiraNumarasi > 1 ? (int?)iHareketParentID : null, null, Global.UsrId, Global.Environment, (Global.UsrId == -1 ? true : false));

          DRS.PMMID = iReturnValue; 
          if (((Global.DeclarationParameters)BP).SiraNumarasi == 1)
            iHareketParentID = DRS.PMMID;

          string sDosyaAdi = "Deaktivasyon-" + DRS.PMMID.ToString() + "-" + DRS.Anahtar + "-" + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".xml";

          DRS.Anahtar = "DA" + sOrderId.ToString() + "_" + DRS.PMMID.ToString();

          lITS.Package_Movement_Master_Update(DRS.PMMID, null, sDosyaAdi, null);

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

          DRS.PreAuthenticate = true;
          DRS.Credentials = new NetworkCredential(sKullaniciAdi, sSifre);
          if (Global.Settings.ProxyAddress != "")
            DRS.Proxy = new WebProxy(Global.Settings.ProxyAddress, Convert.ToInt32(Global.Settings.ProxyPort));

          DeaktivasyonBildirimType DBT = new DeaktivasyonBildirimType();
          DBT.DT = "D"; // Belge türü
          DBT.FR = sGLNNumarasi; // Firma GLN        
          DBT.DS = "10";
          DBT.ISACIKLAMA = "SİSTEMDEN ÇIKARMA";

          DeaktivasyonBildirimTypeBELGE DBTB = new DeaktivasyonBildirimTypeBELGE();
          DBTB.DD = Convert.ToDateTime(DateTime.Now.Date); // Belge Tarihi
          DBTB.DN = DRS.Anahtar; // Belge numarası
          DBT.BELGE = DBTB;

          string sGTIN = OrderDetail.mmr_gtin;
          //if (Global.Environment == 'T') sGTIN = "08680015802145";
          string sXD = OrderDetail.expiry_date;
          string sBN = OrderDetail.ord_batch_no; // Seri no

          var tDeaktivationPackages = lITS.Package_List_Browse_For_Deaktivation(sOrderId, null, ((Global.DeclarationParameters)BP).KayitAdedi).ToList();

          if (tDeaktivationPackages.Count == 0) throw new Exception("Kayıt bulunamadı!");

          ArrayList alDBTU = new ArrayList();

          foreach(var DeaktivationPackage in tDeaktivationPackages)
          {
            DRS.PackageCodes.Add(new Global.PackageCodes(DeaktivationPackage.pck_id, DeaktivationPackage.pck_code));

            DeaktivasyonBildirimTypeURUN DBTU = new DeaktivasyonBildirimTypeURUN();
            DBTU.GTIN = sGTIN;
            DBTU.XD = Convert.ToDateTime(sXD);
            DBTU.BN = sBN;
            DBTU.SN = DeaktivationPackage.pck_code;
            alDBTU.Add(DBTU);
          }

          DBT.URUNLER = alDBTU.ToArray(typeof(DeaktivasyonBildirimTypeURUN)) as DeaktivasyonBildirimTypeURUN[];

          XmlSerializer xmlSerializer = new XmlSerializer(typeof(DeaktivasyonBildirimType));
          xmlSerializer.Serialize(new StreamWriter(Global.Settings.Directory.Outgoing + @"\" + sDosyaAdi), DBT);

          DRS.DeaktivasyonBildirAsync(DBT);
        }
        catch (Exception Ex)
        {
          throw;
        }
      }
    }
  }
}
