namespace ITS
{
  partial class SplashScreen1
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen1));
      this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.lblSurum = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // marqueeProgressBarControl1
      // 
      this.marqueeProgressBarControl1.EditValue = 0;
      this.marqueeProgressBarControl1.Location = new System.Drawing.Point(23, 78);
      this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
      this.marqueeProgressBarControl1.Size = new System.Drawing.Size(404, 12);
      this.marqueeProgressBarControl1.TabIndex = 5;
      // 
      // labelControl2
      // 
      this.labelControl2.Location = new System.Drawing.Point(23, 95);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(63, 13);
      this.labelControl2.TabIndex = 7;
      this.labelControl2.Text = "Baþlatýlýyor...";
      // 
      // pictureEdit1
      // 
      //this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
      //this.pictureEdit1.Location = new System.Drawing.Point(300, 27);
      //this.pictureEdit1.Name = "pictureEdit1";
      //this.pictureEdit1.Properties.AllowFocused = false;
      //this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
      //this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
      //this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      //this.pictureEdit1.Properties.ShowMenu = false;
      //this.pictureEdit1.Properties.ZoomPercent = 13;
      //this.pictureEdit1.Size = new System.Drawing.Size(129, 34);
      //this.pictureEdit1.TabIndex = 8;
      // 
      // labelControl3
      // 
      this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.labelControl3.Location = new System.Drawing.Point(23, 21);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(240, 18);
      this.labelControl3.TabIndex = 9;
      this.labelControl3.Text = "Ýlaç Takip Sistemi Bildirim Uygulamasý";
      // 
      // lblSurum
      // 
      this.lblSurum.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.lblSurum.Location = new System.Drawing.Point(23, 48);
      this.lblSurum.Name = "lblSurum";
      this.lblSurum.Size = new System.Drawing.Size(59, 13);
      this.lblSurum.TabIndex = 10;
      this.lblSurum.Text = "Sürüm 1.0.0";
      // 
      // SplashScreen1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(450, 126);
      this.Controls.Add(this.lblSurum);
      this.Controls.Add(this.labelControl3);
      this.Controls.Add(this.pictureEdit1);
      this.Controls.Add(this.labelControl2);
      this.Controls.Add(this.marqueeProgressBarControl1);
      this.Name = "SplashScreen1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl lblSurum;
  }
}
