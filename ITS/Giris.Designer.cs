using System.Drawing;

namespace ITS
{
  partial class Giris
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
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
        this.grpKullaniciGirisi = new DevExpress.XtraEditors.GroupControl();
        this.cbxIslemOrtami = new DevExpress.XtraEditors.ComboBoxEdit();
        this.lblIslemOrtami = new DevExpress.XtraEditors.LabelControl();
        this.edtSifre = new DevExpress.XtraEditors.TextEdit();
        this.lblSifre = new DevExpress.XtraEditors.LabelControl();
        this.edtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
        this.lblKullaniciAdi = new DevExpress.XtraEditors.LabelControl();
        this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
        this.lblSurum = new DevExpress.XtraEditors.LabelControl();
        this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
        this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
        this.btnGiris = new DevExpress.XtraEditors.SimpleButton();
        this.ımageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
        this.btnCikis = new DevExpress.XtraEditors.SimpleButton();
        ((System.ComponentModel.ISupportInitialize)(this.grpKullaniciGirisi)).BeginInit();
        this.grpKullaniciGirisi.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.cbxIslemOrtami.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.edtSifre.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.edtKullaniciAdi.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ımageCollection1)).BeginInit();
        this.SuspendLayout();
        // 
        // grpKullaniciGirisi
        // 
        this.grpKullaniciGirisi.Controls.Add(this.cbxIslemOrtami);
        this.grpKullaniciGirisi.Controls.Add(this.lblIslemOrtami);
        this.grpKullaniciGirisi.Controls.Add(this.edtSifre);
        this.grpKullaniciGirisi.Controls.Add(this.lblSifre);
        this.grpKullaniciGirisi.Controls.Add(this.edtKullaniciAdi);
        this.grpKullaniciGirisi.Controls.Add(this.lblKullaniciAdi);
        this.grpKullaniciGirisi.Controls.Add(this.labelControl1);
        this.grpKullaniciGirisi.Controls.Add(this.lblSurum);
        this.grpKullaniciGirisi.Controls.Add(this.lblBaslik);
        this.grpKullaniciGirisi.Controls.Add(this.pictureEdit3);
        this.grpKullaniciGirisi.Controls.Add(this.btnGiris);
        this.grpKullaniciGirisi.Controls.Add(this.btnCikis);
        this.grpKullaniciGirisi.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpKullaniciGirisi.Location = new System.Drawing.Point(0, 0);
        this.grpKullaniciGirisi.Name = "grpKullaniciGirisi";
        this.grpKullaniciGirisi.Size = new System.Drawing.Size(292, 229);
        this.grpKullaniciGirisi.TabIndex = 2;
        this.grpKullaniciGirisi.Text = "Kullanıcı Girişi";
        // 
        // cbxIslemOrtami
        // 
        this.cbxIslemOrtami.EditValue = "Gerçek";
        this.cbxIslemOrtami.Location = new System.Drawing.Point(124, 177);
        this.cbxIslemOrtami.Name = "cbxIslemOrtami";
        this.cbxIslemOrtami.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
        this.cbxIslemOrtami.Properties.Items.AddRange(new object[] {
            "Gerçek",
            "Test"});
        this.cbxIslemOrtami.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        this.cbxIslemOrtami.Size = new System.Drawing.Size(100, 20);
        this.cbxIslemOrtami.TabIndex = 13;
        this.cbxIslemOrtami.Visible = false;
        // 
        // lblIslemOrtami
        // 
        this.lblIslemOrtami.Location = new System.Drawing.Point(45, 180);
        this.lblIslemOrtami.Name = "lblIslemOrtami";
        this.lblIslemOrtami.Size = new System.Drawing.Size(60, 13);
        this.lblIslemOrtami.TabIndex = 12;
        this.lblIslemOrtami.Text = "İşlem Ortamı";
        this.lblIslemOrtami.Visible = false;
        // 
        // edtSifre
        // 
        this.edtSifre.Location = new System.Drawing.Point(124, 151);
        this.edtSifre.Name = "edtSifre";
        this.edtSifre.Properties.PasswordChar = '*';
        this.edtSifre.Size = new System.Drawing.Size(100, 20);
        this.edtSifre.TabIndex = 1;
        this.edtSifre.Enter += new System.EventHandler(this.edtSifre_Enter);
        this.edtSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtSifre_KeyDown);
        // 
        // lblSifre
        // 
        this.lblSifre.Location = new System.Drawing.Point(45, 154);
        this.lblSifre.Name = "lblSifre";
        this.lblSifre.Size = new System.Drawing.Size(22, 13);
        this.lblSifre.TabIndex = 11;
        this.lblSifre.Text = "Şifre";
        // 
        // edtKullaniciAdi
        // 
        this.edtKullaniciAdi.Location = new System.Drawing.Point(124, 125);
        this.edtKullaniciAdi.Name = "edtKullaniciAdi";
        this.edtKullaniciAdi.Size = new System.Drawing.Size(100, 20);
        this.edtKullaniciAdi.TabIndex = 0;
        this.edtKullaniciAdi.Enter += new System.EventHandler(this.edtKullaniciAdi_Enter);
        this.edtKullaniciAdi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtKullaniciAdi_KeyDown);
        // 
        // lblKullaniciAdi
        // 
        this.lblKullaniciAdi.Location = new System.Drawing.Point(45, 128);
        this.lblKullaniciAdi.Name = "lblKullaniciAdi";
        this.lblKullaniciAdi.Size = new System.Drawing.Size(55, 13);
        this.lblKullaniciAdi.TabIndex = 9;
        this.lblKullaniciAdi.Text = "Kullanıcı Adı";
        // 
        // labelControl1
        // 
        this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
        this.labelControl1.Location = new System.Drawing.Point(12, 90);
        this.labelControl1.Name = "labelControl1";
        this.labelControl1.Size = new System.Drawing.Size(268, 23);
        this.labelControl1.TabIndex = 8;
        this.labelControl1.Text = "Lütfen kullanıcı adınızı ve şifrenizi girin";
        // 
        // lblSurum
        // 
        this.lblSurum.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        this.lblSurum.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
        this.lblSurum.Location = new System.Drawing.Point(66, 61);
        this.lblSurum.Name = "lblSurum";
        this.lblSurum.Size = new System.Drawing.Size(102, 23);
        this.lblSurum.TabIndex = 7;
        this.lblSurum.Text = "Sürüm 1.0.0";
        // 
        // lblBaslik
        // 
        this.lblBaslik.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
        this.lblBaslik.Location = new System.Drawing.Point(66, 34);
        this.lblBaslik.Name = "lblBaslik";
        this.lblBaslik.Size = new System.Drawing.Size(221, 23);
        this.lblBaslik.TabIndex = 6;
        this.lblBaslik.Text = "İlaç Takip Sistemi Bildirim Uygulaması";
        // 
        // pictureEdit3
        // 
        this.pictureEdit3.EditValue = global::ITS.Properties.Resources.minyon81;
        this.pictureEdit3.Location = new System.Drawing.Point(12, 1);
        this.pictureEdit3.Name = "pictureEdit3";
        this.pictureEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        this.pictureEdit3.Size = new System.Drawing.Size(49, 86);
        this.pictureEdit3.BackColor = Color.Transparent;
            this.pictureEdit3.TabIndex = 5;
        // 
        // btnGiris
        // 
        this.btnGiris.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnGiris.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        this.btnGiris.Appearance.Options.UseFont = true;
        this.btnGiris.ImageIndex = 0;
        this.btnGiris.ImageList = this.ımageCollection1;
        this.btnGiris.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
        this.btnGiris.Location = new System.Drawing.Point(12, 177);
        this.btnGiris.Name = "btnGiris";
        this.btnGiris.Size = new System.Drawing.Size(100, 40);
        this.btnGiris.TabIndex = 2;
        this.btnGiris.Text = "Giriş";
        this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
        // 
        // ımageCollection1
        // 
        //this.ımageCollection1.ImageSize = new System.Drawing.Size(22, 22);
        //this.ımageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ımageCollection1.ImageStream")));
        // 
        // btnCikis
        // 
        this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnCikis.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
        this.btnCikis.Appearance.Options.UseFont = true;
        this.btnCikis.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        //this.btnCikis.ImageIndex = 1;
        //this.btnCikis.ImageList = this.ımageCollection1;
        this.btnCikis.Location = new System.Drawing.Point(180, 177);
        this.btnCikis.Name = "btnCikis";
        this.btnCikis.Size = new System.Drawing.Size(100, 40);
        this.btnCikis.TabIndex = 3;
        this.btnCikis.Text = "Çıkış";
        // 
        // Giris
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnCikis;
        this.ClientSize = new System.Drawing.Size(292, 229);
        this.Controls.Add(this.grpKullaniciGirisi);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "Giris";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "İTS Bildirim Uygulaması Giriş";
        this.Load += new System.EventHandler(this.Giris_Load);
        ((System.ComponentModel.ISupportInitialize)(this.grpKullaniciGirisi)).EndInit();
        this.grpKullaniciGirisi.ResumeLayout(false);
        this.grpKullaniciGirisi.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.cbxIslemOrtami.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.edtSifre.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.edtKullaniciAdi.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ımageCollection1)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.GroupControl grpKullaniciGirisi;
    private DevExpress.XtraEditors.SimpleButton btnGiris;
    private DevExpress.XtraEditors.SimpleButton btnCikis;
    private DevExpress.XtraEditors.PictureEdit pictureEdit3;
    private DevExpress.XtraEditors.LabelControl lblSurum;
    private DevExpress.XtraEditors.LabelControl lblBaslik;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.Utils.ImageCollection ımageCollection1;
    private DevExpress.XtraEditors.TextEdit edtSifre;
    private DevExpress.XtraEditors.LabelControl lblSifre;
    private DevExpress.XtraEditors.TextEdit edtKullaniciAdi;
    private DevExpress.XtraEditors.LabelControl lblKullaniciAdi;
    private DevExpress.XtraEditors.LabelControl lblIslemOrtami;
    private DevExpress.XtraEditors.ComboBoxEdit cbxIslemOrtami;

  }
}