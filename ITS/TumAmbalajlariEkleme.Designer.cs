namespace ITS
{
  partial class TumAmbalajlariEkleme
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TumAmbalajlariEkleme));
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.btnOnayla = new DevExpress.XtraEditors.SimpleButton();
      this.ımageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
      this.dgvUretimEmirleri = new System.Windows.Forms.DataGridView();
      this.Sec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.UretimEmriNumarasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.OlusturulanKodAdedi = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.BasilanKodAdedi = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.BasilmayanKodAdedi = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Durumu = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.VerileriYenile = new System.Windows.Forms.DataGridViewImageColumn();
      ((System.ComponentModel.ISupportInitialize)(this.ımageCollection1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvUretimEmirleri)).BeginInit();
      this.SuspendLayout();
      // 
      // btnOnayla
      // 
      this.btnOnayla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnOnayla.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.btnOnayla.Appearance.Options.UseFont = true;
      this.btnOnayla.ImageIndex = 0;
      this.btnOnayla.ImageList = this.ımageCollection1;
      this.btnOnayla.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
      this.btnOnayla.Location = new System.Drawing.Point(8, 202);
      this.btnOnayla.Name = "btnOnayla";
      this.btnOnayla.Size = new System.Drawing.Size(594, 40);
      this.btnOnayla.TabIndex = 4;
      this.btnOnayla.Text = "Seçili Üretimlerin Tüm Ambalajlarını İTS Sistemine Ekle";
      this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
      // 
      // ımageCollection1
      // 
      this.ımageCollection1.ImageSize = new System.Drawing.Size(22, 22);
      this.ımageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ımageCollection1.ImageStream")));
      this.ımageCollection1.Images.SetKeyName(0, "button_accept.png");
      this.ımageCollection1.Images.SetKeyName(1, "button_cancel.png");
      // 
      // dgvUretimEmirleri
      // 
      this.dgvUretimEmirleri.AllowUserToAddRows = false;
      this.dgvUretimEmirleri.AllowUserToDeleteRows = false;
      this.dgvUretimEmirleri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvUretimEmirleri.BackgroundColor = System.Drawing.SystemColors.Info;
      this.dgvUretimEmirleri.BorderStyle = System.Windows.Forms.BorderStyle.None;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvUretimEmirleri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dgvUretimEmirleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvUretimEmirleri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sec,
            this.UretimEmriNumarasi,
            this.OlusturulanKodAdedi,
            this.BasilanKodAdedi,
            this.BasilmayanKodAdedi,
            this.Durumu,
            this.VerileriYenile});
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvUretimEmirleri.DefaultCellStyle = dataGridViewCellStyle2;
      this.dgvUretimEmirleri.Location = new System.Drawing.Point(8, 8);
      this.dgvUretimEmirleri.Name = "dgvUretimEmirleri";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvUretimEmirleri.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
      this.dgvUretimEmirleri.RowHeadersVisible = false;
      this.dgvUretimEmirleri.Size = new System.Drawing.Size(594, 183);
      this.dgvUretimEmirleri.TabIndex = 3;
      this.dgvUretimEmirleri.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUretimEmirleri_CellClick);
      // 
      // Sec
      // 
      this.Sec.FillWeight = 30F;
      this.Sec.HeaderText = "Seç";
      this.Sec.Name = "Sec";
      // 
      // UretimEmriNumarasi
      // 
      this.UretimEmriNumarasi.DataPropertyName = "order_id";
      this.UretimEmriNumarasi.HeaderText = "Üretim Emri Numarası";
      this.UretimEmriNumarasi.Name = "UretimEmriNumarasi";
      this.UretimEmriNumarasi.ReadOnly = true;
      // 
      // OlusturulanKodAdedi
      // 
      this.OlusturulanKodAdedi.DataPropertyName = "created_usc_count";
      this.OlusturulanKodAdedi.HeaderText = "Oluşturulan Kod Adedi";
      this.OlusturulanKodAdedi.Name = "OlusturulanKodAdedi";
      this.OlusturulanKodAdedi.ReadOnly = true;
      // 
      // BasilanKodAdedi
      // 
      this.BasilanKodAdedi.DataPropertyName = "package_count";
      this.BasilanKodAdedi.HeaderText = "Basılan Kod Adedi";
      this.BasilanKodAdedi.Name = "BasilanKodAdedi";
      this.BasilanKodAdedi.ReadOnly = true;
      // 
      // BasilmayanKodAdedi
      // 
      this.BasilmayanKodAdedi.DataPropertyName = "diff";
      this.BasilmayanKodAdedi.HeaderText = "Basılmayan Kod Adedi";
      this.BasilmayanKodAdedi.Name = "BasilmayanKodAdedi";
      this.BasilmayanKodAdedi.ReadOnly = true;
      this.BasilmayanKodAdedi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.BasilmayanKodAdedi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Durumu
      // 
      this.Durumu.DataPropertyName = "order_status";
      this.Durumu.HeaderText = "Durumu";
      this.Durumu.Name = "Durumu";
      this.Durumu.ReadOnly = true;
      // 
      // VerileriYenile
      // 
      this.VerileriYenile.FillWeight = 32F;
      this.VerileriYenile.HeaderText = "Yen.";
      this.VerileriYenile.Image = global::ITS.Properties.Resources.kaboodleloop;
      this.VerileriYenile.Name = "VerileriYenile";
      // 
      // TumAmbalajlariEkleme
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(607, 254);
      this.Controls.Add(this.dgvUretimEmirleri);
      this.Controls.Add(this.btnOnayla);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TumAmbalajlariEkleme";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Tüm Ambalajları Ekleme";
      this.Shown += new System.EventHandler(this.TumAmbalajlariEkleme_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.ımageCollection1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvUretimEmirleri)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton btnOnayla;
    private DevExpress.Utils.ImageCollection ımageCollection1;
    private System.Windows.Forms.DataGridView dgvUretimEmirleri;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Sec;
    private System.Windows.Forms.DataGridViewTextBoxColumn UretimEmriNumarasi;
    private System.Windows.Forms.DataGridViewTextBoxColumn OlusturulanKodAdedi;
    private System.Windows.Forms.DataGridViewTextBoxColumn BasilanKodAdedi;
    private System.Windows.Forms.DataGridViewTextBoxColumn BasilmayanKodAdedi;
    private System.Windows.Forms.DataGridViewTextBoxColumn Durumu;
    private System.Windows.Forms.DataGridViewImageColumn VerileriYenile;
  }
}