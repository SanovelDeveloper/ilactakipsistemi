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
  public partial class EczaneyeSatisKaydiOlusturma : Form
  {
    private string sBarkod = "";

    public EczaneyeSatisKaydiOlusturma()
    {
      InitializeComponent();
    }

    private void edtBarkod_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyValue == 8)
      {
        edtBarkod.Text = "";
        sBarkod = "";
      }
      else
        if (e.KeyValue == 13)
        {
          KareKod kkBarkod = new KareKod(sBarkod, 'D');

          edtBarkod.Text = kkBarkod.PackageCode;

          sBarkod = "";
        }
        else
          sBarkod += (char)e.KeyValue;
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      if (edtBarkod.Text == "")
      {
        MessageBox.Show("Lütfen ambalaj barkodunu okutun ya da sadece ambalaj kodunu girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        edtBarkod.Focus();
        return;
      }
      try
      {
        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
        {
          lITS.Create_Pharmacy_Sales(edtEczaneGLNNumarasi.Text, edtEczaneAdi.Text, edtBarkod.Text);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      MessageBox.Show("Kayıt eklenmiştir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
      edtBarkod.Text = "";
      edtBarkod.Focus();
    }

    private void btnTemizle_Click(object sender, EventArgs e)
    {
      edtEczaneAdi.Text = "";
      edtEczaneGLNNumarasi.Text = "";
      edtBarkod.Text = "";

      edtEczaneAdi.Focus();
    }


  }
}
