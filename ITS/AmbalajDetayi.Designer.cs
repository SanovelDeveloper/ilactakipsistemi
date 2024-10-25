namespace ITS
{
  partial class AmbalajDetayi
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
      this.lblKayitSayisi = new DevExpress.XtraEditors.LabelControl();
      this.pbcProgress = new DevExpress.XtraEditors.ProgressBarControl();
      this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
      this.edtListelenecekKayitAdedi = new DevExpress.XtraEditors.TextEdit();
      this.lblListelenecekKayitAdedi = new DevExpress.XtraEditors.LabelControl();
      this.edtAmbalajBarkodu = new DevExpress.XtraEditors.TextEdit();
      this.lblAmbalajBarkodu = new DevExpress.XtraEditors.LabelControl();
      this.cbeGecerlilikDurumu = new DevExpress.XtraEditors.ComboBoxEdit();
      this.lblGecerlilikDurumu = new DevExpress.XtraEditors.LabelControl();
      this.edtAmbalajKodu = new DevExpress.XtraEditors.TextEdit();
      this.lblAmbalajKodu = new DevExpress.XtraEditors.LabelControl();
      this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
      this.dgvAmbalajDetayi = new System.Windows.Forms.DataGridView();
      this.btnFiltreyiTemizle = new DevExpress.XtraEditors.SimpleButton();
      this.pck_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pst_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
      this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
      this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
      this.degistir = new System.Windows.Forms.DataGridViewImageColumn();
      ((System.ComponentModel.ISupportInitialize)(this.pbcProgress.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
      this.groupControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.edtListelenecekKayitAdedi.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtAmbalajBarkodu.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cbeGecerlilikDurumu.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtAmbalajKodu.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
      this.groupControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvAmbalajDetayi)).BeginInit();
      this.SuspendLayout();
      // 
      // btnKapat
      // 
      this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKapat.Location = new System.Drawing.Point(606, 539);
      this.btnKapat.Name = "btnKapat";
      this.btnKapat.Size = new System.Drawing.Size(75, 23);
      this.btnKapat.TabIndex = 1;
      this.btnKapat.Text = "Kapat";
      this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
      // 
      // lblKayitSayisi
      // 
      this.lblKayitSayisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblKayitSayisi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.lblKayitSayisi.Location = new System.Drawing.Point(13, 540);
      this.lblKayitSayisi.Name = "lblKayitSayisi";
      this.lblKayitSayisi.Size = new System.Drawing.Size(255, 20);
      this.lblKayitSayisi.TabIndex = 22;
      // 
      // pbcProgress
      // 
      this.pbcProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.pbcProgress.Location = new System.Drawing.Point(13, 539);
      this.pbcProgress.Name = "pbcProgress";
      this.pbcProgress.Properties.EndColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.pbcProgress.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
      this.pbcProgress.Properties.ShowTitle = true;
      this.pbcProgress.Properties.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.pbcProgress.Properties.Step = 1;
      this.pbcProgress.Size = new System.Drawing.Size(255, 24);
      this.pbcProgress.TabIndex = 23;
      this.pbcProgress.Visible = false;
      // 
      // groupControl1
      // 
      this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupControl1.Controls.Add(this.btnFiltreyiTemizle);
      this.groupControl1.Controls.Add(this.edtListelenecekKayitAdedi);
      this.groupControl1.Controls.Add(this.lblListelenecekKayitAdedi);
      this.groupControl1.Controls.Add(this.edtAmbalajBarkodu);
      this.groupControl1.Controls.Add(this.lblAmbalajBarkodu);
      this.groupControl1.Controls.Add(this.cbeGecerlilikDurumu);
      this.groupControl1.Controls.Add(this.lblGecerlilikDurumu);
      this.groupControl1.Controls.Add(this.edtAmbalajKodu);
      this.groupControl1.Controls.Add(this.lblAmbalajKodu);
      this.groupControl1.Location = new System.Drawing.Point(12, 12);
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new System.Drawing.Size(669, 110);
      this.groupControl1.TabIndex = 24;
      this.groupControl1.Text = "Filtreleme";
      // 
      // edtListelenecekKayitAdedi
      // 
      this.edtListelenecekKayitAdedi.EditValue = "100";
      this.edtListelenecekKayitAdedi.Location = new System.Drawing.Point(567, 56);
      this.edtListelenecekKayitAdedi.Name = "edtListelenecekKayitAdedi";
      this.edtListelenecekKayitAdedi.Properties.Mask.EditMask = "f0";
      this.edtListelenecekKayitAdedi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
      this.edtListelenecekKayitAdedi.Size = new System.Drawing.Size(97, 20);
      this.edtListelenecekKayitAdedi.TabIndex = 7;
      this.edtListelenecekKayitAdedi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtListelenecekKayitAdedi_KeyDown);
      // 
      // lblListelenecekKayitAdedi
      // 
      this.lblListelenecekKayitAdedi.Location = new System.Drawing.Point(446, 59);
      this.lblListelenecekKayitAdedi.Name = "lblListelenecekKayitAdedi";
      this.lblListelenecekKayitAdedi.Size = new System.Drawing.Size(115, 13);
      this.lblListelenecekKayitAdedi.TabIndex = 6;
      this.lblListelenecekKayitAdedi.Text = "Listelenecek Kayıt Adedi";
      // 
      // edtAmbalajBarkodu
      // 
      this.edtAmbalajBarkodu.Location = new System.Drawing.Point(101, 82);
      this.edtAmbalajBarkodu.Name = "edtAmbalajBarkodu";
      this.edtAmbalajBarkodu.Size = new System.Drawing.Size(563, 20);
      this.edtAmbalajBarkodu.TabIndex = 5;
      this.edtAmbalajBarkodu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtAmbalajBarkodu_KeyPress);
      this.edtAmbalajBarkodu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtAmbalajBarkodu_KeyDown);
      // 
      // lblAmbalajBarkodu
      // 
      this.lblAmbalajBarkodu.Location = new System.Drawing.Point(12, 85);
      this.lblAmbalajBarkodu.Name = "lblAmbalajBarkodu";
      this.lblAmbalajBarkodu.Size = new System.Drawing.Size(80, 13);
      this.lblAmbalajBarkodu.TabIndex = 4;
      this.lblAmbalajBarkodu.Text = "Ambalaj Barkodu";
      // 
      // cbeGecerlilikDurumu
      // 
      this.cbeGecerlilikDurumu.Location = new System.Drawing.Point(101, 56);
      this.cbeGecerlilikDurumu.Name = "cbeGecerlilikDurumu";
      this.cbeGecerlilikDurumu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cbeGecerlilikDurumu.Size = new System.Drawing.Size(162, 20);
      this.cbeGecerlilikDurumu.TabIndex = 3;
      this.cbeGecerlilikDurumu.SelectedIndexChanged += new System.EventHandler(this.cbeGecerlilikDurumu_SelectedIndexChanged);
      // 
      // lblGecerlilikDurumu
      // 
      this.lblGecerlilikDurumu.Location = new System.Drawing.Point(12, 59);
      this.lblGecerlilikDurumu.Name = "lblGecerlilikDurumu";
      this.lblGecerlilikDurumu.Size = new System.Drawing.Size(81, 13);
      this.lblGecerlilikDurumu.TabIndex = 2;
      this.lblGecerlilikDurumu.Text = "Geçerlilik Durumu";
      // 
      // edtAmbalajKodu
      // 
      this.edtAmbalajKodu.Location = new System.Drawing.Point(101, 30);
      this.edtAmbalajKodu.Name = "edtAmbalajKodu";
      this.edtAmbalajKodu.Size = new System.Drawing.Size(162, 20);
      this.edtAmbalajKodu.TabIndex = 1;
      this.edtAmbalajKodu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtAmbalajKodu_KeyDown);
      // 
      // lblAmbalajKodu
      // 
      this.lblAmbalajKodu.Location = new System.Drawing.Point(12, 33);
      this.lblAmbalajKodu.Name = "lblAmbalajKodu";
      this.lblAmbalajKodu.Size = new System.Drawing.Size(65, 13);
      this.lblAmbalajKodu.TabIndex = 0;
      this.lblAmbalajKodu.Text = "Ambalaj Kodu";
      // 
      // groupControl2
      // 
      this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupControl2.Controls.Add(this.dgvAmbalajDetayi);
      this.groupControl2.Location = new System.Drawing.Point(13, 128);
      this.groupControl2.Name = "groupControl2";
      this.groupControl2.Size = new System.Drawing.Size(668, 405);
      this.groupControl2.TabIndex = 25;
      this.groupControl2.Text = "Ambalaj Listesi";
      // 
      // dgvAmbalajDetayi
      // 
      this.dgvAmbalajDetayi.AllowUserToAddRows = false;
      this.dgvAmbalajDetayi.AllowUserToDeleteRows = false;
      this.dgvAmbalajDetayi.AllowUserToOrderColumns = true;
      this.dgvAmbalajDetayi.AllowUserToResizeRows = false;
      this.dgvAmbalajDetayi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvAmbalajDetayi.BackgroundColor = System.Drawing.SystemColors.Info;
      this.dgvAmbalajDetayi.BorderStyle = System.Windows.Forms.BorderStyle.None;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvAmbalajDetayi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
      this.dgvAmbalajDetayi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvAmbalajDetayi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn3,
            this.degistir,
            this.pck_code,
            this.pst_description,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvAmbalajDetayi.DefaultCellStyle = dataGridViewCellStyle5;
      this.dgvAmbalajDetayi.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvAmbalajDetayi.Location = new System.Drawing.Point(2, 22);
      this.dgvAmbalajDetayi.Name = "dgvAmbalajDetayi";
      this.dgvAmbalajDetayi.ReadOnly = true;
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvAmbalajDetayi.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
      this.dgvAmbalajDetayi.RowHeadersVisible = false;
      this.dgvAmbalajDetayi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
      this.dgvAmbalajDetayi.Size = new System.Drawing.Size(664, 381);
      this.dgvAmbalajDetayi.TabIndex = 4;
      this.dgvAmbalajDetayi.TabStop = false;
      this.dgvAmbalajDetayi.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAmbalajDetayi_CellFormatting);
      this.dgvAmbalajDetayi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAmbalajDetayi_CellClick);
      // 
      // btnFiltreyiTemizle
      // 
      this.btnFiltreyiTemizle.Location = new System.Drawing.Point(567, 27);
      this.btnFiltreyiTemizle.Name = "btnFiltreyiTemizle";
      this.btnFiltreyiTemizle.Size = new System.Drawing.Size(97, 23);
      this.btnFiltreyiTemizle.TabIndex = 8;
      this.btnFiltreyiTemizle.Text = "Filtreyi Temizle";
      this.btnFiltreyiTemizle.Click += new System.EventHandler(this.btnFiltreyiTemizle_Click);
      // 
      // pck_code
      // 
      this.pck_code.HeaderText = "Ambalaj Kodu";
      this.pck_code.Name = "pck_code";
      this.pck_code.ReadOnly = true;
      // 
      // pst_description
      // 
      this.pst_description.HeaderText = "Geçerlilik Durumu";
      this.pst_description.Name = "pst_description";
      this.pst_description.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn3
      // 
      this.dataGridViewTextBoxColumn3.DataPropertyName = "status";
      this.dataGridViewTextBoxColumn3.HeaderText = "Ambalaj Durumu";
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      this.dataGridViewTextBoxColumn3.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn4
      // 
      this.dataGridViewTextBoxColumn4.DataPropertyName = "pck_id";
      this.dataGridViewTextBoxColumn4.HeaderText = "pck_id";
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      this.dataGridViewTextBoxColumn4.ReadOnly = true;
      this.dataGridViewTextBoxColumn4.Visible = false;
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.DataPropertyName = "pck_status_id";
      this.dataGridViewTextBoxColumn5.HeaderText = "pck_status_id";
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.dataGridViewTextBoxColumn5.ReadOnly = true;
      this.dataGridViewTextBoxColumn5.Visible = false;
      // 
      // dataGridViewImageColumn1
      // 
      this.dataGridViewImageColumn1.FillWeight = 10F;
      this.dataGridViewImageColumn1.HeaderText = "#";
      this.dataGridViewImageColumn1.Image = global::ITS.Properties.Resources.edit_remove;
      this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
      this.dataGridViewImageColumn1.ReadOnly = true;
      this.dataGridViewImageColumn1.Width = 25;
      // 
      // dataGridViewImageColumn2
      // 
      this.dataGridViewImageColumn2.FillWeight = 20F;
      this.dataGridViewImageColumn2.HeaderText = "Ekle";
      this.dataGridViewImageColumn2.Image = global::ITS.Properties.Resources.edit_add;
      this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
      this.dataGridViewImageColumn2.ReadOnly = true;
      this.dataGridViewImageColumn2.Visible = false;
      this.dataGridViewImageColumn2.Width = 39;
      // 
      // dataGridViewImageColumn3
      // 
      this.dataGridViewImageColumn3.FillWeight = 20F;
      this.dataGridViewImageColumn3.HeaderText = "Sil";
      this.dataGridViewImageColumn3.Image = global::ITS.Properties.Resources.edit_remove;
      this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
      this.dataGridViewImageColumn3.ReadOnly = true;
      // 
      // degistir
      // 
      this.degistir.FillWeight = 20F;
      this.degistir.HeaderText = "Günc.";
      this.degistir.Image = global::ITS.Properties.Resources.color_line;
      this.degistir.Name = "degistir";
      this.degistir.ReadOnly = true;
      // 
      // AmbalajDetayi
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(693, 572);
      this.Controls.Add(this.groupControl2);
      this.Controls.Add(this.groupControl1);
      this.Controls.Add(this.pbcProgress);
      this.Controls.Add(this.btnKapat);
      this.Controls.Add(this.lblKayitSayisi);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AmbalajDetayi";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Ambalaj İşlemleri";
      this.Load += new System.EventHandler(this.AmbalajDetayi_Load);
      this.Shown += new System.EventHandler(this.AmbalajDetayi_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.pbcProgress.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
      this.groupControl1.ResumeLayout(false);
      this.groupControl1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.edtListelenecekKayitAdedi.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtAmbalajBarkodu.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cbeGecerlilikDurumu.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtAmbalajKodu.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
      this.groupControl2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvAmbalajDetayi)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton btnKapat;
    private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
    private DevExpress.XtraEditors.LabelControl lblKayitSayisi;
    private DevExpress.XtraEditors.ProgressBarControl pbcProgress;
    private DevExpress.XtraEditors.GroupControl groupControl1;
    private DevExpress.XtraEditors.ComboBoxEdit cbeGecerlilikDurumu;
    private DevExpress.XtraEditors.LabelControl lblGecerlilikDurumu;
    private DevExpress.XtraEditors.TextEdit edtAmbalajKodu;
    private DevExpress.XtraEditors.LabelControl lblAmbalajKodu;
    private DevExpress.XtraEditors.TextEdit edtAmbalajBarkodu;
    private DevExpress.XtraEditors.LabelControl lblAmbalajBarkodu;
    private DevExpress.XtraEditors.TextEdit edtListelenecekKayitAdedi;
    private DevExpress.XtraEditors.LabelControl lblListelenecekKayitAdedi;
    private DevExpress.XtraEditors.GroupControl groupControl2;
    private System.Windows.Forms.DataGridView dgvAmbalajDetayi;
    private DevExpress.XtraEditors.SimpleButton btnFiltreyiTemizle;
    private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
    private System.Windows.Forms.DataGridViewImageColumn degistir;
    private System.Windows.Forms.DataGridViewTextBoxColumn pck_code;
    private System.Windows.Forms.DataGridViewTextBoxColumn pst_description;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
  }
}