namespace ITS
{
  partial class AmbalajGecerlilikDurumuDegistir
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
      this.grpGecerlilikDurumunuDegistir = new DevExpress.XtraEditors.GroupControl();
      this.cbeGecerlilikDurumu = new DevExpress.XtraEditors.ComboBoxEdit();
      this.lblGecerlilikDurumu = new DevExpress.XtraEditors.LabelControl();
      this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
      this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.grpGecerlilikDurumunuDegistir)).BeginInit();
      this.grpGecerlilikDurumunuDegistir.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cbeGecerlilikDurumu.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // grpGecerlilikDurumunuDegistir
      // 
      this.grpGecerlilikDurumunuDegistir.Controls.Add(this.btnIptal);
      this.grpGecerlilikDurumunuDegistir.Controls.Add(this.btnTamam);
      this.grpGecerlilikDurumunuDegistir.Controls.Add(this.cbeGecerlilikDurumu);
      this.grpGecerlilikDurumunuDegistir.Controls.Add(this.lblGecerlilikDurumu);
      this.grpGecerlilikDurumunuDegistir.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grpGecerlilikDurumunuDegistir.Location = new System.Drawing.Point(0, 0);
      this.grpGecerlilikDurumunuDegistir.Name = "grpGecerlilikDurumunuDegistir";
      this.grpGecerlilikDurumunuDegistir.Size = new System.Drawing.Size(297, 108);
      this.grpGecerlilikDurumunuDegistir.TabIndex = 0;
      this.grpGecerlilikDurumunuDegistir.Text = "Geçerlilik Durumunu Değiştir";
      // 
      // cbeGecerlilikDurumu
      // 
      this.cbeGecerlilikDurumu.Location = new System.Drawing.Point(124, 35);
      this.cbeGecerlilikDurumu.Name = "cbeGecerlilikDurumu";
      this.cbeGecerlilikDurumu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cbeGecerlilikDurumu.Size = new System.Drawing.Size(162, 20);
      this.cbeGecerlilikDurumu.TabIndex = 5;
      // 
      // lblGecerlilikDurumu
      // 
      this.lblGecerlilikDurumu.Location = new System.Drawing.Point(12, 38);
      this.lblGecerlilikDurumu.Name = "lblGecerlilikDurumu";
      this.lblGecerlilikDurumu.Size = new System.Drawing.Size(104, 13);
      this.lblGecerlilikDurumu.TabIndex = 4;
      this.lblGecerlilikDurumu.Text = "Yeni Geçerlilik Durumu";
      // 
      // btnTamam
      // 
      this.btnTamam.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnTamam.Location = new System.Drawing.Point(124, 73);
      this.btnTamam.Name = "btnTamam";
      this.btnTamam.Size = new System.Drawing.Size(75, 23);
      this.btnTamam.TabIndex = 6;
      this.btnTamam.Text = "Tamam";
      // 
      // btnIptal
      // 
      this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnIptal.Location = new System.Drawing.Point(210, 73);
      this.btnIptal.Name = "btnIptal";
      this.btnIptal.Size = new System.Drawing.Size(75, 23);
      this.btnIptal.TabIndex = 7;
      this.btnIptal.Text = "İptal";
      // 
      // AmbalajGecerlilikDurumuDegistir
      // 
      this.AcceptButton = this.btnTamam;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnIptal;
      this.ClientSize = new System.Drawing.Size(297, 108);
      this.Controls.Add(this.grpGecerlilikDurumunuDegistir);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "AmbalajGecerlilikDurumuDegistir";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Geçerlilik Durumunu Değiştir";
      ((System.ComponentModel.ISupportInitialize)(this.grpGecerlilikDurumunuDegistir)).EndInit();
      this.grpGecerlilikDurumunuDegistir.ResumeLayout(false);
      this.grpGecerlilikDurumunuDegistir.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cbeGecerlilikDurumu.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.GroupControl grpGecerlilikDurumunuDegistir;
    private DevExpress.XtraEditors.SimpleButton btnIptal;
    private DevExpress.XtraEditors.SimpleButton btnTamam;
    private DevExpress.XtraEditors.LabelControl lblGecerlilikDurumu;
    public DevExpress.XtraEditors.ComboBoxEdit cbeGecerlilikDurumu;
  }
}