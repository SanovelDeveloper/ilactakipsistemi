namespace ITS
{
  partial class GrupIciSatisAlisIslemleri
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ITS.SplashScreen1), false, false);
      this.lblAlici = new System.Windows.Forms.Label();
      this.cbeAliciFirma = new DevExpress.XtraEditors.ComboBoxEdit();
      this.lblSatici = new System.Windows.Forms.Label();
      this.cbeSaticiFirma = new DevExpress.XtraEditors.ComboBoxEdit();
      this.label1 = new System.Windows.Forms.Label();
      this.edtUretimEmriNo = new DevExpress.XtraEditors.TextEdit();
      this.btnBildirimleriYap = new DevExpress.XtraEditors.SimpleButton();
      this.btnBildirimiZamanla = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.cbeAliciFirma.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cbeSaticiFirma.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtUretimEmriNo.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // lblAlici
      // 
      this.lblAlici.AutoSize = true;
      this.lblAlici.Font = new System.Drawing.Font("Tahoma", 8.25F);
      this.lblAlici.Location = new System.Drawing.Point(18, 52);
      this.lblAlici.Name = "lblAlici";
      this.lblAlici.Size = new System.Drawing.Size(54, 13);
      this.lblAlici.TabIndex = 34;
      this.lblAlici.Text = "Alıcı Firma";
      // 
      // cbeAliciFirma
      // 
      this.cbeAliciFirma.Location = new System.Drawing.Point(119, 48);
      this.cbeAliciFirma.Name = "cbeAliciFirma";
      this.cbeAliciFirma.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.cbeAliciFirma.Properties.Appearance.Options.UseFont = true;
      this.cbeAliciFirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cbeAliciFirma.Size = new System.Drawing.Size(411, 20);
      this.cbeAliciFirma.TabIndex = 33;
      // 
      // lblSatici
      // 
      this.lblSatici.AutoSize = true;
      this.lblSatici.Font = new System.Drawing.Font("Tahoma", 8.25F);
      this.lblSatici.Location = new System.Drawing.Point(18, 26);
      this.lblSatici.Name = "lblSatici";
      this.lblSatici.Size = new System.Drawing.Size(61, 13);
      this.lblSatici.TabIndex = 32;
      this.lblSatici.Text = "Satıcı Firma";
      // 
      // cbeSaticiFirma
      // 
      this.cbeSaticiFirma.Location = new System.Drawing.Point(119, 22);
      this.cbeSaticiFirma.Name = "cbeSaticiFirma";
      this.cbeSaticiFirma.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.cbeSaticiFirma.Properties.Appearance.Options.UseFont = true;
      this.cbeSaticiFirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cbeSaticiFirma.Size = new System.Drawing.Size(411, 20);
      this.cbeSaticiFirma.TabIndex = 31;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
      this.label1.Location = new System.Drawing.Point(18, 88);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(77, 13);
      this.label1.TabIndex = 30;
      this.label1.Text = "Üretim Emri No";
      // 
      // edtUretimEmriNo
      // 
      this.edtUretimEmriNo.Location = new System.Drawing.Point(119, 84);
      this.edtUretimEmriNo.Name = "edtUretimEmriNo";
      this.edtUretimEmriNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
      this.edtUretimEmriNo.Properties.Appearance.Options.UseFont = true;
      this.edtUretimEmriNo.Properties.MaxLength = 20;
      this.edtUretimEmriNo.Size = new System.Drawing.Size(139, 20);
      this.edtUretimEmriNo.TabIndex = 29;
      // 
      // btnBildirimleriYap
      // 
      this.btnBildirimleriYap.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnBildirimleriYap.Location = new System.Drawing.Point(345, 74);
      this.btnBildirimleriYap.Name = "btnBildirimleriYap";
      this.btnBildirimleriYap.Size = new System.Drawing.Size(185, 22);
      this.btnBildirimleriYap.TabIndex = 28;
      this.btnBildirimleriYap.Text = "Bildirimleri Şimdi Yap";
      this.btnBildirimleriYap.Click += new System.EventHandler(this.btnBildirimleriYap_Click);
      // 
      // btnBildirimiZamanla
      // 
      this.btnBildirimiZamanla.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnBildirimiZamanla.Location = new System.Drawing.Point(345, 102);
      this.btnBildirimiZamanla.Name = "btnBildirimiZamanla";
      this.btnBildirimiZamanla.Size = new System.Drawing.Size(185, 22);
      this.btnBildirimiZamanla.TabIndex = 35;
      this.btnBildirimiZamanla.Text = "Bildirimler Zamanla";
      this.btnBildirimiZamanla.Click += new System.EventHandler(this.btnBildirimiZamanla_Click);
      // 
      // GrupIciSatisAlisIslemleri
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(554, 131);
      this.Controls.Add(this.btnBildirimiZamanla);
      this.Controls.Add(this.lblAlici);
      this.Controls.Add(this.cbeAliciFirma);
      this.Controls.Add(this.lblSatici);
      this.Controls.Add(this.cbeSaticiFirma);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.edtUretimEmriNo);
      this.Controls.Add(this.btnBildirimleriYap);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "GrupIciSatisAlisIslemleri";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Grup İçi  Satış/Alış İşlemleri";
      this.Load += new System.EventHandler(this.GrupIciSatisAlisIslemleri_Load);
      ((System.ComponentModel.ISupportInitialize)(this.cbeAliciFirma.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cbeSaticiFirma.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtUretimEmriNo.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblAlici;
    private DevExpress.XtraEditors.ComboBoxEdit cbeAliciFirma;
    private System.Windows.Forms.Label lblSatici;
    private DevExpress.XtraEditors.ComboBoxEdit cbeSaticiFirma;
    private System.Windows.Forms.Label label1;
    private DevExpress.XtraEditors.TextEdit edtUretimEmriNo;
    private DevExpress.XtraEditors.SimpleButton btnBildirimleriYap;
    private DevExpress.XtraEditors.SimpleButton btnBildirimiZamanla;
  }
}