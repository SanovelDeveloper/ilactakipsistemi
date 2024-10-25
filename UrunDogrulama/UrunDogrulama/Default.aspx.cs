using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Net;
using System.Web.Services;
using System.Web.Services.Protocols;
using UrunDogrulama.EczaneUrunDogrulama;
using UrunDogrulama.UreticiUrunDogrulama;
using UrunDogrulama.DepoUrunDogrulama;

namespace UrunDogrulama
{
  public partial class _Default : System.Web.UI.Page
  {

    private void SetMyFocus(ref DevExpress.Web.ASPxEditors.ASPxTextBox txtBox)
    {
      string focusString = "setTimeout(\"$('" + txtBox.ClientID + "').focus(); \", 100);";
      ClientScript.RegisterStartupScript(this.GetType(), "focusString", focusString, true);
    }
          
    [Serializable]
    private class AmbalajBilgileri 
    {
      public string GTIN;
      public string BatchNo;
      public string ExpiryDate;
      public string PackageCode;      
      
      public AmbalajBilgileri(string sGTIN, string sBatchNo, string sExpiryDate, string sPackageCode)
      {
        GTIN = sGTIN;
        BatchNo = sBatchNo;
        ExpiryDate = sExpiryDate;
        PackageCode = sPackageCode;
      }            
    }

    private Ayarlar Ayarlar
    {
      get
      {
        /*
        Ayarlar a = (Ayarlar)ViewState["Ayarlar"];
        if (a == null)
          ViewState["Ayarlar"] = a = new Ayarlar(Server.MapPath("~/ayarlar.xml"));
        */
        return new Ayarlar(Server.MapPath("~/ayarlar.xml")); ;
      }    
    }
    
    private List<AmbalajBilgileri> lAmbalajBilgileri
    {
      get
      {
        List<AmbalajBilgileri> list = (List<AmbalajBilgileri>)ViewState["AmbalajBilgileri"];
        if (list == null)
          ViewState["AmbalajBilgileri"] = list = new List<AmbalajBilgileri>();
          
        return list;          
      }      
    }
     
    private int IndexOf(string AmbalajKodu)
    {
      for (int i = 0; i < lAmbalajBilgileri.Count; i++)
      {
        if (lAmbalajBilgileri[i].PackageCode == AmbalajKodu)
          return i;
      }
      return -1;
    }    
    
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack) 
        edtAmbalajBarkodu.Focus();      

    }
    protected void edtAmbalajBarkodu_ValueChanged(object sender, EventArgs e)
    {
      KareKod kkBarkod = new KareKod(hidAmbalajBarkodu.Value, 'P');

      edtGTINNumarasi.Text = kkBarkod.GTIN;
      edtSeriNumarasi.Text = kkBarkod.BatchNo;
      edtSonKullanmaTarihi.Text = kkBarkod.ExpiryDate;
      edtAmbalajKodu.Text = kkBarkod.PackageCode;
      /*                                                                        
      DevExpress.Web.ASPxEditors.ListEditItem lei = new DevExpress.Web.ASPxEditors.ListEditItem(edtAmbalajKodu.Text);
      AmbalajBilgileri ab = new AmbalajBilgileri(kkBarkod.GTIN, kkBarkod.BatchNo, kkBarkod.ExpiryDate, kkBarkod.PackageCode);
      int iIndex = IndexOf(kkBarkod.PackageCode);
      if (iIndex == -1)      
      {
        lAmbalajBilgileri.Add(ab);        
        lsbAmbalajlar.Items.Add(lei);
      }
      else 
      {
        lAmbalajBilgileri.RemoveAt(iIndex);
        lsbAmbalajlar.Items.RemoveAt(iIndex);                 
      }      
      
      hidAmbalajBarkodu.Value = "";      
      edtAmbalajBarkodu.Text = "";
      edtAmbalajBarkodu.Focus();      
      */
    }

    protected void btnTemizle_Click(object sender, EventArgs e)
    {
      edtAmbalajBarkodu.Text = "";
      edtAmbalajBarkoduKD.Text = "";
      edtGTINNumarasi.Text = "";
      edtSeriNumarasi.Text = "";
      edtSonKullanmaTarihi.Text = "";
      edtAmbalajKodu.Text = "";
            
      //SetMyFocus(ref edtAmbalajKodu);
      ScriptManager1.SetFocus(edtAmbalajKodu);      
      edtAmbalajBarkodu.Focus();
    }

    private void UrunDogrulamaKontrol(DepoDogrulamaBildirimCevapType EDCT)
    {
      string sonuc = "";
      try      
      {
        for (int i = 0; i < EDCT.URUNLER.Length; i++)
        {
          sonuc += EDCT.URUNLER[i].SN + " ::: " + EDCT.URUNLER[i].UC + " / " + Ayarlar.HataMesajiGetir(EDCT.URUNLER[i].UC) + "<br>";
        }
      }
      catch (Exception ex)
      {
        sonuc = "EX :: " + ex.Message;
      }
      litSonuclar.Text = sonuc;
    }


    protected void btnDogrula_Click(object sender, EventArgs e)
    {
      DepoDogrulamaReceiverService EDS = new DepoDogrulamaReceiverService();

      EDS.Credentials = new NetworkCredential("86800010864430000", "mer1kez2");
      EDS.Proxy = new WebProxy("172.16.0.15", 8080);

      DepoDogrulamaBildirimType EDT = new DepoDogrulamaBildirimType();

      EDT.DT = "V";
      EDT.FR = "8680001086443";

      ArrayList alEDTU = new ArrayList();

      for (int i = 0; i < lAmbalajBilgileri.Count; i++)
      {

        DepoDogrulamaBildirimTypeURUN EDTU = new DepoDogrulamaBildirimTypeURUN();
        EDTU.GTIN = lAmbalajBilgileri[i].GTIN;
        string sTarih = "20" + lAmbalajBilgileri[i].ExpiryDate.Substring(0, 2) + "-" + lAmbalajBilgileri[i].ExpiryDate.Substring(2, 2) + "-";
        if (lAmbalajBilgileri[i].ExpiryDate.Substring(4, 2) == "00")
        {
          int Year = Convert.ToInt32("20" + lAmbalajBilgileri[i].ExpiryDate.Substring(0, 2));
          int Month = Convert.ToInt32(lAmbalajBilgileri[i].ExpiryDate.Substring(2, 2));
          DateTime d = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
          sTarih += d.ToString("yyyy-MM-dd").Substring(8, 2);
        } else sTarih += lAmbalajBilgileri[i].ExpiryDate.Substring(4, 2);
        EDTU.XD = Convert.ToDateTime(sTarih);
        EDTU.BN = lAmbalajBilgileri[i].BatchNo;
        EDTU.SN = lAmbalajBilgileri[i].PackageCode;

        alEDTU.Add(EDTU);
      }

      DepoDogrulamaBildirimTypeURUN[] aEDTU = alEDTU.ToArray(typeof(DepoDogrulamaBildirimTypeURUN)) as DepoDogrulamaBildirimTypeURUN[];
      EDT.URUNLER = aEDTU;

      DepoDogrulamaBildirimCevapType EDCT = EDS.DepoDogrulamaBildir(EDT);
      UrunDogrulamaKontrol(EDCT);
      
    }

    protected void btnEkle_Click(object sender, EventArgs e)
    {
      
      DevExpress.Web.ASPxEditors.ListEditItem lei = new DevExpress.Web.ASPxEditors.ListEditItem(edtAmbalajKodu.Text);
      AmbalajBilgileri ab = new AmbalajBilgileri(edtGTINNumarasi.Text, edtSeriNumarasi.Text, edtSonKullanmaTarihi.Text, edtAmbalajKodu.Text);
      if (edtAmbalajKodu.Text == "") return;
      
      int iIndex = IndexOf(edtAmbalajKodu.Text);
      if (iIndex == -1)
      {
        lAmbalajBilgileri.Add(ab);
        lsbAmbalajlar.Items.Add(lei);
      }
      else
      {
        lAmbalajBilgileri.RemoveAt(iIndex);
        lsbAmbalajlar.Items.RemoveAt(iIndex);
      }

      hidAmbalajBarkodu.Value = "";
      edtAmbalajBarkodu.Text = "";
      edtAmbalajBarkoduKD.Text = "";
      btnTemizle_Click(sender, e);


      btnDogrula.Enabled = lAmbalajBilgileri.Count > 0;
      btnListeyiTemizle.Enabled = lAmbalajBilgileri.Count > 0;
      btnSatirSil.Enabled = lAmbalajBilgileri.Count > 0;
                           
    }

    protected void btnListeyiTemizle_Click(object sender, EventArgs e)
    {
      lAmbalajBilgileri.Clear();
      lsbAmbalajlar.Items.Clear();

      btnDogrula.Enabled = lAmbalajBilgileri.Count > 0;
      btnListeyiTemizle.Enabled = lAmbalajBilgileri.Count > 0;
      btnSatirSil.Enabled = lAmbalajBilgileri.Count > 0;      
    }

    protected void btnSatirSil_Click(object sender, EventArgs e)
    {
      int iIndex = lsbAmbalajlar.SelectedIndex;
      
      lAmbalajBilgileri.RemoveAt(iIndex);
      lsbAmbalajlar.Items.RemoveAt(iIndex);


      btnDogrula.Enabled = lAmbalajBilgileri.Count > 0;
      btnListeyiTemizle.Enabled = lAmbalajBilgileri.Count > 0;
      btnSatirSil.Enabled = lAmbalajBilgileri.Count > 0;            
    }

    protected void edtAmbalajBarkoduKD_ValueChanged(object sender, EventArgs e)
    {
      KareKod kkBarkod = new KareKod(hidAmbalajBarkodu.Value, 'D');

      try
      {
        edtGTINNumarasi.Text = kkBarkod.GTIN;
        edtSeriNumarasi.Text = kkBarkod.BatchNo;
        edtSonKullanmaTarihi.Text = kkBarkod.ExpiryDate;
        edtAmbalajKodu.Text = kkBarkod.PackageCode;
        
        if (edtAmbalajKodu.Text == "")
        {
          ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "alertScript", "alert('Barkod okunabilir değil!');", true);
          btnTemizle_Click(sender, e);
        }
      } catch {
        ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "alertScript", "alert('Barkod okunabilir değil!');", true);
        btnTemizle_Click(sender, e);
      }
    }

  }
}
