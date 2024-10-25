namespace ITS
{
  partial class SatisDetayinaAmbalajEkleme
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
      this.lblUrunDogrulamaBarkod = new DevExpress.XtraEditors.LabelControl();
      this.edtKontrolBarkod = new DevExpress.XtraEditors.TextEdit();
      this.grdEklenenAmbalajlar = new DevExpress.XtraGrid.GridControl();
      this.grdEklenenAmbalajlarView = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
      this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.edtKontrolBarkod.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdEklenenAmbalajlar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdEklenenAmbalajlarView)).BeginInit();
      this.SuspendLayout();
      // 
      // lblUrunDogrulamaBarkod
      // 
      this.lblUrunDogrulamaBarkod.Location = new System.Drawing.Point(12, 15);
      this.lblUrunDogrulamaBarkod.Name = "lblUrunDogrulamaBarkod";
      this.lblUrunDogrulamaBarkod.Size = new System.Drawing.Size(33, 13);
      this.lblUrunDogrulamaBarkod.TabIndex = 13;
      this.lblUrunDogrulamaBarkod.Text = "Barkod";
      // 
      // edtKontrolBarkod
      // 
      this.edtKontrolBarkod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.edtKontrolBarkod.Location = new System.Drawing.Point(64, 12);
      this.edtKontrolBarkod.Name = "edtKontrolBarkod";
      this.edtKontrolBarkod.Size = new System.Drawing.Size(541, 20);
      this.edtKontrolBarkod.TabIndex = 12;
      this.edtKontrolBarkod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtKontrolBarkod_KeyDown);
      // 
      // grdEklenenAmbalajlar
      // 
      this.grdEklenenAmbalajlar.Location = new System.Drawing.Point(12, 38);
      this.grdEklenenAmbalajlar.MainView = this.grdEklenenAmbalajlarView;
      this.grdEklenenAmbalajlar.Name = "grdEklenenAmbalajlar";
      this.grdEklenenAmbalajlar.Size = new System.Drawing.Size(593, 319);
      this.grdEklenenAmbalajlar.TabIndex = 14;
      this.grdEklenenAmbalajlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdEklenenAmbalajlarView});
      // 
      // grdEklenenAmbalajlarView
      // 
      this.grdEklenenAmbalajlarView.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdEklenenAmbalajlarView.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdEklenenAmbalajlarView.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.ColumnFilterButton.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.ColumnFilterButton.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
      this.grdEklenenAmbalajlarView.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
      this.grdEklenenAmbalajlarView.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdEklenenAmbalajlarView.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
      this.grdEklenenAmbalajlarView.Appearance.Empty.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
      this.grdEklenenAmbalajlarView.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
      this.grdEklenenAmbalajlarView.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.EvenRow.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.EvenRow.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.EvenRow.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
      this.grdEklenenAmbalajlarView.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
      this.grdEklenenAmbalajlarView.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.FilterCloseButton.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FilterCloseButton.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FilterCloseButton.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdEklenenAmbalajlarView.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
      this.grdEklenenAmbalajlarView.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.FilterPanel.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FilterPanel.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
      this.grdEklenenAmbalajlarView.Appearance.FixedLine.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
      this.grdEklenenAmbalajlarView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.FocusedCell.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FocusedCell.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
      this.grdEklenenAmbalajlarView.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
      this.grdEklenenAmbalajlarView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.FocusedRow.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FocusedRow.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FocusedRow.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grdEklenenAmbalajlarView.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grdEklenenAmbalajlarView.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.FooterPanel.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FooterPanel.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.FooterPanel.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
      this.grdEklenenAmbalajlarView.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
      this.grdEklenenAmbalajlarView.Appearance.GroupButton.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.GroupButton.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdEklenenAmbalajlarView.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdEklenenAmbalajlarView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.GroupFooter.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.GroupFooter.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.GroupFooter.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
      this.grdEklenenAmbalajlarView.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
      this.grdEklenenAmbalajlarView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.GroupPanel.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.GroupPanel.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdEklenenAmbalajlarView.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdEklenenAmbalajlarView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.GroupRow.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.GroupRow.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.GroupRow.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grdEklenenAmbalajlarView.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grdEklenenAmbalajlarView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.HeaderPanel.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.HeaderPanel.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.HeaderPanel.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
      this.grdEklenenAmbalajlarView.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
      this.grdEklenenAmbalajlarView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.HideSelectionRow.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.HideSelectionRow.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.HideSelectionRow.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grdEklenenAmbalajlarView.Appearance.HorzLine.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
      this.grdEklenenAmbalajlarView.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
      this.grdEklenenAmbalajlarView.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.OddRow.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.OddRow.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.OddRow.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
      this.grdEklenenAmbalajlarView.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
      this.grdEklenenAmbalajlarView.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
      this.grdEklenenAmbalajlarView.Appearance.Preview.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.Preview.Options.UseFont = true;
      this.grdEklenenAmbalajlarView.Appearance.Preview.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
      this.grdEklenenAmbalajlarView.Appearance.Row.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.Row.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.Row.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
      this.grdEklenenAmbalajlarView.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
      this.grdEklenenAmbalajlarView.Appearance.RowSeparator.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
      this.grdEklenenAmbalajlarView.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
      this.grdEklenenAmbalajlarView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
      this.grdEklenenAmbalajlarView.Appearance.SelectedRow.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.SelectedRow.Options.UseBorderColor = true;
      this.grdEklenenAmbalajlarView.Appearance.SelectedRow.Options.UseForeColor = true;
      this.grdEklenenAmbalajlarView.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
      this.grdEklenenAmbalajlarView.Appearance.TopNewRow.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
      this.grdEklenenAmbalajlarView.Appearance.VertLine.Options.UseBackColor = true;
      this.grdEklenenAmbalajlarView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
      this.grdEklenenAmbalajlarView.GridControl = this.grdEklenenAmbalajlar;
      this.grdEklenenAmbalajlarView.GroupCount = 1;
      this.grdEklenenAmbalajlarView.Name = "grdEklenenAmbalajlarView";
      this.grdEklenenAmbalajlarView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
      this.grdEklenenAmbalajlarView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
      this.grdEklenenAmbalajlarView.OptionsBehavior.Editable = false;
      this.grdEklenenAmbalajlarView.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.grdEklenenAmbalajlarView.OptionsView.EnableAppearanceEvenRow = true;
      this.grdEklenenAmbalajlarView.OptionsView.EnableAppearanceOddRow = true;
      this.grdEklenenAmbalajlarView.OptionsView.ShowFooter = true;
      this.grdEklenenAmbalajlarView.OptionsView.ShowGroupPanel = false;
      this.grdEklenenAmbalajlarView.OptionsView.ShowIndicator = false;
      this.grdEklenenAmbalajlarView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
      // 
      // gridColumn1
      // 
      this.gridColumn1.Caption = "SSCC";
      this.gridColumn1.FieldName = "pag_sscc";
      this.gridColumn1.Name = "gridColumn1";
      this.gridColumn1.Visible = true;
      this.gridColumn1.VisibleIndex = 0;
      // 
      // gridColumn2
      // 
      this.gridColumn2.Caption = "Ambalaj Kodu";
      this.gridColumn2.FieldName = "pck_code";
      this.gridColumn2.Name = "gridColumn2";
      this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "pck_code", "Kayıt sayısı: {0}")});
      this.gridColumn2.Visible = true;
      this.gridColumn2.VisibleIndex = 0;
      // 
      // SatisDetayinaAmbalajEkleme
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(617, 369);
      this.Controls.Add(this.grdEklenenAmbalajlar);
      this.Controls.Add(this.lblUrunDogrulamaBarkod);
      this.Controls.Add(this.edtKontrolBarkod);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SatisDetayinaAmbalajEkleme";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Satış Detayına Ambalaj Ekleme";
      ((System.ComponentModel.ISupportInitialize)(this.edtKontrolBarkod.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdEklenenAmbalajlar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdEklenenAmbalajlarView)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.LabelControl lblUrunDogrulamaBarkod;
    private DevExpress.XtraEditors.TextEdit edtKontrolBarkod;
    private DevExpress.XtraGrid.GridControl grdEklenenAmbalajlar;
    private DevExpress.XtraGrid.Views.Grid.GridView grdEklenenAmbalajlarView;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
  }
}