using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Functions
{
  public class Global
  {
    public static int UsrId;
    public static char Environment;
    public static string ConnectionString;

    public static Settings Settings;

    public class PackageCodes
    {
      int iPackageID;
      string sPackageCode;

      public int PackageID
      {
        get { return iPackageID; }
        set { iPackageID = value; }
      }
      public string PackageCode
      {
        get { return sPackageCode; }
        set { sPackageCode = value; }
      }
      public PackageCodes(int ID, string Code)
      {
        iPackageID = ID;
        sPackageCode = Code;
      }
    }

    public class DeclarationParameters
    {
      public string OrderId;
      public int SiraNumarasi;
      public int BaslangicId;
      public int KayitAdedi;

      public DeclarationParameters(string oi, int sn, int ka)
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

    public static int AmbalajKodunaGoreIDDondur(List<PackageCodes> lUAK, string Kod)
    {
      int r = -1;
      for (int i = 0; i < lUAK.Count; i++)
      {
        if (lUAK[i].PackageCode == Kod)
        {
          r = lUAK[i].PackageID;
          break;
        }
      }
      return r;
    }

    const int LOGON32_LOGON_INTERACTIVE = 2;
    const int LOGON32_LOGON_NETWORK = 3;
    const int LOGON32_LOGON_BATCH = 4;
    const int LOGON32_LOGON_SERVICE = 5;
    const int LOGON32_LOGON_UNLOCK = 7;
    const int LOGON32_LOGON_NETWORK_CLEARTEXT = 8;
    const int LOGON32_LOGON_NEW_CREDENTIALS = 9;
    const int LOGON32_PROVIDER_DEFAULT = 0;

    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern int LogonUser(
      string lpszUsername,
      string lpszDomain,
      string lpszPassword,
      int dwLogonType,
      int dwLogonProvider,
      out IntPtr phToken
      );
    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern int ImpersonateLoggedOnUser(
      IntPtr hToken
    );

    [DllImport("advapi32.dll", SetLastError = true)]
    static extern int RevertToSelf();

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern int CloseHandle(IntPtr hObject);

    public static IntPtr ChangeCredential()
    {
      IntPtr lnToken;
      int TResult = LogonUser("its", "TOKSOZHOLDING", "1sanovel",
            LOGON32_LOGON_NETWORK, LOGON32_PROVIDER_DEFAULT,
            out lnToken);
      if (TResult > 0)
        ImpersonateLoggedOnUser(lnToken);
      
      return lnToken;
    }

    public static void RevertCredential(IntPtr lnToken)
    {
      RevertToSelf();
      CloseHandle(lnToken);
    }

  }
}
