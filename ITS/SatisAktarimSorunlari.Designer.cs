namespace ITS
{
  partial class SatisAktarimSorunlari
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
        this.cbxAktarimYeri = new DevExpress.XtraEditors.ComboBoxEdit();
        this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
        this.btnKontrolEt = new DevExpress.XtraEditors.SimpleButton();
        this.memSonuclar = new DevExpress.XtraEditors.MemoEdit();
        this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
        this.edtBelgeNumarasi = new DevExpress.XtraEditors.TextEdit();
        ((System.ComponentModel.ISupportInitialize)(this.cbxAktarimYeri.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.memSonuclar.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.edtBelgeNumarasi.Properties)).BeginInit();
        this.SuspendLayout();
        // 
        // cbxAktarimYeri
        // 
        this.cbxAktarimYeri.Location = new System.Drawing.Point(291, 15);
        this.cbxAktarimYeri.Name = "cbxAktarimYeri";
        this.cbxAktarimYeri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.cbxAktarimYeri.Properties.Items.AddRange(new object[] {
            "TTS",
            "AGE"});
        this.cbxAktarimYeri.Size = new System.Drawing.Size(100, 20);
        this.cbxAktarimYeri.TabIndex = 0;
        // 
        // labelControl1
        // 
        this.labelControl1.Location = new System.Drawing.Point(228, 18);
        this.labelControl1.Name = "labelControl1";
        this.labelControl1.Size = new System.Drawing.Size(57, 13);
        this.labelControl1.TabIndex = 1;
        this.labelControl1.Text = "Aktarım Yeri";
        // 
        // btnKontrolEt
        // 
        this.btnKontrolEt.Location = new System.Drawing.Point(397, 13);
        this.btnKontrolEt.Name = "btnKontrolEt";
        this.btnKontrolEt.Size = new System.Drawing.Size(120, 23);
        this.btnKontrolEt.TabIndex = 2;
        this.btnKontrolEt.Text = "Kontrol Et";
        this.btnKontrolEt.Click += new System.EventHandler(this.btnKontrolEt_Click);
        // 
        // memSonuclar
        // 
        this.memSonuclar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.memSonuclar.Location = new System.Drawing.Point(13, 47);
        this.memSonuclar.Name = "memSonuclar";
        this.memSonuclar.Size = new System.Drawing.Size(661, 254);
        this.memSonuclar.TabIndex = 3;
        // 
        // labelControl2
        // 
        this.labelControl2.Location = new System.Drawing.Point(12, 18);
        this.labelControl2.Name = "labelControl2";
        this.labelControl2.Size = new System.Drawing.Size(99, 13);
        this.labelControl2.TabIndex = 4;
        this.labelControl2.Text = "Satış Belge Numarası";
        // 
        // edtBelgeNumarasi
        // 
        this.edtBelgeNumarasi.Location = new System.Drawing.Point(117, 15);
        this.edtBelgeNumarasi.Name = "edtBelgeNumarasi";
        this.edtBelgeNumarasi.Size = new System.Drawing.Size(100, 20);
        this.edtBelgeNumarasi.TabIndex = 5;
        // 
        // SatisAktarimSorunlari
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(686, 313);
        this.Controls.Add(this.edtBelgeNumarasi);
        this.Controls.Add(this.labelControl2);
        this.Controls.Add(this.memSonuclar);
        this.Controls.Add(this.btnKontrolEt);
        this.Controls.Add(this.labelControl1);
        this.Controls.Add(this.cbxAktarimYeri);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "SatisAktarimSorunlari";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Satış Aktarım Sorunları";
        ((System.ComponentModel.ISupportInitialize)(this.cbxAktarimYeri.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.memSonuclar.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.edtBelgeNumarasi.Properties)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.ComboBoxEdit cbxAktarimYeri;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.SimpleButton btnKontrolEt;
    private DevExpress.XtraEditors.MemoEdit memSonuclar;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    public DevExpress.XtraEditors.TextEdit edtBelgeNumarasi;
  }
}