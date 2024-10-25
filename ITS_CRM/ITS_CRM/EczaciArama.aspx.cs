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


namespace ITS_CRM
{
  public partial class EczaciArama : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Request.QueryString.Count != 2 || Request.QueryString["q"] == null) return;

      string sConnectionString = ConfigurationManager.ConnectionStrings["SDSConnectionString"].ConnectionString;
      SqlConnection conMain = new SqlConnection(sConnectionString);
      conMain.Open();
      try
      {
        SqlCommand scmData = new SqlCommand();
        scmData.Connection = conMain;
        scmData.CommandText = "ITSPharmacySearch;1";
        scmData.CommandType = CommandType.StoredProcedure;
        scmData.Parameters.Add(new SqlParameter("@PharmacistName", Request.QueryString["q"]));
        scmData.Parameters.Add(new SqlParameter("@CityName", Request.QueryString["c"]));

        SqlDataReader sdrReader = scmData.ExecuteReader();
        if (!sdrReader.HasRows) return;
        while (sdrReader.Read())
        {
          Response.Write(sdrReader["CU_PharmacyName"] + "|" + sdrReader["CU_ID"] + "|" + sdrReader["CU_Name"] + "|" + sdrReader["CO_Name"] + "|" + sdrReader["CT_Name"] + "|" + sdrReader["PH_Number"] + "|" + sdrReader["CU_Email"] + "|" + sdrReader["Brick"] + "|" + sdrReader["AD_Address"] + Environment.NewLine);
        }
        sdrReader.Close();
      }
      finally
      {
        conMain.Close();
      }          
      
    }
  }
}
