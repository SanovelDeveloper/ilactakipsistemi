/*******************************************************************************/
/*  Copyright (c) 2009 SANOVEL A.Ş.  / bilsis@sanovel.com.tr                   */
/*  All rights reserved.                                                       */
/*                                                                             */
/*  Tanım    : İTS uygulamasının bildirim zamanlama ekranıdır.                 */
/*  Amaç     : İTS uygulamasında üretim, satış, ihracat ve pts bildirimlerinin */
/*             zamanlanması için kullanılır.                                   */
/*  Kısıtlar :  -                                                              */
/*                                                                             */
/*  Düzenleme Tarihçesi:                                                       */
/*  Versiyon  Tarih       Kişi     Açıklama                                    */
/*    1.0     23/07/2014  EA       Başlandı.                                   */
/*                                                                             */
/*                                                                             */
/*  Açıklama ve Yorumlar:                                                      */
/*                                                                             */
/*                                                                             */
/*  Kısaltmalar:                                                               */
/*  EA : Erhan AKARLAR                                                         */
/*******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LINQ;
using DevExpress.XtraSplashScreen;


namespace ITS
{
  public partial class GrupIciSatisAlisIslemleri : Form
  {
    main myMainForm;

    public class ValueDisplay
    {
      private string sValue;
      private string sDisplayText;

      public ValueDisplay(string sv, string sd)
      {
        sValue = sv;
        sDisplayText = sd;
      }

      public override string ToString()
      {
        return sDisplayText;
      }

      public string Value
      {
        get
        {
          return sValue;
        }
      }
    }


    public GrupIciSatisAlisIslemleri(main mainForm)
    {
      InitializeComponent();
      myMainForm = mainForm;
    }

    private void GrupIciSatisAlisIslemleri_Load(object sender, EventArgs e)
    {
      using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
      {
        var tCompanyList = lITS.Group_Company_Sales_Company_Browse().ToList();
          
        
        cbeSaticiFirma.Properties.Items.Clear();
        cbeAliciFirma.Properties.Items.Clear();

        foreach (var CompanyList in tCompanyList) 
        {
          cbeSaticiFirma.Properties.Items.Add(new ValueDisplay(CompanyList.amr_gln_number.ToString(),
                                                               CompanyList.Company.ToString()));

          cbeAliciFirma.Properties.Items.Add(new ValueDisplay(CompanyList.amr_gln_number.ToString(),
                                                              CompanyList.Company.ToString()));
        
        }

        cbeSaticiFirma.SelectedIndex = -1;
      }      
    }

    private void btnBildirimleriYap_Click(object sender, EventArgs e)
    {
      if (cbeSaticiFirma.SelectedIndex == -1)
      {
        MessageBox.Show("Satıcı firma bilgisi boş geçilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        DialogResult = DialogResult.None;
        return;
      }

      if (cbeAliciFirma.SelectedIndex == -1)
      {
        MessageBox.Show("Alıcı firma bilgisi boş geçilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        DialogResult = DialogResult.None;
        return;
      }

      if (edtUretimEmriNo.Text == "")
      {
        MessageBox.Show("Üretim emri no bilgisi boş geçilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        DialogResult = DialogResult.None;
        return;
      }

      if (MessageBox.Show("Satış bildirimi yapılacaktır. Bu işlemin iptali yoktur. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;

      using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 240000 })
      {
        Cursor = Cursors.WaitCursor;
        SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
        Application.DoEvents();

        try
        {
          DeclarationServices.SendSales SatisBildirimi = new DeclarationServices.SendSales(Global.UsrId, Global.Environment, Global.ITSConnectionString);
          SatisBildirimi.SendAsync(edtUretimEmriNo.Text, 2, ((ValueDisplay)cbeSaticiFirma.SelectedItem).Value, ((ValueDisplay)cbeAliciFirma.SelectedItem).Value);

          DeclarationServices.SendReceipt SB = new DeclarationServices.SendReceipt(Global.UsrId, Global.Environment, Global.ITSConnectionString);
          SB.Send(edtUretimEmriNo.Text, ((ValueDisplay)cbeAliciFirma.SelectedItem).Value);          
        }
        catch (Exception ex)
        {
          MessageBox.Show("Satış bildirimi yapılamadı! Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

          if (lITS.Transaction != null) lITS.Transaction.Rollback();
          throw;
        }
        finally
        {
          Cursor = Cursors.Default;
          SplashScreenManager.CloseForm();
        }
      }
    }

    private void btnBildirimiZamanla_Click(object sender, EventArgs e)
    {
      using (BildirimZamanlama frmBildirimZamanlama = new BildirimZamanlama())
      {
        switch (frmBildirimZamanlama.ShowDialog())
        {
          case DialogResult.OK:
            using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
            {
              try
              {
                lITS.Scheduled_Declaration_Insert(edtUretimEmriNo.Text,
                                                  'G',
                                                  frmBildirimZamanlama.dteBildirimZamani.DateTime,
                                                  Global.UsrId,
                                                  ((ValueDisplay)cbeSaticiFirma.SelectedItem).Value,
                                                  ((ValueDisplay)cbeAliciFirma.SelectedItem).Value);
              }
              catch (Exception ex)
              {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
            }
            break;

          case DialogResult.Abort:
            using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
            {
              try
              {
                lITS.Scheduled_Declaration_Delete(edtUretimEmriNo.Text, 'G');
              }
              catch (Exception ex)
              {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
            }
            break;
        }    
      }
    }
  }
}
