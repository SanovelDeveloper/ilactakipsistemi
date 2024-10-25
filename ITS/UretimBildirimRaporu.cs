using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ITS
{
  public partial class UretimBildirimRaporu : Form
  {
    private string sUretimEmriNo;

    public UretimBildirimRaporu(string UretimEmriNo)
    {
      sUretimEmriNo = UretimEmriNo;
      InitializeComponent();
    }

    private void UretimBildirimRaporu_Load(object sender, EventArgs e)
    {      
      reportViewer1.LocalReport.EnableExternalImages = true;

      production_Decalaration_ReportTableAdapter.Connection = new SqlConnection(Global.ITSConnectionString);
      production_Decalaration_ReportTableAdapter.Fill(dstUretimBildirimRaporu.Production_Decalaration_Report, sUretimEmriNo);
      reportViewer1.RefreshReport();      
      
    }
  }
}
