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
using System.Xml.Linq;

namespace ITS_CRM
{
  public partial class UrunSorgulamaSonuclari : System.Web.UI.Page
  {
    public DataSet dsUrunSorgulamaSonuclari;
    
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Request.QueryString["pc"] == null || Request.QueryString["pc"].ToString() == "") return;
      
      string sConnectionString = ConfigurationManager.ConnectionStrings["ITS_CRMConnectionString"].ConnectionString;
      SqlConnection conMain = new SqlConnection(sConnectionString);
      conMain.Open();
      try
      {
        SqlCommand scmData = new SqlCommand();
        scmData.Connection = conMain;
        scmData.CommandText = "Package_Search;1";
        scmData.CommandType = CommandType.StoredProcedure;
        if (Request.QueryString["ugtin"].ToString() != "" && Request.QueryString["ugtin"].ToString() != "0")
          scmData.Parameters.Add(new SqlParameter("@mmr_gtin", Request.QueryString["ugtin"].ToString()));
        else if (Request.QueryString["gtin"].ToString() != "")
          scmData.Parameters.Add(new SqlParameter("@mmr_gtin", Request.QueryString["gtin"].ToString()));
        if (Request.QueryString["batch"].ToString() != "")
          scmData.Parameters.Add(new SqlParameter("@batch", Request.QueryString["batch"].ToString()));
        scmData.Parameters.Add(new SqlParameter("@pck_code", Request.QueryString["pc"].ToString()));

        SqlDataAdapter sdaData = new SqlDataAdapter(scmData);
        dsUrunSorgulamaSonuclari = new DataSet();
        sdaData.Fill(dsUrunSorgulamaSonuclari);
        
        string sCriterion = "";
        if (Request.QueryString["ugtin"].ToString() != "" && Request.QueryString["ugtin"].ToString() != "0")
          sCriterion += "gtin = " + Request.QueryString["ugtin"].ToString() + ", ";
        else if (Request.QueryString["gtin"].ToString() != "")
          sCriterion += "gtin = " + Request.QueryString["gtin"].ToString() + ", ";
        if (Request.QueryString["batch"].ToString() != "")
          sCriterion += "batch = " + Request.QueryString["batch"].ToString() + ", ";
        sCriterion += "package_code = " + Request.QueryString["pc"].ToString();          
                
        scmData.CommandText = "Log_Insert;1";
        scmData.CommandType = CommandType.StoredProcedure;
        scmData.Parameters.Clear();
        scmData.Parameters.Add(new SqlParameter("@log_tck_id", Convert.ToInt32(Request.QueryString["tck_id"])));        
        scmData.Parameters.Add(new SqlParameter("@log_user_email_address", Request.ServerVariables["AUTH_USER"].ToString()));
        scmData.Parameters.Add(new SqlParameter("@log_type", "S"));
        scmData.Parameters.Add(new SqlParameter("@log_criterion", sCriterion));
        scmData.Parameters.Add(new SqlParameter("@log_rowcount", dsUrunSorgulamaSonuclari.Tables[0].Rows.Count));        
        scmData.ExecuteNonQuery();
      }
      finally
      {
        conMain.Close();
      }          
    }
  }
}
