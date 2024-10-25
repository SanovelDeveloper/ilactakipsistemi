namespace ITS
{
  partial class UretimBildirimRaporu
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
      Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
      this.Production_Decalaration_ReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.dstUretimBildirimRaporu = new ITS.dstUretimBildirimRaporu();
      this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
      this.production_Decalaration_ReportTableAdapter = new ITS.dstUretimBildirimRaporuTableAdapters.Production_Decalaration_ReportTableAdapter();
      ((System.ComponentModel.ISupportInitialize)(this.Production_Decalaration_ReportBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dstUretimBildirimRaporu)).BeginInit();
      this.SuspendLayout();
      // 
      // Production_Decalaration_ReportBindingSource
      // 
      this.Production_Decalaration_ReportBindingSource.DataMember = "Production_Decalaration_Report";
      this.Production_Decalaration_ReportBindingSource.DataSource = this.dstUretimBildirimRaporu;
      // 
      // dstUretimBildirimRaporu
      // 
      this.dstUretimBildirimRaporu.DataSetName = "dstUretimBildirimRaporu";
      this.dstUretimBildirimRaporu.EnforceConstraints = false;
      this.dstUretimBildirimRaporu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // reportViewer1
      // 
      this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
      reportDataSource1.Name = "dstUretimBildirimRaporu_Production_Decalaration_Report";
      reportDataSource1.Value = this.Production_Decalaration_ReportBindingSource;
      this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
      this.reportViewer1.LocalReport.ReportEmbeddedResource = "ITS.UretimBildirimRaporu.rdlc";
      this.reportViewer1.Location = new System.Drawing.Point(0, 0);
      this.reportViewer1.Name = "reportViewer1";
      this.reportViewer1.ShowBackButton = false;
      this.reportViewer1.ShowDocumentMapButton = false;
      this.reportViewer1.ShowFindControls = false;
      this.reportViewer1.ShowPromptAreaButton = false;
      this.reportViewer1.Size = new System.Drawing.Size(638, 667);
      this.reportViewer1.TabIndex = 0;
      // 
      // production_Decalaration_ReportTableAdapter
      // 
      this.production_Decalaration_ReportTableAdapter.ClearBeforeFill = true;
      // 
      // UretimBildirimRaporu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(638, 667);
      this.Controls.Add(this.reportViewer1);
      this.Name = "UretimBildirimRaporu";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Üretim Bildirim Raporu";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.UretimBildirimRaporu_Load);
      ((System.ComponentModel.ISupportInitialize)(this.Production_Decalaration_ReportBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dstUretimBildirimRaporu)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    private System.Windows.Forms.BindingSource Production_Decalaration_ReportBindingSource;
    private dstUretimBildirimRaporu dstUretimBildirimRaporu;
    private ITS.dstUretimBildirimRaporuTableAdapters.Production_Decalaration_ReportTableAdapter production_Decalaration_ReportTableAdapter;
  }
}