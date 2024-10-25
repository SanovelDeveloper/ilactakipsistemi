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
  public partial class KolileriYerDegistirme : Form
  {
    private string sBarkod = "";
    private string sSSCC = "";
    public string OrderNumber;

    public KolileriYerDegistirme()
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
            try
            {
              using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
              {
                lITS.Update_SSCC(OrderNumber, sBarkod);
              }
            }
            catch (Exception ex)
            {
              labelControl2.Text = ex.Message;
            }
          }
          edtKontrolBarkod.Text = "";
          sBarkod = "";


        }
        else
          sBarkod += (char)e.KeyValue;
    }

    private void KolileriYerDegistirme_Load(object sender, EventArgs e)
    {

    }
  }
}
