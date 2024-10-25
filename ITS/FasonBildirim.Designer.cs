namespace ITS
{
  partial class FasonBildirim
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
      this.sleCari = new DevExpress.XtraEditors.SearchLookUpEdit();
      this.sleCariView = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.sleCariKod = new DevExpress.XtraGrid.Columns.GridColumn();
      this.sleCariAdi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.lblSatisIptalYeniCari = new DevExpress.XtraEditors.LabelControl();
      this.btnPTSBildir = new DevExpress.XtraEditors.SimpleButton();
      this.lblUretimEmriNumaralari = new DevExpress.XtraEditors.LabelControl();
      this.edtUretimEmriNumaralari = new DevExpress.XtraEditors.TextEdit();
      this.lblSSCC = new DevExpress.XtraEditors.LabelControl();
      this.edtSSCC = new DevExpress.XtraEditors.TextEdit();
      this.lblMessage = new DevExpress.XtraEditors.LabelControl();
      this.btnClose = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.sleCari.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sleCariView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtUretimEmriNumaralari.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtSSCC.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // sleCari
      // 
      this.sleCari.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.sleCari.Location = new System.Drawing.Point(122, 35);
      this.sleCari.Name = "sleCari";
      this.sleCari.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.sleCari.Properties.DisplayMember = "account_name";
      this.sleCari.Properties.NullText = "";
      this.sleCari.Properties.PopupFormSize = new System.Drawing.Size(600, 500);
      this.sleCari.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
      this.sleCari.Properties.ShowClearButton = false;
      this.sleCari.Properties.ValueMember = "amr_account_code";
      this.sleCari.Properties.View = this.sleCariView;
      this.sleCari.Size = new System.Drawing.Size(628, 20);
      this.sleCari.TabIndex = 3;
      // 
      // sleCariView
      // 
      this.sleCariView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sleCariKod,
            this.sleCariAdi});
      this.sleCariView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.sleCariView.Name = "sleCariView";
      this.sleCariView.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.sleCariView.OptionsView.ShowGroupPanel = false;
      // 
      // sleCariKod
      // 
      this.sleCariKod.Caption = "Cari Hesap Kodu";
      this.sleCariKod.FieldName = "amr_account_code";
      this.sleCariKod.Name = "sleCariKod";
      this.sleCariKod.Visible = true;
      this.sleCariKod.VisibleIndex = 0;
      this.sleCariKod.Width = 191;
      // 
      // sleCariAdi
      // 
      this.sleCariAdi.Caption = "Cari Hesap Adı";
      this.sleCariAdi.FieldName = "amr_account_name";
      this.sleCariAdi.Name = "sleCariAdi";
      this.sleCariAdi.Visible = true;
      this.sleCariAdi.VisibleIndex = 1;
      this.sleCariAdi.Width = 740;
      // 
      // lblSatisIptalYeniCari
      // 
      this.lblSatisIptalYeniCari.Location = new System.Drawing.Point(8, 38);
      this.lblSatisIptalYeniCari.Name = "lblSatisIptalYeniCari";
      this.lblSatisIptalYeniCari.Size = new System.Drawing.Size(52, 13);
      this.lblSatisIptalYeniCari.TabIndex = 2;
      this.lblSatisIptalYeniCari.Text = "Cari Hesap";
      // 
      // btnPTSBildir
      // 
      this.btnPTSBildir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnPTSBildir.Location = new System.Drawing.Point(514, 92);
      this.btnPTSBildir.Name = "btnPTSBildir";
      this.btnPTSBildir.Size = new System.Drawing.Size(108, 23);
      this.btnPTSBildir.TabIndex = 9;
      this.btnPTSBildir.Tag = "2";
      this.btnPTSBildir.Text = "PTS Oluştur ve Bildir";
      this.btnPTSBildir.Click += new System.EventHandler(this.btnPTSBildir_Click);
      // 
      // lblUretimEmriNumaralari
      // 
      this.lblUretimEmriNumaralari.Location = new System.Drawing.Point(8, 12);
      this.lblUretimEmriNumaralari.Name = "lblUretimEmriNumaralari";
      this.lblUretimEmriNumaralari.Size = new System.Drawing.Size(88, 13);
      this.lblUretimEmriNumaralari.TabIndex = 17;
      this.lblUretimEmriNumaralari.Text = "Üretim Emri Detayı";
      // 
      // edtUretimEmriNumaralari
      // 
      this.edtUretimEmriNumaralari.Location = new System.Drawing.Point(122, 9);
      this.edtUretimEmriNumaralari.Name = "edtUretimEmriNumaralari";
      this.edtUretimEmriNumaralari.Properties.ReadOnly = true;
      this.edtUretimEmriNumaralari.Size = new System.Drawing.Size(628, 20);
      this.edtUretimEmriNumaralari.TabIndex = 16;
      this.edtUretimEmriNumaralari.EditValueChanged += new System.EventHandler(this.edtKontrolBarkod_EditValueChanged);
      // 
      // lblSSCC
      // 
      this.lblSSCC.Location = new System.Drawing.Point(8, 64);
      this.lblSSCC.Name = "lblSSCC";
      this.lblSSCC.Size = new System.Drawing.Size(179, 13);
      this.lblSSCC.TabIndex = 19;
      this.lblSSCC.Text = "Son Kalan Ambalajların SSCC Barkodu";
      // 
      // edtSSCC
      // 
      this.edtSSCC.Location = new System.Drawing.Point(193, 61);
      this.edtSSCC.Name = "edtSSCC";
      this.edtSSCC.Size = new System.Drawing.Size(557, 20);
      this.edtSSCC.TabIndex = 18;
      this.edtSSCC.EditValueChanged += new System.EventHandler(this.edtSSCC_EditValueChanged);
      // 
      // lblMessage
      // 
      this.lblMessage.Location = new System.Drawing.Point(8, 102);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(0, 13);
      this.lblMessage.TabIndex = 20;
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.Location = new System.Drawing.Point(642, 92);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(108, 23);
      this.btnClose.TabIndex = 21;
      this.btnClose.Tag = "2";
      this.btnClose.Text = "Kapat";
      this.btnClose.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // FasonBildirim
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(762, 127);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.lblMessage);
      this.Controls.Add(this.lblSSCC);
      this.Controls.Add(this.edtSSCC);
      this.Controls.Add(this.lblUretimEmriNumaralari);
      this.Controls.Add(this.edtUretimEmriNumaralari);
      this.Controls.Add(this.btnPTSBildir);
      this.Controls.Add(this.sleCari);
      this.Controls.Add(this.lblSatisIptalYeniCari);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FasonBildirim";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Fason Bildirim";
      this.Load += new System.EventHandler(this.FasonBildirim_Load);
      ((System.ComponentModel.ISupportInitialize)(this.sleCari.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sleCariView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtUretimEmriNumaralari.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtSSCC.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.SearchLookUpEdit sleCari;
    private DevExpress.XtraGrid.Views.Grid.GridView sleCariView;
    private DevExpress.XtraGrid.Columns.GridColumn sleCariKod;
    private DevExpress.XtraGrid.Columns.GridColumn sleCariAdi;
    private DevExpress.XtraEditors.LabelControl lblSatisIptalYeniCari;
    private DevExpress.XtraEditors.SimpleButton btnPTSBildir;
    private DevExpress.XtraEditors.LabelControl lblUretimEmriNumaralari;
    private DevExpress.XtraEditors.TextEdit edtUretimEmriNumaralari;
    private DevExpress.XtraEditors.LabelControl lblSSCC;
    private DevExpress.XtraEditors.TextEdit edtSSCC;
    private DevExpress.XtraEditors.LabelControl lblMessage;
    private DevExpress.XtraEditors.SimpleButton btnClose;
  }
}