/*******************************************************************************/
/*  Copyright (c) 2010 SANOVEL A.Ş.  / bilsis@sanovel.com.tr                   */
/*  All rights reserved.                                                       */
/*                                                                             */
/*  Tanım    : İTS uygulamasının üretim emri bazında TTS'de üretilen tüm       */
/*             ambalajların alınması için kullanılan ekrandır.                 */
/*  Amaç     : TTS sisteminden üretim emrine ait tüm ambalajların alınması     */
/*             üretim emri seçilebilen ve seçilen üretimlerin tüm ambalajlarını*/
/*             ITS sistemine aktaran ekrandır.                                 */
/*  Kısıtlar :  -                                                              */
/*                                                                             */
/*  Düzenleme Tarihçesi:                                                       */
/*  Versiyon  Tarih       Kişi     Açıklama                                    */
/*    1.0     25/08/2010  AY       Başlandı.                                   */
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
using LINQ;

namespace ITS
{
  public partial class TumAmbalajlariEkleme : Form
  {
    private string sUretimEmriNo;
    
    public TumAmbalajlariEkleme(string UretimEmriNo)
    {
      sUretimEmriNo = UretimEmriNo;
      InitializeComponent();
    }

    private void TumAmbalajlariEkleme_Shown(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      try
      {
        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
        {
          dgvUretimEmirleri.DataSource = lITS.Order_List_Browse_For_All_Orders(sUretimEmriNo).ToList();
        }
      }
      finally
      {
        Cursor = Cursors.Default;
      } 

      /*
      SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
      conITS.Open();      
      try
      {
        dgvUretimEmirleri.Rows.Clear();

        SqlCommand scmData = new SqlCommand();
        scmData.Connection = conITS;
        scmData.CommandText = "TTS_Production_Order_Browse;1";
        scmData.CommandType = CommandType.StoredProcedure;
        scmData.Parameters.Clear();
        scmData.Parameters.Add(new SqlParameter("@order_id", sUretimEmriNo));

        SqlDataReader sdrData = scmData.ExecuteReader();
        while (sdrData.Read())
        {
          object[] satir = new object[] { null, sdrData["order_id"].ToString(), sdrData["created_usc_count"].ToString(),
                                                sdrData["package_count"].ToString(), sdrData["diff"].ToString(), 
                                                sdrData["order_status"].ToString() };
          dgvUretimEmirleri.Rows.Add(satir);          
          Application.DoEvents();
        }
        sdrData.Close();
      }
      finally
      {
        conITS.Close();
        Cursor = Cursors.Default;
      } 
      */
    }

    private void btnOnayla_Click(object sender, EventArgs e)
    {
      string sUretimEmriNumaralari = "";
      for (int i = 0; i < dgvUretimEmirleri.Rows.Count; i++)
      {
        if (dgvUretimEmirleri.Rows[i].Cells[0].Value != null && (bool)(dgvUretimEmirleri.Rows[i].Cells[0].Value))
          sUretimEmriNumaralari += dgvUretimEmirleri.Rows[i].Cells[2].Value.ToString() + ",";       
      }

      if (sUretimEmriNumaralari == "") return;
      
      Cursor = Cursors.WaitCursor;
      btnOnayla.Enabled = false;
      try
      {
        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
        {
          lITS.Package_List_Insert_From_Not_Printed_Packages(sUretimEmriNumaralari, Global.UsrId);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("İşlem esnasında hata oluştu. Hata = " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      finally
      {
        btnOnayla.Enabled = true;
        Cursor = Cursors.Default;
      }      
      /*
      SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
      conITS.Open();

      try
      {
        SqlCommand scmData = new SqlCommand();
        scmData.CommandTimeout = 600000;
        scmData.Connection = conITS;
        scmData.CommandText = "Get_All_Data_From_TTS";
        scmData.CommandType = CommandType.StoredProcedure;
        scmData.Parameters.Clear();
        scmData.Parameters.Add(new SqlParameter("@order_ids", sUretimEmriNumaralari));
        scmData.Parameters.Add(new SqlParameter("@pck_usr_id", Global.UsrId));        
        scmData.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        MessageBox.Show("İşlem esnasında hata oluştu. Hata = " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      finally
      {
        conITS.Close();
        conITS.Dispose();

        btnOnayla.Enabled = true;
        Cursor = Cursors.Default;
      }
      */
      MessageBox.Show("Seçilen üretim emri numaralarına ait tüm ambalajlar alındı ve onaylı duruma getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);      
      DialogResult = DialogResult.OK;
    }

    private void dgvUretimEmirleri_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex == 1)
      {
        Cursor = Cursors.WaitCursor;
        try
        {
          using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
          {
            lITS.Get_All_Package_Code_From_TTS(dgvUretimEmirleri.Rows[e.RowIndex].Cells[2].Value.ToString());
            dgvUretimEmirleri.DataSource = lITS.Order_List_Browse_For_All_Orders(sUretimEmriNo).ToList();
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
          Cursor = Cursors.Default;
        }
      }
    }
  }
}
