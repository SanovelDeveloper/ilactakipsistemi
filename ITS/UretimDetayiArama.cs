using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using LINQ;

namespace ITS
{
  public partial class UretimDetayiArama : DevExpress.XtraEditors.XtraForm
  {
    public UretimDetayiArama()
    {
      InitializeComponent();
    }

    private string sBarkod = "";
    public string UretimEmriNo = "";
    public string AmbalajKodu = "";

    private void Search()
    {
      using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
      {
        if (edtAmbalajKodu.Text.Length < 3) return;

        List<Package_List_BrowseResult> tPackageList;
        if (edtAmbalajKodu.Text.Substring(0, 2) == "00" && edtAmbalajKodu.Text.Length == 20) //SSCC
          tPackageList = lITS.Package_List_Browse(null,
                                                  null,
                                                  cbeGecerlilikDurumu.SelectedIndex > -1 ? ((main.GecerlilikDurumuDetayi)cbeGecerlilikDurumu.SelectedItem).Value : (byte?)null,
                                                  "",
                                                  edtAmbalajKodu.Text,
                                                  null,
                                                  100).ToList();
        else
          tPackageList = lITS.Package_List_Browse(null,
                                                  null,
                                                  cbeGecerlilikDurumu.SelectedIndex > -1 ? ((main.GecerlilikDurumuDetayi)cbeGecerlilikDurumu.SelectedItem).Value : (byte?)null,
                                                  edtAmbalajKodu.Text,
                                                  "",
                                                  null,
                                                  100).ToList();

        grdAmbalajDetayi.DataSource = tPackageList;
      }
    }

    private void edtAmbalajKodu_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Search();
      }
    }

    private void cbeGecerlilikDurumu_SelectedIndexChanged(object sender, EventArgs e)
    {
      Search();
    }

    private void edtAmbalajBarkodu_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue == 8)
      {
        edtAmbalajBarkodu.Text = "";
        sBarkod = "";
      }
      else if (e.KeyValue == 13)
      {
        if (sBarkod.Length > 2 && sBarkod.Substring(0, 2) == "00" && sBarkod.Length == 20) // SSCC
        {
          edtAmbalajKodu.Text = sBarkod;
        }
        else
        {
          KareKod kkBarkod = new KareKod(sBarkod, 'D');
          edtAmbalajKodu.Text = kkBarkod.PackageCode;
        }
        Search();
        edtAmbalajBarkodu.SelectAll();
        sBarkod = "";
      }
      else
        sBarkod += (char)e.KeyValue;
    }

    private void grdAmbalajDetayiView_DoubleClick(object sender, EventArgs e)
    {
      UretimEmriNo = grdAmbalajDetayiView.GetFocusedRowCellValue(grdAmbalajDetayiOrderId).ToString();
      AmbalajKodu = grdAmbalajDetayiView.GetFocusedRowCellValue(grdAmbalajDetayiPackageCode).ToString();
      Close();
    }

    private void UretimDetayiArama_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Escape) Close();
    }
  }
}