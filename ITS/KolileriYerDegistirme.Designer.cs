namespace ITS
{
  partial class KolileriYerDegistirme
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
      this.lblUrunDogrulamaBarkod = new DevExpress.XtraEditors.LabelControl();
      this.edtKontrolBarkod = new DevExpress.XtraEditors.TextEdit();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.edtKontrolBarkod.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // lblUrunDogrulamaBarkod
      // 
      this.lblUrunDogrulamaBarkod.Location = new System.Drawing.Point(20, 15);
      this.lblUrunDogrulamaBarkod.Name = "lblUrunDogrulamaBarkod";
      this.lblUrunDogrulamaBarkod.Size = new System.Drawing.Size(58, 13);
      this.lblUrunDogrulamaBarkod.TabIndex = 15;
      this.lblUrunDogrulamaBarkod.Text = "Koli Barkodu";
      // 
      // edtKontrolBarkod
      // 
      this.edtKontrolBarkod.Location = new System.Drawing.Point(84, 12);
      this.edtKontrolBarkod.Name = "edtKontrolBarkod";
      this.edtKontrolBarkod.Size = new System.Drawing.Size(662, 20);
      this.edtKontrolBarkod.TabIndex = 14;
      this.edtKontrolBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtKontrolBarkod_KeyDown);
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
      this.labelControl2.Location = new System.Drawing.Point(20, 43);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(0, 19);
      this.labelControl2.TabIndex = 18;
      // 
      // KolileriYerDegistirme
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(758, 77);
      this.Controls.Add(this.labelControl2);
      this.Controls.Add(this.lblUrunDogrulamaBarkod);
      this.Controls.Add(this.edtKontrolBarkod);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "KolileriYerDegistirme";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Kolileri Yer Değiştirme";
      this.Load += new System.EventHandler(this.KolileriYerDegistirme_Load);
      ((System.ComponentModel.ISupportInitialize)(this.edtKontrolBarkod.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.LabelControl lblUrunDogrulamaBarkod;
    private DevExpress.XtraEditors.TextEdit edtKontrolBarkod;
    private DevExpress.XtraEditors.LabelControl labelControl2;
  }
}