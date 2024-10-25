using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using LINQ;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ITS
{
    partial class CariGLNListesi : Form
    {
        public string customergln;
        private IContainer components = (IContainer)null;
        private GroupControl grpCariListeArama;
        private GridControl grdCariGlnListesi;
        private GridView grdCariGlnListesiView;
        private GridColumn gridColumnamr_account_code;
        private GridColumn gridColumnamr_account_name;
        private GridColumn gridColumnamr_gln_number;
        private GridColumn gridColumnamr_branch_gln_number;
        private GridColumn gridColumncountry;
        private GridColumn gridColumnamr_id;
        private LabelControl labelControl1;
        private TextEdit edtUlke;
        private LabelControl labelControl2;
        private TextEdit edtGLNKodu;
        private TextEdit edtCariAdi;
        private LabelControl labelControl30;
        private TextEdit edtCariKodu;
        private SimpleButton btnArama;
        private SimpleButton btnTemizle;

        public CariGLNListesi()
        {
            this.InitializeComponent();
            this.customergln = "";
        }

        private void Listele(
          string account_code,
          string account_name,
          string gln_number,
          string country)
        {
            ITSDataContext itsDataContext1 = new ITSDataContext(Global.ITSConnectionString);
            itsDataContext1.CommandTimeout = 120000;
            using (ITSDataContext itsDataContext2 = itsDataContext1)
                this.grdCariGlnListesi.DataSource = (object)itsDataContext2.Account_Master_Browse(account_code, account_name, gln_number, country).ToList<Account_Master_BrowseResult>();
        }

        private void CariGLNListesi_Load(object sender, EventArgs e)
        {
            this.customergln = "";
            this.Listele((string)null, (string)null, (string)null, (string)null);
        }

        private void btnTemizle_Click(object sender, EventArgs e) => this.Listele((string)null, (string)null, (string)null, (string)null);

        private void btnArama_Click(object sender, EventArgs e) => this.Listele(this.edtCariKodu.Text, this.edtCariAdi.Text, this.edtGLNKodu.Text, this.edtUlke.Text);

        private void grdCariGlnListesi_DoubleClick(object sender, EventArgs e)
        {
            foreach (int selectedRow in this.grdCariGlnListesiView.GetSelectedRows())
            {
                if (selectedRow >= 0)
                    this.customergln = this.grdCariGlnListesiView.GetRowCellValue(selectedRow, this.grdCariGlnListesiView.Columns[2]).ToString();
            }
            this.Close();
        }

        private void EdtCariKodu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            this.Listele(this.edtCariKodu.Text, this.edtCariAdi.Text, this.edtGLNKodu.Text, this.edtUlke.Text);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpCariListeArama = new GroupControl();
            this.btnArama = new SimpleButton();
            this.btnTemizle = new SimpleButton();
            this.labelControl1 = new LabelControl();
            this.edtUlke = new TextEdit();
            this.labelControl2 = new LabelControl();
            this.edtGLNKodu = new TextEdit();
            this.edtCariAdi = new TextEdit();
            this.labelControl30 = new LabelControl();
            this.edtCariKodu = new TextEdit();
            this.grdCariGlnListesi = new GridControl();
            this.grdCariGlnListesiView = new GridView();
            this.gridColumnamr_account_code = new GridColumn();
            this.gridColumnamr_account_name = new GridColumn();
            this.gridColumnamr_branch_gln_number = new GridColumn();
            this.gridColumnamr_gln_number = new GridColumn();
            this.gridColumncountry = new GridColumn();
            this.gridColumnamr_id = new GridColumn();
            this.grpCariListeArama.BeginInit();
            this.grpCariListeArama.SuspendLayout();
            this.edtUlke.Properties.BeginInit();
            this.edtGLNKodu.Properties.BeginInit();
            this.edtCariAdi.Properties.BeginInit();
            this.edtCariKodu.Properties.BeginInit();
            this.grdCariGlnListesi.BeginInit();
            this.grdCariGlnListesiView.BeginInit();
            this.SuspendLayout();
            this.grpCariListeArama.Controls.Add((Control)this.btnArama);
            this.grpCariListeArama.Controls.Add((Control)this.btnTemizle);
            this.grpCariListeArama.Controls.Add((Control)this.labelControl1);
            this.grpCariListeArama.Controls.Add((Control)this.edtUlke);
            this.grpCariListeArama.Controls.Add((Control)this.labelControl2);
            this.grpCariListeArama.Controls.Add((Control)this.edtGLNKodu);
            this.grpCariListeArama.Controls.Add((Control)this.edtCariAdi);
            this.grpCariListeArama.Controls.Add((Control)this.labelControl30);
            this.grpCariListeArama.Controls.Add((Control)this.edtCariKodu);
            this.grpCariListeArama.Dock = DockStyle.Top;
            this.grpCariListeArama.Location = new Point(0, 0);
            this.grpCariListeArama.Name = "grpCariListeArama";
            this.grpCariListeArama.Size = new Size(787, 96);
            this.grpCariListeArama.TabIndex = 1;
            this.grpCariListeArama.Text = "Arama ";
            this.btnArama.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnArama.Location = new Point(596, 34);
            this.btnArama.Name = "btnArama";
            this.btnArama.Size = new Size(73, 48);
            this.btnArama.TabIndex = 74;
            this.btnArama.Text = "Aramayı\r\nListele";
            this.btnArama.Click += new EventHandler(this.btnArama_Click);
            this.btnTemizle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnTemizle.Location = new Point(686, 34);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new Size(73, 48);
            this.btnTemizle.TabIndex = 73;
            this.btnTemizle.Text = "Aramayı \r\nTemizle";
            this.btnTemizle.Click += new EventHandler(this.btnTemizle_Click);
            this.labelControl1.Location = new Point(324, 64);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(20, 13);
            this.labelControl1.TabIndex = 72;
            this.labelControl1.Text = "Ülke";
            this.edtUlke.Location = new Point(376, 61);
            this.edtUlke.Name = "edtUlke";
            this.edtUlke.Size = new Size(213, 20);
            this.edtUlke.TabIndex = 71;
            this.edtUlke.KeyPress += new KeyPressEventHandler(this.EdtCariKodu_KeyPress);
            this.labelControl2.Location = new Point(13, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(46, 13);
            this.labelControl2.TabIndex = 70;
            this.labelControl2.Text = "GLN Kodu";
            this.edtGLNKodu.Location = new Point(96, 61);
            this.edtGLNKodu.Name = "edtGLNKodu";
            this.edtGLNKodu.Size = new Size(213, 20);
            this.edtGLNKodu.TabIndex = 69;
            this.edtGLNKodu.KeyPress += new KeyPressEventHandler(this.EdtCariKodu_KeyPress);
            this.edtCariAdi.Location = new Point(240, 35);
            this.edtCariAdi.Name = "edtCariAdi";
            this.edtCariAdi.Size = new Size(349, 20);
            this.edtCariAdi.TabIndex = 67;
            this.edtCariAdi.KeyPress += new KeyPressEventHandler(this.EdtCariKodu_KeyPress);
            this.labelControl30.Location = new Point(13, 38);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new Size(71, 13);
            this.labelControl30.TabIndex = 66;
            this.labelControl30.Text = "Cari Kodu / Adı";
            this.edtCariKodu.Location = new Point(96, 35);
            this.edtCariKodu.Name = "edtCariKodu";
            this.edtCariKodu.Size = new Size(140, 20);
            this.edtCariKodu.TabIndex = 65;
            this.edtCariKodu.KeyPress += new KeyPressEventHandler(this.EdtCariKodu_KeyPress);
            this.grdCariGlnListesi.Dock = DockStyle.Fill;
            this.grdCariGlnListesi.Location = new Point(0, 96);
            this.grdCariGlnListesi.MainView = (BaseView)this.grdCariGlnListesiView;
            this.grdCariGlnListesi.Name = "grdCariGlnListesi";
            this.grdCariGlnListesi.Size = new Size(787, 318);
            this.grdCariGlnListesi.TabIndex = 5;
            this.grdCariGlnListesi.ViewCollection.AddRange(new BaseView[1]
            {
        (BaseView) this.grdCariGlnListesiView
            });
            this.grdCariGlnListesi.DoubleClick += new EventHandler(this.grdCariGlnListesi_DoubleClick);
            this.grdCariGlnListesiView.Appearance.ColumnFilterButton.BackColor = Color.FromArgb(236, 232, 201);
            this.grdCariGlnListesiView.Appearance.ColumnFilterButton.BorderColor = Color.FromArgb(236, 232, 201);
            this.grdCariGlnListesiView.Appearance.ColumnFilterButton.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.ColumnFilterButtonActive.BackColor = Color.FromArgb(221, 231, 234);
            this.grdCariGlnListesiView.Appearance.ColumnFilterButtonActive.BorderColor = Color.FromArgb(221, 231, 234);
            this.grdCariGlnListesiView.Appearance.ColumnFilterButtonActive.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.Empty.BackColor = Color.FromArgb(236, 232, 201);
            this.grdCariGlnListesiView.Appearance.Empty.BackColor2 = Color.White;
            this.grdCariGlnListesiView.Appearance.Empty.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.EvenRow.BackColor = Color.FromArgb(221, 231, 234);
            this.grdCariGlnListesiView.Appearance.EvenRow.BorderColor = Color.FromArgb(221, 231, 234);
            this.grdCariGlnListesiView.Appearance.EvenRow.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.EvenRow.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.EvenRow.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.EvenRow.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.FilterCloseButton.BackColor = Color.FromArgb(216, 209, 179);
            this.grdCariGlnListesiView.Appearance.FilterCloseButton.BorderColor = Color.FromArgb(216, 209, 179);
            this.grdCariGlnListesiView.Appearance.FilterCloseButton.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.FilterPanel.BackColor = Color.FromArgb(236, 232, 201);
            this.grdCariGlnListesiView.Appearance.FilterPanel.BackColor2 = Color.White;
            this.grdCariGlnListesiView.Appearance.FilterPanel.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.FixedLine.BackColor = Color.FromArgb(122, 114, 113);
            this.grdCariGlnListesiView.Appearance.FixedLine.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.FocusedCell.BackColor = Color.White;
            this.grdCariGlnListesiView.Appearance.FocusedCell.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.FocusedRow.BackColor = Color.FromArgb(200, 192, 157);
            this.grdCariGlnListesiView.Appearance.FocusedRow.BorderColor = Color.FromArgb(226, 219, 188);
            this.grdCariGlnListesiView.Appearance.FocusedRow.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.FooterPanel.BackColor = Color.FromArgb(216, 209, 170);
            this.grdCariGlnListesiView.Appearance.FooterPanel.BorderColor = Color.FromArgb(216, 209, 170);
            this.grdCariGlnListesiView.Appearance.FooterPanel.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.GroupButton.BackColor = Color.FromArgb(216, 209, 179);
            this.grdCariGlnListesiView.Appearance.GroupButton.BorderColor = Color.FromArgb(216, 209, 179);
            this.grdCariGlnListesiView.Appearance.GroupButton.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.GroupFooter.BackColor = Color.FromArgb(236, 232, 201);
            this.grdCariGlnListesiView.Appearance.GroupFooter.BorderColor = Color.FromArgb(236, 232, 201);
            this.grdCariGlnListesiView.Appearance.GroupFooter.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.GroupPanel.BackColor = Color.FromArgb(246, 242, 213);
            this.grdCariGlnListesiView.Appearance.GroupPanel.BackColor2 = Color.White;
            this.grdCariGlnListesiView.Appearance.GroupPanel.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.GroupRow.BackColor = Color.FromArgb(236, 232, 201);
            this.grdCariGlnListesiView.Appearance.GroupRow.BorderColor = Color.FromArgb(236, 232, 201);
            this.grdCariGlnListesiView.Appearance.GroupRow.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.GroupRow.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.GroupRow.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.HeaderPanel.BackColor = Color.FromArgb(216, 209, 170);
            this.grdCariGlnListesiView.Appearance.HeaderPanel.BorderColor = Color.FromArgb(216, 209, 170);
            this.grdCariGlnListesiView.Appearance.HeaderPanel.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.HideSelectionRow.BackColor = Color.FromArgb(237, 230, 203);
            this.grdCariGlnListesiView.Appearance.HideSelectionRow.BorderColor = Color.FromArgb(237, 230, 203);
            this.grdCariGlnListesiView.Appearance.HideSelectionRow.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.HorzLine.BackColor = Color.FromArgb(216, 209, 170);
            this.grdCariGlnListesiView.Appearance.HorzLine.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.OddRow.BackColor = Color.FromArgb(242, 244, 236);
            this.grdCariGlnListesiView.Appearance.OddRow.BorderColor = Color.FromArgb(242, 244, 236);
            this.grdCariGlnListesiView.Appearance.OddRow.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.OddRow.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.OddRow.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.OddRow.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.Preview.BackColor = Color.FromArgb(251, 252, 247);
            this.grdCariGlnListesiView.Appearance.Preview.Font = new Font("Verdana", 7.5f);
            this.grdCariGlnListesiView.Appearance.Preview.ForeColor = Color.FromArgb(148, 148, 148);
            this.grdCariGlnListesiView.Appearance.Preview.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.Preview.Options.UseFont = true;
            this.grdCariGlnListesiView.Appearance.Preview.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.Row.BackColor = Color.FromArgb(242, 244, 236);
            this.grdCariGlnListesiView.Appearance.Row.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.Row.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.Row.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.RowSeparator.BackColor = Color.FromArgb(236, 232, 201);
            this.grdCariGlnListesiView.Appearance.RowSeparator.BackColor2 = Color.White;
            this.grdCariGlnListesiView.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.SelectedRow.BackColor = Color.FromArgb(221, 215, 188);
            this.grdCariGlnListesiView.Appearance.SelectedRow.BorderColor = Color.FromArgb(237, 230, 203);
            this.grdCariGlnListesiView.Appearance.SelectedRow.ForeColor = Color.Black;
            this.grdCariGlnListesiView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.grdCariGlnListesiView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grdCariGlnListesiView.Appearance.TopNewRow.BackColor = Color.White;
            this.grdCariGlnListesiView.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grdCariGlnListesiView.Appearance.VertLine.BackColor = Color.FromArgb(216, 209, 170);
            this.grdCariGlnListesiView.Appearance.VertLine.Options.UseBackColor = true;
            this.grdCariGlnListesiView.ColumnPanelRowHeight = 32;
            this.grdCariGlnListesiView.Columns.AddRange(new GridColumn[6]
            {
        this.gridColumnamr_account_code,
        this.gridColumnamr_account_name,
        this.gridColumnamr_branch_gln_number,
        this.gridColumnamr_gln_number,
        this.gridColumncountry,
        this.gridColumnamr_id
            });
            this.grdCariGlnListesiView.GridControl = this.grdCariGlnListesi;
            this.grdCariGlnListesiView.Name = "grdCariGlnListesiView";
            this.grdCariGlnListesiView.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
            this.grdCariGlnListesiView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False;
            this.grdCariGlnListesiView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdCariGlnListesiView.OptionsView.EnableAppearanceEvenRow = true;
            this.grdCariGlnListesiView.OptionsView.EnableAppearanceOddRow = true;
            this.grdCariGlnListesiView.OptionsView.ShowGroupPanel = false;
            this.grdCariGlnListesiView.OptionsView.ShowIndicator = false;
            this.gridColumnamr_account_code.Caption = "Cari Kodu";
            this.gridColumnamr_account_code.FieldName = "amr_account_code";
            this.gridColumnamr_account_code.Name = "gridColumnamr_account_code";
            this.gridColumnamr_account_code.OptionsColumn.AllowEdit = false;
            this.gridColumnamr_account_code.Visible = true;
            this.gridColumnamr_account_code.VisibleIndex = 0;
            this.gridColumnamr_account_code.Width = 102;
            this.gridColumnamr_account_name.Caption = "Cari Adı";
            this.gridColumnamr_account_name.FieldName = "amr_account_name";
            this.gridColumnamr_account_name.Name = "gridColumnamr_account_name";
            this.gridColumnamr_account_name.OptionsColumn.AllowEdit = false;
            this.gridColumnamr_account_name.Visible = true;
            this.gridColumnamr_account_name.VisibleIndex = 1;
            this.gridColumnamr_account_name.Width = 267;
            this.gridColumnamr_branch_gln_number.Caption = "GLN";
            this.gridColumnamr_branch_gln_number.FieldName = "amr_branch_gln_number";
            this.gridColumnamr_branch_gln_number.Name = "gridColumnamr_branch_gln_number";
            this.gridColumnamr_branch_gln_number.OptionsColumn.AllowEdit = false;
            this.gridColumnamr_branch_gln_number.Visible = true;
            this.gridColumnamr_branch_gln_number.VisibleIndex = 2;
            this.gridColumnamr_branch_gln_number.Width = 136;
            this.gridColumnamr_gln_number.Caption = "Merkez GLN";
            this.gridColumnamr_gln_number.FieldName = "amr_gln_number";
            this.gridColumnamr_gln_number.Name = "gridColumnamr_gln_number";
            this.gridColumnamr_gln_number.OptionsColumn.AllowEdit = false;
            this.gridColumnamr_gln_number.Visible = true;
            this.gridColumnamr_gln_number.VisibleIndex = 3;
            this.gridColumnamr_gln_number.Width = 136;
            this.gridColumncountry.Caption = "Ülke";
            this.gridColumncountry.FieldName = "country";
            this.gridColumncountry.Name = "gridColumncountry";
            this.gridColumncountry.OptionsColumn.AllowEdit = false;
            this.gridColumncountry.Visible = true;
            this.gridColumncountry.VisibleIndex = 4;
            this.gridColumncountry.Width = 142;
            this.gridColumnamr_id.Caption = "amr_id";
            this.gridColumnamr_id.FieldName = "amr_id";
            this.gridColumnamr_id.Name = "gridColumnamr_id";
            this.gridColumnamr_id.OptionsColumn.AllowEdit = false;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(787, 414);
            this.Controls.Add((Control)this.grdCariGlnListesi);
            this.Controls.Add((Control)this.grpCariListeArama);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = nameof(CariGLNListesi);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Cari Seçim Listesi";
            this.Load += new EventHandler(this.CariGLNListesi_Load);
            this.grpCariListeArama.EndInit();
            this.grpCariListeArama.ResumeLayout(false);
            this.grpCariListeArama.PerformLayout();
            this.edtUlke.Properties.EndInit();
            this.edtGLNKodu.Properties.EndInit();
            this.edtCariAdi.Properties.EndInit();
            this.edtCariKodu.Properties.EndInit();
            this.grdCariGlnListesi.EndInit();
            this.grdCariGlnListesiView.EndInit();
            this.ResumeLayout(false);
        }
    }
}
