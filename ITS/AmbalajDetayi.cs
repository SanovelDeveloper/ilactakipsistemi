/*******************************************************************************/
/*  Copyright (c) 2009 SANOVEL A.Ş.  / bilsis@sanovel.com.tr                   */
/*  All rights reserved.                                                       */
/*                                                                             */
/*  Tanım    : İTS uygulamasının ambalaj detayı ekranıdır.                     */
/*  Amaç     : İTS uygulamasında seçili olan bir üretim emrine ait ambalajların*/
/*             detaylarını göstermek                                           */
/*  Kısıtlar :  -                                                              */
/*                                                                             */
/*  Düzenleme Tarihçesi:                                                       */
/*  Versiyon  Tarih       Kişi     Açıklama                                    */
/*    1.0     11/01/2010  AY       Başlandı.                                   */
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
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ITS
{
  public partial class AmbalajDetayi : Form
  {
    public string sOrderId;
    public int iKayitSayisi;
    private int iListelenecekKayitSayisi;
    private bool bKapat = false;
    private string sBarkod = "";

    public class GecerlilikDurumuDetayi
    {
      private string sValue;
      private string sDisplayText;

      public GecerlilikDurumuDetayi(string sv, string sd)
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
        get { return sValue; }
      }
    }
        
    private void ListeyiYenile()
    {
      Cursor = Cursors.WaitCursor;
      SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
      conITS.Open();
      btnKapat.Enabled = false;
      edtListelenecekKayitAdedi.Enabled = false;
      edtAmbalajBarkodu.Enabled = false;
      edtAmbalajKodu.Enabled = false;
      cbeGecerlilikDurumu.Enabled = false;      
      try
      {
        int k = 0;
        dgvAmbalajDetayi.Rows.Clear();
        iListelenecekKayitSayisi = Convert.ToInt32(edtListelenecekKayitAdedi.Text);
        
        SqlCommand scmData = new SqlCommand();
        scmData.Connection = conITS;
        scmData.CommandText = "Package_List_Browse;1";
        scmData.CommandType = CommandType.StoredProcedure;
        scmData.Parameters.Clear();
        scmData.Parameters.Add(new SqlParameter("@order_id", sOrderId));
        scmData.Parameters.Add(new SqlParameter("@rowcount", Convert.ToInt32(edtListelenecekKayitAdedi.Text)));
        scmData.Parameters.Add(new SqlParameter("@pck_code", edtAmbalajKodu.Text));
        if (cbeGecerlilikDurumu.SelectedIndex > -1)
          scmData.Parameters.Add(new SqlParameter("@status_id", ((GecerlilikDurumuDetayi)cbeGecerlilikDurumu.SelectedItem).Value));

        SqlDataReader sdrData = scmData.ExecuteReader();
        pbcProgress.Visible = true;
        pbcProgress.Properties.Maximum = iListelenecekKayitSayisi;
        while (sdrData.Read())
        {
          if (bKapat) break;

          object[] satir = new object[] { null, null, sdrData["pck_code"].ToString(), sdrData["pst_description"].ToString(), sdrData["status"].ToString(), sdrData["pck_id"], sdrData["pck_status_id"] };

          dgvAmbalajDetayi.Rows.Add(satir);
          pbcProgress.PerformStep();
          pbcProgress.Update();
          k++;
          Application.DoEvents();
        }        
        lblKayitSayisi.Text = "Toplam kayıt sayısı: " + k.ToString();
        sdrData.Close();
        pbcProgress.Visible = false;
      }
      finally
      {
        conITS.Close();
        btnKapat.Enabled = true;
        edtListelenecekKayitAdedi.Enabled = true;
        edtAmbalajBarkodu.Enabled = true;
        edtAmbalajKodu.Enabled = true;
        cbeGecerlilikDurumu.Enabled = true;
        Cursor = Cursors.Default;
        
      }                    
    }
    
    public AmbalajDetayi(string order_id, int kayit_sayisi)
    {
      sOrderId = order_id;
      iKayitSayisi = kayit_sayisi;
      InitializeComponent();
    }

    private void btnKapat_Click(object sender, EventArgs e)
    {
      bKapat = true;
      Close();
    }

    private void AmbalajDetayi_Load(object sender, EventArgs e)
    {
      SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
      conITS.Open();
      try
      {
        SqlCommand scmData = new SqlCommand();
        scmData.Connection = conITS;
        scmData.CommandText = "SELECT pst_status_id, pst_description FROM Package_Status";
        scmData.CommandType = CommandType.Text;
        SqlDataReader sdrData = scmData.ExecuteReader();
        while (sdrData.Read())
        {
          cbeGecerlilikDurumu.Properties.Items.Add(new GecerlilikDurumuDetayi(sdrData["pst_status_id"].ToString(), sdrData["pst_description"].ToString()));
        }
        sdrData.Close();
      }
      finally
      {
        conITS.Close();
      }          
    }

    private void dgvAmbalajDetayi_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);    
      if (e.ColumnIndex == 0)
      {        
        conITS.Open();
        try
        {
          if (dgvAmbalajDetayi.Rows[e.RowIndex].Cells[6].Value.ToString() == "99") 
          {
            SqlCommand scmData = new SqlCommand();
            scmData.Connection = conITS;
            scmData.CommandText = "Package_List_Update";
            scmData.CommandType = CommandType.StoredProcedure;
            scmData.Parameters.Add(new SqlParameter("@pck_id", Convert.ToInt32(dgvAmbalajDetayi.Rows[e.RowIndex].Cells[5].Value)));
            scmData.Parameters.Add(new SqlParameter("@pck_status_id", 10));            
            scmData.ExecuteNonQuery();

            dgvAmbalajDetayi.Rows[e.RowIndex].Cells[0].Value = Properties.Resources.edit_remove;
            dgvAmbalajDetayi.Rows[e.RowIndex].Cells[6].Value = 10;
            dgvAmbalajDetayi.Rows[e.RowIndex].Cells[3].Value = "İYİ DURUMDA";          
          } 
          else 
          {          
            SqlCommand scmData = new SqlCommand();
            scmData.Connection = conITS;
            scmData.CommandText = "Package_List_Delete";
            scmData.CommandType = CommandType.StoredProcedure;
            scmData.Parameters.Add(new SqlParameter("@pck_id", Convert.ToInt32(dgvAmbalajDetayi.Rows[e.RowIndex].Cells[5].Value)));
            scmData.ExecuteNonQuery();

            dgvAmbalajDetayi.Rows[e.RowIndex].Cells[0].Value = Properties.Resources.edit_add;
            dgvAmbalajDetayi.Rows[e.RowIndex].Cells[6].Value = 99;
            dgvAmbalajDetayi.Rows[e.RowIndex].Cells[3].Value = "BİLDİRİLMEYECEK";
          }
        }
        finally
        {
          conITS.Close();
        }                  
      } else if (e.ColumnIndex == 1) {
        using (AmbalajGecerlilikDurumuDegistir frmAmbalajGecerlilikDurumuDegistir = new AmbalajGecerlilikDurumuDegistir())
        {
          for (int i = 0; i < cbeGecerlilikDurumu.Properties.Items.Count; i++)
            frmAmbalajGecerlilikDurumuDegistir.cbeGecerlilikDurumu.Properties.Items.Add(cbeGecerlilikDurumu.Properties.Items[i]);
            
          if (frmAmbalajGecerlilikDurumuDegistir.ShowDialog() == DialogResult.OK)
          {
            conITS.Open();
            try
            {
              SqlCommand scmData = new SqlCommand();
              scmData.Connection = conITS;
              scmData.CommandText = "Package_List_Update";
              scmData.CommandType = CommandType.StoredProcedure;
              scmData.Parameters.Add(new SqlParameter("@pck_id", Convert.ToInt32(dgvAmbalajDetayi.Rows[e.RowIndex].Cells[5].Value)));
              scmData.Parameters.Add(new SqlParameter("@pck_status_id", ((GecerlilikDurumuDetayi)frmAmbalajGecerlilikDurumuDegistir.cbeGecerlilikDurumu.SelectedItem).Value));
              scmData.ExecuteNonQuery();

              dgvAmbalajDetayi.Rows[e.RowIndex].Cells[6].Value = ((GecerlilikDurumuDetayi)frmAmbalajGecerlilikDurumuDegistir.cbeGecerlilikDurumu.SelectedItem).Value;
              dgvAmbalajDetayi.Rows[e.RowIndex].Cells[3].Value = ((GecerlilikDurumuDetayi)frmAmbalajGecerlilikDurumuDegistir.cbeGecerlilikDurumu.SelectedItem).ToString();
            }
            finally
            {
              conITS.Close();
            }                 
          }
        }
      }
    }

    private void AmbalajDetayi_Shown(object sender, EventArgs e)
    {
      edtAmbalajBarkodu.Focus();      
      Application.DoEvents();            
      ListeyiYenile();
    }


    private void dgvAmbalajDetayi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      if (e.ColumnIndex == 0)
      {
        if (dgvAmbalajDetayi.Rows[e.RowIndex].Cells[6].Value.ToString() == "99")
          e.Value = Properties.Resources.edit_add;
        else e.Value = Properties.Resources.edit_remove;
      }
    }

    private void edtAmbalajBarkodu_KeyDown(object sender, KeyEventArgs e)
    {

    }

    private void edtAmbalajBarkodu_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 8) 
      {
        edtAmbalajBarkodu.Text = "";
        sBarkod = "";        
      } 
      else if (e.KeyChar == 13) 
      {
        KareKod kkBarkod = new KareKod(sBarkod, 'P');
        edtAmbalajKodu.Text = kkBarkod.PackageCode;
        ListeyiYenile();
        edtAmbalajBarkodu.SelectAll();
        sBarkod = "";
      } 
      else sBarkod += e.KeyChar;

    }

    private void edtAmbalajKodu_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        ListeyiYenile();
      }
    }

    private void edtListelenecekKayitAdedi_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        ListeyiYenile();
      }
    }

    private void cbeGecerlilikDurumu_SelectedIndexChanged(object sender, EventArgs e)
    {
      ListeyiYenile();
    }

    private void btnFiltreyiTemizle_Click(object sender, EventArgs e)
    {
      edtListelenecekKayitAdedi.Text = "100";
      edtAmbalajKodu.Text = "";
      edtAmbalajBarkodu.Text = "";
      sBarkod = "";
      cbeGecerlilikDurumu.SelectedIndex = -1;
    }
  }
}
