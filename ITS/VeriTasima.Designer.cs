namespace ITS
{
    partial class VeriTasima
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
            this.sleTargetAccount = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.sleTargetAccountView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl38 = new DevExpress.XtraEditors.LabelControl();
            this.edtTargetShippingOrderIPTSNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl41 = new DevExpress.XtraEditors.LabelControl();
            this.btnOnayla = new DevExpress.XtraEditors.SimpleButton();
            this.sleTargetAccountamr_account_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sleTargetAccountamr_account_name = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sleTargetAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleTargetAccountView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTargetShippingOrderIPTSNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sleTargetAccount
            // 
            this.sleTargetAccount.Location = new System.Drawing.Point(134, 38);
            this.sleTargetAccount.Name = "sleTargetAccount";
            this.sleTargetAccount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sleTargetAccount.Properties.Appearance.Options.UseFont = true;
            this.sleTargetAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sleTargetAccount.Properties.DisplayMember = "account_name";
            this.sleTargetAccount.Properties.NullText = "";
            this.sleTargetAccount.Properties.PopupFormSize = new System.Drawing.Size(600, 500);
            this.sleTargetAccount.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.sleTargetAccount.Properties.ShowClearButton = false;
            this.sleTargetAccount.Properties.ValueMember = "amr_account_code";
            this.sleTargetAccount.Properties.View = this.sleTargetAccountView;
            this.sleTargetAccount.Size = new System.Drawing.Size(426, 20);
            this.sleTargetAccount.TabIndex = 46;
            // 
            // sleTargetAccountView
            // 
            this.sleTargetAccountView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.sleTargetAccountamr_account_code,
            this.sleTargetAccountamr_account_name});
            this.sleTargetAccountView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.sleTargetAccountView.Name = "sleTargetAccountView";
            this.sleTargetAccountView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.sleTargetAccountView.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl38
            // 
            this.labelControl38.Location = new System.Drawing.Point(20, 41);
            this.labelControl38.Name = "labelControl38";
            this.labelControl38.Size = new System.Drawing.Size(104, 13);
            this.labelControl38.TabIndex = 45;
            this.labelControl38.Text = "Cari Hesap Kodu / Adı";
            // 
            // edtTargetShippingOrderIPTSNumber
            // 
            this.edtTargetShippingOrderIPTSNumber.Location = new System.Drawing.Point(134, 13);
            this.edtTargetShippingOrderIPTSNumber.Name = "edtTargetShippingOrderIPTSNumber";
            this.edtTargetShippingOrderIPTSNumber.Size = new System.Drawing.Size(148, 20);
            this.edtTargetShippingOrderIPTSNumber.TabIndex = 44;
            // 
            // labelControl41
            // 
            this.labelControl41.Location = new System.Drawing.Point(20, 15);
            this.labelControl41.Name = "labelControl41";
            this.labelControl41.Size = new System.Drawing.Size(99, 13);
            this.labelControl41.TabIndex = 43;
            this.labelControl41.Text = "Satış Belge Numarası";
            // 
            // btnOnayla
            // 
            this.btnOnayla.Location = new System.Drawing.Point(566, 35);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(73, 23);
            this.btnOnayla.TabIndex = 47;
            this.btnOnayla.Text = "Onayla";
            this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
            // 
            // sleTargetAccountamr_account_code
            // 
            this.sleTargetAccountamr_account_code.Caption = "Cari Hesap Kodu";
            this.sleTargetAccountamr_account_code.FieldName = "amr_account_code";
            this.sleTargetAccountamr_account_code.Name = "sleTargetAccountamr_account_code";
            this.sleTargetAccountamr_account_code.Visible = true;
            this.sleTargetAccountamr_account_code.VisibleIndex = 0;
            this.sleTargetAccountamr_account_code.Width = 191;
            // 
            // sleTargetAccountamr_account_name
            // 
            this.sleTargetAccountamr_account_name.Caption = "Cari Hesap Adı";
            this.sleTargetAccountamr_account_name.FieldName = "amr_account_name";
            this.sleTargetAccountamr_account_name.Name = "sleTargetAccountamr_account_name";
            this.sleTargetAccountamr_account_name.Visible = true;
            this.sleTargetAccountamr_account_name.VisibleIndex = 1;
            this.sleTargetAccountamr_account_name.Width = 740;
            // 
            // VeriTasima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 70);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.sleTargetAccount);
            this.Controls.Add(this.labelControl38);
            this.Controls.Add(this.edtTargetShippingOrderIPTSNumber);
            this.Controls.Add(this.labelControl41);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VeriTasima";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Veri Taşıma";
            this.Load += new System.EventHandler(this.VeriTasima_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sleTargetAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sleTargetAccountView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTargetShippingOrderIPTSNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit sleTargetAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView sleTargetAccountView;
        private DevExpress.XtraGrid.Columns.GridColumn sleTargetAccountamr_account_code;
        private DevExpress.XtraGrid.Columns.GridColumn sleTargetAccountamr_account_name;
        private DevExpress.XtraEditors.LabelControl labelControl38;
        private DevExpress.XtraEditors.TextEdit edtTargetShippingOrderIPTSNumber;
        private DevExpress.XtraEditors.LabelControl labelControl41;
        private DevExpress.XtraEditors.SimpleButton btnOnayla;

    }
}