namespace ITS_Guncelleme
{
  partial class Main
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      this.btnDurdur = new DevExpress.XtraEditors.SimpleButton();
      this.pbcIndiriliyor = new DevExpress.XtraEditors.ProgressBarControl();
      ((System.ComponentModel.ISupportInitialize)(this.pbcIndiriliyor.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // btnDurdur
      // 
      this.btnDurdur.Location = new System.Drawing.Point(333, 47);
      this.btnDurdur.Name = "btnDurdur";
      this.btnDurdur.Size = new System.Drawing.Size(75, 23);
      this.btnDurdur.TabIndex = 6;
      this.btnDurdur.Text = "Durdur";
      this.btnDurdur.Click += new System.EventHandler(this.btnDurdur_Click);
      // 
      // pbcIndiriliyor
      // 
      this.pbcIndiriliyor.Location = new System.Drawing.Point(12, 12);
      this.pbcIndiriliyor.Name = "pbcIndiriliyor";
      this.pbcIndiriliyor.Properties.ShowTitle = true;
      this.pbcIndiriliyor.Size = new System.Drawing.Size(719, 29);
      this.pbcIndiriliyor.TabIndex = 7;
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(743, 77);
      this.Controls.Add(this.pbcIndiriliyor);
      this.Controls.Add(this.btnDurdur);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Main";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "İTS Uygulaması Güncelleme Modülü";
      this.Load += new System.EventHandler(this.Main_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pbcIndiriliyor.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton btnDurdur;
    private DevExpress.XtraEditors.ProgressBarControl pbcIndiriliyor;

  }
}

