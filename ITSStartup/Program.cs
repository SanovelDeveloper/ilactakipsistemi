using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.ComponentModel;

namespace ITSStartup
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]

    static string GetMD5HashFromFile(string fileName)
    {
      FileStream file = new FileStream(fileName, FileMode.Open);
      MD5 md5 = new MD5CryptoServiceProvider();
      byte[] retVal = md5.ComputeHash(file);
      file.Close();

      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < retVal.Length; i++)
      {
        sb.Append(retVal[i].ToString("x2"));
      }
      return sb.ToString();
    }

    static void CheckAndDownloadFiles()
    {
      INIFile INI = new INIFile(Application.StartupPath + "\\config.ini");
      string sDefaultAlias = INI.IniReadValue("StartUp", "DefaultAlias");
      string sITSConnectionString = String.Format("Data Source={0};Initial Catalog=ITS;Persist Security Info=True;User ID=ITS_USER;Password=fast;Application Name=ITS;", sDefaultAlias);


      SqlConnection conITS = new SqlConnection(sITSConnectionString);
      conITS.Open();
      try
      {
        SqlCommand scmData = new SqlCommand();
        scmData.Connection = conITS;
        scmData.CommandText = "SELECT * FROM File_List";
        scmData.CommandType = CommandType.Text;

        using (SqlDataReader sdrData = scmData.ExecuteReader())
        {
          if (!sdrData.HasRows) return;
          while (sdrData.Read())
          {
            if (GetMD5HashFromFile(sdrData["fle_file_name"].ToString()) != sdrData["fle_md5"].ToString())
            {
              WebClient webClient = new WebClient();              
              webClient.DownloadFile(new Uri("http://sim.sanovel.com.tr/itsupdate/" + sdrData["fle_file_name"].ToString()), Application.StartupPath + @"\" + sdrData["fle_file_name"].ToString());
            }
          }
        }

      }
      finally
      {
        conITS.Close();
        using (System.Diagnostics.Process Proc = new System.Diagnostics.Process())
        {
          Proc.StartInfo.FileName = "ITS.exe";
          Proc.Start();
        }
      }
    }

    static void Main()
    {
      CheckAndDownloadFiles();
      //Application.EnableVisualStyles();
      //Application.SetCompatibleTextRenderingDefault(false);
      //Application.Run(new Form1());
    }
  }
}
