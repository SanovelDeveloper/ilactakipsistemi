using System;
using System.Collections.Generic;
using System.Text;

namespace UrunDogrulama
{
  public class KareKod
  {
    public string GTIN;
    public string BatchNo;
    public string ExpiryDate;
    public string PackageCode;

    public KareKod(string Barkod, char Tip)
    {
      string sT = "";
      try
      {
        if (Barkod.Length > 13)
        {
          if (Tip == 'D') // KeyDown
          {
            if (Barkod.IndexOf((char)221) > -1) // Ascii mode on
            {
              string sParca1 = Barkod.Substring(2, Barkod.IndexOf((char)221) - 2);
              string sParca2 = Barkod.Substring(Barkod.IndexOf((char)221) + 1, Barkod.Length - Barkod.IndexOf((char)221) - 1);

              GTIN = sParca1.Substring(0, 14);
              ExpiryDate = sParca2.Substring(2, 6);

              sT = sParca1.Substring(14, sParca1.IndexOf((char)17) - 13);
              if (sT[0] == 49 && sT[1] == 48)
              {// ilk 2 karakter "10" ise
                BatchNo = sT.Substring(2, sT.IndexOf((char)17) - 2);
                PackageCode = sParca2.Substring(10, sParca2.IndexOf((char)17) - 10);
              }
              else if (sT[0] == 50 && sT[1] == 49)
              {// ilk 2 karakter "21" ise
                PackageCode = sT.Substring(2, sT.IndexOf((char)17) - 2);
                BatchNo = sParca2.Substring(10, sParca2.IndexOf((char)17) - 10);
              }

              BatchNo = BatchNo.Replace((char)16, (char)32).Replace(" ", "");
              PackageCode = PackageCode.Replace((char)16, (char)32).Replace(" ", "");
            }
            else if (Barkod.IndexOf((char)119) > -1) // Ascii mode off
            {
              string sParca1 = Barkod.Substring(2, Barkod.IndexOf((char)119) - 2);
              string sParca2 = Barkod.Substring(Barkod.IndexOf((char)119) + 1, Barkod.Length - Barkod.IndexOf((char)119) - 1);

              GTIN = sParca1.Substring(0, 14);
              ExpiryDate = sParca2.Substring(2, 6);
              sT = sParca1.Substring(14, sParca1.Length - 14);
              if (sT[0] == 49 && sT[1] == 48)
              { // ilk 2 karakter "10" ise
                BatchNo = sParca1.Substring(16, sParca1.Length - 16);
                PackageCode = sParca2.Substring(10, sParca2.Length - 10);
              }
              else if (sT[0] == 50 && sT[1] == 49)
              {// ilk 2 karakter "21" ise
                PackageCode = sParca1.Substring(16, sParca1.Length - 16);
                BatchNo = sParca2.Substring(10, sParca2.Length - 10);
              }

              BatchNo = BatchNo.Replace((char)16, (char)32).Replace(" ", "");
              PackageCode = PackageCode.Replace((char)16, (char)32).Replace(" ", "");
            }
          }
          else if (Tip == 'P') // KeyPress
          {
            string sParca1 = Barkod.Substring(2, Barkod.IndexOf((char)29) - 2);
            string sParca2 = Barkod.Substring(Barkod.IndexOf((char)29) + 1, Barkod.Length - Barkod.IndexOf((char)29) - 1);

            GTIN = sParca1.Substring(0, 14);
            ExpiryDate = sParca2.Substring(2, 6);
            sT = sParca1.Substring(14, sParca1.Length - 14);
            if (sT[0] == 49 && sT[1] == 48)
            {// ilk 2 karakter "10" ise
              BatchNo = sParca1.Substring(16, sParca1.Length - 16);
              PackageCode = sParca2.Substring(10, sParca2.Length - 10);
            }
            else if (sT[0] == 50 && sT[1] == 49)
            {// ilk 2 karakter "21" ise
              PackageCode = sParca1.Substring(16, sParca1.Length - 16);
              BatchNo = sParca2.Substring(10, sParca2.Length - 10);
            }

          }
        }
      }
      catch
      {
        return;
      }
    }
  }
}
