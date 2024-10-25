using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;

namespace Global
{
  public class Settings
  {
    public class ServisAdresleri
    {
      private string sUretimBildirimi;
      public string UretimBildirimi
      {
        get { return sUretimBildirimi; }
        set { sUretimBildirimi = value; }
      }

      private string sDeaktivasyonBildirimi;
      public string DeaktivasyonBildirimi
      {
        get { return sDeaktivasyonBildirimi; }
        set { sDeaktivasyonBildirimi = value; }
      }

      private string sIhracatBildirimi;
      public string IhracatBildirimi
      {
        get { return sIhracatBildirimi; }
        set { sIhracatBildirimi = value; }
      }

      private string sSatisBildirimi;
      public string SatisBildirimi
      {
        get { return sSatisBildirimi; }
        set { sSatisBildirimi = value; }
      }

      private string sSatisIptalBildirimi;
      public string SatisIptalBildirimi
      {
        get { return sSatisIptalBildirimi; }
        set { sSatisIptalBildirimi = value; }
      }
    }

    private string sProxyAdresi;
    public string ProxyAdresi
    {
      get { return sProxyAdresi; }
      set { sProxyAdresi = value; }
    }
    private string sProxyPort;
    public string ProxyPort
    {
      get { return sProxyPort; }
      set { sProxyPort = value; }
    }


    private string sITSKullaniciAdiSanovel;
    public string ITSKullaniciAdiSanovel
    {
      get { return sITSKullaniciAdiSanovel; }
      set { sITSKullaniciAdiSanovel = value; }
    }
    private string sITSKullaniciSifreSanovel;
    public string ITSKullaniciSifreSanovel
    {
      get { return sITSKullaniciSifreSanovel; }
      set { sITSKullaniciSifreSanovel = value; }
    }
    private string sGLNNumarasiSanovel;
    public string GLNNumarasiSanovel
    {
      get { return sGLNNumarasiSanovel; }
      set { sGLNNumarasiSanovel = value; }
    }

    private string sITSKullaniciAdiAset;
    public string ITSKullaniciAdiAset
    {
      get { return sITSKullaniciAdiAset; }
      set { sITSKullaniciAdiAset = value; }
    }
    private string sITSKullaniciSifreAset;
    public string ITSKullaniciSifreAset
    {
      get { return sITSKullaniciSifreAset; }
      set { sITSKullaniciSifreAset = value; }
    }
    private string sGLNNumarasiAset;
    public string GLNNumarasiAset
    {
      get { return sGLNNumarasiAset; }
      set { sGLNNumarasiAset = value; }
    }

    private string sITSKullaniciAdiAdilna;
    public string ITSKullaniciAdiAdilna
    {
      get { return sITSKullaniciAdiAdilna; }
      set { sITSKullaniciAdiAdilna = value; }
    }
    private string sITSKullaniciSifreAdilna;
    public string ITSKullaniciSifreAdilna
    {
      get { return sITSKullaniciSifreAdilna; }
      set { sITSKullaniciSifreAdilna = value; }
    }
    private string sGLNNumarasiAdilna;
    public string GLNNumarasiAdilna
    {
      get { return sGLNNumarasiAdilna; }
      set { sGLNNumarasiAdilna = value; }
    }

    private int iTekSeferdeGonderilecekAmbalajAdedi;
    public int TekSeferdeGonderilecekAmbalajAdedi
    {
      get { return iTekSeferdeGonderilecekAmbalajAdedi; }
      set { iTekSeferdeGonderilecekAmbalajAdedi = value; }
    }

    public ServisAdresleri saServisler = new ServisAdresleri();
    public string sDosyaAdi = "ayarlar.xml";

    public void AyarlariOku()
    {
      int i = 0;
      XmlTextReader xmlOkuyucu = new XmlTextReader(sDosyaAdi);

      while (xmlOkuyucu.Read())
      {
        if (xmlOkuyucu.NodeType == XmlNodeType.Element)
        {
          switch (xmlOkuyucu.Name)
          {
            case "proxy_adresi":
              sProxyAdresi = xmlOkuyucu.ReadString();
              break;
            case "proxy_port":
              sProxyPort = xmlOkuyucu.ReadString();
              break;
            case "tek_seferde_gonderilecek_ambalaj_adedi":
              iTekSeferdeGonderilecekAmbalajAdedi = Convert.ToInt32(xmlOkuyucu.ReadString());
              break;

          }
        }
      }
      xmlOkuyucu.Close();
    }

    public string HataMesajiGetir(string HataKodu)
    {
      string sErrorMessage = "";

      return sErrorMessage;
    }

    public void AyarlariYaz()
    {
      XmlTextWriter xmlYazici = new XmlTextWriter(sDosyaAdi, System.Text.UTF8Encoding.UTF8);
      xmlYazici.Formatting = Formatting.Indented;
      try
      {
        xmlYazici.WriteStartDocument();
        xmlYazici.WriteStartElement("ayarlar");

        xmlYazici.WriteStartElement("proxy_kullanici_ayarlari");
        xmlYazici.WriteElementString("proxy_adresi", sProxyAdresi);
        xmlYazici.WriteElementString("proxy_port", sProxyPort);
        xmlYazici.WriteEndElement();

        xmlYazici.WriteStartElement("bildirim_ayarlari");
        xmlYazici.WriteElementString("tek_seferde_gonderilecek_ambalaj_adedi", iTekSeferdeGonderilecekAmbalajAdedi.ToString());
        xmlYazici.WriteEndElement();

        xmlYazici.WriteEndDocument();

      }
      catch (Exception Ex)
      {
        throw Ex;
      }
      finally
      {
        xmlYazici.Close();
      }
    }

    public Settings(char OrtamTipi)
    {
      if (OrtamTipi == 'T') sDosyaAdi = "ayarlar_test.xml";
      else sDosyaAdi = "ayarlar.xml";

      AyarlariOku();
    }
  }
}
