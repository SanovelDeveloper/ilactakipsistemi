using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.DataVisualization.Charting;
using System.Xml.Linq;

namespace ITSWeb
{
  public partial class _Default : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void ASPxButton1_Click(object sender, EventArgs e)
    { 
      sdsUretimiBildirilmisUretimEmirleri.SelectParameters.Clear();
      if (edtUretimEmriNumarasi.Text != "")
        sdsUretimiBildirilmisUretimEmirleri.SelectParameters.Add(new Parameter("ord_order_id", TypeCode.String, edtUretimEmriNumarasi.Text));
      if (edtMalzemeAdi.Text != "")
        sdsUretimiBildirilmisUretimEmirleri.SelectParameters.Add(new Parameter("mmr_item_name", TypeCode.String, edtMalzemeAdi.Text));
      if (dteBaslangicTarihi.Value != null)
        sdsUretimiBildirilmisUretimEmirleri.SelectParameters.Add(new Parameter("begin_date", TypeCode.DateTime, dteBaslangicTarihi.Value.ToString()));
      if (dteBitisTarihi.Value != null)
        sdsUretimiBildirilmisUretimEmirleri.SelectParameters.Add(new Parameter("end_date", TypeCode.DateTime, dteBitisTarihi.Value.ToString()));
        
      trlUretimBildirimiYapilmisUretimEmirleri.DataBind();
    }

    protected void sdsUretimiBildirilmisUretimEmirleri_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
      if (!Page.IsPostBack)
        e.Cancel = true;
    }
  }
}
