namespace ITS
{
  partial class UretimDetayiArama
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UretimDetayiArama));
      this.edtAmbalajBarkodu = new DevExpress.XtraEditors.TextEdit();
      this.lblAmbalajBarkodu = new DevExpress.XtraEditors.LabelControl();
      this.cbeGecerlilikDurumu = new DevExpress.XtraEditors.ComboBoxEdit();
      this.lblGecerlilikDurumu = new DevExpress.XtraEditors.LabelControl();
      this.edtAmbalajKodu = new DevExpress.XtraEditors.TextEdit();
      this.lblAmbalajKodu = new DevExpress.XtraEditors.LabelControl();
      this.grdAmbalajDetayi = new DevExpress.XtraGrid.GridControl();
      this.grdAmbalajDetayiView = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.grdAmbalajDetayiOrderId = new DevExpress.XtraGrid.Columns.GridColumn();
      this.grdAmbalajDetayiPackageCode = new DevExpress.XtraGrid.Columns.GridColumn();
      this.grdAmbalajDetayiStatus = new DevExpress.XtraGrid.Columns.GridColumn();
      this.grdAmbalajDetayiDecStatus = new DevExpress.XtraGrid.Columns.GridColumn();
      this.grdAmbalajDetayiInsertedBy = new DevExpress.XtraGrid.Columns.GridColumn();
      this.grdAmbalajDetayiPrintedStatus = new DevExpress.XtraGrid.Columns.GridColumn();
      this.grdAmbalajDetayiSource = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.edtAmbalajBarkodu.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cbeGecerlilikDurumu.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtAmbalajKodu.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdAmbalajDetayi)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdAmbalajDetayiView)).BeginInit();
      this.SuspendLayout();
      // 
      // edtAmbalajBarkodu
      // 
      this.edtAmbalajBarkodu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.edtAmbalajBarkodu.Location = new System.Drawing.Point(132, 63);
      this.edtAmbalajBarkodu.Name = "edtAmbalajBarkodu";
      this.edtAmbalajBarkodu.Size = new System.Drawing.Size(573, 20);
      this.edtAmbalajBarkodu.TabIndex = 11;
      this.edtAmbalajBarkodu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtAmbalajBarkodu_KeyDown);
      // 
      // lblAmbalajBarkodu
      // 
      this.lblAmbalajBarkodu.Location = new System.Drawing.Point(12, 66);
      this.lblAmbalajBarkodu.Name = "lblAmbalajBarkodu";
      this.lblAmbalajBarkodu.Size = new System.Drawing.Size(116, 13);
      this.lblAmbalajBarkodu.TabIndex = 10;
      this.lblAmbalajBarkodu.Text = "Ambalaj / SSCC Barkodu";
      // 
      // cbeGecerlilikDurumu
      // 
      this.cbeGecerlilikDurumu.Location = new System.Drawing.Point(132, 37);
      this.cbeGecerlilikDurumu.Name = "cbeGecerlilikDurumu";
      this.cbeGecerlilikDurumu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cbeGecerlilikDurumu.Size = new System.Drawing.Size(162, 20);
      this.cbeGecerlilikDurumu.TabIndex = 9;
      this.cbeGecerlilikDurumu.SelectedIndexChanged += new System.EventHandler(this.cbeGecerlilikDurumu_SelectedIndexChanged);
      // 
      // lblGecerlilikDurumu
      // 
      this.lblGecerlilikDurumu.Location = new System.Drawing.Point(12, 40);
      this.lblGecerlilikDurumu.Name = "lblGecerlilikDurumu";
      this.lblGecerlilikDurumu.Size = new System.Drawing.Size(81, 13);
      this.lblGecerlilikDurumu.TabIndex = 8;
      this.lblGecerlilikDurumu.Text = "Geçerlilik Durumu";
      // 
      // edtAmbalajKodu
      // 
      this.edtAmbalajKodu.Location = new System.Drawing.Point(132, 11);
      this.edtAmbalajKodu.Name = "edtAmbalajKodu";
      this.edtAmbalajKodu.Size = new System.Drawing.Size(162, 20);
      this.edtAmbalajKodu.TabIndex = 7;
      this.edtAmbalajKodu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtAmbalajKodu_KeyDown);
      // 
      // lblAmbalajKodu
      // 
      this.lblAmbalajKodu.Location = new System.Drawing.Point(12, 14);
      this.lblAmbalajKodu.Name = "lblAmbalajKodu";
      this.lblAmbalajKodu.Size = new System.Drawing.Size(101, 13);
      this.lblAmbalajKodu.TabIndex = 6;
      this.lblAmbalajKodu.Text = "Ambalaj / SSCC Kodu";
      // 
      // grdAmbalajDetayi
      // 
      this.grdAmbalajDetayi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.grdAmbalajDetayi.Location = new System.Drawing.Point(12, 100);
      this.grdAmbalajDetayi.MainView = this.grdAmbalajDetayiView;
      this.grdAmbalajDetayi.Name = "grdAmbalajDetayi";
      this.grdAmbalajDetayi.Size = new System.Drawing.Size(693, 350);
      this.grdAmbalajDetayi.TabIndex = 12;
      this.grdAmbalajDetayi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAmbalajDetayiView});
      // 
      // grdAmbalajDetayiView
      // 
      this.grdAmbalajDetayiView.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdAmbalajDetayiView.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdAmbalajDetayiView.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.ColumnFilterButton.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.ColumnFilterButton.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
      this.grdAmbalajDetayiView.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
      this.grdAmbalajDetayiView.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdAmbalajDetayiView.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
      this.grdAmbalajDetayiView.Appearance.Empty.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
      this.grdAmbalajDetayiView.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
      this.grdAmbalajDetayiView.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.EvenRow.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.EvenRow.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.EvenRow.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
      this.grdAmbalajDetayiView.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
      this.grdAmbalajDetayiView.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.FilterCloseButton.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.FilterCloseButton.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.FilterCloseButton.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdAmbalajDetayiView.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
      this.grdAmbalajDetayiView.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.FilterPanel.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.FilterPanel.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
      this.grdAmbalajDetayiView.Appearance.FixedLine.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
      this.grdAmbalajDetayiView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.FocusedCell.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.FocusedCell.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
      this.grdAmbalajDetayiView.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
      this.grdAmbalajDetayiView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.FocusedRow.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.FocusedRow.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.FocusedRow.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grdAmbalajDetayiView.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grdAmbalajDetayiView.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.FooterPanel.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.FooterPanel.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.FooterPanel.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.FooterPanel.Options.UseTextOptions = true;
      this.grdAmbalajDetayiView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
      this.grdAmbalajDetayiView.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
      this.grdAmbalajDetayiView.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
      this.grdAmbalajDetayiView.Appearance.GroupButton.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.GroupButton.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdAmbalajDetayiView.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdAmbalajDetayiView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.GroupFooter.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.GroupFooter.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.GroupFooter.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
      this.grdAmbalajDetayiView.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
      this.grdAmbalajDetayiView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.GroupPanel.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.GroupPanel.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdAmbalajDetayiView.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdAmbalajDetayiView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.GroupRow.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.GroupRow.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.GroupRow.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grdAmbalajDetayiView.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grdAmbalajDetayiView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.HeaderPanel.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.HeaderPanel.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.HeaderPanel.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.HeaderPanel.Options.UseTextOptions = true;
      this.grdAmbalajDetayiView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
      this.grdAmbalajDetayiView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
      this.grdAmbalajDetayiView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
      this.grdAmbalajDetayiView.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
      this.grdAmbalajDetayiView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.HideSelectionRow.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.HideSelectionRow.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.HideSelectionRow.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grdAmbalajDetayiView.Appearance.HorzLine.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
      this.grdAmbalajDetayiView.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
      this.grdAmbalajDetayiView.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.OddRow.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.OddRow.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.OddRow.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
      this.grdAmbalajDetayiView.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
      this.grdAmbalajDetayiView.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
      this.grdAmbalajDetayiView.Appearance.Preview.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.Preview.Options.UseFont = true;
      this.grdAmbalajDetayiView.Appearance.Preview.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
      this.grdAmbalajDetayiView.Appearance.Row.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.Row.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.Row.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdAmbalajDetayiView.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
      this.grdAmbalajDetayiView.Appearance.RowSeparator.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
      this.grdAmbalajDetayiView.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
      this.grdAmbalajDetayiView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
      this.grdAmbalajDetayiView.Appearance.SelectedRow.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.SelectedRow.Options.UseBorderColor = true;
      this.grdAmbalajDetayiView.Appearance.SelectedRow.Options.UseForeColor = true;
      this.grdAmbalajDetayiView.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
      this.grdAmbalajDetayiView.Appearance.TopNewRow.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grdAmbalajDetayiView.Appearance.VertLine.Options.UseBackColor = true;
      this.grdAmbalajDetayiView.ColumnPanelRowHeight = 32;
      this.grdAmbalajDetayiView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdAmbalajDetayiOrderId,
            this.grdAmbalajDetayiPackageCode,
            this.grdAmbalajDetayiStatus,
            this.grdAmbalajDetayiDecStatus,
            this.grdAmbalajDetayiInsertedBy,
            this.grdAmbalajDetayiPrintedStatus,
            this.grdAmbalajDetayiSource});
      this.grdAmbalajDetayiView.GridControl = this.grdAmbalajDetayi;
      this.grdAmbalajDetayiView.Name = "grdAmbalajDetayiView";
      this.grdAmbalajDetayiView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
      this.grdAmbalajDetayiView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
      this.grdAmbalajDetayiView.OptionsBehavior.AllowIncrementalSearch = true;
      this.grdAmbalajDetayiView.OptionsCustomization.AllowFilter = false;
      this.grdAmbalajDetayiView.OptionsCustomization.AllowGroup = false;
      this.grdAmbalajDetayiView.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.grdAmbalajDetayiView.OptionsView.EnableAppearanceEvenRow = true;
      this.grdAmbalajDetayiView.OptionsView.EnableAppearanceOddRow = true;
      this.grdAmbalajDetayiView.OptionsView.ShowFooter = true;
      this.grdAmbalajDetayiView.OptionsView.ShowGroupPanel = false;
      this.grdAmbalajDetayiView.OptionsView.ShowIndicator = false;
      this.grdAmbalajDetayiView.DoubleClick += new System.EventHandler(this.grdAmbalajDetayiView_DoubleClick);
      // 
      // grdAmbalajDetayiOrderId
      // 
      this.grdAmbalajDetayiOrderId.Caption = "Üretim Emri No";
      this.grdAmbalajDetayiOrderId.FieldName = "pck_order_id";
      this.grdAmbalajDetayiOrderId.Name = "grdAmbalajDetayiOrderId";
      this.grdAmbalajDetayiOrderId.OptionsColumn.AllowEdit = false;
      this.grdAmbalajDetayiOrderId.OptionsColumn.AllowIncrementalSearch = false;
      this.grdAmbalajDetayiOrderId.Visible = true;
      this.grdAmbalajDetayiOrderId.VisibleIndex = 0;
      this.grdAmbalajDetayiOrderId.Width = 71;
      // 
      // grdAmbalajDetayiPackageCode
      // 
      this.grdAmbalajDetayiPackageCode.Caption = "Ambalaj Kodu";
      this.grdAmbalajDetayiPackageCode.FieldName = "pck_code";
      this.grdAmbalajDetayiPackageCode.Name = "grdAmbalajDetayiPackageCode";
      this.grdAmbalajDetayiPackageCode.OptionsColumn.AllowEdit = false;
      this.grdAmbalajDetayiPackageCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "pck_code", "Toplam kayıt sayısı: {0}")});
      this.grdAmbalajDetayiPackageCode.Visible = true;
      this.grdAmbalajDetayiPackageCode.VisibleIndex = 1;
      this.grdAmbalajDetayiPackageCode.Width = 165;
      // 
      // grdAmbalajDetayiStatus
      // 
      this.grdAmbalajDetayiStatus.Caption = "Geçerlilik Durumu";
      this.grdAmbalajDetayiStatus.FieldName = "pst_description";
      this.grdAmbalajDetayiStatus.Name = "grdAmbalajDetayiStatus";
      this.grdAmbalajDetayiStatus.OptionsColumn.AllowEdit = false;
      this.grdAmbalajDetayiStatus.OptionsColumn.AllowIncrementalSearch = false;
      this.grdAmbalajDetayiStatus.Visible = true;
      this.grdAmbalajDetayiStatus.VisibleIndex = 2;
      this.grdAmbalajDetayiStatus.Width = 116;
      // 
      // grdAmbalajDetayiDecStatus
      // 
      this.grdAmbalajDetayiDecStatus.Caption = "Bildirim Durumu";
      this.grdAmbalajDetayiDecStatus.FieldName = "status";
      this.grdAmbalajDetayiDecStatus.Name = "grdAmbalajDetayiDecStatus";
      this.grdAmbalajDetayiDecStatus.OptionsColumn.AllowEdit = false;
      this.grdAmbalajDetayiDecStatus.OptionsColumn.AllowIncrementalSearch = false;
      this.grdAmbalajDetayiDecStatus.Visible = true;
      this.grdAmbalajDetayiDecStatus.VisibleIndex = 3;
      this.grdAmbalajDetayiDecStatus.Width = 89;
      // 
      // grdAmbalajDetayiInsertedBy
      // 
      this.grdAmbalajDetayiInsertedBy.Caption = "Ekleyen";
      this.grdAmbalajDetayiInsertedBy.FieldName = "inserted_user";
      this.grdAmbalajDetayiInsertedBy.Name = "grdAmbalajDetayiInsertedBy";
      this.grdAmbalajDetayiInsertedBy.OptionsColumn.AllowEdit = false;
      this.grdAmbalajDetayiInsertedBy.OptionsColumn.AllowIncrementalSearch = false;
      this.grdAmbalajDetayiInsertedBy.Visible = true;
      this.grdAmbalajDetayiInsertedBy.VisibleIndex = 4;
      this.grdAmbalajDetayiInsertedBy.Width = 105;
      // 
      // grdAmbalajDetayiPrintedStatus
      // 
      this.grdAmbalajDetayiPrintedStatus.Caption = "Basılma Durumu";
      this.grdAmbalajDetayiPrintedStatus.FieldName = "was_printed";
      this.grdAmbalajDetayiPrintedStatus.Name = "grdAmbalajDetayiPrintedStatus";
      this.grdAmbalajDetayiPrintedStatus.OptionsColumn.AllowEdit = false;
      this.grdAmbalajDetayiPrintedStatus.OptionsColumn.AllowIncrementalSearch = false;
      this.grdAmbalajDetayiPrintedStatus.Visible = true;
      this.grdAmbalajDetayiPrintedStatus.VisibleIndex = 5;
      this.grdAmbalajDetayiPrintedStatus.Width = 65;
      // 
      // grdAmbalajDetayiSource
      // 
      this.grdAmbalajDetayiSource.Caption = "Data Kaynağı";
      this.grdAmbalajDetayiSource.FieldName = "pck_source";
      this.grdAmbalajDetayiSource.Name = "grdAmbalajDetayiSource";
      this.grdAmbalajDetayiSource.OptionsColumn.AllowEdit = false;
      this.grdAmbalajDetayiSource.OptionsColumn.AllowIncrementalSearch = false;
      this.grdAmbalajDetayiSource.Visible = true;
      this.grdAmbalajDetayiSource.VisibleIndex = 6;
      this.grdAmbalajDetayiSource.Width = 78;
      // 
      // UretimDetayiArama
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(717, 462);
      this.Controls.Add(this.grdAmbalajDetayi);
      this.Controls.Add(this.edtAmbalajBarkodu);
      this.Controls.Add(this.lblAmbalajBarkodu);
      this.Controls.Add(this.cbeGecerlilikDurumu);
      this.Controls.Add(this.lblGecerlilikDurumu);
      this.Controls.Add(this.edtAmbalajKodu);
      this.Controls.Add(this.lblAmbalajKodu);
      //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UretimDetayiArama";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Üretim Arama";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UretimDetayiArama_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.edtAmbalajBarkodu.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cbeGecerlilikDurumu.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.edtAmbalajKodu.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdAmbalajDetayi)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdAmbalajDetayiView)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.TextEdit edtAmbalajBarkodu;
    private DevExpress.XtraEditors.LabelControl lblAmbalajBarkodu;
    private DevExpress.XtraEditors.LabelControl lblGecerlilikDurumu;
    private DevExpress.XtraEditors.TextEdit edtAmbalajKodu;
    private DevExpress.XtraEditors.LabelControl lblAmbalajKodu;
    private DevExpress.XtraGrid.GridControl grdAmbalajDetayi;
    private DevExpress.XtraGrid.Views.Grid.GridView grdAmbalajDetayiView;
    private DevExpress.XtraGrid.Columns.GridColumn grdAmbalajDetayiPackageCode;
    private DevExpress.XtraGrid.Columns.GridColumn grdAmbalajDetayiStatus;
    private DevExpress.XtraGrid.Columns.GridColumn grdAmbalajDetayiDecStatus;
    private DevExpress.XtraGrid.Columns.GridColumn grdAmbalajDetayiInsertedBy;
    private DevExpress.XtraGrid.Columns.GridColumn grdAmbalajDetayiOrderId;
    private DevExpress.XtraGrid.Columns.GridColumn grdAmbalajDetayiPrintedStatus;
    private DevExpress.XtraGrid.Columns.GridColumn grdAmbalajDetayiSource;
    public DevExpress.XtraEditors.ComboBoxEdit cbeGecerlilikDurumu;


  }
}