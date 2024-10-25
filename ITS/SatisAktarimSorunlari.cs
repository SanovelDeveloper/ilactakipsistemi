using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LINQ;
using System.Collections;
using DevExpress.XtraSplashScreen;

namespace ITS
{
  public partial class SatisAktarimSorunlari : Form
  {
    public SatisAktarimSorunlari()
    {
      InitializeComponent();
    }

    private void btnKontrolEt_Click(object sender, EventArgs e)
    {
      if (edtBelgeNumarasi.Text == "")
      {
        MessageBox.Show("Satış belge numarasını giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        edtBelgeNumarasi.Focus();
        return;
      }

      if (cbxAktarimYeri.SelectedIndex == -1)
      {
        MessageBox.Show("Aktarım yerini seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        cbxAktarimYeri.Focus();
        return;
      }
      Cursor = Cursors.WaitCursor;
      SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
      try
      {
        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
        {
          var tWarnings = lITS.Control_Shipping_Data_Transfer(edtBelgeNumarasi.Text, (byte?)(cbxAktarimYeri.SelectedIndex + 1)).ToList();
          if (tWarnings.Count == 0)
          {
            memSonuclar.Text = "Herhangi bir hata bulunamadı!";
          }

          ArrayList array = new ArrayList(memSonuclar.Lines);
          foreach (var W in tWarnings)
          {
            array.Add(W.warning);
          }
          memSonuclar.Lines = array.ToArray(typeof(string)) as string[];
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        SplashScreenManager.CloseForm();
        Cursor = Cursors.Default;
      }

    }


  }
}
