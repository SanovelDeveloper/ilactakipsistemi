namespace ITS
{
  partial class SatisVerisiOlusturma
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
      this.bedVeriDosyasi = new DevExpress.XtraEditors.ButtonEdit();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.edtFaturaNumarasi = new DevExpress.XtraEditors.TextEdit();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.btnVeriyiKaydet = new DevExpress.XtraEditors.SimpleButton();
      this.lblSonuc = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.bedVeriDosyasi.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtFaturaNumarasi.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // bedVeriDosyasi
      // 
      this.bedVeriDosyasi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.bedVeriDosyasi.Location = new System.Drawing.Point(103, 8);
      this.bedVeriDosyasi.Name = "bedVeriDosyasi";
      this.bedVeriDosyasi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.bedVeriDosyasi.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_Properties_ButtonClick);
      this.bedVeriDosyasi.Size = new System.Drawing.Size(480, 20);
      this.bedVeriDosyasi.TabIndex = 0;
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(13, 38);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(79, 13);
      this.labelControl1.TabIndex = 1;
      this.labelControl1.Text = "Fatura Numarası";
      // 
      // labelControl2
      // 
      this.labelControl2.Location = new System.Drawing.Point(13, 11);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(58, 13);
      this.labelControl2.TabIndex = 2;
      this.labelControl2.Text = "Veri Dosyası";
      // 
      // edtFaturaNumarasi
      // 
      this.edtFaturaNumarasi.Location = new System.Drawing.Point(103, 34);
      this.edtFaturaNumarasi.Name = "edtFaturaNumarasi";
      this.edtFaturaNumarasi.Size = new System.Drawing.Size(100, 20);
      this.edtFaturaNumarasi.TabIndex = 3;
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.DefaultExt = "*.xlsx";
      this.openFileDialog1.Filter = "*.xlsx|*.xlsx|*.xls|*.xls";
      // 
      // btnVeriyiKaydet
      // 
      this.btnVeriyiKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnVeriyiKaydet.Location = new System.Drawing.Point(508, 33);
      this.btnVeriyiKaydet.Name = "btnVeriyiKaydet";
      this.btnVeriyiKaydet.Size = new System.Drawing.Size(75, 23);
      this.btnVeriyiKaydet.TabIndex = 4;
      this.btnVeriyiKaydet.Text = "Veriyi Kaydet";
      this.btnVeriyiKaydet.Click += new System.EventHandler(this.btnVeriyiKaydet_Click);
      // 
      // lblSonuc
      // 
      this.lblSonuc.Location = new System.Drawing.Point(111, 72);
      this.lblSonuc.Name = "lblSonuc";
      this.lblSonuc.Size = new System.Drawing.Size(0, 13);
      this.lblSonuc.TabIndex = 5;
      // 
      // SatisVerisiOlusturma
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(595, 64);
      this.Controls.Add(this.lblSonuc);
      this.Controls.Add(this.btnVeriyiKaydet);
      this.Controls.Add(this.edtFaturaNumarasi);
      this.Controls.Add(this.labelControl2);
      this.Controls.Add(this.labelControl1);
      this.Controls.Add(this.bedVeriDosyasi);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SatisVerisiOlusturma";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Satış Verisi Oluşturma";
      ((System.ComponentModel.ISupportInitialize)(this.bedVeriDosyasi.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtFaturaNumarasi.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.ButtonEdit bedVeriDosyasi;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.TextEdit edtFaturaNumarasi;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private DevExpress.XtraEditors.SimpleButton btnVeriyiKaydet;
    private DevExpress.XtraEditors.LabelControl lblSonuc;
  }
}