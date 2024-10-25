using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;


namespace UrunDogrulama
{
  [Serializable]
  public class Ayarlar
  {
       
    public class HataMesajlari
    {
      private string sHataKodu;
      public string HataKodu
      {
        get { return sHataKodu; }
        set { sHataKodu = value; }
      }

      private string sHataMesaji;
      public string HataMesaji
      {
        get { return sHataMesaji; }
        set { sHataMesaji = value; }
      }

      private string sHataTipi;
      public string HataTipi
      {
        get { return sHataTipi; }
        set { sHataTipi = value; }
      }            
    }
    
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
    
    public string sProxyAdresi;
    public string ProxyAdresi
    {
      get { return sProxyAdresi; }
      set { sProxyAdresi = value; }
    }          
    public string sProxyPort;
    public string ProxyPort
    {
      get { return sProxyPort; }
      set { sProxyPort = value; }
    }       


    public string sITSKullaniciAdiSanovel;
    public string ITSKullaniciAdiSanovel
    {
      get { return sITSKullaniciAdiSanovel; }
      set { sITSKullaniciAdiSanovel = value; }
    }       
    public string sITSKullaniciSifreSanovel;
    public string ITSKullaniciSifreSanovel
    {
      get { return sITSKullaniciSifreSanovel; }
      set { sITSKullaniciSifreSanovel = value; }
    }
    public string sGLNNumarasiSanovel;
    public string GLNNumarasiSanovel
    {
      get { return sGLNNumarasiSanovel; }
      set { sGLNNumarasiSanovel = value; }
    }
    
    public string sITSKullaniciAdiAset;
    public string ITSKullaniciAdiAset
    {
      get { return sITSKullaniciAdiAset; }
      set { sITSKullaniciAdiAset = value; }
    }
    public string sITSKullaniciSifreAset;
    public string ITSKullaniciSifreAset
    {
      get { return sITSKullaniciSifreAset; }
      set { sITSKullaniciSifreAset = value; }
    }
    public string sGLNNumarasiAset;
    public string GLNNumarasiAset
    {
      get { return sGLNNumarasiAset; }
      set { sGLNNumarasiAset = value; }
    }
        
    public string sITSKullaniciAdiAdilna;
    public string ITSKullaniciAdiAdilna
    {
      get { return sITSKullaniciAdiAdilna; }
      set { sITSKullaniciAdiAdilna = value; }
    }
    public string sITSKullaniciSifreAdilna;
    public string ITSKullaniciSifreAdilna
    {
      get { return sITSKullaniciSifreAdilna; }
      set { sITSKullaniciSifreAdilna = value; }
    }
    public string sGLNNumarasiAdilna;
    public string GLNNumarasiAdilna
    {
      get { return sGLNNumarasiAdilna; }
      set { sGLNNumarasiAdilna = value; }
    }    
    
    public int iTekSeferdeGonderilecekAmbalajAdedi;
    public int TekSeferdeGonderilecekAmbalajAdedi
    {
      get { return iTekSeferdeGonderilecekAmbalajAdedi; }
      set { iTekSeferdeGonderilecekAmbalajAdedi = value; }    
    }
    
    public List<HataMesajlari> lAyarlar = new List<HataMesajlari>(); 
    public ServisAdresleri saServisler = new ServisAdresleri();
    //public string sDosyaAdi = "ayarlar.xml";
    
    public void AyarlariOku(string sDosyaAdi)
    {
      int i = 0;
      XmlTextReader xmlOkuyucu = new XmlTextReader(sDosyaAdi);
      
      while (xmlOkuyucu.Read())
      {
        if (xmlOkuyucu.NodeType == XmlNodeType.Element)
        {
          switch (xmlOkuyucu.Name)
          { 
            case "hata_mesaji": 
              lAyarlar.Add(new HataMesajlari());
              i++;
              break;
            case "mesaj_tipi":
              lAyarlar[i-1].HataTipi = xmlOkuyucu.ReadString();
              break;
            case "mesaj_kodu":              
              lAyarlar[i-1].HataKodu = xmlOkuyucu.ReadString();
              break;
            case "mesaj":
              lAyarlar[i-1].HataMesaji = xmlOkuyucu.ReadString();
              break;
            case "uretim_bildirimi":
              saServisler.UretimBildirimi = xmlOkuyucu.ReadString();
              break;
            case "deaktivasyon_bildirimi":
              saServisler.DeaktivasyonBildirimi = xmlOkuyucu.ReadString();
              break;
            case "ihracat_bildirimi":
              saServisler.IhracatBildirimi = xmlOkuyucu.ReadString();
              break;
            case "satis_bildirimi":
              saServisler.SatisBildirimi = xmlOkuyucu.ReadString();
              break;
            case "satis_iptal_bildirimi":
              saServisler.SatisIptalBildirimi = xmlOkuyucu.ReadString();
              break;
            case "proxy_adresi":
              sProxyAdresi = xmlOkuyucu.ReadString();
              break;
            case "proxy_port":
              sProxyPort = xmlOkuyucu.ReadString();
              break;
            case "GLN_numarasi_Sanovel":
              sGLNNumarasiSanovel = xmlOkuyucu.ReadString();
              break;
            case "ITS_kullanici_adi":
              sITSKullaniciAdiSanovel = xmlOkuyucu.ReadString();
              break;
            case "ITS_sifre":
              sITSKullaniciSifreSanovel = xmlOkuyucu.ReadString();
              break;
            case "GLN_numarasi_Aset":
              sGLNNumarasiAset = xmlOkuyucu.ReadString();
              break;              
            case "ITS_kullanici_adi_Aset":
              sITSKullaniciAdiAset = xmlOkuyucu.ReadString();
              break;
            case "ITS_sifre_Aset":
              sITSKullaniciSifreAset = xmlOkuyucu.ReadString();
              break;
            case "GLN_numarasi_Adilna":
              sGLNNumarasiAdilna = xmlOkuyucu.ReadString();
              break;              
            case "ITS_kullanici_adi_Adilna":
              sITSKullaniciAdiAdilna = xmlOkuyucu.ReadString();
              break;
            case "ITS_sifre_Adilna":
              sITSKullaniciSifreAdilna = xmlOkuyucu.ReadString();
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
      string HataMesaji = "";
      for (int i = 0; i < lAyarlar.Count - 1 ; i++)
      {
        if (lAyarlar[i].HataKodu == HataKodu)
        {
          HataMesaji = lAyarlar[i].HataMesaji;
          break;
        }
      }
      return HataMesaji;
    }    
    
    public Ayarlar(string sDosyaAdi)
    {
      AyarlariOku(sDosyaAdi);
    }
  }
}
