using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Global
{
  public class Global
  {
    public static int UsrId;
    public static char OrtamTipi;
    public static string ConnectionString;

    public static Settings Settings;

    public class AmbalajKodlari
    {
      int iAmbalajID;
      string sAmbalajKodu;

      public int AmbalajId
      {
        get { return iAmbalajID; }
        set { iAmbalajID = value; }
      }
      public string AmbalajKodu
      {
        get { return sAmbalajKodu; }
        set { sAmbalajKodu = value; }
      }
      public AmbalajKodlari(int ID, string Kod)
      {
        iAmbalajID = ID;
        sAmbalajKodu = Kod;
      }
    }

    public class BildirimParametreleri
    {
      public string OrderId;
      public int SiraNumarasi;
      public int BaslangicId;
      public int KayitAdedi;

      public BildirimParametreleri(string oi, int sn, int ka)
      {
        OrderId = oi;
        SiraNumarasi = sn + 1;
        BaslangicId = sn * ka;
        KayitAdedi = ka;
      }
    }

    public class Sonuclar : IComparable
    {
      public string Sonuc;
      public int AmbalajID;

      public Sonuclar(string S1, int S2)
      {
        Sonuc = S1;
        AmbalajID = S2;
      }

      public int CompareTo(object obj)
      {
        return Sonuc.CompareTo(((Sonuclar)obj).Sonuc);
      }
    }

    public static int AmbalajKodunaGoreIDDondur(List<AmbalajKodlari> lUAK, string Kod)
    {
      int r = -1;
      for (int i = 0; i < lUAK.Count; i++)
      {
        if (lUAK[i].AmbalajKodu == Kod)
        {
          r = lUAK[i].AmbalajId;
          break;
        }
      }
      return r;
    } 
  }
}
