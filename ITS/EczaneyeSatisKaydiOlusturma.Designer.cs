namespace ITS
{
  partial class EczaneyeSatisKaydiOlusturma
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
      this.edtEczaneGLNNumarasi = new DevExpress.XtraEditors.TextEdit();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.edtEczaneAdi = new DevExpress.XtraEditors.TextEdit();
      this.edtBarkod = new DevExpress.XtraEditors.TextEdit();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
      this.lblSonuc = new DevExpress.XtraEditors.LabelControl();
      this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.edtEczaneGLNNumarasi.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtEczaneAdi.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtBarkod.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // edtEczaneGLNNumarasi
      // 
      this.edtEczaneGLNNumarasi.Location = new System.Drawing.Point(154, 37);
      this.edtEczaneGLNNumarasi.Name = "edtEczaneGLNNumarasi";
      this.edtEczaneGLNNumarasi.Size = new System.Drawing.Size(115, 20);
      this.edtEczaneGLNNumarasi.TabIndex = 2;
      // 
      // labelControl2
      // 
      this.labelControl2.Location = new System.Drawing.Point(11, 40);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(103, 13);
      this.labelControl2.TabIndex = 6;
      this.labelControl2.Text = "Eczane GLN Numarası";
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(11, 15);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(52, 13);
      this.labelControl1.TabIndex = 5;
      this.labelControl1.Text = "Eczane Adı";
      // 
      // edtEczaneAdi
      // 
      this.edtEczaneAdi.Location = new System.Drawing.Point(154, 11);
      this.edtEczaneAdi.Name = "edtEczaneAdi";
      this.edtEczaneAdi.Size = new System.Drawing.Size(362, 20);
      this.edtEczaneAdi.TabIndex = 1;
      // 
      // edtBarkod
      // 
      this.edtBarkod.Location = new System.Drawing.Point(154, 63);
      this.edtBarkod.Name = "edtBarkod";
      this.edtBarkod.Size = new System.Drawing.Size(362, 20);
      this.edtBarkod.TabIndex = 3;
      this.edtBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtBarkod_KeyDown);
      // 
      // labelControl3
      // 
      this.labelControl3.Location = new System.Drawing.Point(11, 67);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(137, 13);
      this.labelControl3.TabIndex = 9;
      this.labelControl3.Text = "Ambalaj Barkodu ya da Kodu";
      // 
      // btnKaydet
      // 
      this.btnKaydet.Location = new System.Drawing.Point(410, 89);
      this.btnKaydet.Name = "btnKaydet";
      this.btnKaydet.Size = new System.Drawing.Size(106, 23);
      this.btnKaydet.TabIndex = 4;
      this.btnKaydet.Text = "Satış Kaydı Oluştur";
      this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
      // 
      // lblSonuc
      // 
      this.lblSonuc.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
      this.lblSonuc.Location = new System.Drawing.Point(154, 95);
      this.lblSonuc.Name = "lblSonuc";
      this.lblSonuc.Size = new System.Drawing.Size(0, 13);
      this.lblSonuc.TabIndex = 12;
      // 
      // btnTemizle
      // 
      this.btnTemizle.Location = new System.Drawing.Point(11, 89);
      this.btnTemizle.Name = "btnTemizle";
      this.btnTemizle.Size = new System.Drawing.Size(106, 23);
      this.btnTemizle.TabIndex = 13;
      this.btnTemizle.Text = "Temizle";
      this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
      // 
      // EczaneyeSatisKaydiOlusturma
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(527, 120);
      this.Controls.Add(this.btnTemizle);
      this.Controls.Add(this.lblSonuc);
      this.Controls.Add(this.btnKaydet);
      this.Controls.Add(this.edtBarkod);
      this.Controls.Add(this.labelControl3);
      this.Controls.Add(this.edtEczaneAdi);
      this.Controls.Add(this.edtEczaneGLNNumarasi);
      this.Controls.Add(this.labelControl2);
      this.Controls.Add(this.labelControl1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "EczaneyeSatisKaydiOlusturma";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Eczaneye Satış Kaydı Oluşturma";
      ((System.ComponentModel.ISupportInitialize)(this.edtEczaneGLNNumarasi.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtEczaneAdi.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtBarkod.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.TextEdit edtEczaneGLNNumarasi;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.TextEdit edtEczaneAdi;
    private DevExpress.XtraEditors.TextEdit edtBarkod;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.SimpleButton btnKaydet;
    private DevExpress.XtraEditors.LabelControl lblSonuc;
    private DevExpress.XtraEditors.SimpleButton btnTemizle;
  }
}