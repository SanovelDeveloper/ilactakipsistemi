using System.ComponentModel;
using System.Drawing;

namespace ITS
{
    partial class TTSdeEkstraUretimEmriOlustur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TTSdeEkstraUretimEmriOlustur));
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TTSdeEkstraUretimEmriOlustur));
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.edtUretimEmriGunSayisi = new DevExpress.XtraEditors.TextEdit();
            this.btnAGEyeGonderilebilirUretimEmirleriniGetir = new DevExpress.XtraEditors.SimpleButton();
            this.edtEkstraOlusturulacakKodAdedi = new DevExpress.XtraEditors.TextEdit();
            this.lblEkstraOlusturulacakKodAdedi = new DevExpress.XtraEditors.LabelControl();
            this.btnEkstraUretimEmriOlustur = new DevExpress.XtraEditors.SimpleButton();
            this.lblOlusturulanUretimEmriNumarasi = new DevExpress.XtraEditors.LabelControl();
            this.cbeUretimHatti = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblUretimHatti = new DevExpress.XtraEditors.LabelControl();
            this.mpbUretimEmriniGonder = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.lblUretimEmriNumarasi = new DevExpress.XtraEditors.LabelControl();
            this.edtUretimEmriNumarasi = new DevExpress.XtraEditors.TextEdit();
            this.btnUretimEmriniGetir = new DevExpress.XtraEditors.SimpleButton();
            this.cbeTTSSistemi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblTTSSistemi = new DevExpress.XtraEditors.LabelControl();
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleri = new DevExpress.XtraGrid.GridControl();
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cheKolilemeYapilacak = new DevExpress.XtraEditors.CheckEdit();
            this.lblUretimMiktari = new DevExpress.XtraEditors.LabelControl();
            this.edtUretimMiktari = new DevExpress.XtraEditors.TextEdit();
            this.cbeCaseCode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblKoliKodu = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.edtUretimEmriGunSayisi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEkstraOlusturulacakKodAdedi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeUretimHatti.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpbUretimEmriniGonder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUretimEmriNumarasi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeTTSSistemi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTTSdeEkstraOlusturulabilirUretimEmirleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheKolilemeYapilacak.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUretimMiktari.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeCaseCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl22
            // 
            this.labelControl22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl22.Location = new System.Drawing.Point(625, 18);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(32, 13);
            this.labelControl22.TabIndex = 9;
            this.labelControl22.Text = "Günlük";
            // 
            // labelControl21
            // 
            this.labelControl21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl21.Location = new System.Drawing.Point(556, 18);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(18, 13);
            this.labelControl21.TabIndex = 8;
            this.labelControl21.Text = "Son";
            // 
            // edtUretimEmriGunSayisi
            // 
            this.edtUretimEmriGunSayisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUretimEmriGunSayisi.EditValue = "7";
            this.edtUretimEmriGunSayisi.Location = new System.Drawing.Point(580, 15);
            this.edtUretimEmriGunSayisi.Name = "edtUretimEmriGunSayisi";
            this.edtUretimEmriGunSayisi.Properties.Mask.EditMask = "f0";
            this.edtUretimEmriGunSayisi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.edtUretimEmriGunSayisi.Size = new System.Drawing.Size(39, 20);
            this.edtUretimEmriGunSayisi.TabIndex = 7;
            this.edtUretimEmriGunSayisi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtUretimEmriGunSayisi_KeyDown);
            // 
            // btnAGEyeGonderilebilirUretimEmirleriniGetir
            // 
            this.btnAGEyeGonderilebilirUretimEmirleriniGetir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAGEyeGonderilebilirUretimEmirleriniGetir.Location = new System.Drawing.Point(674, 12);
            this.btnAGEyeGonderilebilirUretimEmirleriniGetir.Name = "btnAGEyeGonderilebilirUretimEmirleriniGetir";
            this.btnAGEyeGonderilebilirUretimEmirleriniGetir.Size = new System.Drawing.Size(149, 23);
            this.btnAGEyeGonderilebilirUretimEmirleriniGetir.TabIndex = 6;
            this.btnAGEyeGonderilebilirUretimEmirleriniGetir.Tag = "1";
            this.btnAGEyeGonderilebilirUretimEmirleriniGetir.Text = "Üretim Emirlerini Getir";
            this.btnAGEyeGonderilebilirUretimEmirleriniGetir.Click += new System.EventHandler(this.btnAGEyeGonderilebilirUretimEmirleriniGetir_Click);
            // 
            // edtEkstraOlusturulacakKodAdedi
            // 
            this.edtEkstraOlusturulacakKodAdedi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEkstraOlusturulacakKodAdedi.EditValue = "";
            this.edtEkstraOlusturulacakKodAdedi.Enabled = false;
            this.edtEkstraOlusturulacakKodAdedi.Location = new System.Drawing.Point(170, 477);
            this.edtEkstraOlusturulacakKodAdedi.Name = "edtEkstraOlusturulacakKodAdedi";
            this.edtEkstraOlusturulacakKodAdedi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.edtEkstraOlusturulacakKodAdedi.Properties.Appearance.Options.UseFont = true;
            this.edtEkstraOlusturulacakKodAdedi.Properties.Mask.EditMask = "f0";
            this.edtEkstraOlusturulacakKodAdedi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.edtEkstraOlusturulacakKodAdedi.Size = new System.Drawing.Size(89, 20);
            this.edtEkstraOlusturulacakKodAdedi.TabIndex = 10;
            // 
            // lblEkstraOlusturulacakKodAdedi
            // 
            this.lblEkstraOlusturulacakKodAdedi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEkstraOlusturulacakKodAdedi.Location = new System.Drawing.Point(12, 482);
            this.lblEkstraOlusturulacakKodAdedi.Name = "lblEkstraOlusturulacakKodAdedi";
            this.lblEkstraOlusturulacakKodAdedi.Size = new System.Drawing.Size(149, 13);
            this.lblEkstraOlusturulacakKodAdedi.TabIndex = 11;
            this.lblEkstraOlusturulacakKodAdedi.Text = "Ekstra Oluşturulacak Kod Adedi";
            // 
            // btnEkstraUretimEmriOlustur
            // 
            this.btnEkstraUretimEmriOlustur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEkstraUretimEmriOlustur.Enabled = false;
            this.btnEkstraUretimEmriOlustur.Location = new System.Drawing.Point(265, 476);
            this.btnEkstraUretimEmriOlustur.Name = "btnEkstraUretimEmriOlustur";
            this.btnEkstraUretimEmriOlustur.Size = new System.Drawing.Size(184, 23);
            this.btnEkstraUretimEmriOlustur.TabIndex = 12;
            this.btnEkstraUretimEmriOlustur.Tag = "1";
            this.btnEkstraUretimEmriOlustur.Text = "Ekstra Üretim Emri Oluştur";
            this.btnEkstraUretimEmriOlustur.Click += new System.EventHandler(this.btnEkstraUretimEmriOlustur_Click);
            // 
            // lblOlusturulanUretimEmriNumarasi
            // 
            this.lblOlusturulanUretimEmriNumarasi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOlusturulanUretimEmriNumarasi.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOlusturulanUretimEmriNumarasi.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblOlusturulanUretimEmriNumarasi.Location = new System.Drawing.Point(469, 470);
            this.lblOlusturulanUretimEmriNumarasi.Name = "lblOlusturulanUretimEmriNumarasi";
            this.lblOlusturulanUretimEmriNumarasi.Size = new System.Drawing.Size(0, 19);
            this.lblOlusturulanUretimEmriNumarasi.TabIndex = 13;
            // 
            // cbeUretimHatti
            // 
            this.cbeUretimHatti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbeUretimHatti.Enabled = false;
            this.cbeUretimHatti.Location = new System.Drawing.Point(170, 430);
            this.cbeUretimHatti.Name = "cbeUretimHatti";
            this.cbeUretimHatti.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbeUretimHatti.Properties.Appearance.Options.UseFont = true;
            this.cbeUretimHatti.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeUretimHatti.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbeUretimHatti.Size = new System.Drawing.Size(279, 20);
            this.cbeUretimHatti.TabIndex = 20;
            // 
            // lblUretimHatti
            // 
            this.lblUretimHatti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUretimHatti.Location = new System.Drawing.Point(12, 435);
            this.lblUretimHatti.Name = "lblUretimHatti";
            this.lblUretimHatti.Size = new System.Drawing.Size(57, 13);
            this.lblUretimHatti.TabIndex = 19;
            this.lblUretimHatti.Text = "Üretim Hattı";
            // 
            // mpbUretimEmriniGonder
            // 
            this.mpbUretimEmriniGonder.EditValue = "Gönderiliyor...";
            this.mpbUretimEmriniGonder.Location = new System.Drawing.Point(469, 411);
            this.mpbUretimEmriniGonder.Name = "mpbUretimEmriniGonder";
            this.mpbUretimEmriniGonder.Properties.ShowTitle = true;
            this.mpbUretimEmriniGonder.Size = new System.Drawing.Size(127, 88);
            this.mpbUretimEmriniGonder.TabIndex = 21;
            this.mpbUretimEmriniGonder.Visible = false;
            // 
            // lblUretimEmriNumarasi
            // 
            this.lblUretimEmriNumarasi.Location = new System.Drawing.Point(207, 18);
            this.lblUretimEmriNumarasi.Name = "lblUretimEmriNumarasi";
            this.lblUretimEmriNumarasi.Size = new System.Drawing.Size(101, 13);
            this.lblUretimEmriNumarasi.TabIndex = 23;
            this.lblUretimEmriNumarasi.Text = "Üretim Emri Numarası";
            // 
            // edtUretimEmriNumarasi
            // 
            this.edtUretimEmriNumarasi.EditValue = "";
            this.edtUretimEmriNumarasi.Location = new System.Drawing.Point(314, 15);
            this.edtUretimEmriNumarasi.Name = "edtUretimEmriNumarasi";
            this.edtUretimEmriNumarasi.Size = new System.Drawing.Size(56, 20);
            this.edtUretimEmriNumarasi.TabIndex = 1;
            this.edtUretimEmriNumarasi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtUretimEmriNumarasi_KeyDown);
            // 
            // btnUretimEmriniGetir
            // 
            this.btnUretimEmriniGetir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUretimEmriniGetir.Location = new System.Drawing.Point(389, 12);
            this.btnUretimEmriniGetir.Name = "btnUretimEmriniGetir";
            this.btnUretimEmriniGetir.Size = new System.Drawing.Size(149, 23);
            this.btnUretimEmriniGetir.TabIndex = 24;
            this.btnUretimEmriniGetir.Tag = "1";
            this.btnUretimEmriniGetir.Text = "Üretim Emrini Getir";
            this.btnUretimEmriniGetir.Click += new System.EventHandler(this.btnUretimEmriniGetir_Click);
            // 
            // cbeTTSSistemi
            // 
            this.cbeTTSSistemi.Enabled = false;
            this.cbeTTSSistemi.Location = new System.Drawing.Point(72, 15);
            this.cbeTTSSistemi.Name = "cbeTTSSistemi";
            this.cbeTTSSistemi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbeTTSSistemi.Properties.Appearance.Options.UseFont = true;
            this.cbeTTSSistemi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeTTSSistemi.Properties.Items.AddRange(new object[] {
            "1. Faz",
            "2. Faz"});
            this.cbeTTSSistemi.Size = new System.Drawing.Size(98, 20);
            this.cbeTTSSistemi.TabIndex = 26;
            this.cbeTTSSistemi.SelectedIndexChanged += new System.EventHandler(this.cbeTTSSistemi_SelectedIndexChanged);
            // 
            // lblTTSSistemi
            // 
            this.lblTTSSistemi.Location = new System.Drawing.Point(12, 18);
            this.lblTTSSistemi.Name = "lblTTSSistemi";
            this.lblTTSSistemi.Size = new System.Drawing.Size(54, 13);
            this.lblTTSSistemi.TabIndex = 25;
            this.lblTTSSistemi.Text = "TTS Sistemi";
            // 
            // grdTTSdeEkstraOlusturulabilirUretimEmirleri
            // 
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleri.Location = new System.Drawing.Point(9, 41);
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleri.MainView = this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleri.Name = "grdTTSdeEkstraOlusturulabilirUretimEmirleri";
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleri.Size = new System.Drawing.Size(814, 360);
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleri.TabIndex = 27;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView});
            // 
            // grdTTSdeEkstraOlusturulabilirUretimEmirleriView
            // 
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Empty.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.EvenRow.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.EvenRow.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.EvenRow.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FixedLine.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupButton.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupRow.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.GroupRow.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.HorzLine.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.OddRow.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.OddRow.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.OddRow.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Preview.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Preview.Options.UseFont = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Preview.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Row.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.Row.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Appearance.VertLine.Options.UseBackColor = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId,
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo,
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName,
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo,
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate,
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount});
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.GridControl = this.grdTTSdeEkstraOlusturulabilirUretimEmirleri;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.Name = "grdTTSdeEkstraOlusturulabilirUretimEmirleriView";
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.OptionsView.EnableAppearanceEvenRow = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.OptionsView.EnableAppearanceOddRow = true;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.OptionsView.ShowGroupPanel = false;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.OptionsView.ShowIndicator = false;
            this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView_FocusedRowChanged);
            // 
            // dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId
            // 
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId.Caption = "Üretim Emri No";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId.FieldName = "TB022_ORDER_ID";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId.Name = "dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId.OptionsColumn.AllowEdit = false;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId.OptionsColumn.AllowFocus = false;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId.Visible = true;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId.VisibleIndex = 0;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId.Width = 86;
            // 
            // dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo
            // 
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo.Caption = "Malzeme Kodu";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo.FieldName = "mmr_item_no";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo.Name = "dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo.OptionsColumn.AllowEdit = false;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo.OptionsColumn.AllowFocus = false;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo.Visible = true;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo.VisibleIndex = 1;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo.Width = 96;
            // 
            // dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName
            // 
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName.Caption = "Malzeme Adı";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName.FieldName = "mmr_item_name";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName.Name = "dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName.OptionsColumn.AllowEdit = false;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName.OptionsColumn.AllowFocus = false;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName.Visible = true;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName.VisibleIndex = 2;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName.Width = 335;
            // 
            // dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo
            // 
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo.Caption = "Seri Takip No";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo.FieldName = "TB022_PK_BATCH_NO";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo.Name = "dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo.OptionsColumn.AllowEdit = false;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo.OptionsColumn.AllowFocus = false;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo.Visible = true;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo.VisibleIndex = 3;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo.Width = 94;
            // 
            // dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate
            // 
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate.Caption = "Son Kullanma Tarihi";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate.FieldName = "TB022_EXPIRY_DATE";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate.Name = "dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate.OptionsColumn.AllowEdit = false;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate.OptionsColumn.AllowFocus = false;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate.Visible = true;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate.VisibleIndex = 4;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate.Width = 103;
            // 
            // dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount
            // 
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount.Caption = "Hedef Miktar";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount.FieldName = "TB022_TARGET_QTY";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount.Name = "dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount";
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount.OptionsColumn.AllowEdit = false;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount.OptionsColumn.AllowFocus = false;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount.Visible = true;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount.VisibleIndex = 5;
            this.dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount.Width = 96;
            // 
            // cheKolilemeYapilacak
            // 
            this.cheKolilemeYapilacak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cheKolilemeYapilacak.Enabled = false;
            this.cheKolilemeYapilacak.Location = new System.Drawing.Point(11, 409);
            this.cheKolilemeYapilacak.Name = "cheKolilemeYapilacak";
            this.cheKolilemeYapilacak.Properties.Caption = "Kolileme Yapılıp, SSCC Basılacak";
            this.cheKolilemeYapilacak.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cheKolilemeYapilacak.Size = new System.Drawing.Size(176, 19);
            this.cheKolilemeYapilacak.TabIndex = 28;
            // 
            // lblUretimMiktari
            // 
            this.lblUretimMiktari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUretimMiktari.Location = new System.Drawing.Point(12, 458);
            this.lblUretimMiktari.Name = "lblUretimMiktari";
            this.lblUretimMiktari.Size = new System.Drawing.Size(65, 13);
            this.lblUretimMiktari.TabIndex = 30;
            this.lblUretimMiktari.Text = "Üretim Miktarı";
            // 
            // edtUretimMiktari
            // 
            this.edtUretimMiktari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtUretimMiktari.EditValue = "";
            this.edtUretimMiktari.Enabled = false;
            this.edtUretimMiktari.Location = new System.Drawing.Point(170, 453);
            this.edtUretimMiktari.Name = "edtUretimMiktari";
            this.edtUretimMiktari.Properties.Mask.EditMask = "f0";
            this.edtUretimMiktari.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.edtUretimMiktari.Size = new System.Drawing.Size(89, 20);
            this.edtUretimMiktari.TabIndex = 29;
            this.edtUretimMiktari.EditValueChanged += new System.EventHandler(this.edtUretimMiktari_EditValueChanged);
            // 
            // cbeCaseCode
            // 
            this.cbeCaseCode.Location = new System.Drawing.Point(303, 408);
            this.cbeCaseCode.Name = "cbeCaseCode";
            this.cbeCaseCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbeCaseCode.Properties.Appearance.Options.UseFont = true;
            this.cbeCaseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeCaseCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbeCaseCode.Size = new System.Drawing.Size(146, 20);
            this.cbeCaseCode.TabIndex = 32;
            // 
            // lblKoliKodu
            // 
            this.lblKoliKodu.Location = new System.Drawing.Point(251, 411);
            this.lblKoliKodu.Name = "lblKoliKodu";
            this.lblKoliKodu.Size = new System.Drawing.Size(43, 13);
            this.lblKoliKodu.TabIndex = 31;
            this.lblKoliKodu.Text = "Koli Kodu";
            // 
            // TTSdeEkstraUretimEmriOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 505);
            this.Controls.Add(this.cbeCaseCode);
            this.Controls.Add(this.lblKoliKodu);
            this.Controls.Add(this.lblUretimMiktari);
            this.Controls.Add(this.edtUretimMiktari);
            this.Controls.Add(this.cheKolilemeYapilacak);
            this.Controls.Add(this.grdTTSdeEkstraOlusturulabilirUretimEmirleri);
            this.Controls.Add(this.cbeTTSSistemi);
            this.Controls.Add(this.lblTTSSistemi);
            this.Controls.Add(this.btnUretimEmriniGetir);
            this.Controls.Add(this.lblUretimEmriNumarasi);
            this.Controls.Add(this.edtUretimEmriNumarasi);
            this.Controls.Add(this.mpbUretimEmriniGonder);
            this.Controls.Add(this.cbeUretimHatti);
            this.Controls.Add(this.lblUretimHatti);
            this.Controls.Add(this.lblOlusturulanUretimEmriNumarasi);
            this.Controls.Add(this.btnEkstraUretimEmriOlustur);
            this.Controls.Add(this.lblEkstraOlusturulacakKodAdedi);
            this.Controls.Add(this.edtEkstraOlusturulacakKodAdedi);
            this.Controls.Add(this.labelControl22);
            this.Controls.Add(this.labelControl21);
            this.Controls.Add(this.edtUretimEmriGunSayisi);
            this.Controls.Add(this.btnAGEyeGonderilebilirUretimEmirleriniGetir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            //this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TTSdeEkstraUretimEmriOlustur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TTS Sisteminde Ekstra Üretim Emri Oluşturma";
            this.Load += new System.EventHandler(this.TTSdeEkstraUretimEmriOlustur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtUretimEmriGunSayisi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEkstraOlusturulacakKodAdedi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeUretimHatti.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mpbUretimEmriniGonder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUretimEmriNumarasi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeTTSSistemi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTTSdeEkstraOlusturulabilirUretimEmirleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTTSdeEkstraOlusturulabilirUretimEmirleriView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cheKolilemeYapilacak.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUretimMiktari.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeCaseCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.TextEdit edtUretimEmriGunSayisi;
        private DevExpress.XtraEditors.SimpleButton btnAGEyeGonderilebilirUretimEmirleriniGetir;
        private DevExpress.XtraEditors.TextEdit edtEkstraOlusturulacakKodAdedi;
        private DevExpress.XtraEditors.LabelControl lblEkstraOlusturulacakKodAdedi;
        private DevExpress.XtraEditors.SimpleButton btnEkstraUretimEmriOlustur;
        private DevExpress.XtraEditors.LabelControl lblOlusturulanUretimEmriNumarasi;
        private DevExpress.XtraEditors.LabelControl lblUretimHatti;
        private DevExpress.XtraEditors.MarqueeProgressBarControl mpbUretimEmriniGonder;
        public DevExpress.XtraEditors.ComboBoxEdit cbeUretimHatti;
        private DevExpress.XtraEditors.LabelControl lblUretimEmriNumarasi;
        private DevExpress.XtraEditors.TextEdit edtUretimEmriNumarasi;
        private DevExpress.XtraEditors.SimpleButton btnUretimEmriniGetir;
        private DevExpress.XtraEditors.ComboBoxEdit cbeTTSSistemi;
        private DevExpress.XtraEditors.LabelControl lblTTSSistemi;
        private DevExpress.XtraGrid.GridControl grdTTSdeEkstraOlusturulabilirUretimEmirleri;
        private DevExpress.XtraGrid.Views.Grid.GridView grdTTSdeEkstraOlusturulabilirUretimEmirleriView;
        private DevExpress.XtraGrid.Columns.GridColumn dgvTTSdeEkstraOlusturulabilirUretimEmirleriOrderId;
        private DevExpress.XtraGrid.Columns.GridColumn dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemNo;
        private DevExpress.XtraGrid.Columns.GridColumn dgvTTSdeEkstraOlusturulabilirUretimEmirleriItemName;
        private DevExpress.XtraGrid.Columns.GridColumn dgvTTSdeEkstraOlusturulabilirUretimEmirleriBatchNo;
        private DevExpress.XtraGrid.Columns.GridColumn dgvTTSdeEkstraOlusturulabilirUretimEmirleriExpiryDate;
        private DevExpress.XtraGrid.Columns.GridColumn dgvTTSdeEkstraOlusturulabilirUretimEmirleriProductionAmount;
        private DevExpress.XtraEditors.CheckEdit cheKolilemeYapilacak;
        private DevExpress.XtraEditors.LabelControl lblUretimMiktari;
        private DevExpress.XtraEditors.TextEdit edtUretimMiktari;
        private DevExpress.XtraEditors.ComboBoxEdit cbeCaseCode;
        private DevExpress.XtraEditors.LabelControl lblKoliKodu;
    }
}