/*******************************************************************************/
/*  Copyright (c) 2009 SANOVEL A.Ş.  / bilsis@sanovel.com.tr                   */
/*  All rights reserved.                                                       */
/*                                                                             */
/*  Tanım    : İTS uygulamasının ambalaj detayı ekleme ekranıdır.              */
/*  Amaç     : İTS uygulaması üzerinde seçilen bir üretim emri içersine        */
/*             TTS tarafından eklenmemiş ambalajların eklenmesi.               */
/*  Kısıtlar :  -                                                              */
/*                                                                             */
/*  Düzenleme Tarihçesi:                                                       */
/*  Versiyon  Tarih       Kişi     Açıklama                                    */
/*    1.0     12/01/2010  AY       Başlandı.                                   */
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
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ITS
{
  public partial class AmbalajEkleme : Form
  {
    private string sBarkod = "";
    private List<string> lPackageCodes = new List<string>();
    private string sUretimEmriNo;
    
    public AmbalajEkleme(string UretimEmriNo)
    {
      sUretimEmriNo = UretimEmriNo;
      InitializeComponent();
    }

    private void AmbalajEkleme_Shown(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
      conITS.Open();
      edtAmbalajBarkodu.Enabled = false;     
      try
      {
        int k = 0;
        dgvEklenenAmbalajlar.Rows.Clear();

        SqlCommand scmData = new SqlCommand() { Connection = conITS, CommandText = "Package_List_Browse;1", CommandType = CommandType.StoredProcedure };
        scmData.Parameters.Clear();
        scmData.Parameters.Add(new SqlParameter("@order_id", edtUretimEmriNumarasi.Text));
        scmData.Parameters.Add(new SqlParameter("@rowcount", 10000));
        scmData.Parameters.Add(new SqlParameter("@usr_id", Global.UsrId));

        SqlDataReader sdrData = scmData.ExecuteReader();
        while (sdrData.Read())
        {
          object[] satir = new object[] { null, sdrData["pck_code"].ToString(), sdrData["pck_id"] };
          dgvEklenenAmbalajlar.Rows.Add(satir);
          lPackageCodes.Add(sdrData["pck_code"].ToString());
          k++;
          Application.DoEvents();
        }
        sdrData.Close();
      }
      finally
      {
        conITS.Close();
        edtAmbalajBarkodu.Enabled = true;
        edtAmbalajBarkodu.Focus();
        Cursor = Cursors.Default;
      }                          
    }

    private void AmbalajEkleme_Load(object sender, EventArgs e)
    {
      SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
      conITS.Open();
      try
      {
        dgvEklenenAmbalajlar.Rows.Clear();

        SqlCommand scmData = new SqlCommand() { Connection = conITS, CommandText = "Order_Detail", CommandType = CommandType.StoredProcedure };
        scmData.Parameters.Clear();
        scmData.Parameters.Add(new SqlParameter("@order_id", sUretimEmriNo));

        SqlDataReader sdrData = scmData.ExecuteReader();
        if (!sdrData.HasRows) throw new Exception("Kayıt bulunamadı!");

        sdrData.Read();

        edtUretimEmriNumarasi.Text = sUretimEmriNo;
        edtMalzemeKodu.Text = sdrData["mmr_item_no"].ToString();
        edtMalzemeAdi.Text = sdrData["mmr_item_name"].ToString();
        edtGTINNumarasi.Text = sdrData["mmr_gtin"].ToString();
        edtSeriTakipNo.Text = sdrData["ord_batch_no"].ToString();
        edtUretilenMiktar.Text = sdrData["total_package_quantity"].ToString();
        edtOnayliMiktar.Text = sdrData["approval_quantity"].ToString();
        
        sdrData.Close();
      } 
      catch (Exception ex) 
      {
        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      } 
      finally
      {
        conITS.Close();
      }                          
    }

    private void dgvEklenenAmbalajlar_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex == 0)
      {
        SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);          
        conITS.Open();
        try
        {
          using (SqlCommand scmData = new SqlCommand() { Connection = conITS, CommandText = "Package_List_Delete", CommandType = CommandType.StoredProcedure })
          {
            scmData.Parameters.Add(new SqlParameter("@pck_id", Convert.ToInt32(dgvEklenenAmbalajlar.Rows[e.RowIndex].Cells[2].Value)));
            scmData.Parameters.Add(new SqlParameter("@operation", "D"));
            scmData.ExecuteNonQuery();
          }
          string sAmbalajKodu = dgvEklenenAmbalajlar.Rows[e.RowIndex].Cells[1].Value.ToString();
          dgvEklenenAmbalajlar.Rows.RemoveAt(lPackageCodes.IndexOf(sAmbalajKodu));
          lPackageCodes.Remove(sAmbalajKodu);
        }
        finally
        {
          conITS.Close();
        }
      }
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
        KareKod kkBarkod = new KareKod(sBarkod, 'D');

        if (kkBarkod.GTIN != edtGTINNumarasi.Text || kkBarkod.BatchNo != edtSeriTakipNo.Text)
        {
          MessageBox.Show("Barkodu girilen kutu işlem yapılmak istenen ürüne ya da serisine ait değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          edtAmbalajBarkodu.Text = "";
          sBarkod = "";
          return;
        }

        SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
        conITS.Open();
        try
        {
          SqlCommand scmData = new SqlCommand() { Connection = conITS };

          if (lPackageCodes.IndexOf(kkBarkod.PackageCode) > -1)
          {
            if (MessageBox.Show("Ambalaj zaten eklenmiş. Silmek mi istiyorsunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
              scmData.CommandText = "Package_List_Delete";
              scmData.CommandType = CommandType.StoredProcedure;
              scmData.Parameters.Clear();
              scmData.Parameters.Add(new SqlParameter("@pck_id", (int)dgvEklenenAmbalajlar.Rows[lPackageCodes.IndexOf(kkBarkod.PackageCode)].Cells[2].Value));
              scmData.Parameters.Add(new SqlParameter("@operation", "D"));
              scmData.ExecuteNonQuery();
              dgvEklenenAmbalajlar.Rows.RemoveAt(lPackageCodes.IndexOf(kkBarkod.PackageCode));
              lPackageCodes.Remove(kkBarkod.PackageCode);
            }
          }
          else
          {
            scmData.CommandText = "Package_List_Insert";
            scmData.CommandType = CommandType.StoredProcedure;
            scmData.Parameters.Clear();
            scmData.Parameters.Add(new SqlParameter("@pck_order_id", edtUretimEmriNumarasi.Text));
            scmData.Parameters.Add(new SqlParameter("@pck_code", kkBarkod.PackageCode));
            scmData.Parameters.Add(new SqlParameter("@usr_id", Global.UsrId));
            scmData.Parameters.Add(new SqlParameter("@pck_original_order_id", edtUretimEmriNumarasi.Text));
            scmData.Parameters.Add(new SqlParameter("@pck_source", "USR"));
            scmData.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            scmData.ExecuteNonQuery();

            int iPckId = (int)scmData.Parameters["@RETURN_VALUE"].Value;
            lPackageCodes.Add(kkBarkod.PackageCode);
            object[] satir = new object[] { null, kkBarkod.PackageCode, iPckId };
            dgvEklenenAmbalajlar.Rows.Add(satir);
          }

        }
        catch (Exception Ex)
        {
          MessageBox.Show(Ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        finally
        {
          conITS.Close();
          edtAmbalajBarkodu.Text = "";
          sBarkod = "";
        }
      }
      else sBarkod += (char)e.KeyValue;
    }
  }
}
