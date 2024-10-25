using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ITS
{
  public static class Guvenlik
  {  
    
    public enum Yetkiler
    {
      KayitOkuma = 1,
      KayitEkleme = 2,
      KayitGuncelleme = 4,
      KayitSilme = 8,
      Aktarma = 16,
      Yazdirma = 32
    }
    
    
    private class KullaniciGuvenlikListesi
    {            
      public Yetkiler Yetkiler;
      public string FonksiyonAdi;
    }
    
    private static List<KullaniciGuvenlikListesi> lGuvenlikListesi = new List<KullaniciGuvenlikListesi>();
    
    public static void GuvenlikOku()
    {
      SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
      conITS.Open();
      try
      {
        SqlCommand scmData = new SqlCommand();
        scmData.Connection = conITS;
        scmData.CommandText = "User_Authority;1";
        scmData.CommandType = CommandType.StoredProcedure;
        scmData.Parameters.Clear();
        scmData.Parameters.Add(new SqlParameter("@usr_id", Global.UsrId));

        SqlDataReader sdrData = scmData.ExecuteReader();

        while (sdrData.Read())
        {
          KullaniciGuvenlikListesi GuvenlikListesi = new KullaniciGuvenlikListesi();
          GuvenlikListesi.FonksiyonAdi = sdrData["fun_page_name"].ToString();

          if (Convert.ToBoolean(sdrData["rgh_read"]) || Global.SuperVisor)
            GuvenlikListesi.Yetkiler = GuvenlikListesi.Yetkiler | Yetkiler.KayitOkuma;
          if (Convert.ToBoolean(sdrData["rgh_insert"]) || Global.SuperVisor)
            GuvenlikListesi.Yetkiler = GuvenlikListesi.Yetkiler | Yetkiler.KayitEkleme;
          if (Convert.ToBoolean(sdrData["rgh_update"]) || Global.SuperVisor)
            GuvenlikListesi.Yetkiler = GuvenlikListesi.Yetkiler | Yetkiler.KayitGuncelleme;
          if (Convert.ToBoolean(sdrData["rgh_delete"]) || Global.SuperVisor)
            GuvenlikListesi.Yetkiler = GuvenlikListesi.Yetkiler | Yetkiler.KayitSilme;
          if (Convert.ToBoolean(sdrData["rgh_export"]) || Global.SuperVisor)
            GuvenlikListesi.Yetkiler = GuvenlikListesi.Yetkiler | Yetkiler.Aktarma;
          if (Convert.ToBoolean(sdrData["rgh_print"]) || Global.SuperVisor)
            GuvenlikListesi.Yetkiler = GuvenlikListesi.Yetkiler | Yetkiler.Yazdirma;

          lGuvenlikListesi.Add(GuvenlikListesi);                                                            
        }        
        
        sdrData.Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      finally
      {
        conITS.Close();
      }      
    }
    
    public static bool GuvenlikKontrol(string FonksiyonAdi, Yetkiler Yetkiler)
    {      
      for (int i = 0; i < lGuvenlikListesi.Count; i++)
      {
        if (lGuvenlikListesi[i].FonksiyonAdi == FonksiyonAdi)
          if (Yetkiler != 0 && ((lGuvenlikListesi[i].Yetkiler & Yetkiler) == Yetkiler))
            return true;
          else return Global.SuperVisor;
      }
        
      return Global.SuperVisor;
    }
    public static bool GuvenlikKontrol(string FonksiyonAdi, int Yetkiler)
    {
      for (int i = 0; i < lGuvenlikListesi.Count; i++)
      {
        if (lGuvenlikListesi[i].FonksiyonAdi == FonksiyonAdi)
          if (Yetkiler != 0 && (((int)lGuvenlikListesi[i].Yetkiler & Yetkiler) == Yetkiler))
            return true;
          else return Global.SuperVisor;
      }

      return Global.SuperVisor;
    }    
  }
}
