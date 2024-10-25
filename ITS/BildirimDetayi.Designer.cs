namespace ITS
{
  partial class BildirimDetayi
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
        this.lstBildirimDetayi = new DevExpress.XtraEditors.ListBoxControl();
        ((System.ComponentModel.ISupportInitialize)(this.lstBildirimDetayi)).BeginInit();
        this.SuspendLayout();
        // 
        // lstBildirimDetayi
        // 
        this.lstBildirimDetayi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.lstBildirimDetayi.Appearance.BackColor = System.Drawing.SystemColors.Info;
        this.lstBildirimDetayi.Appearance.Options.UseBackColor = true;
        this.lstBildirimDetayi.Location = new System.Drawing.Point(12, 12);
        this.lstBildirimDetayi.Name = "lstBildirimDetayi";
        this.lstBildirimDetayi.Size = new System.Drawing.Size(769, 404);
        this.lstBildirimDetayi.TabIndex = 0;
        // 
        // BildirimDetayi
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(793, 428);
        this.Controls.Add(this.lstBildirimDetayi);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "BildirimDetayi";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "BildirimDetayi";
        ((System.ComponentModel.ISupportInitialize)(this.lstBildirimDetayi)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    public DevExpress.XtraEditors.ListBoxControl lstBildirimDetayi;

  }
}