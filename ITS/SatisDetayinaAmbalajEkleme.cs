using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LINQ;

namespace ITS
{
  public partial class SatisDetayinaAmbalajEkleme : Form
  {
    private string sBarkod = "";
    private string sSSCC = "";
    public string OrderNumber;

    public SatisDetayinaAmbalajEkleme()
    {
      InitializeComponent();
    }

    private void edtKontrolBarkod_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue == 8)
      {
        edtKontrolBarkod.Text = "";
        sBarkod = "";
      }
      else
        if (e.KeyValue == 13)
        {
          if (sBarkod.Length > 2 && sBarkod.Substring(0, 2) == "00" && sBarkod.Length == 20) // SSCC
          {
            sSSCC = sBarkod;
          }
          else
          {
            if (sSSCC == "")
              MessageBox.Show("Öncelikle koli barkodunu okutmalısınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
              KareKod kkBarkod = new KareKod(sBarkod, 'D');
              try
              {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                  lITS.Package_Aggregation_Insert(OrderNumber, sSSCC, sBarkod);
                  grdEklenenAmbalajlar.DataSource = lITS.Package_Aggregation_Browse(OrderNumber);
                }
              }
              catch (Exception ex)
              {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
            }
          }
          edtKontrolBarkod.Text = "";
          sBarkod = "";

          
        }
        else
          sBarkod += (char)e.KeyValue;
    }
  }
}
