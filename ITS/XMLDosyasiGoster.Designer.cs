namespace ITS
{
  partial class XMLDosyasiGoster
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
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.bedXMLDosyasi = new DevExpress.XtraEditors.ButtonEdit();
      this.lblDosya = new DevExpress.XtraEditors.LabelControl();
      this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.webXML = new System.Windows.Forms.WebBrowser();
      this.ofdXML = new System.Windows.Forms.OpenFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bedXMLDosyasi.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.lblDosya);
      this.panelControl1.Controls.Add(this.bedXMLDosyasi);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(770, 43);
      this.panelControl1.TabIndex = 2;
      // 
      // bedXMLDosyasi
      // 
      this.bedXMLDosyasi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.bedXMLDosyasi.Location = new System.Drawing.Point(48, 12);
      this.bedXMLDosyasi.Name = "bedXMLDosyasi";
      this.bedXMLDosyasi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.bedXMLDosyasi.Size = new System.Drawing.Size(711, 20);
      this.bedXMLDosyasi.TabIndex = 2;
      this.bedXMLDosyasi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bedXMLDosyasi_ButtonClick);
      // 
      // lblDosya
      // 
      this.lblDosya.Location = new System.Drawing.Point(12, 15);
      this.lblDosya.Name = "lblDosya";
      this.lblDosya.Size = new System.Drawing.Size(30, 13);
      this.lblDosya.TabIndex = 3;
      this.lblDosya.Text = "Dosya";
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.webXML);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl2.Location = new System.Drawing.Point(0, 43);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(770, 478);
      this.panelControl2.TabIndex = 3;
      // 
      // webXML
      // 
      this.webXML.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webXML.Location = new System.Drawing.Point(2, 2);
      this.webXML.MinimumSize = new System.Drawing.Size(20, 20);
      this.webXML.Name = "webXML";
      this.webXML.Size = new System.Drawing.Size(766, 474);
      this.webXML.TabIndex = 1;
      // 
      // ofdXML
      // 
      this.ofdXML.Filter = "XML Dosyası (*.xml)|*.xml";
      this.ofdXML.RestoreDirectory = true;
      // 
      // XMLDosyasiGoster
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(770, 521);
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl1);
      this.MinimizeBox = false;
      this.Name = "XMLDosyasiGoster";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "XML Dosyası";
      this.Load += new System.EventHandler(this.XMLDosyasiGoster_Load);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.panelControl1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bedXMLDosyasi.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.LabelControl lblDosya;
    private DevExpress.XtraEditors.ButtonEdit bedXMLDosyasi;
    private DevExpress.XtraEditors.PanelControl panelControl2;
    private System.Windows.Forms.WebBrowser webXML;
    private System.Windows.Forms.OpenFileDialog ofdXML;
  }
}