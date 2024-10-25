/*******************************************************************************/
/*  Copyright (c) 2009 SANOVEL A.Ş.  / bilsis@sanovel.com.tr                   */
/*  All rights reserved.                                                       */
/*                                                                             */
/*  Tanım    : İTS uygulamasının giriş ekranıdır.                              */
/*  Amaç     : İTS uygulamasına giriş esnasında kullanıcı ve şifre doğrulama   */
/*  Kısıtlar :  -                                                              */
/*                                                                             */
/*  Düzenleme Tarihçesi:                                                       */
/*  Versiyon  Tarih       Kişi     Açıklama                                    */
/*    1.0     30/12/2009  AY       Başlandı.                                   */
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
using System.Net;
using System.Windows.Forms;

namespace ITS
{
  public partial class Giris : Form
  {
    public Giris()
    {
      InitializeComponent();
    }

    private void YeniSurumKontrolu()
    {
      SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
      conITS.Open();
      try
      {
        SqlCommand scmData = new SqlCommand();
        scmData.Connection = conITS;
        scmData.CommandText = "SELECT pro_value FROM Properties WHERE pro_name = 'Version'";
        scmData.CommandType = CommandType.Text;

        using (SqlDataReader sdrData = scmData.ExecuteReader())
        {
          if (!sdrData.HasRows)
            throw new Exception("Kayıt bulunamadı!");
          sdrData.Read();
          try
          {
            if (sdrData["pro_value"].ToString().CompareTo(Application.ProductVersion) > 0)
            {
              MessageBox.Show("İTS Bildirim Uygulamasının yeni bir sürümü bulundu. Uygulama otomatik olarak güncellenecek.", "İTS Yeni Sürüm Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Information);
              using (System.Diagnostics.Process Proc = new System.Diagnostics.Process())
              {
                Proc.StartInfo.FileName = "ITS_Guncelleme.exe";
                Proc.Start();
              }
            }
          }
          finally
          {
            sdrData.Close();
          }
        }

      }
      finally
      {
        conITS.Close();
      }
    }
    
    private void Giris_Load(object sender, EventArgs e)
    {    
      lblSurum.Text = "Sürüm " + Application.ProductVersion.Substring(0, Application.ProductVersion.Length-2);

      INIFile INI = new INIFile(Application.StartupPath + "\\config.ini");
      string DefaultAlias = INI.IniReadValue("StartUp", "DefaultAlias");
      string MESAlias = INI.IniReadValue("StartUp", "MESAlias");

      ITS.Properties.Settings setITS = new ITS.Properties.Settings();
      Global.ITSConnectionString = setITS.ITSConnectionString.Replace("Data Source=ITS;", String.Format("Data Source={0};", DefaultAlias));
      Global.ITSConnectionString = Global.ITSConnectionString.Replace("Workstation ID=WORKSTATION_ID", String.Format("Workstation ID={0} {1}", Global.UsrName, Dns.GetHostName()));

      Global.MESConnectionString = String.Format("Data Source={0};Initial Catalog=SECURITY;Persist Security Info=True;User ID=MES;Password=fast", MESAlias);

      Global.Environment = Convert.ToChar(INI.IniReadValue("StartUp", "Environment"));

      Functions.Global.ConnectionString = Global.ITSConnectionString;
            
      //Thread.Sleep(2000);
      YeniSurumKontrolu();      
    }

    private void edtSifre_KeyDown(object sender, KeyEventArgs e)
    {        
      if (e.KeyCode == Keys.Enter) 
        if (!e.Control && Global.Environment == 'G') {
          lblIslemOrtami.Visible = false;
          cbxIslemOrtami.Visible = false;
          btnGiris.Focus();
          this.Height = 229;      
        } else {
          cbxIslemOrtami.SelectedIndex = 1;
          lblIslemOrtami.Visible = true;
          cbxIslemOrtami.Visible = true;
          if (Global.Environment == 'T')
          {
            cbxIslemOrtami.Enabled = false;
            btnGiris.Focus();
          }
          else
            cbxIslemOrtami.Focus();
          
          this.Height = 259;          
        }
    }

    private void btnGiris_Click(object sender, EventArgs e)
    {
      if (cbxIslemOrtami.SelectedIndex == 1)
      {
        if (MessageBox.Show("Test ortamına giriş yapacaksınız. Emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
        {
          cbxIslemOrtami.SelectedIndex = 0;
          cbxIslemOrtami.Focus();
          return;
        }
      }
      
      
      int iUsrId;



      SqlConnection conMES = new SqlConnection(Global.MESConnectionString);
      conMES.Open();
      try
      {
        SqlCommand scmData = new SqlCommand() { Connection = conMES, CommandText = "User_Check;1", CommandType = CommandType.StoredProcedure };
        scmData.Parameters.Add(new SqlParameter("@usr_name", edtKullaniciAdi.Text));
        SqlDataReader sdrData = scmData.ExecuteReader();
        if (!sdrData.HasRows) 
        {
          MessageBox.Show("Kullanıcı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);          
          edtKullaniciAdi.Focus();
          edtKullaniciAdi.SelectAll();
          return;
        }
        
        sdrData.Read();
        try 
        { 
          iUsrId = Convert.ToInt32(sdrData["usr_id"]); 
          Global.SuperVisor = Convert.ToBoolean(sdrData["IsSupervisor"]);
        } 
        finally 
        { 
          sdrData.Close(); 
        }        
        
        scmData.CommandText = "User_Authentication;1";
        scmData.CommandType = CommandType.StoredProcedure;
        scmData.Parameters.Clear();
        scmData.Parameters.Add(new SqlParameter("@usr_id", iUsrId));
        scmData.Parameters.Add(new SqlParameter("@usr_password", edtSifre.Text));
        scmData.Parameters.Add(new SqlParameter("@usr_host", Dns.GetHostName().ToString()));
        scmData.Parameters.Add(new SqlParameter("@form_name", "frmLogin"));
        try {
          scmData.ExecuteNonQuery();
        } catch (Exception Ex) {
          MessageBox.Show(Ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
          edtSifre.Focus();
          edtSifre.SelectAll();
          return;
        }
        
        scmData.CommandText = "User_Entry_Failed_Update;1";
        scmData.CommandType = CommandType.StoredProcedure;
        scmData.Parameters.Clear();
        scmData.Parameters.Add(new SqlParameter("@usr_id", iUsrId));
        scmData.Parameters.Add(new SqlParameter("@usr_password_failed_count", Convert.ToInt16(0)));
        scmData.Parameters.Add(new SqlParameter("@usr_password_blocked", Convert.ToByte(0)));
        scmData.ExecuteNonQuery();
             
      }
      finally
      {
        conMES.Close();
      }          
      
      Global.UsrId = iUsrId;
      Global.UsrName = edtKullaniciAdi.Text;
      if (cbxIslemOrtami.SelectedIndex == 0) Global.Environment = 'G';
      else Global.Environment = 'T';
      
      Guvenlik.GuvenlikOku();      
      
      this.DialogResult = DialogResult.OK;
      Close();           
      
    }

    private void edtKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter) edtSifre.Focus();
    }

    private void edtKullaniciAdi_Enter(object sender, EventArgs e)
    {
      edtKullaniciAdi.SelectAll();
    }

    private void edtSifre_Enter(object sender, EventArgs e)
    {
      edtSifre.SelectAll();
    }
  }
}
