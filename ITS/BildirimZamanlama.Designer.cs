namespace ITS
{
  partial class BildirimZamanlama
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
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.dteBildirimZamani = new DevExpress.XtraEditors.DateEdit();
      this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
      this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
      this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
      this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.dteBildirimZamani.Properties.VistaTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteBildirimZamani.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.labelControl1.Appearance.Options.UseFont = true;
      this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
      this.labelControl1.Location = new System.Drawing.Point(12, 12);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(334, 32);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "Lütfen seçtiğiniz bildirimlerin yapılmasını istediğiniz zamanı girin";
      // 
      // dteBildirimZamani
      // 
      this.dteBildirimZamani.EditValue = null;
      this.dteBildirimZamani.Location = new System.Drawing.Point(70, 50);
      this.dteBildirimZamani.Name = "dteBildirimZamani";
      this.dteBildirimZamani.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.dteBildirimZamani.Properties.DisplayFormat.FormatString = "g";
      this.dteBildirimZamani.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.dteBildirimZamani.Properties.EditFormat.FormatString = "g";
      this.dteBildirimZamani.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
      this.dteBildirimZamani.Properties.Mask.EditMask = "g";
      this.dteBildirimZamani.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.dteBildirimZamani.Size = new System.Drawing.Size(218, 20);
      this.dteBildirimZamani.TabIndex = 1;
      // 
      // shapeContainer1
      // 
      this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
      this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
      this.shapeContainer1.Name = "shapeContainer1";
      this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
      this.shapeContainer1.Size = new System.Drawing.Size(358, 129);
      this.shapeContainer1.TabIndex = 2;
      this.shapeContainer1.TabStop = false;
      // 
      // lineShape1
      // 
      this.lineShape1.Name = "lineShape1";
      this.lineShape1.X1 = 13;
      this.lineShape1.X2 = 345;
      this.lineShape1.Y1 = 84;
      this.lineShape1.Y2 = 84;
      // 
      // btnIptal
      // 
      this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnIptal.Location = new System.Drawing.Point(271, 99);
      this.btnIptal.Name = "btnIptal";
      this.btnIptal.Size = new System.Drawing.Size(75, 23);
      this.btnIptal.TabIndex = 3;
      this.btnIptal.Text = "İptal";
      // 
      // btnKaydet
      // 
      this.btnKaydet.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnKaydet.Location = new System.Drawing.Point(13, 99);
      this.btnKaydet.Name = "btnKaydet";
      this.btnKaydet.Size = new System.Drawing.Size(123, 23);
      this.btnKaydet.TabIndex = 4;
      this.btnKaydet.Text = "Zamanlamayı Kaydet";
      this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
      // 
      // simpleButton1
      // 
      this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Abort;
      this.simpleButton1.Location = new System.Drawing.Point(142, 99);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(123, 23);
      this.simpleButton1.TabIndex = 5;
      this.simpleButton1.Tag = "btnZamanlamayiSil";
      this.simpleButton1.Text = "Zamanlamayı Sil";
      // 
      // BildirimZamanlama
      // 
      this.AcceptButton = this.btnKaydet;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnIptal;
      this.ClientSize = new System.Drawing.Size(358, 129);
      this.Controls.Add(this.simpleButton1);
      this.Controls.Add(this.btnKaydet);
      this.Controls.Add(this.btnIptal);
      this.Controls.Add(this.dteBildirimZamani);
      this.Controls.Add(this.labelControl1);
      this.Controls.Add(this.shapeContainer1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "BildirimZamanlama";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Bildirim Zamanlama";
      ((System.ComponentModel.ISupportInitialize)(this.dteBildirimZamani.Properties.VistaTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dteBildirimZamani.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.LabelControl labelControl1;
    private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
    private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
    private DevExpress.XtraEditors.SimpleButton btnIptal;
    private DevExpress.XtraEditors.SimpleButton btnKaydet;
    public DevExpress.XtraEditors.DateEdit dteBildirimZamani;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;

  }
}