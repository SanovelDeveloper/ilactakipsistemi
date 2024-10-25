using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;


namespace ITS_CRM
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
        
    public List<HataMesajlari> lAyarlar = new List<HataMesajlari>(); 
    
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
