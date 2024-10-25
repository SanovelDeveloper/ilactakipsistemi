using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using ITS_CRM.DepoUrunDogrulama;


namespace ITS_CRM
{
  public partial class UrunDogrulamaSonuclari : System.Web.UI.Page
  {
    public string Kriterler;
    public int TckId;
  
    private Ayarlar Ayarlar
    {
      get
      {
        return new Ayarlar(Server.MapPath("~/ayarlar.xml")); ;
      }
    }
  
    private void UrunDogrulamaKontrol(DepoDogrulamaBildirimCevapType EDCT)
    {
      string sonuc = "";
      try
      {
        for (int i = 0; i < EDCT.URUNLER.Length; i++)
        {
          sonuc += EDCT.URUNLER[i].UC + " / " + Ayarlar.HataMesajiGetir(EDCT.URUNLER[i].UC) + "<br>";
        }
      }
      catch (Exception ex)
      {
        sonuc = "EX :: " + ex.Message;
      }
      Response.Write(sonuc);

      
      string sConnectionString = ConfigurationManager.ConnectionStrings["ITS_CRMConnectionString"].ConnectionString;
      SqlConnection conMain = new SqlConnection(sConnectionString);
      conMain.Open();
      try
      {
        SqlCommand scmData = new SqlCommand();
        scmData.Connection = conMain;      
        scmData.CommandText = "Log_Insert;1";
        scmData.CommandType = CommandType.StoredProcedure;
        scmData.Parameters.Clear();
        scmData.Parameters.Add(new SqlParameter("@log_tck_id", TckId));
        scmData.Parameters.Add(new SqlParameter("@log_user_email_address", Request.ServerVariables["AUTH_USER"].ToString()));
        scmData.Parameters.Add(new SqlParameter("@log_type", "D"));
        scmData.Parameters.Add(new SqlParameter("@log_criterion", Kriterler));
        scmData.Parameters.Add(new SqlParameter("@log_verification_result", EDCT.URUNLER[0].UC));
        scmData.ExecuteNonQuery();
      }
      finally
      {
        conMain.Close();
      }
    }
      
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Request.QueryString.Count != 5) return;
      if (Request.QueryString["gtin"] == null || Request.QueryString["batch_no"] == null || Request.QueryString["exp_date"] == null || Request.QueryString["pac_code"] == null || Request.QueryString["tck_id"] == null) return;
      
      string sGTIN = Request.QueryString["gtin"].ToString();
      string sBatchNo = Request.QueryString["batch_no"].ToString();
      string sExpiryDate = Request.QueryString["exp_date"].ToString();
      string sPackageCode = Request.QueryString["pac_code"].ToString();

      TckId = Convert.ToInt32(Request.QueryString["tck_id"].ToString());
      Kriterler = "gtin = " + sGTIN + ", batch = " + sBatchNo + ", exp_date = " + sExpiryDate + ", package_code = " + sPackageCode;
      
      DepoDogrulamaReceiverService EDS = new DepoDogrulamaReceiverService();

      //EDS.Credentials = new NetworkCredential("econgar", "mar1mara2");      
      EDS.Credentials = new NetworkCredential("86800010864430000", "mer1kez2");      
      EDS.Proxy = new WebProxy("172.16.0.15", 8080);

      DepoDogrulamaBildirimType EDT = new DepoDogrulamaBildirimType();

      EDT.DT = "V";
      EDT.FR = "8680001086443";

      ArrayList alEDTU = new ArrayList();

      DepoDogrulamaBildirimTypeURUN EDTU = new DepoDogrulamaBildirimTypeURUN();
      EDTU.GTIN = sGTIN;  
      EDTU.XD = Convert.ToDateTime(sExpiryDate);
      EDTU.BN = sBatchNo;
      EDTU.SN = sPackageCode;

      alEDTU.Add(EDTU);

      DepoDogrulamaBildirimTypeURUN[] aEDTU = alEDTU.ToArray(typeof(DepoDogrulamaBildirimTypeURUN)) as DepoDogrulamaBildirimTypeURUN[];
      EDT.URUNLER = aEDTU;

      DepoDogrulamaBildirimCevapType EDCT = EDS.DepoDogrulamaBildir(EDT);
      UrunDogrulamaKontrol(EDCT);
    }
  }
}
