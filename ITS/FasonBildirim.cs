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
  public partial class FasonBildirim : Form
  {
    public string OrderDetails;
    public string OrderNumber;


    public FasonBildirim()
    {
      InitializeComponent();
    }

    private void FasonBildirim_Load(object sender, EventArgs e)
    {
      sleCari.Properties.DataSource = new ITSDataContext(Global.ITSConnectionString).vAccount_Masters.ToList();
        edtUretimEmriNumaralari.Text = OrderDetails;
    }

    private void edtKontrolBarkod_EditValueChanged(object sender, EventArgs e)
    {

    }

    private void btnPTSBildir_Click(object sender, EventArgs e)
    {
      if (edtSSCC.Text.Length < 20)
        if (MessageBox.Show("SSCC barkodu girişi yapmazsanız sistem otomatik bir barkod oluşturacaktır, emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        else
          edtSSCC.Text = "";

      string CustomerCode = sleCariView.GetFocusedRowCellValue(sleCariKod).ToString();

      Cursor = Cursors.WaitCursor;
      SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
      try
      {
        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
        {
            lITS.Create_Shipping_Order_From_Production(OrderNumber, CustomerCode, edtSSCC.Text);

            DeclarationServices.SendPTS PTS = new DeclarationServices.SendPTS(Global.UsrId, Global.Environment, Global.ITSConnectionString);
            PTS.GonderAsync("UR" + OrderNumber);         
        }

        lblMessage.Text = "PTS verisi oluşturuldu ve bildirildi.";
      }
      catch (Exception ex)
      {
        lblMessage.Text = "Hata: " + ex.Message;
      }
      finally
      {
        Cursor = Cursors.Default;
        SplashScreenManager.CloseForm();
      }
    }

    private void edtSSCC_EditValueChanged(object sender, EventArgs e)
    {

    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
