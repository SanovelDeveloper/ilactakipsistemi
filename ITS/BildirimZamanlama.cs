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
/*    1.0     19/12/2011  AY       Başlandı.                                   */
/*                                                                             */
/*                                                                             */
/*  Açıklama ve Yorumlar:                                                      */
/*                                                                             */
/*                                                                             */
/*  Kısaltmalar:                                                               */
/*  AY : Ali YAZICI                                                            */
/*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ITS
{
  public partial class BildirimZamanlama : Form
  {
    public BildirimZamanlama()
    {
      InitializeComponent();
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      if (dteBildirimZamani.DateTime < DateTime.Now)
      {
        MessageBox.Show("Geçmişe dönük zamanlama yapamazsınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        DialogResult = DialogResult.None;
      }
    }

  }
}
