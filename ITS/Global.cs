using System;
using System.Collections.Generic;
using System.Text;

namespace ITS
{
  public static class Global
  {
    public static string ITSConnectionString;
    public static string MESConnectionString;
  
    public static int UsrId;
    public static string UsrName;
    public static char Environment = 'G'; // G: Gerçek, T: Test    
    public static bool SuperVisor = false;
  }
}
