/*******************************************************************************/
/*  Copyright (c) 2009 SANOVEL A.Ş.  / bilsis@sanovel.com.tr                   */
/*  All rights reserved.                                                       */
/*                                                                             */
/*  Tanım    : İTS uygulamasının ana ekranıdır.                                */
/*  Amaç     : İTS uygulamasının içersindeki bütün ana fonksiyonları           */
/*             çalıştırmak.                                                    */
/*  Kısıtlar :  -                                                              */
/*                                                                             */
/*  Düzenleme Tarihçesi:                                                       */
/*  Versiyon  Tarih       Kişi     Açıklama                                    */
/*    1.0     15/12/2009  AY       Başlandı.                                   */
/*    1.1     05/01/2012  AY       V2.0.0 geliştirilmeye başlandı.             */
/*    1.2     15/05/2014  EA       V2.1.0 geliştirilmeye başlandı.             */
/*                                                                             */
/*                                                                             */
/*  Açıklama ve Yorumlar:                                                      */
/*                                                                             */
/*                                                                             */
/*  Kısaltmalar:                                                               */
/*  AY : Ali YAZICI                                                            */
/*  EA : Erhan AKARLAR                                                         */
/*******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.IO;
using ITS.UrunDogrulama;
using ITS.UreticiUrunDogrulama;
using ITS.DepoUrunDogrulama;
using ITS.PTSAlma;
using LINQ;
using Functions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using DeclarationServices.VerificationService;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraExport;
using System.Xml.Serialization;
using ITS.Services;
using System.Xml;
using ITS.AgeSoapClass;
using DevExpress.Pdf.Native;

namespace ITS
{
    public partial class main : Form
    {
        private string sBarkod = "";
        public bool bFormKapanamaz = false;
        public main()
        {
            InitializeComponent();

            SetAutoGenerateColumns(this);
        }
        private void SplashScreenViewStatus(bool status)
        {
            if (status)
            {
                this.Cursor = Cursors.WaitCursor;
                SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
            }
            else
            {
                SplashScreenManager.CloseForm();
                this.Cursor = Cursors.Default;
            }
        }
        public class UretimHattiDetayi
        {
            private string sValue;
            private string sDisplayText;

            public UretimHattiDetayi(string sv, string sd)
            {
                sValue = sv;
                sDisplayText = sd;
            }

            public override string ToString()
            {
                return sDisplayText;
            }

            public string Value
            {
                get
                {
                    return sValue;
                }
            }
        }

        public class GecerlilikDurumuDetayi
        {
            private byte sValue;
            private string sDisplayText;

            public GecerlilikDurumuDetayi(byte sv, string sd)
            {
                sValue = sv;
                sDisplayText = sd;
            }

            public override string ToString()
            {
                return sDisplayText;
            }

            public byte Value
            {
                get
                {
                    return sValue;
                }
            }
        }

        public class TumAmbalajlariKontrolParametreleri
        {
            public int SiraNumarasi;
            public int BaslangicId;
            public int KayitAdedi;

            public TumAmbalajlariKontrolParametreleri(int sn, int ka)
            {
                SiraNumarasi = sn;
                BaslangicId = sn * ka;
                KayitAdedi = ka;
            }
        }

        public int iHareketParentID = 0;
        public bool bKapanamaz = false;
        public bool bThreadCalisiyor = false;
        public Settings Settings;
        public static ResourceManager rmMain = new ResourceManager("ITS", Assembly.GetExecutingAssembly());
        public System.Timers.Timer tmrStatus = new System.Timers.Timer();
        public int DogrulamaIcinCalisanThreadSayisi = 0;
        private bool bUDSeriBazindaAmbalaj = false;
        private byte ClickedButton = 0;

        private string strAmrAccountCode = "";
        private string strPTSNumber = "";
        private string strCompanyGLN = "";
        private int intMomAccountId = 0;
        private string strTB073CUSTOMERID = "";
        private string strDbCompanyName = "";
        private int intSiparisMasterSayisi;


        private void SetAutoGenerateColumns(Control Parent)
        {
            foreach (Control ctrl in Parent.Controls)
            {
                if (ctrl.GetType() == typeof(DataGridView))
                {
                    (ctrl as DataGridView).AutoGenerateColumns = false;
                }
                if (ctrl.Controls.Count > 0)
                    SetAutoGenerateColumns(ctrl);
            }
        }

        private void ButtonEnabledChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton btn = (DevExpress.XtraEditors.SimpleButton)sender;

            if (btn.Enabled)
            {
                Control ctrl = btn;
                int k = 0;
                while (1 == 1)
                {
                    k++;
                    ctrl = ctrl.Parent;

                    if (ctrl.GetType() == typeof(DevExpress.XtraTab.XtraTabPage))
                        break;

                    if (k == 10)
                        break;
                }

                if (btn.Tag != null)
                    btn.Enabled = Guvenlik.GuvenlikKontrol(ctrl.Name, Convert.ToInt32(btn.Tag));
                else
                    btn.Enabled = true;
            }
        }

        private void ApplyButtonsSecurity()
        {
            for (int i = 0; i < edtSource.TabPages.Count; i++)
            {
                foreach (Control ctrl1 in edtSource.TabPages[i].Controls)
                {
                    if (ctrl1.GetType() == typeof(DevExpress.XtraEditors.GroupControl) || ctrl1.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
                    {
                        foreach (Control ctrl2 in ctrl1.Controls)
                        {
                            if (ctrl2.GetType() == typeof(DevExpress.XtraEditors.PanelControl))
                            {
                                foreach (Control ctrl3 in ctrl2.Controls)
                                {
                                    if (ctrl3.GetType() == typeof(DevExpress.XtraEditors.SimpleButton))
                                    {
                                        ctrl3.EnabledChanged += new System.EventHandler(ButtonEnabledChanged);
                                        ctrl3.Enabled = true;
                                    }
                                }
                            }

                            if (ctrl2.GetType() == typeof(DevExpress.XtraEditors.SimpleButton))
                            {
                                ctrl2.EnabledChanged += new System.EventHandler(ButtonEnabledChanged);
                                ctrl2.Enabled = true;
                            }
                        }
                    }

                    if (ctrl1.GetType() == typeof(DevExpress.XtraEditors.SimpleButton))
                    {
                        ctrl1.EnabledChanged += new System.EventHandler(ButtonEnabledChanged);
                        ctrl1.Enabled = true;
                    }
                }
            }
        }

        private void UretimDetaylariListesiniYenile()
        {
            if (edtUDUretimEmriNo.Text == "" && !bUDSeriBazindaAmbalaj)
            {
                MessageBox.Show("Lütfen öncelikle Üretim Emri Numarasını girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                edtUDUretimEmriNo.Focus();
                return;
            }

            Cursor = Cursors.WaitCursor;
            SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    if (!bUDSeriBazindaAmbalaj)
                    {
                        btnUDAktarilmayanlariAl.Enabled = true;
                        var tOrderDetail = lITS.Order_Detail(edtUDUretimEmriNo.Text).ToList();

                        if (tOrderDetail.Count == 0)
                            throw new Exception("Kayıt bulunamadı!");

                        var OrderDetail = tOrderDetail.First();

                        edtUDUretimEmriNoPerm.Text = edtUDUretimEmriNo.Text;
                        sleUDMalzemeKoduAdi.Text = String.Format("{0} / {1}", OrderDetail.mmr_item_no, OrderDetail.mmr_item_name);
                        edtUDMalzemeKodu.Text = OrderDetail.mmr_item_no;
                        edtUDSeriTakipNumarasi.Text = OrderDetail.ord_batch_no;
                        edtUDSonKullanmaTarihi.Text = OrderDetail.ord_expiry_date.ToString();
                        edtUDUretimMiktari.Text = OrderDetail.ord_target_quantity.ToString();
                        edtUDUretilenMiktar.Text = OrderDetail.total_package_quantity.ToString();
                        edtUDGonderilecekMiktar.Text = OrderDetail.approval_quantity.ToString();
                        edtUDGonderilmeyecekMiktar.Text = OrderDetail.disapproval_quantity.ToString();
                        edtUDGonderilenMiktar.Text = OrderDetail.sent_quantity.ToString();

                        if (OrderDetail.sscc_found == 1)
                        {
                            lblUDUretilenKoli.Visible = true;
                            edtUDUretilenKoli.Visible = true;
                            edtUDUretilenKoli.Text = OrderDetail.case_quantity.ToString() + " Koli";
                            if (OrderDetail.not_case_quantity.Value > 0)
                                edtUDUretilenKoli.Text += ", " + OrderDetail.not_case_quantity.ToString() + " Adet";
                        }
                        else
                        {
                            lblUDUretilenKoli.Visible = false;
                            edtUDUretilenKoli.Visible = false;
                        }

                        btnYeniAmbalajEkle.Enabled = true;
                        btnTumAmbalajlariAl.Enabled = true;
                        btnTumAmbalajlariOnayliDurumaGetir.Enabled = true;
                        btnAmbalajVerileriniIlkHalineGetir.Enabled = true;

                        int iListelenecekKayitSayisi = Convert.ToInt32(edtListelenecekKayitAdedi.Text);

                        List<Package_List_BrowseResult> tPackageList;

                        if (edtAmbalajKodu.Text.Length > 2 && edtAmbalajKodu.Text.Substring(0, 2) == "00" && edtAmbalajKodu.Text.Length == 20) //SSCC
                            tPackageList = lITS.Package_List_Browse(edtUDUretimEmriNo.Text,
                                                                    null,
                                                                    cbeGecerlilikDurumu.SelectedIndex > -1 ? ((GecerlilikDurumuDetayi)cbeGecerlilikDurumu.SelectedItem).Value : (byte?)null,
                                                                    "",
                                                                    edtAmbalajKodu.Text,
                                                                    null,
                                                                    iListelenecekKayitSayisi).ToList();
                        else
                            tPackageList = lITS.Package_List_Browse(edtUDUretimEmriNo.Text,
                                                                    null,
                                                                    cbeGecerlilikDurumu.SelectedIndex > -1 ? ((GecerlilikDurumuDetayi)cbeGecerlilikDurumu.SelectedItem).Value : (byte?)null,
                                                                    edtAmbalajKodu.Text,
                                                                    "",
                                                                    null,
                                                                    iListelenecekKayitSayisi).ToList();

                        grdAmbalajDetayi.DataSource = tPackageList;
                        grdUretimArkaPlanAmbalajlar.DataSource = lITS.Package_List_Not_Printed_Browse(edtUDUretimEmriNo.Text).ToList();

                        grdAmbalajDetayiSSCC.Visible = (OrderDetail.sscc_found == 1);
                    }
                    else
                    {

                        btnYeniAmbalajEkle.Enabled = false;
                        btnUDAktarilmayanlariAl.Enabled = false;
                        btnTumAmbalajlariAl.Enabled = false;
                        btnTumAmbalajlariOnayliDurumaGetir.Enabled = false;
                        btnAmbalajVerileriniIlkHalineGetir.Enabled = false;

                        int iListelenecekKayitSayisi = Convert.ToInt32(edtListelenecekKayitAdedi.Text);

                        var tPackageList = lITS.Package_List_Browse_For_Production_Detail((cheUruneGoreListele.Checked ? edtUDMalzemeKodu.Text : null),
                                                                                          edtUDSeriTakipNumarasi.Text,
                                                                                          null,
                                                                                          cbeGecerlilikDurumu.SelectedIndex > -1 ? ((GecerlilikDurumuDetayi)cbeGecerlilikDurumu.SelectedItem).Value : (byte?)null,
                                                                                          edtAmbalajKodu.Text,
                                                                                          null,
                                                                                          iListelenecekKayitSayisi).ToList();

                        grdAmbalajDetayi.DataSource = tPackageList;

                        grdUretimArkaPlanAmbalajlar.DataSource = lITS.Package_List_Not_Printed_Browse_For_Production_Detail((cheUruneGoreListele.Checked ? edtUDMalzemeKodu.Text : null),
                                                                                                                            edtUDSeriTakipNumarasi.Text).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnYeniAmbalajEkle.Enabled = false;
                btnTumAmbalajlariAl.Enabled = false;
                btnTumAmbalajlariOnayliDurumaGetir.Enabled = false;
                btnAmbalajVerileriniIlkHalineGetir.Enabled = false;
            }
            finally
            {
                SplashScreenManager.CloseForm();
                Cursor = Cursors.Default;
            }
        }

        private void AmbalajDurumunuOtomatikDegistir()
        {
            if (cheOtomatikDurumuDegistirilsin.Checked)
            {
                if (edtAmbalajKodu.Text.Length > 2 && edtAmbalajKodu.Text.Substring(0, 2) == "00" && edtAmbalajKodu.Text.Length == 20) //SSCC
                    return;

                if (cbeOtomatikDurumDegisimiDurumListesi.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen öncelikle yeni geçerlilik durum bilgisini seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (grdAmbalajDetayiView.RowCount == 0)
                {
                    MessageBox.Show("Filtrelenen ambalaj bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (grdAmbalajDetayiView.RowCount > 1)
                {
                    MessageBox.Show("Filtreleme sonucunda birden fazla kayıt listelendi. Otomatik durum değiştirilmesi yapılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                    {
                        Package_List_BrowseResult Row = (Package_List_BrowseResult)grdAmbalajDetayiView.GetFocusedRow();

                        lITS.Package_List_Update(Row.pck_id,
                                                 ((GecerlilikDurumuDetayi)cbeOtomatikDurumDegisimiDurumListesi.SelectedItem).Value);
                        Row.pck_status_id = ((GecerlilikDurumuDetayi)cbeOtomatikDurumDegisimiDurumListesi.SelectedItem).Value;
                        Row.pst_description = ((GecerlilikDurumuDetayi)cbeOtomatikDurumDegisimiDurumListesi.SelectedItem).ToString();
                        grdAmbalajDetayiView.UpdateCurrentRow();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    edtAmbalajKodu.Text = "";
                    edtAmbalajBarkodu.Text = "";
                    edtAmbalajBarkodu.Focus();
                }
            }
        }

        private void AmbalajDurumuOtomatikDeaktiveEdilsin()
        {
            if (cheOtomatikDeaktiveEdilsin.Checked)
            {
                if (grdDAmbalajDetayiView.RowCount == 0)
                {
                    MessageBox.Show("Filtrelenen ambalaj bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (grdDAmbalajDetayiView.RowCount > 1)
                {
                    MessageBox.Show("Filtreleme sonucunda birden fazla kayıt listelendi. Otomatik durum değiştirilmesi yapılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                    {
                        Package_List_BrowseResult Row = (Package_List_BrowseResult)grdDAmbalajDetayiView.GetFocusedRow();
                        lITS.Package_List_Update(Row.pck_id, 98);
                        Row.pck_status_id = 98;
                        Row.pst_description = "DEAKTİVE EDİLECEK";
                        grdDAmbalajDetayiView.UpdateCurrentRow();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    edtDAmbalajKodu.Text = "";
                    edtDAmbalajBarkodu.Text = "";
                    edtDAmbalajBarkodu.Focus();
                }
            }
        }

        private void DeaktiveIcinUretimDetaylariListesiniYenile()
        {
            if (edtDUretimEmriNumarasi.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Üretim Emri Numarasını girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                edtDUretimEmriNumarasi.Focus();
                return;
            }

            Cursor = Cursors.WaitCursor;
            edtDListelenecekKayitAdedi.Enabled = false;
            edtDAmbalajBarkodu.Enabled = false;
            edtDAmbalajKodu.Enabled = false;
            cbeDGecerlilikDurumu.Enabled = false;
            SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {

                    var tOrderDetail = lITS.Order_Detail(edtDUretimEmriNumarasi.Text).ToList();
                    if (tOrderDetail.Count == 0)
                        throw new Exception("Kayıt bulunamadı!");

                    var OrderDetail = tOrderDetail.First();

                    edtDMalzemeKoduAdi.Text = String.Format("{0} / {1}", OrderDetail.mmr_item_no, OrderDetail.mmr_item_name);
                    edtDSeriTakipNumarasi.Text = OrderDetail.ord_batch_no;
                    edtDSonKullanmaTarihi.Text = OrderDetail.ord_expiry_date.ToString();
                    edtDUretimMiktari.Text = OrderDetail.ord_target_quantity.ToString();
                    edtDUretilenMiktar.Text = OrderDetail.total_package_quantity.ToString();
                    edtDDeaktiveEdilecekMiktar.Text = OrderDetail.deactivation_quantity.ToString();
                    edtDGonderilenMiktar.Text = OrderDetail.sent_quantity.ToString();
                    edtDDeaktiveEdilenMiktar.Text = OrderDetail.made_of_deactivation_quantity.ToString();

                    int iListelenecekKayitSayisi = Convert.ToInt32(edtDListelenecekKayitAdedi.Text);

                    var tPackageList = lITS.Package_List_Browse(edtDUretimEmriNumarasi.Text,
                                                                null,
                                                                cbeDGecerlilikDurumu.SelectedIndex > -1 ? ((GecerlilikDurumuDetayi)cbeDGecerlilikDurumu.SelectedItem).Value : (byte?)null,
                                                                edtDAmbalajKodu.Text,
                                                                "",
                                                                null,
                                                                iListelenecekKayitSayisi).ToList();

                    grdDAmbalajDetayi.DataSource = tPackageList;
                    btnTumSeriDeaktiveEdilsin.Enabled = (tPackageList.Count > 0);
                    btnDeaktivasyonBildirimi.Enabled = (tPackageList.Count > 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SplashScreenManager.CloseForm();
                Cursor = Cursors.Default;
                edtDListelenecekKayitAdedi.Enabled = true;
                edtDAmbalajBarkodu.Enabled = true;
                edtDAmbalajKodu.Enabled = true;
                cbeDGecerlilikDurumu.Enabled = true;
            }

        }


        private void Main_Load(object sender, EventArgs e)
        {
            Settings = new Settings(Global.Environment);

            for (int i = 0; i < edtSource.TabPages.Count; i++)
            {
                if (edtSource.TabPages[i].Tag != null && edtSource.TabPages[i].Tag.ToString() == "99")
                    continue;

                edtSource.TabPages[i].PageVisible = Guvenlik.GuvenlikKontrol(edtSource.TabPages[i].Name, Guvenlik.Yetkiler.KayitOkuma);
            }

            tbpProductionOrderInsertSettings.PageVisible = Guvenlik.GuvenlikKontrol("tbpUretimEmriEkleme", Guvenlik.Yetkiler.KayitEkleme);
            tbpSystemSettings.PageVisible = Global.SuperVisor;

            ApplyButtonsSecurity();
            Control.CheckForIllegalCrossThreadCalls = false;

            if (Global.Environment == 'T')
                this.Text = this.Text + " [TEST ORTAMI]";

            lblSurum.Text = "Sürüm " + Application.ProductVersion.Substring(0, Application.ProductVersion.Length - 2);
            tmrStatus.Elapsed += new System.Timers.ElapsedEventHandler(tmrStatus_Elapsed);
            tmrStatus.Interval = 3000;
            sstMain.Items[0].Width = this.Width - 150;
            sstMain.Items[1].Text = DateTime.Now.ToString();
            pnlHakkinda.Left = (tbpHakkinda.Width - pnlHakkinda.Width) / 2;
            pnlHakkinda.Top = (tbpHakkinda.Height - pnlHakkinda.Height) / 2;

            grdProductionOrderInsertSettings.DataSource = new ITSDataContext(Global.ITSConnectionString).Production_Order_Insert_Settings.OrderBy(p => p.pos_min);

            Application.DoEvents();
            SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
            conITS.Open();

            try
            {
                SqlCommand scmData = new SqlCommand() { Connection = conITS, CommandText = "SELECT pst_status_id, pst_description FROM Package_Status", CommandType = CommandType.Text };
                SqlDataReader sdrData = scmData.ExecuteReader();
                while (sdrData.Read())
                {
                    cbeGecerlilikDurumu.Properties.Items.Add(new GecerlilikDurumuDetayi(Convert.ToByte(sdrData["pst_status_id"]), sdrData["pst_description"].ToString()));
                    cbeDGecerlilikDurumu.Properties.Items.Add(new GecerlilikDurumuDetayi(Convert.ToByte(sdrData["pst_status_id"]), sdrData["pst_description"].ToString()));
                    cbeOtomatikDurumDegisimiDurumListesi.Properties.Items.Add(new GecerlilikDurumuDetayi(Convert.ToByte(sdrData["pst_status_id"]), sdrData["pst_description"].ToString()));
                }

                sdrData.Close();
            }
            finally
            {
                conITS.Close();
            }



            btnUretimBildirimi.Enabled = false;
            btnSeciliUretimleinBildirimleriniZamanla.Enabled = false;
            btnTumSeriDeaktiveEdilsin.Enabled = false;
            btnTumDeaktivastyonBildirimleriniYap.Enabled = false;
            btnDeaktivasyonBildirimi.Enabled = false;
            btnSeciliPTSSatislarinBildiriminiYap.Enabled = false;
            btnPTSBildirimleriniZamanla.Enabled = false;
            btnSeciliSatisBildirimleriniZamanla.Enabled = false;
            btnSeciliSatisBildirimleriniYap.Enabled = false;
            btnShippingOrderIScheduledDeclaration.Enabled = false;
            btnShippingOrderIDeclarationNow.Enabled = false;
            btnSatisDetayAmbalajEkle.Enabled = true;
            btnSatisIptalOlustur.Enabled = false;
            btnUrunDogrulama.Enabled = false;
            btnYeniAmbalajEkle.Enabled = false;
            btnUDAktarilmayanlariAl.Enabled = false;
            btnTumAmbalajlariAl.Enabled = false;
            btnTumAmbalajlariOnayliDurumaGetir.Enabled = false;
            btnAmbalajVerileriniIlkHalineGetir.Enabled = false;
            btnSatisIptalBildirimiYap.Enabled = false;
            btnSiparisTransfer_SiparisleriTTSGonder.Enabled = false;
            btnSiparisTransfer_SiparisleriAGEGonder.Enabled = false;
            btnPTSAktar.Enabled = false;
            btnPTSSil.Enabled = false;

            btnLeatusaGonderilecekPaketListesineAitUretimEmirleriniGetir.Enabled = false;
            btnPaketListesiniLeatusaGonder.Enabled = false;




            sleUDMalzemeKoduAdi.Properties.DataSource = new ITSDataContext(Global.ITSConnectionString).Order_List_Browse_For_Search().ToList();
            sleSatisIptalYeniCari.Properties.DataSource = new ITSDataContext(Global.ITSConnectionString).vAccount_Masters.ToList();
            slePTSKontrolDocumentNumber.Properties.DataSource = new ITSDataContext(Global.ITSConnectionString).Receiving_Thirdparty_Packages_Master_Browse().ToList();
            slePTSSenderCompany.Properties.DataSource = new ITSDataContext(Global.ITSConnectionString).vAccount_Masters.ToList();
            slePTSReceiverCompany.Properties.DataSource = new ITSDataContext(Global.ITSConnectionString).Group_Company_Sales_Company_Browse().ToList();

            cbeTTSSistemi.SelectedIndex = 1;

            ServicePointManager.Expect100Continue = false;

            SplashScreenManager.CloseForm();
        }

        void tmrStatus_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            sstMain.Items[0].Text = "";
            sstMain.Items[0].Image = null;
            tmrStatus.Stop();
        }

        #region Genel

        private void tbcMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tbpGuvenlik)
            {
                SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
                SqlConnection conMES = new SqlConnection(Global.MESConnectionString);
                conITS.Open();
                conMES.Open();

                try
                {
                    SqlCommand scmData = new SqlCommand();
                    scmData.Connection = conITS;
                    scmData.CommandText = "SELECT fun_id, fun_description FROM Functions WHERE fun_is_active = 1";
                    scmData.CommandType = CommandType.Text;
                    SqlDataAdapter sdaFonksiyonlar = new SqlDataAdapter(scmData);
                    DataSet dsFonksiyonlar = new DataSet();
                    sdaFonksiyonlar.Fill(dsFonksiyonlar, "Fonksiyonlar");

                    dgvFonksiyonListesi.DataSource = dsFonksiyonlar.Tables[0];

                    scmData.Connection = conMES;
                    scmData.CommandText = "Users_Browse_For_ITS;1";
                    scmData.CommandType = CommandType.StoredProcedure;
                    scmData.Parameters.Clear();
                    scmData.Parameters.Add(new SqlParameter("@show_all", Convert.ToSingle(0)));
                    SqlDataAdapter sdaKullanicilar = new SqlDataAdapter(scmData);
                    DataSet dsKullanicilar = new DataSet();
                    sdaKullanicilar.Fill(dsKullanicilar, "Kullanicilar");

                    dgvKullaniciListesi.DataSource = dsKullanicilar.Tables[0];

                    if (dgvKullaniciListesi.SelectedRows.Count > 0)
                        dgvKullaniciListesi.SelectedRows[0].Selected = false;

                    if (dgvFonksiyonListesi.SelectedRows.Count > 0)
                        dgvFonksiyonListesi.SelectedRows[0].Selected = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    conMES.Close();
                    conITS.Close();
                }
            }
            else if (e.Page == tbpAyarlar)
            {
                edtUretimBildirimi.Text = Settings.Services.Production;
                edtDeaktivasyonBildirimi.Text = Settings.Services.Deactivation;
                edtIhracatBildirimi.Text = Settings.Services.Export;
                edtSatisBildirimi.Text = Settings.Services.Sales;
                edtSatisIptalBildirimi.Text = Settings.Services.CancelSales;
                edtUrunDogrulamaBildirimi.Text = Settings.Services.Confirmation;
                edtPTSBildirimi.Text = Settings.Services.PTSSend;
                edtPTSAlmaBildirimi.Text = Settings.Services.PTSReceive;
                edtPTSTransferBilgileriBildirimi.Text = Settings.Services.PTSTransferHelper;

                edtSanovelGLN.Text = Settings.Security.SanovelGLN;
                edtSanovelUser.Text = Settings.Security.SanovelUser;
                edtITSSifreSanovel.Text = Settings.Security.SanovelPassword;
                edtAsetGLN.Text = Settings.Security.AsetGLN;
                edtAsetUser.Text = Settings.Security.AsetUser;
                edtITSSifreAset.Text = Settings.Security.AsetPassword;
                edtAdilnaGLN.Text = Settings.Security.AdilnaGLN;
                edtAdilnaUser.Text = Settings.Security.AdilnaUser;
                edtITSSifreAdilna.Text = Settings.Security.AdilnaPassword;

                edtGelenDosya.Text = Settings.Directory.Incoming;
                edtGidenDosya.Text = Settings.Directory.Outgoing;
                edtGeciciDosya.Text = Settings.Directory.Temp;

                edtProxy.Text = Settings.ProxyAddress;
                edtProxyPort.Text = Settings.ProxyPort;
                edtDeclarationCount.Text = Settings.DeclarationCount.ToString();
            }
        }


        #endregion


        #region TabPage Üretim Emri Ekleme

        private void btnUretimEmirleriniGetir_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdWMSUretimEmirleri.DataSource = lITS.WMS_Production_Order_Browse().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnUretimEmriniGonder.Enabled = (grdWMSUretimEmirleriView.RowCount > 0);
            }
        }
        private void btnUretimEmriniGonder_Click(object sender, EventArgs e)
        {

            if (!this.UretimEmriAlanKontrolu(1))
                return;
            this.btnUretimEmriniGonder.Height = 76;
            try
            {
                this.UretimEmriAc(1);
            }
            finally
            {
                this.btnUretimEmriniGonder.Height = 100;
                this.btnUretimEmirleriniGetir_Click(sender, e);
            }
            btnUretimEmirleriniGetir_Click(sender, e);
        }
        private void btnEkstraUretimEmriOlustur_Click(object sender, EventArgs e)
        {
            //TTS Sisteminde Ekstra Üretim Emri Oluştur
            using (TTSdeEkstraUretimEmriOlustur frmTTSdeEkstraUretimEmriOlustur = new TTSdeEkstraUretimEmriOlustur())
            {
                frmTTSdeEkstraUretimEmriOlustur.ShowDialog(this);
            }
        }
        private void btnUretimEmriniFarmakodGonder_Click(object sender, EventArgs e)
        {
            if (!this.UretimEmriAlanKontrolu(2))
                return;
            using (CariGLNListesi cariGlnListesi = new CariGLNListesi())
            {
                int num = (int)cariGlnListesi.ShowDialog();
                this.strCompanyGLN = "";
                if (cariGlnListesi.customergln != "")
                {
                    this.strCompanyGLN = cariGlnListesi.customergln;
                    this.btnUretimEmriniFarmakodGonder.Height = 76;

                    this.UretimEmriAc(2);

                    this.btnUretimEmriniFarmakodGonder.Height = 100;
                }
            }
            this.btnUretimEmirleriniGetir_Click(sender, e);
        }
        private void btnUretimEmriniFarmakodYurticiGonder_Click(object sender, EventArgs e)
        {

            if (!this.UretimEmriAlanKontrolu(1))
                return;
            using (CariGLNListesi cariGlnListesi = new CariGLNListesi())
            {
                int num = (int)cariGlnListesi.ShowDialog();
                this.strCompanyGLN = "";
                if (cariGlnListesi.customergln != "")
                {
                    this.strCompanyGLN = cariGlnListesi.customergln;
                    this.btnUretimEmriniFarmakodYurticiGonder.Height = 76;
                    this.UretimEmriAc(3);
                    this.btnUretimEmriniFarmakodYurticiGonder.Height = 100;
                }
            }
            this.btnUretimEmirleriniGetir_Click(sender, e);

        }
        private bool UretimEmriAlanKontrolu(int selectedsystem)
        {
            if (this.grdWMSUretimEmirleriView.RowCount == 0)
            {
                int num = (int)MessageBox.Show("Üretim Emri Listesinde veri bulunamadı, işlem yapılamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (this.edtUretimMiktari.Text == "" || this.edtUretimMiktari.Text == "0")
            {
                int num = (int)MessageBox.Show("Üretim Miktarı boş geçilemez!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (this.edtGTINNumarasi.Text == "")
            {
                int num = (int)MessageBox.Show("GTIN numarası boş geçilemez!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (this.cbeUretimHatti.SelectedIndex == -1 && selectedsystem == 1)
            {
                int num = (int)MessageBox.Show("Üretim hattı boş geçilemez!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (this.dteSonKullanmaTarihi.Text == "")
            {
                int num = (int)MessageBox.Show("Son kullanma tarihi boş geçilemez!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (!this.dteSonKullanmaTarihi.Properties.ReadOnly && this.dteSonKullanmaTarihi.DateTime > this.dteUretimeBaslamaZamani.DateTime.AddMonths(Convert.ToInt32(this.edtRafOmru.Text) + 1))
            {
                int num = (int)MessageBox.Show("Son kullanma tarihi raf ömründen fazla olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (!this.dteSonKullanmaTarihi.Properties.ReadOnly && this.dteSonKullanmaTarihi.DateTime < this.dteUretimeBaslamaZamani.DateTime.AddMonths(Convert.ToInt32(this.edtRafOmru.Text) - 1))
            {
                int num = (int)MessageBox.Show("Son kullanma tarihi raf ömründen az olamaz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (this.cheKolilemeYapilacak.Checked && this.cbeCaseCode.SelectedIndex == -1)
            {
                int num = (int)MessageBox.Show("Kolileme yapılacak ise koli kodu seçimi zorunludur!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (this.cbePakSeviyesi.SelectedIndex != -1 || selectedsystem != 2)
                return true;
            int num1 = (int)MessageBox.Show("Paketleme Seviyesi seçilmemiş, lütfen seçim yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }
        private void UretimEmriAc(int system)
        {
            string empty = string.Empty;
            string maxpackaginglevel = string.Empty;
            this.bFormKapanamaz = true;
            this.SplashScreenViewStatus(true);
            switch (system)
            {
                case 1:
                    try
                    {  //Üretim Emrini TTS Sistemine Gönder
                        string batchOrder = BatchOrderRepository.TTSCreateBatchOrder("itsup", "poins1", this.edtUretimEmriNo.Text, this.edtSeriTakipNo.Text, Convert.ToInt32(((main.UretimHattiDetayi)this.cbeUretimHatti.SelectedItem).Value), 5, "TR", DateTime.Now, this.dteSonKullanmaTarihi.DateTime, "0" + this.edtGTINNumarasi.Text, "", Convert.ToInt32(this.edtUretimMiktari.Text), "", "", this.cheKolilemeYapilacak.Checked ? this.cbeCaseCode.Text : "", "", "", true);
                        if (batchOrder != "FUNCTION PERFORMED")
                        {
                            int num = (int)MessageBox.Show("Üretim emri eklenirken bir hata oluştu. TTS'in verdiği hata: " + batchOrder, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            this.bFormKapanamaz = false;
                            this.SplashScreenViewStatus(false);
                            return;
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        int num = (int)MessageBox.Show(ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.bFormKapanamaz = false;
                        this.SplashScreenViewStatus(false);
                        return;
                    }
                case 2:
                    //Üretim Emrini Farmakod Sistemine Gönder
                    switch (this.cbePakSeviyesi.SelectedIndex)
                    {
                        case 0:
                            maxpackaginglevel = "EA";
                            break;
                        case 1:
                            maxpackaginglevel = "CA";
                            break;
                        case 2:
                            maxpackaginglevel = "PL";
                            break;
                    }
                    try
                    {
                        if (!BatchOrderRepository.FarmakodCreateBatchOrder(this.edtUretimEmriNo.Text, this.strCompanyGLN, this.edtGTINNumarasi.Text, this.edtUretimEmriNo.Text, this.edtSeriTakipNo.Text, this.dteSonKullanmaTarihi.DateTime, DateTime.Now, Convert.ToInt32(this.edtUretimMiktari.Text), maxpackaginglevel, new int?((main.UretimHattiDetayi)this.cbeUretimHatti.SelectedItem == null ? 0 : Convert.ToInt32(((main.UretimHattiDetayi)this.cbeUretimHatti.SelectedItem).Value)), this.dteUretimeBaslamaZamani.DateTime))
                        {
                            this.bFormKapanamaz = false;
                            this.SplashScreenViewStatus(false);
                            return;
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        this.bFormKapanamaz = false;
                        this.SplashScreenViewStatus(false);
                        return;
                    }
                case 3:
                    //Üretim Emrini Farmakod Yurtiçi Sistemine Gönder
                    try
                    {
                        if (!BatchOrderRepository.FarmakodYurtIciAddWorkOrderr(this.edtUretimEmriNo.Text, this.strCompanyGLN, "0" + this.edtGTINNumarasi.Text, this.edtUretimEmriNo.Text, this.edtSeriTakipNo.Text, this.dteSonKullanmaTarihi.DateTime, DateTime.Now, Convert.ToInt32(this.edtUretimMiktari.Text), this.dteUretimeBaslamaZamani.DateTime))
                        {
                            this.bFormKapanamaz = false;
                            this.SplashScreenViewStatus(false);
                            return;
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        this.bFormKapanamaz = false;
                        this.SplashScreenViewStatus(false);
                        return;
                    }
            }
            this.bFormKapanamaz = false;
            this.SplashScreenViewStatus(false);
        }
        private void grdWMSUretimEmirleriView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            WMS_Production_Order_BrowseResult Row = (WMS_Production_Order_BrowseResult)grdWMSUretimEmirleriView.GetRow(e.FocusedRowHandle);

            edtUretimEmriNo.Text = Row.pom_id.ToString();
            edtMalzemeKodu.Text = Row.mmr_item_no.ToString();
            edtMalzemeAdi.Text = Row.mmr_sanovel_material_name.ToString();
            edtSeriTakipNo.Text = Row.pom_supplier_batch_number.ToString();
            edtUretimMiktari.Text = Row.calculated_pom_amount.ToString();
            edtGTINNumarasi.Text = Row.barcode.ToString();
            edtRafOmru.Text = Row.pom_shelf_life.ToString();
            dteUretimeBaslamaZamani.DateTime = Convert.ToDateTime(Row.pom_production_start_date);

            if (Row.expiry_date.HasValue)
            {
                dteSonKullanmaTarihi.DateTime = Convert.ToDateTime(Row.expiry_date);
                dteSonKullanmaTarihi.Properties.ReadOnly = true;
            }
            else
            {
                dteSonKullanmaTarihi.Text = "";
                dteSonKullanmaTarihi.Properties.ReadOnly = false;
            }

            cbeUretimHatti.SelectedIndex = -1;
            cbeTTSSistemi.SelectedIndex = 1;

            using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
            {
                var tCaseList = lITS.Material_Master_Cases_Browse('0' + edtGTINNumarasi.Text).ToList();
                cbeCaseCode.Properties.Items.Clear();
                foreach (var Code in tCaseList)
                {
                    cbeCaseCode.Properties.Items.Add(Code.TB020_GTIN);
                }
            }
            cbeCaseCode.SelectedIndex = 0;
            List<string> pcklevellist = new List<string>();
            pcklevellist.Add("Ürün");
            pcklevellist.Add("Koli");
            pcklevellist.Add("Palet");
            foreach (var item in pcklevellist)
            {
                cbePakSeviyesi.Properties.Items.Add(item);
            }

            cbePakSeviyesi.SelectedIndex = -1;
            // @bilgehan Paket Seviyesi buraya eklenecek 
            // cbePakSeviyesi dropdown dolacak

        }
        /// <summary>
        /// Eski btnUretimEmriniGonder_OLD_Click kullanılmıyor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUretimEmriniGonder_OLD_Click(object sender, EventArgs e)
        {
            if (!this.UretimEmriAlanKontrolu(1))
                return;

            Cursor = Cursors.WaitCursor;
            btnUretimEmriniGonder.Height = 121;
            mpbUretimEmriniGonder.Visible = true;
            bKapanamaz = true;
            Application.DoEvents();

            try
            {
                if (cbeTTSSistemi.SelectedIndex == 0)
                {
                    using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                    {
                        lITS.WMS_Production_Order_Insert_To_TTS(edtUretimEmriNo.Text,
                                                                edtSeriTakipNo.Text,
                                                                Convert.ToInt32(((UretimHattiDetayi)cbeUretimHatti.SelectedItem).Value),
                                                                edtGTINNumarasi.Text,
                                                                Convert.ToInt32(edtUretimMiktari.Text),
                                                                dteUretimeBaslamaZamani.DateTime,
                                                                dteSonKullanmaTarihi.DateTime);
                    }
                }
                else
                  if (cbeTTSSistemi.SelectedIndex == 1)
                {
                    TTS.Main CBO = new ITS.TTS.Main();
                    //CBO.Url = "http://172.16.117.200/TTBOWS2/TTSPlantWebService.asmx";

                    string sResult = CBO.CreateBatchOrder("itsup",
                                                          "poins1",
                                                          edtUretimEmriNo.Text, // order id
                                                          edtSeriTakipNo.Text, // batch no
                                                          Convert.ToInt32(((UretimHattiDetayi)(cbeUretimHatti.SelectedItem)).Value), // üretim bandı
                                                          5,
                                                          "TR",
                                                          DateTime.Now,
                                                          dteSonKullanmaTarihi.DateTime // SKT
                                                          ,
                                                          "0" + edtGTINNumarasi.Text // GTIN 
                                                          ,
                                                          "",
                                                          Convert.ToInt32(edtUretimMiktari.Text) // üretim miktarı
                                                          ,
                                                          "",
                                                          "",
                                                          (cheKolilemeYapilacak.Checked ? cbeCaseCode.Text : "") // sscc icin ürün kodu
                                                          ,
                                                          "",
                                                          "",
                                                          true);

                    if (sResult == "FUNCTION PERFORMED") // ekleme başarılı
                    {
                        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                        {
                            lITS.WMS_Production_Order_Insert_To_TTSV2(edtUretimEmriNo.Text,
                            edtSeriTakipNo.Text,
                            Convert.ToInt32(((UretimHattiDetayi)cbeUretimHatti.SelectedItem).Value),
                            "0" + edtGTINNumarasi.Text,
                            Convert.ToInt32(edtUretimMiktari.Text),
                            dteUretimeBaslamaZamani.DateTime,
                            dteSonKullanmaTarihi.DateTime);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Üretim emri eklenirken bir hata oluştu. TTS'in verdiği hata: " + sResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                btnUretimEmriniGonder.Height = 149;
                mpbUretimEmriniGonder.Visible = false;
                bKapanamaz = false;
                Application.DoEvents();
            }

            btnUretimEmirleriniGetir_Click(sender, e);
        }
        private void btnFiltreyiTemizle_Click(object sender, EventArgs e)
        {
            edtListelenecekKayitAdedi.Text = "1000";
            edtAmbalajKodu.Text = "";
            edtAmbalajBarkodu.Text = "";
            sBarkod = "";
            cbeGecerlilikDurumu.SelectedIndex = -1;

            cheOtomatikDurumuDegistirilsin.Checked = false;
            UretimDetaylariListesiniYenile();
        }

        private void cbeGecerlilikDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            UretimDetaylariListesiniYenile();
        }

        private void edtListelenecekKayitAdedi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                UretimDetaylariListesiniYenile();
        }

        private void edtAmbalajBarkodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 8)
            {
                edtAmbalajBarkodu.Text = "";
                sBarkod = "";
            }
            else
                if (e.KeyValue == 13)
            {
                if (sBarkod.Length > 2
                    && sBarkod.Substring(0, 2) == "00"
                    && sBarkod.Length == 20) // SSCC
                {
                    edtAmbalajKodu.Text = sBarkod;
                }
                else
                {
                    KareKod kkBarkod = new KareKod(sBarkod, 'D');
                    edtAmbalajKodu.Text = kkBarkod.PackageCode;
                }

                UretimDetaylariListesiniYenile();
                edtAmbalajBarkodu.SelectAll();
                sBarkod = "";

                AmbalajDurumunuOtomatikDegistir();
            }
            else
                sBarkod += (char)e.KeyValue;
        }

        private void grdAmbalajDetayiView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.AbsoluteIndex == 1)
            {
                if (grdAmbalajDetayiView.GetRow(e.RowHandle).GetType().Name == "Package_List_BrowseResult")
                {
                    Package_List_BrowseResult Row = (Package_List_BrowseResult)grdAmbalajDetayiView.GetRow(e.RowHandle);
                    if (Row.pck_status_id == 99)
                        e.RepositoryItem = grdAmbalajDetayiAddRep;
                    else
                        e.RepositoryItem = grdAmbalajDetayiDeleteRep;
                }
                else
                    if (grdAmbalajDetayiView.GetRow(e.RowHandle).GetType().Name == "Package_List_Browse_For_Production_DetailResult")
                {
                    Package_List_Browse_For_Production_DetailResult Row = (Package_List_Browse_For_Production_DetailResult)grdAmbalajDetayiView.GetRow(e.RowHandle);

                    if (Row.pck_status_id == 99)
                        e.RepositoryItem = grdAmbalajDetayiAddRep;
                    else
                        e.RepositoryItem = grdAmbalajDetayiDeleteRep;
                }
            }
        }

        private void btnYeniAmbalajEkle_Click(object sender, EventArgs e)
        {
            if (edtUDUretimEmriNoPerm.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Üretim Emri Numarasını girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                edtUDUretimEmriNo.Focus();
                return;
            }

            using (AmbalajEkleme frmAmbalajEkleme = new AmbalajEkleme(edtUDUretimEmriNoPerm.Text))
            {
                frmAmbalajEkleme.ShowDialog(this);
            }
        }

        private void btnUDAktarilmayanlariAl_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnUDAktarilmayanlariAl.Enabled = false;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 1200000 })
                {
                    SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
                    try
                    {
                        lITS.Get_Production_Data_From_TTSV3(edtUDUretimEmriNoPerm.Text);
                    }
                    finally
                    {
                        SplashScreenManager.CloseForm();
                    }

                    UretimDetaylariListesiniYenile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                btnUDAktarilmayanlariAl.Enabled = true;
            }
        }

        private void btnTumAmbalajlariAl_Click(object sender, EventArgs e)
        {
            if (edtUDUretimEmriNoPerm.Text == "")
            {
                MessageBox.Show("Lütfen öncelikle Üretim Emri Numarasını girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                edtUDUretimEmriNo.Focus();
                return;
            }
            using (TumAmbalajlariEkleme frmTumAmbalajlariEkleme = new TumAmbalajlariEkleme(edtUDUretimEmriNoPerm.Text))
            {
                if (frmTumAmbalajlariEkleme.ShowDialog(this) == DialogResult.OK)
                    UretimDetaylariListesiniYenile();
            }

            /*
            string sIBResult = Microsoft.VisualBasic.Interaction.InputBox("Lütfen üretim emri numarasını girin", "Üretim Emri Numarası", edtUDUretimEmriNo.Text, -1, -1);

            if (sIBResult == "") 
            {
              MessageBox.Show("Lütfen üretim emri numarasını girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
            }

            Cursor = Cursors.WaitCursor;
            btnTumAmbalajlariAl.Enabled = false;
      
            SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
            conITS.Open();
      
            try
            {
              SqlCommand scmData = new SqlCommand();
              scmData.CommandTimeout = 600000;       
              scmData.Connection = conITS;
              scmData.CommandText = "Get_All_Data_From_TTS";
              scmData.CommandType = CommandType.StoredProcedure;
              scmData.Parameters.Clear();
              scmData.Parameters.Add(new SqlParameter("@order_id", sIBResult));
              scmData.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
              MessageBox.Show("İşlem esnasında hata oluştu. Hata = " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;        
            }
            finally
            {
              conITS.Close();
              conITS.Dispose();

              btnTumAmbalajlariAl.Enabled = true;
              Cursor = Cursors.Default;
            }

            MessageBox.Show("Girilen üretim emri numarasına ait tüm ambalajlar alındı ve onaylı duruma getirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (edtUDUretimEmriNo.Text == sIBResult) UretimDetaylariListesiniYenile();
            */
        }

        private void btnTumAmbalajlariOnayliDurumaGetir_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnTumAmbalajlariOnayliDurumaGetir.Enabled = false;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    lITS.Package_List_Update_For_All_Packages_Good(edtUDUretimEmriNoPerm.Text);
                    UretimDetaylariListesiniYenile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                btnTumAmbalajlariOnayliDurumaGetir.Enabled = true;
            }
        }

        private void btnAmbalajVerileriniIlkHalineGetir_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnAmbalajVerileriniIlkHalineGetir.Enabled = false;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    lITS.Package_List_Update_First_Status(edtUDUretimEmriNoPerm.Text);
                    UretimDetaylariListesiniYenile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                btnAmbalajVerileriniIlkHalineGetir.Enabled = true;
            }
        }



        #endregion


        #region TabPage AGE Entegrasyon

        #endregion


        #region TabPage Üretim Bildirimi

        #endregion


        #region TabPage Üretim Detayları



        private void edtUDUretimEmriNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (UretimDetayiArama frmUretimDetayiArama = new UretimDetayiArama() { AllowFormSkin = false })
            {
                frmUretimDetayiArama.cbeGecerlilikDurumu.Properties.Items.Assign(cbeGecerlilikDurumu.Properties.Items);
                frmUretimDetayiArama.ShowDialog();

                if (frmUretimDetayiArama.UretimEmriNo != "")
                {
                    edtUDUretimEmriNo.Text = frmUretimDetayiArama.UretimEmriNo;
                    edtAmbalajKodu.Text = frmUretimDetayiArama.AmbalajKodu;
                    bUDSeriBazindaAmbalaj = false;
                    cheUruneGoreListele.Enabled = false;
                    UretimDetaylariListesiniYenile();
                }
            }
        }

        private void edtUDUretimEmriNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bUDSeriBazindaAmbalaj = false;
                cheUruneGoreListele.Enabled = false;
                UretimDetaylariListesiniYenile();
            }
        }

        private void sleUDMalzemeKoduAdi_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (e.CloseMode == DevExpress.XtraEditors.PopupCloseMode.Normal)
            {
                bUDSeriBazindaAmbalaj = true;
                cheUruneGoreListele.Enabled = true;

                Order_List_Browse_For_SearchResult Row = (Order_List_Browse_For_SearchResult)sleUDMalzemeKoduAdiView.GetFocusedRow();
                edtUDSeriTakipNumarasi.Text = Row.ord_batch_no;
                edtUDSonKullanmaTarihi.Text = Row.ord_expiry_date.ToString("d");
                edtUDMalzemeKodu.Text = Row.mmr_item_no;
                edtUDUretimEmriNo.Text = "";
                edtUDUretimEmriNoPerm.Text = "";

                RefreshProductionDetail();
                UretimDetaylariListesiniYenile();
            }
        }

        private void cheUruneGoreListele_CheckedChanged(object sender, EventArgs e)
        {
            RefreshProductionDetail();
            UretimDetaylariListesiniYenile();
        }

        private void edtAmbalajKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UretimDetaylariListesiniYenile();
                AmbalajDurumunuOtomatikDegistir();
            }
        }

        private void cheOtomatikDurumuDegistirilsin_CheckedChanged(object sender, EventArgs e)
        {
            cbeOtomatikDurumDegisimiDurumListesi.Visible = cheOtomatikDurumuDegistirilsin.Checked;
        }

        #endregion


        #region TabPage Deaktivitasyon Bildirimi

        #endregion


        #region TabPage Sipariş Transferleri
        public List<Sales_Invoice_and_Waybill_List_Waiting_For_TTS_ShipmentResult> allCari = new List<Sales_Invoice_and_Waybill_List_Waiting_For_TTS_ShipmentResult>();
        public class OrderWaybillDetail
        {

        }

        private void btnSiparisTransfer_VerileriYenile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 240000 })
                {


                    grdSiparisListesi.DataSource = null;
                    grdSiparisDetayListesi.DataSource = null;
                    var spWaitingForTTSShipment = lITS.Sales_Invoice_and_Waybill_List_Waiting_For_TTS_Shipment().ToList();

                    intSiparisMasterSayisi = spWaitingForTTSShipment.Count();
                    grdSiparisListesi.DataSource = spWaitingForTTSShipment;
                    // grdSiparisListesiView.Focus();
                    if (intSiparisMasterSayisi == 0)
                    {
                        grdSiparisDetayListesi.DataSource = null;
                        btnSiparisTransfer_SiparisleriTTSGonder.Enabled = false;
                        btnSiparisTransfer_SiparisleriAGEGonder.Enabled = false;
                    }
                    else
                    {

                        if (cheTotalOrderWaybill.Checked)
                        {

                            allCari.Clear();
                            int rowHandle = 0;
                            while (grdSiparisListesiView.IsValidRowHandle(rowHandle))
                            {
                                allCari.Add((Sales_Invoice_and_Waybill_List_Waiting_For_TTS_ShipmentResult)grdSiparisListesiView.GetRow(rowHandle));
                                bool isSelected = grdSiparisListesiView.IsRowSelected(rowHandle);
                                rowHandle++;
                            }


                            if (allCari.Count > 0)
                            {

                                List<Sales_Invoice_and_Waybill_Detail_Browse_For_TTS_ShipmentResult> allWaybill = new List<Sales_Invoice_and_Waybill_Detail_Browse_For_TTS_ShipmentResult>();

                                foreach (var item in allCari)
                                {
                                    allWaybill.AddRange((List<Sales_Invoice_and_Waybill_Detail_Browse_For_TTS_ShipmentResult>)lITS.Sales_Invoice_and_Waybill_Detail_Browse_For_TTS_Shipment(item.mom_id.Value).ToList());
                                }
                                grdSiparisDetayListesi.DataSource = allWaybill;
                            }
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSiparisTransfer_VerileriYenile.Enabled = true;
            }
            finally
            {
                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = false;
                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = false;
            }
        }

        private void grdSiparisListesiView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (intSiparisMasterSayisi == 0)
                return;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 240000 })
                {
                    Sales_Invoice_and_Waybill_List_Waiting_For_TTS_ShipmentResult Row = (Sales_Invoice_and_Waybill_List_Waiting_For_TTS_ShipmentResult)grdSiparisListesiView.GetRow(e.FocusedRowHandle);

                    if (Row != null && Row.mom_id.Value > 0)
                    {
                        grdSiparisDetayListesi.DataSource = null;
                        grdSiparisDetayListesi.DataSource = lITS.Sales_Invoice_and_Waybill_Detail_Browse_For_TTS_Shipment(Row.mom_id.Value).ToList();
                        strDbCompanyName = Row.db_company_name.ToString();
                        strAmrAccountCode = Row.amr_account_code.ToString();
                        strPTSNumber = Row.mom_parameter_2.ToString();
                        strCompanyGLN = Row.com_gln_number.ToString();
                        intMomAccountId = Row.mom_account_id.Value;
                        strTB073CUSTOMERID = Row.TB073_CUSTOMER_ID.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = false;
            }
            finally
            {
                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = false;
                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = false;
            }
        }

        private void btnSiparisTransfer_SiparisleriTTSGonder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili siparişler TTS'e aktarılacaktır. Bu işlemin iptali yoktur. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                btnSiparisTransfer_VerileriYenile.Enabled = false;
                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = false;
                SiparisTransferEkle(sender, e, 0);
                btnSiparisTransfer_VerileriYenile.Enabled = true;
                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                //btnSiparisTransfer_VerileriYenile_Click(sender, e);       
            }
            catch
            {
                throw;
            }
        }

        private void btnSiparisTransfer_SiparisleriAGEGonder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili siparişler AGE'ye aktarılacaktır. Bu işlemin iptali yoktur. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                btnSiparisTransfer_VerileriYenile.Enabled = false;
                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = false;
                SiparisTransferEkle(sender, e, 1);
                btnSiparisTransfer_VerileriYenile.Enabled = true;
                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                //btnSiparisTransfer_VerileriYenile_Click(sender, e);       
            }
            catch
            {
                throw;
            }
        }

        private bool SiparisTransferEkle_ForLeatusDB(object sender, EventArgs e, Int16 type)
        {
            Cursor = Cursors.WaitCursor;
            if (type == 0)
            {
                btnSiparisTransfer_SiparisleriTTSGonder.Height = 38;
                mpbSiparisTransfer_ProgressBarTTS.Visible = true;
            }
            else
            {
                btnSiparisTransfer_SiparisleriAGEGonder.Height = 38;
                mpbSiparisTransfer_ProgressBarAGE.Visible = true;
            }

            Application.DoEvents();

            try
            {
                TTS.Main CBO = new ITS.TTS.Main();
                //CBO.Url = "http://172.16.117.200/TTBOWS2/TTSPlantWebService.asmx";

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {


                    var spWaitingForTTSShipment = lITS.Sales_Invoice_and_Waybill_List_Waiting_For_TTS_Shipment().ToList();

                    for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
                    {
                        if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                           && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                        {
                            string SiparisDetayModMomID = grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModMomID).ToString();
                            var tempCari = spWaitingForTTSShipment.FirstOrDefault(m => m.mom_id == Convert.ToInt32(SiparisDetayModMomID));
                            strDbCompanyName = tempCari.db_company_name.ToString();
                            strAmrAccountCode = tempCari.amr_account_code.ToString();
                            strPTSNumber = tempCari.mom_parameter_2.ToString();
                            strCompanyGLN = tempCari.com_gln_number.ToString();
                            intMomAccountId = tempCari.mom_account_id.Value;
                            strTB073CUSTOMERID = tempCari.TB073_CUSTOMER_ID.ToString();

                            var spResult = lITS.Sales_Invoice_and_Waybill_List_Control(strPTSNumber, type).First();

                            if ((type == 0) && (spResult.kontrol == 0))
                            {
                                string sResult = "CreateShippingOrder hatası!";
                                //string sResult = CBO.CreateShippingOrder("itsup",                         //pUserName 
                                //                                         "poins1",                        //pPassword 
                                //                                         strPTSNumber,                    //pOrderId 
                                //                                         "Shipping",                      //pOrderType
                                //                                         true,                            //pIsPromoted
                                //                                         DateTime.Now,                    //pDeliveryTimestamp
                                //                                         "Sell",                          //pOrderKind
                                //                                         "2",                             //pSSCCExtDigit
                                //                                         strCompanyGLN,                   //pSSCCGLNPrefix 
                                //                                         Convert.ToInt32(strTB073CUSTOMERID),//pCustomersId 
                                //                                         null,                            //pCarrier 
                                //                                         null,                            //pTruck 
                                //                                         "ITS Entegrasyonu ile açılmıştır.",//pFreeText1 
                                //                                         null,                            //pFreeText2 
                                //                                         null                             //pFreeText3 
                                //                                         );

                                TB034_WH_OUT_ORDER tB034_WH_OUT_ORDER = new TB034_WH_OUT_ORDER();
                                tB034_WH_OUT_ORDER.TB034_OUT_ORDER_ID = strPTSNumber;
                                tB034_WH_OUT_ORDER.TB034_TYPE = Convert.ToChar("S");
                                tB034_WH_OUT_ORDER.TB034_DELIVERY_TS = DateTime.Now;
                                tB034_WH_OUT_ORDER.TB034_KIND = "Sell";
                                tB034_WH_OUT_ORDER.TB034_CUSTOMER_ID = Convert.ToInt32(strTB073CUSTOMERID);
                                tB034_WH_OUT_ORDER.TB034_FREE_TEXT1 = "ITS Entegrasyonu ile açılmıştır.";
                                tB034_WH_OUT_ORDER.TB034_STATUS = Convert.ToChar("O");
                                tB034_WH_OUT_ORDER.TB034_SCHED_TIMESTAMP = DateTime.Now;
                                tB034_WH_OUT_ORDER.TB034_OPEN_TIMESTAMP = DateTime.Now;
                                tB034_WH_OUT_ORDER.TB034_SSCC_EXT_DIGIT = Convert.ToChar("2"); ;
                                tB034_WH_OUT_ORDER.TB034_SSCC_GLN_PREFIX = strCompanyGLN;




                                //if (sResult == "FUNCTION PERFORMED") // ekleme başarılı
                                if (CreateShippingOrderToTB034_WH_OUT_ORDER(tB034_WH_OUT_ORDER))
                                {

                                    string sDeatilResult = "AddShippingOrderBOM hatası!";

                                    //string sDeatilResult = CBO.AddShippingOrderBOM(
                                    //    "itsup",//pUserName 
                                    //    "poins1",//pPassword 
                                    //    strPTSNumber,//pShippingOrderId 
                                    //    "0" + grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//pGTIN
                                    //    Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()) //pTargetQuantity
                                    //    );

                                    TB135_WH_OUTORDERS_BOM tB135_WH_OUTORDERS_BOM = new TB135_WH_OUTORDERS_BOM();
                                    tB135_WH_OUTORDERS_BOM.TB135_OUT_ORDER_ID = strPTSNumber;
                                    tB135_WH_OUTORDERS_BOM.TB135_GTIN = "0" + grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString();
                                    tB135_WH_OUTORDERS_BOM.TB135_TARGET_QTY = Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString());
                                    tB135_WH_OUTORDERS_BOM.TB135_QUANTITY = 0;
                                    tB135_WH_OUTORDERS_BOM.TB135_COMPLETE = 0;

                                    //if (sDeatilResult == "FUNCTION PERFORMED")
                                    if (AddShippingOrderBOMToTB135_WH_OUTORDERS_BOM(tB135_WH_OUTORDERS_BOM))
                                        // ekleme başarılı
                                        //Entegrasyon SP'si çalıştırılacak...
                                        lITS.ENTEGRASYON_KAYDI_EKLE_TTS(
                                                DateTime.Now,//@PRMENTEGRASYON_TARIHI, 
                                                strAmrAccountCode,//@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                                null,//@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                                strPTSNumber,//@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),//@PRMENTEGRASYON_ID VARCHAR (40), 
                                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),//@PRMENTEGRASYON_LOTNUMARASI VARCHAR(20), 
                                                Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),//@PRMENTEGRASYON_MIKTAR INT, 
                                                strDbCompanyName//@PRMENTEGRASYON_KURUMKODU VARCHAR (13)                                                        
                                                );
                                    else
                                    {
                                        MessageBox.Show("Sipariş detay kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sDeatilResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        btnSiparisTransfer_VerileriYenile.Enabled = true;
                                        btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                        btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                        return false;
                                    }


                                }
                                else
                                {
                                    MessageBox.Show("Sipariş kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Application.DoEvents();
                                    btnSiparisTransfer_VerileriYenile.Enabled = true;
                                    btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                    btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                    return false;
                                }
                            }
                            else if ((type == 0) && (spResult.kontrol == 1))
                            {
                                string sDeatilResult = "AddShippingOrderBOM";

                                //string sDeatilResult = CBO.AddShippingOrderBOM(
                                //    "itsup",//pUserName 
                                //    "poins1",//pPassword 
                                //    strPTSNumber,//pShippingOrderId 
                                //    "0" + grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//pGTIN
                                //    Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString())  //pTargetQuantity
                                //    );
                                TB135_WH_OUTORDERS_BOM tB135_WH_OUTORDERS_BOM = new TB135_WH_OUTORDERS_BOM();
                                tB135_WH_OUTORDERS_BOM.TB135_OUT_ORDER_ID = strPTSNumber;
                                tB135_WH_OUTORDERS_BOM.TB135_GTIN = "0" + grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString();
                                tB135_WH_OUTORDERS_BOM.TB135_TARGET_QTY = Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString());
                                tB135_WH_OUTORDERS_BOM.TB135_QUANTITY = 0;
                                tB135_WH_OUTORDERS_BOM.TB135_COMPLETE = 0;
                                //if (sDeatilResult == "FUNCTION PERFORMED") // ekleme başarılı
                                if (AddShippingOrderBOMToTB135_WH_OUTORDERS_BOM(tB135_WH_OUTORDERS_BOM))
                                {
                                    //Entegrasyon SP'si çalıştırılacak...
                                    lITS.ENTEGRASYON_KAYDI_EKLE_TTS(
                                        DateTime.Now,//@PRMENTEGRASYON_TARIHI, 
                                        strAmrAccountCode,//@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                        null,//@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                        strPTSNumber,//@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                        grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),//@PRMENTEGRASYON_ID VARCHAR (40), 
                                        grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                        grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),//@PRMENTEGRASYON_LOTNUMARASI VARCHAR (20), 
                                        Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),//@PRMENTEGRASYON_MIKTAR INT, 
                                        strDbCompanyName//@PRMENTEGRASYON_KURUMKODU VARCHAR (13)                                                        
                                        );
                                }
                                else
                                {
                                    MessageBox.Show("Sipariş detay kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sDeatilResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    btnSiparisTransfer_VerileriYenile.Enabled = true;
                                    btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                    btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                    return false;
                                }

                            }
                            else if ((type == 1) && (spResult.kontrol == 0))
                            {

                                lITS.ENTEGRASYON_KAYDI_EKLE_AGE(
                                    DateTime.Now,//@PRMENTEGRASYON_TARIHI, 
                                    strAmrAccountCode,//@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                    null,//@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                    strPTSNumber,//@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                    grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),//@PRMENTEGRASYON_ID VARCHAR (40), 
                                    grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                    grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),//@PRMENTEGRASYON_LOTNUMARASI VARCHAR (20), 
                                    Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),//@PRMENTEGRASYON_MIKTAR INT, 
                                    strDbCompanyName//@PRMENTEGRASYON_KURUMKODU VARCHAR (13)
                                    );

                                lITS.ENTEGRASYON_DURUM_GUNCELLE_AGE(
                                    Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString()),//@PRMENTEGRASYON_ID INT,
                                    1 //@PRMENTEGRASYON_DURUM
                                    );

                            }
                            else if (spResult.kontrol == 2)
                            {
                                if (type == 0)
                                    MessageBox.Show("Sipariş detay kaydı TTS sisteminde mevcut, AGE sistemine aktarım yapılamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (type == 1)
                                    MessageBox.Show("Sipariş detay kaydı AGE sisteminde mevcut, TTS sistemine aktarım yapılamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                btnSiparisTransfer_VerileriYenile.Enabled = true;
                                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.DoEvents();
                btnSiparisTransfer_VerileriYenile.Enabled = true;
                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;

                if (type == 0)
                {
                    btnSiparisTransfer_SiparisleriTTSGonder.Height = 57;
                    mpbSiparisTransfer_ProgressBarTTS.Visible = false;
                }
                else
                {
                    btnSiparisTransfer_SiparisleriAGEGonder.Height = 57;
                    mpbSiparisTransfer_ProgressBarAGE.Visible = false;
                }

                Application.DoEvents();
            }

            btnSiparisTransfer_VerileriYenile_Click(sender, e);
            return true;
        }


        #region @bilgehan Leatus sevkiyat masalarının dbsine sevkiyat iş emirlerinin gönderilmesi

        private bool CreateShippingOrderToTB034_WH_OUT_ORDER(TB034_WH_OUT_ORDER tB034_WH_OUT_ORDER)
        {
            bool result = false;

            using (var lTTS = new TTSDataContext() { CommandTimeout = 1200000 })
            {

                try
                {
                    if (tB034_WH_OUT_ORDER != null)
                    {
                        lTTS.TB034_WH_OUT_ORDERs.InsertOnSubmit(tB034_WH_OUT_ORDER);
                        lTTS.SubmitChanges();

                        if (!String.IsNullOrEmpty(tB034_WH_OUT_ORDER.TB034_OUT_ORDER_ID))
                        {
                            result = true;
                        }
                    }

                }
                catch (Exception ex) { result = false; }
            }
            return result;
        }
        private bool AddShippingOrderBOMToTB135_WH_OUTORDERS_BOM(TB135_WH_OUTORDERS_BOM tB135_WH_OUTORDERS_BOM)
        {
            bool result = false;

            using (var lTTS = new TTSDataContext() { CommandTimeout = 1200000 })
            {

                try
                {
                    if (tB135_WH_OUTORDERS_BOM != null)
                    {
                        lTTS.TB135_WH_OUTORDERS_BOMs.InsertOnSubmit(tB135_WH_OUTORDERS_BOM);
                        lTTS.SubmitChanges();

                        if (!String.IsNullOrEmpty(tB135_WH_OUTORDERS_BOM.TB135_OUT_ORDER_ID))
                        {
                            result = true;
                        }
                    }

                }
                catch (Exception ex) { result = false; }
            }
            return result;
        }

        #endregion
        private bool SiparisTransferEkle(object sender, EventArgs e, Int16 type)
        {
            Cursor = Cursors.WaitCursor;
            if (type == 0)
            {
                btnSiparisTransfer_SiparisleriTTSGonder.Height = 38;
                mpbSiparisTransfer_ProgressBarTTS.Visible = true;
            }
            else
            {
                btnSiparisTransfer_SiparisleriAGEGonder.Height = 38;
                mpbSiparisTransfer_ProgressBarAGE.Visible = true;
            }

            Application.DoEvents();

            try
            {
                TTS.Main CBO = new ITS.TTS.Main();
                //CBO.Url = "http://172.16.117.200/TTBOWS2/TTSPlantWebService.asmx";

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {


                    var spWaitingForTTSShipment = lITS.Sales_Invoice_and_Waybill_List_Waiting_For_TTS_Shipment().ToList();

                    for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
                    {
                        if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                           && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                        {
                            string SiparisDetayModMomID = grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModMomID).ToString();
                            var tempCari = spWaitingForTTSShipment.FirstOrDefault(m => m.mom_id == Convert.ToInt32(SiparisDetayModMomID));
                            strDbCompanyName = tempCari.db_company_name.ToString();
                            strAmrAccountCode = tempCari.amr_account_code.ToString();
                            strPTSNumber = tempCari.mom_parameter_2.ToString();
                            strCompanyGLN = tempCari.com_gln_number.ToString();
                            intMomAccountId = tempCari.mom_account_id.Value;
                            strTB073CUSTOMERID = tempCari.TB073_CUSTOMER_ID.ToString();

                            var spResult = lITS.Sales_Invoice_and_Waybill_List_Control(strPTSNumber, type).First();

                            if ((type == 0) && (spResult.kontrol == 0))
                            {
                                string sResult = CBO.CreateShippingOrder("itsup",                         //pUserName 
                                                                         "poins1",                        //pPassword 
                                                                         strPTSNumber,                    //pOrderId 
                                                                         "Shipping",                      //pOrderType
                                                                         true,                            //pIsPromoted
                                                                         DateTime.Now,                    //pDeliveryTimestamp
                                                                         "Sell",                          //pOrderKind
                                                                         "2",                             //pSSCCExtDigit
                                                                         strCompanyGLN,                   //pSSCCGLNPrefix 
                                                                         Convert.ToInt32(strTB073CUSTOMERID),//pCustomersId 
                                                                         null,                            //pCarrier 
                                                                         null,                            //pTruck 
                                                                         "ITS Entegrasyonu ile açılmıştır.",//pFreeText1 
                                                                         null,                            //pFreeText2 
                                                                         null                             //pFreeText3 
                                                                         );

                                if (sResult == "FUNCTION PERFORMED") // ekleme başarılı
                                {

                                    string sDeatilResult = CBO.AddShippingOrderBOM(
                                        "itsup",//pUserName 
                                        "poins1",//pPassword 
                                        strPTSNumber,//pShippingOrderId 
                                        "0" + grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//pGTIN
                                        Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()) //pTargetQuantity
                                        );

                                    if (sDeatilResult == "FUNCTION PERFORMED")
                                        // ekleme başarılı
                                        //Entegrasyon SP'si çalıştırılacak...
                                        lITS.ENTEGRASYON_KAYDI_EKLE_TTS(
                                                DateTime.Now,//@PRMENTEGRASYON_TARIHI, 
                                                strAmrAccountCode,//@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                                null,//@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                                strPTSNumber,//@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),//@PRMENTEGRASYON_ID VARCHAR (40), 
                                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),//@PRMENTEGRASYON_LOTNUMARASI VARCHAR(20), 
                                                Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),//@PRMENTEGRASYON_MIKTAR INT, 
                                                strDbCompanyName//@PRMENTEGRASYON_KURUMKODU VARCHAR (13)                                                        
                                                );
                                    else
                                    {
                                        MessageBox.Show("Sipariş detay kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sDeatilResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        btnSiparisTransfer_VerileriYenile.Enabled = true;
                                        btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                        btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                        return false;
                                    }


                                }
                                else
                                {
                                    MessageBox.Show("Sipariş kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Application.DoEvents();
                                    btnSiparisTransfer_VerileriYenile.Enabled = true;
                                    btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                    btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                    return false;
                                }
                            }
                            else if ((type == 0) && (spResult.kontrol == 1))
                            {

                                string sDeatilResult = CBO.AddShippingOrderBOM(
                                    "itsup",//pUserName 
                                    "poins1",//pPassword 
                                    strPTSNumber,//pShippingOrderId 
                                    "0" + grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//pGTIN
                                    Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString())  //pTargetQuantity
                                    );

                                if (sDeatilResult == "FUNCTION PERFORMED") // ekleme başarılı
                                {
                                    //Entegrasyon SP'si çalıştırılacak...
                                    lITS.ENTEGRASYON_KAYDI_EKLE_TTS(
                                        DateTime.Now,//@PRMENTEGRASYON_TARIHI, 
                                        strAmrAccountCode,//@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                        null,//@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                        strPTSNumber,//@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                        grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),//@PRMENTEGRASYON_ID VARCHAR (40), 
                                        grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                        grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),//@PRMENTEGRASYON_LOTNUMARASI VARCHAR (20), 
                                        Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),//@PRMENTEGRASYON_MIKTAR INT, 
                                        strDbCompanyName//@PRMENTEGRASYON_KURUMKODU VARCHAR (13)                                                        
                                        );
                                }
                                else
                                {
                                    MessageBox.Show("Sipariş detay kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sDeatilResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    btnSiparisTransfer_VerileriYenile.Enabled = true;
                                    btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                    btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                    return false;
                                }

                            }
                            else if ((type == 1) && (spResult.kontrol == 0))
                            {

                                lITS.ENTEGRASYON_KAYDI_EKLE_AGE(
                                    DateTime.Now,//@PRMENTEGRASYON_TARIHI, 
                                    strAmrAccountCode,//@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                    null,//@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                    strPTSNumber,//@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                    grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),//@PRMENTEGRASYON_ID VARCHAR (40), 
                                    grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                    grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),//@PRMENTEGRASYON_LOTNUMARASI VARCHAR (20), 
                                    Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),//@PRMENTEGRASYON_MIKTAR INT, 
                                    strDbCompanyName//@PRMENTEGRASYON_KURUMKODU VARCHAR (13)
                                    );

                                lITS.ENTEGRASYON_DURUM_GUNCELLE_AGE(
                                    Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString()),//@PRMENTEGRASYON_ID INT,
                                    1 //@PRMENTEGRASYON_DURUM
                                    );

                            }
                            else if (spResult.kontrol == 2)
                            {
                                if (type == 0)
                                    MessageBox.Show("Sipariş detay kaydı TTS sisteminde mevcut, AGE sistemine aktarım yapılamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (type == 1)
                                    MessageBox.Show("Sipariş detay kaydı AGE sisteminde mevcut, TTS sistemine aktarım yapılamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                btnSiparisTransfer_VerileriYenile.Enabled = true;
                                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.DoEvents();
                btnSiparisTransfer_VerileriYenile.Enabled = true;
                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;

                if (type == 0)
                {
                    btnSiparisTransfer_SiparisleriTTSGonder.Height = 57;
                    mpbSiparisTransfer_ProgressBarTTS.Visible = false;
                }
                else
                {
                    btnSiparisTransfer_SiparisleriAGEGonder.Height = 57;
                    mpbSiparisTransfer_ProgressBarAGE.Visible = false;
                }

                Application.DoEvents();
            }

            btnSiparisTransfer_VerileriYenile_Click(sender, e);
            return true;
        }

        private void grdSiparisDetayListesiView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Boolean blnkontrol = false;

            for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
            {
                if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                    && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                {
                    btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                    btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                    blnkontrol = true;
                }
            }

            if (blnkontrol == false)
            {
                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = false;
                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = false;
            }
        }

        private void mnuSiparisDetayTumunuSec_TumunuSec_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
            {
                grdSiparisDetayListesiView.SetRowCellValue(i, dgvSiparisDetayChecked, true);
            }
        }

        private void mnuSiparisDetayTumunuSec_TumunuKaldir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
            {
                grdSiparisDetayListesiView.SetRowCellValue(i, dgvSiparisDetayChecked, false);
            }
        }
        private bool SiparisTransferEkleOLD(object sender, EventArgs e, Int16 type)
        {
            Cursor = Cursors.WaitCursor;
            if (type == 0)
            {
                btnSiparisTransfer_SiparisleriTTSGonder.Height = 38;
                mpbSiparisTransfer_ProgressBarTTS.Visible = true;
            }
            else
            {
                btnSiparisTransfer_SiparisleriAGEGonder.Height = 38;
                mpbSiparisTransfer_ProgressBarAGE.Visible = true;
            }

            Application.DoEvents();

            try
            {
                TTS.Main CBO = new ITS.TTS.Main();
                //CBO.Url = "http://172.16.117.200/TTBOWS2/TTSPlantWebService.asmx";

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    var spResult = lITS.Sales_Invoice_and_Waybill_List_Control(strPTSNumber,
                                                                               type).First();

                    if ((type == 0) && (spResult.kontrol == 0))
                    {
                        string sResult = CBO.CreateShippingOrder("itsup",                         //pUserName 
                                                                 "poins1",                        //pPassword 
                                                                 strPTSNumber,                    //pOrderId 
                                                                 "Shipping",                      //pOrderType
                                                                 true,                            //pIsPromoted
                                                                 DateTime.Now,                    //pDeliveryTimestamp
                                                                 "Sell",                          //pOrderKind
                                                                 "2",                             //pSSCCExtDigit
                                                                 strCompanyGLN,                   //pSSCCGLNPrefix 
                                                                 Convert.ToInt32(strTB073CUSTOMERID),                   //pCustomersId 
                                                                 null,                            //pCarrier 
                                                                 null,                            //pTruck 
                                                                 "ITS Entegrasyonu ile açılmıştır.",                    //pFreeText1 
                                                                 null,                            //pFreeText2 
                                                                 null                             //pFreeText3 
                                                                 );

                        if (sResult == "FUNCTION PERFORMED") // ekleme başarılı
                        {
                            for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
                            {
                                if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                                   && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                                {
                                    string sDeatilResult = CBO.AddShippingOrderBOM("itsup",                   //pUserName 
                                                                                   "poins1",                  //pPassword 
                                                                                   strPTSNumber,              //pShippingOrderId 
                                                                                   "0" + grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),             //pGTIN
                                                                                   Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString())  //pTargetQuantity
                                                                                   );

                                    if (sDeatilResult == "FUNCTION PERFORMED") // ekleme başarılı
                                        //Entegrasyon SP'si çalıştırılacak...
                                        lITS.ENTEGRASYON_KAYDI_EKLE_TTS(
                                                                        DateTime.Now,                                                                                                 //@PRMENTEGRASYON_TARIHI, 
                                                                        strAmrAccountCode,                                                                                            //@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                                                        null,                                                                                                         //@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                                                        strPTSNumber,                                                                                                 //@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                                                        grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),                               //@PRMENTEGRASYON_ID VARCHAR (40), 
                                                                        grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),                          //@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                                                        grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),              //@PRMENTEGRASYON_LOTNUMARASI VARCHAR (20), 
                                                                        Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),        //@PRMENTEGRASYON_MIKTAR INT, 
                                                                        strDbCompanyName                                                                                              //@PRMENTEGRASYON_KURUMKODU VARCHAR (13)                                                        
                                                                        );
                                    else
                                    {
                                        MessageBox.Show("Sipariş detay kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sDeatilResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        btnSiparisTransfer_VerileriYenile.Enabled = true;
                                        btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                        btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                        return false;
                                    }
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Sipariş kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.DoEvents();
                            btnSiparisTransfer_VerileriYenile.Enabled = true;
                            btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                            btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                            return false;
                        }
                    }
                    else if ((type == 0) && (spResult.kontrol == 1))
                    {
                        for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
                        {
                            if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                               && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                            {
                                string sDeatilResult = CBO.AddShippingOrderBOM("itsup",                   //pUserName 
                                                                               "poins1",                  //pPassword 
                                                                               strPTSNumber,              //pShippingOrderId 
                                                                               "0" + grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),             //pGTIN
                                                                               Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString())  //pTargetQuantity
                                                                               );

                                if (sDeatilResult == "FUNCTION PERFORMED") // ekleme başarılı
                                {
                                    //Entegrasyon SP'si çalıştırılacak...
                                    lITS.ENTEGRASYON_KAYDI_EKLE_TTS(
                                                                    DateTime.Now,                                                                                                 //@PRMENTEGRASYON_TARIHI, 
                                                                    strAmrAccountCode,                                                                                            //@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                                                    null,                                                                                                         //@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                                                    strPTSNumber,                                                                                                 //@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                                                    grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),                               //@PRMENTEGRASYON_ID VARCHAR (40), 
                                                                    grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),                          //@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                                                    grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),              //@PRMENTEGRASYON_LOTNUMARASI VARCHAR (20), 
                                                                    Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),        //@PRMENTEGRASYON_MIKTAR INT, 
                                                                    strDbCompanyName                                                                                              //@PRMENTEGRASYON_KURUMKODU VARCHAR (13)                                                        
                                                                    );
                                }
                                else
                                {
                                    MessageBox.Show("Sipariş detay kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sDeatilResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    btnSiparisTransfer_VerileriYenile.Enabled = true;
                                    btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                    btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                    return false;
                                }
                            }
                        }
                    }
                    else if ((type == 1) && (spResult.kontrol == 0))
                    {
                        for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
                        {
                            if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                               && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                            {
                                lITS.ENTEGRASYON_KAYDI_EKLE_AGE(
                                                                DateTime.Now,                                                                                                 //@PRMENTEGRASYON_TARIHI, 
                                                                strAmrAccountCode,                                                                                            //@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                                                null,                                                                                                         //@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                                                strPTSNumber,                                                                                                 //@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),                               //@PRMENTEGRASYON_ID VARCHAR (40), 
                                                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),                          //@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),              //@PRMENTEGRASYON_LOTNUMARASI VARCHAR (20), 
                                                                Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),        //@PRMENTEGRASYON_MIKTAR INT, 
                                                                strDbCompanyName                                                                                              //@PRMENTEGRASYON_KURUMKODU VARCHAR (13)                                                        
                                                                );


                                lITS.ENTEGRASYON_DURUM_GUNCELLE_AGE(
                                                                    Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString()),          //@PRMENTEGRASYON_ID INT,
                                                                    1                                                                                                         //@PRMENTEGRASYON_DURUM
                                                                    );
                            }
                        }
                    }
                    else if (spResult.kontrol == 2)
                    {
                        if (type == 0)
                            MessageBox.Show("Sipariş detay kaydı TTS sisteminde mevcut, AGE sistemine aktarım yapılamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (type == 1)
                            MessageBox.Show("Sipariş detay kaydı AGE sisteminde mevcut, TTS sistemine aktarım yapılamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        btnSiparisTransfer_VerileriYenile.Enabled = true;
                        btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                        btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                        return false;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.DoEvents();
                btnSiparisTransfer_VerileriYenile.Enabled = true;
                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;

                if (type == 0)
                {
                    btnSiparisTransfer_SiparisleriTTSGonder.Height = 57;
                    mpbSiparisTransfer_ProgressBarTTS.Visible = false;
                }
                else
                {
                    btnSiparisTransfer_SiparisleriAGEGonder.Height = 57;
                    mpbSiparisTransfer_ProgressBarAGE.Visible = false;
                }

                Application.DoEvents();
            }

            btnSiparisTransfer_VerileriYenile_Click(sender, e);
            return true;
        }
        private bool SiparisTransferEkle11111(object sender, EventArgs e, Int16 type)
        {
            Cursor = Cursors.WaitCursor;
            if (type == 0)
            {
                btnSiparisTransfer_SiparisleriTTSGonder.Height = 38;
                mpbSiparisTransfer_ProgressBarTTS.Visible = true;
            }
            else
            {
                btnSiparisTransfer_SiparisleriAGEGonder.Height = 38;
                mpbSiparisTransfer_ProgressBarAGE.Visible = true;
            }

            Application.DoEvents();

            try
            {
                TTS.Main CBO = new ITS.TTS.Main();
                //CBO.Url = "http://172.16.117.200/TTBOWS2/TTSPlantWebService.asmx";

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {



                    var spWaitingForTTSShipment = lITS.Sales_Invoice_and_Waybill_List_Waiting_For_TTS_Shipment().ToList();

                    for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
                    {
                        if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                           && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                        {

                            string SiparisDetayModMomID = grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModMomID).ToString();
                            var tempCari = spWaitingForTTSShipment.FirstOrDefault(m => m.mom_id == Convert.ToInt16(SiparisDetayModMomID));
                            strDbCompanyName = tempCari.db_company_name.ToString();
                            strAmrAccountCode = tempCari.amr_account_code.ToString();
                            strPTSNumber = tempCari.mom_parameter_2.ToString();
                            strCompanyGLN = tempCari.com_gln_number.ToString();
                            intMomAccountId = tempCari.mom_account_id.Value;
                            strTB073CUSTOMERID = tempCari.TB073_CUSTOMER_ID.ToString();

                            // var spResult = lITS.Sales_Invoice_and_Waybill_List_Control(strPTSNumber, type).First();


                        }
                    }



                    var spResult = lITS.Sales_Invoice_and_Waybill_List_Control(strPTSNumber, type).First();

                    if ((type == 0))
                    {
                        if ((spResult.kontrol == 0))
                        {
                            string sResult = CBO.CreateShippingOrder("itsup",                         //pUserName 
                                                                "poins1",                        //pPassword 
                                                                strPTSNumber,                    //pOrderId 
                                                                "Shipping",                      //pOrderType
                                                                true,                            //pIsPromoted
                                                                DateTime.Now,                    //pDeliveryTimestamp
                                                                "Sell",                          //pOrderKind
                                                                "2",                             //pSSCCExtDigit
                                                                strCompanyGLN,                   //pSSCCGLNPrefix 
                                                                Convert.ToInt32(strTB073CUSTOMERID),//pCustomersId 
                                                                null,                            //pCarrier 
                                                                null,                            //pTruck 
                                                                "ITS Entegrasyonu ile açılmıştır.",//pFreeText1 
                                                                null,                            //pFreeText2 
                                                                null                             //pFreeText3 
                                                                );

                            if (sResult == "FUNCTION PERFORMED") // ekleme başarılı
                            {
                                for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
                                {
                                    if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                                       && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                                    {
                                        string sDeatilResult = CBO.AddShippingOrderBOM(
                                            "itsup",//pUserName 
                                            "poins1",//pPassword 
                                            strPTSNumber,//pShippingOrderId 
                                            "0" + grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//pGTIN
                                            Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()) //pTargetQuantity
                                            );

                                        if (sDeatilResult == "FUNCTION PERFORMED")
                                            // ekleme başarılı
                                            //Entegrasyon SP'si çalıştırılacak...
                                            lITS.ENTEGRASYON_KAYDI_EKLE_TTS(
                                            DateTime.Now,//@PRMENTEGRASYON_TARIHI, 
                                            strAmrAccountCode,//@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                            null,//@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                            strPTSNumber,//@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                            grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),//@PRMENTEGRASYON_ID VARCHAR (40), 
                                            grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                            grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),//@PRMENTEGRASYON_LOTNUMARASI VARCHAR(20), 
                                            Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),//@PRMENTEGRASYON_MIKTAR INT, 
                                            strDbCompanyName//@PRMENTEGRASYON_KURUMKODU VARCHAR (13)                                                        
                                            );
                                        else
                                        {
                                            MessageBox.Show("Sipariş detay kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sDeatilResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            btnSiparisTransfer_VerileriYenile.Enabled = true;
                                            btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                            btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                            return false;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show("Sipariş kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.DoEvents();
                                btnSiparisTransfer_VerileriYenile.Enabled = true;
                                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                return false;
                            }
                        }
                        else if (spResult.kontrol == 1)
                        {
                            for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
                            {
                                if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                                   && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                                {
                                    string sDeatilResult = CBO.AddShippingOrderBOM(
                                        "itsup",//pUserName 
                                        "poins1",//pPassword 
                                        strPTSNumber,//pShippingOrderId 
                                        "0" + grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//pGTIN
                                        Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString())  //pTargetQuantity
                                        );

                                    if (sDeatilResult == "FUNCTION PERFORMED") // ekleme başarılı
                                    {
                                        //Entegrasyon SP'si çalıştırılacak...
                                        lITS.ENTEGRASYON_KAYDI_EKLE_TTS(
                                    DateTime.Now,//@PRMENTEGRASYON_TARIHI, 
                                    strAmrAccountCode,//@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                    null,//@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                    strPTSNumber,//@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                    grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),//@PRMENTEGRASYON_ID VARCHAR (40), 
                                    grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                    grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),//@PRMENTEGRASYON_LOTNUMARASI VARCHAR (20), 
                                    Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),//@PRMENTEGRASYON_MIKTAR INT, 
                                    strDbCompanyName//@PRMENTEGRASYON_KURUMKODU VARCHAR (13)                                                        
                                    );
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sipariş detay kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sDeatilResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        btnSiparisTransfer_VerileriYenile.Enabled = true;
                                        btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                        btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                        return false;
                                    }
                                }
                            }
                        }



                    }
                    else if ((type == 1))
                    {

                        if (spResult.kontrol == 0)
                        {
                            for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
                            {
                                if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                                   && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                                {
                                    lITS.ENTEGRASYON_KAYDI_EKLE_AGE(
                                DateTime.Now,//@PRMENTEGRASYON_TARIHI, 
                                strAmrAccountCode,//@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                null,//@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                strPTSNumber,//@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),//@PRMENTEGRASYON_ID VARCHAR (40), 
                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),//@PRMENTEGRASYON_LOTNUMARASI VARCHAR (20), 
                                Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),//@PRMENTEGRASYON_MIKTAR INT, 
                                strDbCompanyName//@PRMENTEGRASYON_KURUMKODU VARCHAR (13)
                                );

                                    lITS.ENTEGRASYON_DURUM_GUNCELLE_AGE(
                                Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString()),//@PRMENTEGRASYON_ID INT,
                                1 //@PRMENTEGRASYON_DURUM
                                );
                                }
                            }
                        }
                    }
                    else if (spResult.kontrol == 2)
                    {
                        if (type == 0)
                            MessageBox.Show("Sipariş detay kaydı TTS sisteminde mevcut, AGE sistemine aktarım yapılamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (type == 1)
                            MessageBox.Show("Sipariş detay kaydı AGE sisteminde mevcut, TTS sistemine aktarım yapılamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        btnSiparisTransfer_VerileriYenile.Enabled = true;
                        btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                        btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                        return false;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.DoEvents();
                btnSiparisTransfer_VerileriYenile.Enabled = true;
                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;

                if (type == 0)
                {
                    btnSiparisTransfer_SiparisleriTTSGonder.Height = 57;
                    mpbSiparisTransfer_ProgressBarTTS.Visible = false;
                }
                else
                {
                    btnSiparisTransfer_SiparisleriAGEGonder.Height = 57;
                    mpbSiparisTransfer_ProgressBarAGE.Visible = false;
                }

                Application.DoEvents();
            }

            btnSiparisTransfer_VerileriYenile_Click(sender, e);
            return true;
        }
        private bool SiparisTransferEkle11111222222(object sender, EventArgs e, Int16 type)
        {
            Cursor = Cursors.WaitCursor;
            if (type == 0)
            {
                btnSiparisTransfer_SiparisleriTTSGonder.Height = 38;
                mpbSiparisTransfer_ProgressBarTTS.Visible = true;
            }
            else
            {
                btnSiparisTransfer_SiparisleriAGEGonder.Height = 38;
                mpbSiparisTransfer_ProgressBarAGE.Visible = true;
            }

            Application.DoEvents();

            try
            {
                TTS.Main CBO = new ITS.TTS.Main();
                //CBO.Url = "http://172.16.117.200/TTBOWS2/TTSPlantWebService.asmx";

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {




                    var spResult = lITS.Sales_Invoice_and_Waybill_List_Control(strPTSNumber, type).First();

                    if ((type == 0) && (spResult.kontrol == 0))
                    {
                        string sResult = CBO.CreateShippingOrder("itsup",                         //pUserName 
                                                                 "poins1",                        //pPassword 
                                                                 strPTSNumber,                    //pOrderId 
                                                                 "Shipping",                      //pOrderType
                                                                 true,                            //pIsPromoted
                                                                 DateTime.Now,                    //pDeliveryTimestamp
                                                                 "Sell",                          //pOrderKind
                                                                 "2",                             //pSSCCExtDigit
                                                                 strCompanyGLN,                   //pSSCCGLNPrefix 
                                                                 Convert.ToInt32(strTB073CUSTOMERID),//pCustomersId 
                                                                 null,                            //pCarrier 
                                                                 null,                            //pTruck 
                                                                 "ITS Entegrasyonu ile açılmıştır.",//pFreeText1 
                                                                 null,                            //pFreeText2 
                                                                 null                             //pFreeText3 
                                                                 );

                        if (sResult == "FUNCTION PERFORMED") // ekleme başarılı
                        {
                            for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
                            {
                                if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                                   && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                                {
                                    string sDeatilResult = CBO.AddShippingOrderBOM(
                                        "itsup",//pUserName 
                                        "poins1",//pPassword 
                                        strPTSNumber,//pShippingOrderId 
                                        "0" + grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//pGTIN
                                        Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()) //pTargetQuantity
                                        );

                                    if (sDeatilResult == "FUNCTION PERFORMED")
                                        // ekleme başarılı
                                        //Entegrasyon SP'si çalıştırılacak...
                                        lITS.ENTEGRASYON_KAYDI_EKLE_TTS(
                                        DateTime.Now,//@PRMENTEGRASYON_TARIHI, 
                                        strAmrAccountCode,//@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                        null,//@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                        strPTSNumber,//@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                        grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),//@PRMENTEGRASYON_ID VARCHAR (40), 
                                        grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                        grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),//@PRMENTEGRASYON_LOTNUMARASI VARCHAR(20), 
                                        Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),//@PRMENTEGRASYON_MIKTAR INT, 
                                        strDbCompanyName//@PRMENTEGRASYON_KURUMKODU VARCHAR (13)                                                        
                                        );
                                    else
                                    {
                                        MessageBox.Show("Sipariş detay kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sDeatilResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        btnSiparisTransfer_VerileriYenile.Enabled = true;
                                        btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                        btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                        return false;
                                    }
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Sipariş kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.DoEvents();
                            btnSiparisTransfer_VerileriYenile.Enabled = true;
                            btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                            btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                            return false;
                        }
                    }
                    else if ((type == 0) && (spResult.kontrol == 1))
                    {
                        for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
                        {
                            if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                               && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                            {
                                string sDeatilResult = CBO.AddShippingOrderBOM(
                                    "itsup",//pUserName 
                                    "poins1",//pPassword 
                                    strPTSNumber,//pShippingOrderId 
                                    "0" + grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//pGTIN
                                    Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString())  //pTargetQuantity
                                    );

                                if (sDeatilResult == "FUNCTION PERFORMED") // ekleme başarılı
                                {
                                    //Entegrasyon SP'si çalıştırılacak...
                                    lITS.ENTEGRASYON_KAYDI_EKLE_TTS(
                                DateTime.Now,//@PRMENTEGRASYON_TARIHI, 
                                strAmrAccountCode,//@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                                null,//@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                                strPTSNumber,//@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),//@PRMENTEGRASYON_ID VARCHAR (40), 
                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                                grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),//@PRMENTEGRASYON_LOTNUMARASI VARCHAR (20), 
                                Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),//@PRMENTEGRASYON_MIKTAR INT, 
                                strDbCompanyName//@PRMENTEGRASYON_KURUMKODU VARCHAR (13)                                                        
                                );
                                }
                                else
                                {
                                    MessageBox.Show("Sipariş detay kaydı eklenirken bir hata oluştu. TTS'in verdiği hata: " + sDeatilResult, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    btnSiparisTransfer_VerileriYenile.Enabled = true;
                                    btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                                    btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                                    return false;
                                }
                            }
                        }
                    }
                    else if ((type == 1) && (spResult.kontrol == 0))
                    {
                        for (int i = 0; i < grdSiparisDetayListesiView.RowCount; i++)
                        {
                            if (grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked) != null
                               && Convert.ToBoolean(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayChecked)) == true)
                            {
                                lITS.ENTEGRASYON_KAYDI_EKLE_AGE(
                            DateTime.Now,//@PRMENTEGRASYON_TARIHI, 
                            strAmrAccountCode,//@PRMENTEGRASYON_MUSTERIKODU VARCHAR (13), 
                            null,//@PRMENTEGRASYON_SIPARISNUMARASI VARCHAR (20), 
                            strPTSNumber,//@PRMENTEGRASYON_FATURANUMARASI VARCHAR (20), 
                            grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString(),//@PRMENTEGRASYON_ID VARCHAR (40), 
                            grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayMmmBarcode).ToString(),//@PRMENTEGRASYON_URUNKODU VARCHAR (20), 
                            grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModSupplierBatchNumber).ToString(),//@PRMENTEGRASYON_LOTNUMARASI VARCHAR (20), 
                            Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModQuantity).ToString()),//@PRMENTEGRASYON_MIKTAR INT, 
                            strDbCompanyName//@PRMENTEGRASYON_KURUMKODU VARCHAR (13)
                            );

                                lITS.ENTEGRASYON_DURUM_GUNCELLE_AGE(
                            Convert.ToInt32(grdSiparisDetayListesiView.GetRowCellValue(i, dgvSiparisDetayModID).ToString()),//@PRMENTEGRASYON_ID INT,
                            1 //@PRMENTEGRASYON_DURUM
                            );
                            }
                        }
                    }
                    else if (spResult.kontrol == 2)
                    {
                        if (type == 0)
                            MessageBox.Show("Sipariş detay kaydı TTS sisteminde mevcut, AGE sistemine aktarım yapılamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (type == 1)
                            MessageBox.Show("Sipariş detay kaydı AGE sisteminde mevcut, TTS sistemine aktarım yapılamaz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        btnSiparisTransfer_VerileriYenile.Enabled = true;
                        btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                        btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                        return false;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.DoEvents();
                btnSiparisTransfer_VerileriYenile.Enabled = true;
                btnSiparisTransfer_SiparisleriTTSGonder.Enabled = true;
                btnSiparisTransfer_SiparisleriAGEGonder.Enabled = true;
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;

                if (type == 0)
                {
                    btnSiparisTransfer_SiparisleriTTSGonder.Height = 57;
                    mpbSiparisTransfer_ProgressBarTTS.Visible = false;
                }
                else
                {
                    btnSiparisTransfer_SiparisleriAGEGonder.Height = 57;
                    mpbSiparisTransfer_ProgressBarAGE.Visible = false;
                }

                Application.DoEvents();
            }

            btnSiparisTransfer_VerileriYenile_Click(sender, e);
            return true;
        }
        #endregion


        #region TabPage Satış ve PTS Bildirimi

        #endregion


        #region TabPage Satış Detay Bilgileri

        #endregion


        #region TabPage Satış İptal Bildirimi

        #endregion


        #region TabPage İhracat Bildirimi

        #endregion


        #region TabPage PTS Bildirimi

        #endregion


        #region TabPage Ürün Doğrulama

        #endregion


        #region TabPage Raporlar

        #endregion


        #region TabPage Ayarlar

        #endregion


        #region TabPage Güvenlik

        #endregion



        private void btnUretimBildirimi_Click(object sender, EventArgs e)
        {
            if (btnUretimBildirimi.Text == "Seçili Üretimin PTS Bildirimini Yap") // fason
            {
                string sOrderNumber = "";
                string sOrderDetails = "";
                for (int i = 0; i < grdUretimBildirimiView.RowCount; i++)
                {
                    if (grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiChecked) != null
                       && Convert.ToBoolean(grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiChecked)) == true &&
                      grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiProductionType).ToString() == "Fason")
                    {
                        sOrderNumber = grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiOrderId).ToString();
                        sOrderDetails = sOrderNumber + " - " + grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiItemName).ToString() + " - " + grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiBatchNo).ToString();
                    }
                }

                if (sOrderNumber != "")
                    using (FasonBildirim frmFasonBildirim = new FasonBildirim() { OrderNumber = sOrderNumber, OrderDetails = sOrderDetails })
                    {
                        frmFasonBildirim.ShowDialog(this);
                    }
            }
            else
            {
                if (MessageBox.Show("Seçili üretimin bildirimi yapılacaktır. Bu işlemin iptali yoktur. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                Cursor = Cursors.WaitCursor;
                try
                {
                    sstMain.Items[0].Text = "Üretim bildirimleri gönderiliyor...";
                    sstMain.Items[0].Image = ITS.Properties.Resources.kaboodleloop;

                    bKapanamaz = true;
                    btnUretimBildirimi.Enabled = false;
                    btnSeciliUretimleinBildirimleriniZamanla.Enabled = false;
                    btnUretimBilgileriniGetir.Enabled = false;
                    grdUretimBildirimi.Enabled = false;
                    mpbUretimBildirimleriGonderiliyor.Visible = true;
                    mpbUretimBildirimleriGonderiliyor.Text = "Üretim bildirimleri gönderiliyor...";

                    string sHareketParentIDList = "";

                    DeclarationServices.SendProduction UB = new DeclarationServices.SendProduction(Global.UsrId, Global.Environment, Global.ITSConnectionString);


                    for (int i = 0; i < grdUretimBildirimiView.RowCount; i++)
                    {
                        if (grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiChecked) != null
                           && Convert.ToBoolean(grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiChecked)) == true)
                        {
                            iHareketParentID = UB.UretimBildirimineBasla(Convert.ToInt32(grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiUnsentQuantity)), grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiOrderId).ToString());
                            sHareketParentIDList += iHareketParentID.ToString() + ",";
                        }
                    }



                    sstMain.Items[0].Text = "Üretim bildirimleri gönderildi.";
                    sstMain.Items[0].Image = ITS.Properties.Resources.accept;
                    mpbUretimBildirimleriGonderiliyor.Text = "Üretim bildirimleri gönderildi. Raporlar sekmesine yönlendiriliyorsunuz. Bu işlem biraz vakit alabilir.";          

                    if (iHareketParentID > 0)
                    {
                        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                        {
                            grdUretimBildirimi.DataSource = lITS.Order_List_Browse().ToList();
                            Application.DoEvents();
                            grdRaporlar.DataSource = lITS.Package_Movement_Master_Browse(null,
                                                                                         null,
                                                                                         null,
                                                                                         null,
                                                                                         null,
                                                                                         iHareketParentID,
                                                                                         null,
                                                                                         null,
                                                                                         null).ToList();

                        }

                        Application.DoEvents();
                        edtSource.SelectedTabPage = tbpRaporlar;
                        tbcRaporlar.SelectedTabPage = tbpBildirimDetayRaporu;
                        Application.DoEvents();
                    }



                }
                catch (Exception ex)
                {
                    sstMain.Items[0].Text = "Üretim bildirimleri gönderilemedi! Hata: " + ex.Message;
                    sstMain.Items[0].Image = ITS.Properties.Resources.important;
                    MessageBox.Show("Üretim bildirimleri gönderilemedi! Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                   
                    Cursor = Cursors.Default;
                    tmrStatus.Start();
                    bKapanamaz = false;
                    btnUretimBildirimi.Enabled = true;
                    btnSeciliUretimleinBildirimleriniZamanla.Enabled = true;
                    btnUretimBilgileriniGetir.Enabled = true;
                    grdUretimBildirimi.Enabled = true;
                    mpbUretimBildirimleriGonderiliyor.Visible = false;
                    //UretimBilgileriniYenile();   
                }
            }
        }


        private void btnServisAdresleriniGeriAl_Click(object sender, EventArgs e)
        {
            if (tbcSettings.SelectedTabPage == tbpUserSettings)
            {
                edtProxy.Text = Settings.ProxyAddress;
                edtProxyPort.Text = Settings.ProxyPort;
                edtDeclarationCount.Text = Settings.DeclarationCount.ToString();
            }
            else if (tbcSettings.SelectedTabPage == tbpSystemSettings)
            {
                edtUretimBildirimi.Text = Settings.Services.Production;
                edtDeaktivasyonBildirimi.Text = Settings.Services.Deactivation;
                edtIhracatBildirimi.Text = Settings.Services.Export;
                edtSatisBildirimi.Text = Settings.Services.Sales;
                edtSatisIptalBildirimi.Text = Settings.Services.CancelSales;
                edtUrunDogrulamaBildirimi.Text = Settings.Services.Confirmation;
                edtPTSBildirimi.Text = Settings.Services.PTSSend;
                edtPTSAlmaBildirimi.Text = Settings.Services.PTSReceive;
                edtPTSTransferBilgileriBildirimi.Text = Settings.Services.PTSTransferHelper;

                edtSanovelGLN.Text = Settings.Security.SanovelGLN;
                edtSanovelUser.Text = Settings.Security.SanovelUser;
                edtITSSifreSanovel.Text = Settings.Security.SanovelPassword;

                edtAsetGLN.Text = Settings.Security.AsetGLN;
                edtAsetUser.Text = Settings.Security.AsetUser;
                edtITSSifreAset.Text = Settings.Security.AsetPassword;

                edtAdilnaGLN.Text = Settings.Security.AdilnaGLN;
                edtAdilnaUser.Text = Settings.Security.AdilnaUser;
                edtITSSifreAdilna.Text = Settings.Security.AdilnaPassword;

                edtArvenGLN.Text = Settings.Security.ArvenGLN;
                edtArvenUser.Text = Settings.Security.ArvenUser;
                edtITSSifreArven.Text = Settings.Security.ArvenPassword;

                edtGelenDosya.Text = Settings.Directory.Incoming;
                edtGidenDosya.Text = Settings.Directory.Outgoing;
                edtGeciciDosya.Text = Settings.Directory.Temp;
            }
        }

        private void btnServisAdresleriKaydet_Click(object sender, EventArgs e)
        {
            if (tbcSettings.SelectedTabPage == tbpUserSettings)
            {
                Settings.ProxyAddress = edtProxy.Text;
                Settings.ProxyPort = edtProxyPort.Text;
                Settings.DeclarationCount = Convert.ToInt32(edtDeclarationCount.Text);
                try
                {
                    Settings.WriteSettings();
                }
                catch (Exception Ex)
                {
                    sstMain.Items[0].Text = "Ayarlar kaydedilemedi! Hata: " + Ex.Message;
                    sstMain.Items[0].Image = ITS.Properties.Resources.important;
                    tmrStatus.Start();
                    return;
                }
            }
            else if (tbcSettings.SelectedTabPage == tbpSystemSettings)
            {
                Cursor = Cursors.WaitCursor;

                try
                {
                    using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                    {
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "production_declaration_address").First().set_setting_variable = edtUretimBildirimi.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "deactivation_declaration_address").First().set_setting_variable = edtDeaktivasyonBildirimi.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "export_declaration_address").First().set_setting_variable = edtIhracatBildirimi.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "sales_declaration_address").First().set_setting_variable = edtSatisBildirimi.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "cancel_sales_declaration_address").First().set_setting_variable = edtSatisIptalBildirimi.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "confirmation_address").First().set_setting_variable = edtUrunDogrulamaBildirimi.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "pts_address").First().set_setting_variable = edtPTSBildirimi.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "pts_transfer_helper_address").First().set_setting_variable = edtPTSBildirimi.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "pts_receiver_address").First().set_setting_variable = edtPTSBildirimi.Text;

                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "sanovel_gln").First().set_setting_variable = edtSanovelGLN.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "sanovel_user").First().set_setting_variable = edtSanovelUser.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "sanovel_password").First().set_setting_variable = edtITSSifreSanovel.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "aset_gln").First().set_setting_variable = edtAsetGLN.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "aset_user").First().set_setting_variable = edtAsetUser.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "aset_password").First().set_setting_variable = edtITSSifreAset.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "adilna_gln").First().set_setting_variable = edtAdilnaGLN.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "adilna_user").First().set_setting_variable = edtAdilnaUser.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "adilna_password").First().set_setting_variable = edtITSSifreAdilna.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "incoming_files").First().set_setting_variable = edtGelenDosya.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "outgoing_files").First().set_setting_variable = edtGidenDosya.Text;
                        lITS.Global_Settings.Where(s => s.set_environment == Global.Environment && s.set_setting_name == "temp_files").First().set_setting_variable = edtGeciciDosya.Text;

                        lITS.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    Cursor = Cursors.Default;
                }

                Settings.Services.Production = edtUretimBildirimi.Text;
                Settings.Services.Deactivation = edtDeaktivasyonBildirimi.Text;
                Settings.Services.Export = edtIhracatBildirimi.Text;
                Settings.Services.Sales = edtSatisBildirimi.Text;
                Settings.Services.CancelSales = edtSatisIptalBildirimi.Text;
                Settings.Services.Confirmation = edtUrunDogrulamaBildirimi.Text;
                Settings.Services.PTSSend = edtPTSBildirimi.Text;
                edtPTSAlmaBildirimi.Text = Settings.Services.PTSReceive;
                edtPTSTransferBilgileriBildirimi.Text = Settings.Services.PTSTransferHelper;

                Settings.Security.SanovelGLN = edtSanovelGLN.Text;
                Settings.Security.SanovelUser = edtSanovelUser.Text;
                Settings.Security.SanovelPassword = edtITSSifreSanovel.Text;
                Settings.Security.AsetGLN = edtAsetGLN.Text;
                Settings.Security.AsetUser = edtAsetUser.Text;
                Settings.Security.AsetPassword = edtITSSifreAset.Text;
                Settings.Security.AdilnaGLN = edtAdilnaGLN.Text;
                Settings.Security.AdilnaUser = edtAdilnaUser.Text;
                Settings.Security.AdilnaPassword = edtITSSifreAdilna.Text;

                Settings.Directory.Incoming = edtGelenDosya.Text;
                Settings.Directory.Outgoing = edtGidenDosya.Text;
                Settings.Directory.Temp = edtGeciciDosya.Text;
            }

            sstMain.Items[0].Text = "Ayarlar kaydedildi.";
            sstMain.Items[0].Image = ITS.Properties.Resources.accept;
            tmrStatus.Start();
        }

        private void tmrZaman_Tick(object sender, EventArgs e)
        {
            sstMain.Items[1].Text = DateTime.Now.ToString();
        }


        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            sstMain.Items[0].Width = this.Width - 150;
            pnlHakkinda.Left = (tbpHakkinda.Width - pnlHakkinda.Width) / 2;
            pnlHakkinda.Top = (tbpHakkinda.Height - pnlHakkinda.Height) / 2;
        }

        private void edtUretimBildirimi_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ofdWSDL.ShowDialog();
            ((DevExpress.XtraEditors.ButtonEdit)sender).Text = ofdWSDL.FileName;
        }
        private void UretimBilgileriniYenile()
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdUretimBildirimi.DataSource = lITS.Order_List_Browse().ToList();
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void btnUretimBilgileriniGetir_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdUretimBildirimi.DataSource = lITS.Order_List_Browse().ToList();
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = bKapanamaz;
        }

        private void btnRaporuCalistir_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (dteRaporBaslangicTarihi.Text == "")
                    dteRaporBaslangicTarihi.DateTime = DateTime.Today.AddDays(-7);
                if (dteRaporBitisTarihi.Text == "")
                    dteRaporBitisTarihi.DateTime = DateTime.Today;

                string sTypes = "";
                if (cheRaporUretim.Checked) sTypes += "P,";
                if (cheRaporDeaktivasyon.Checked) sTypes += "D,";
                if (cheRaporSatis.Checked) sTypes += "S,";
                if (cheRaporPTS.Checked) sTypes += "C,";
                if (cheRaporSatisIptal.Checked) sTypes += "T,";

                grdRaporlarBatchNo.Visible = (cheRaporUretim.Checked || cheRaporDeaktivasyon.Checked);
                grdRaporlarExpiryDate.Visible = (cheRaporUretim.Checked || cheRaporDeaktivasyon.Checked);

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdRaporlar.DataSource = lITS.Package_Movement_Master_Browse(dteRaporBaslangicTarihi.DateTime,
                                                                                 dteRaporBitisTarihi.DateTime,
                                                                                 edtRaporMalzemeAdi.Text,
                                                                                 edtRaporUretimEmriNumarasi.Text,
                                                                                 (edtRaporKayitAdedi.Text != "" ? Convert.ToInt32(edtRaporKayitAdedi.Text) : (int?)null),
                                                                                 null,
                                                                                 null,
                                                                                 sTypes,
                                                                                 (cboBildirimZamani.SelectedIndex == 0 ? false : true)).ToList();
                }

                RaporDetayiGoster();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnGonderilenDosyayiAc_Click(object sender, EventArgs e)
        {
            Package_Movement_Master_BrowseResult Row = grdRaporlarView.GetFocusedRow() as Package_Movement_Master_BrowseResult;
            if (Row == null) return;

            if (Row.pmm_sending_file_name != null)
            {
                using (XMLDosyasiGoster frmXMLDosyasiGoster = new XMLDosyasiGoster(Settings.Directory.Outgoing + @"\" + Row.pmm_sending_file_name.ToString()))
                {
                    frmXMLDosyasiGoster.ShowDialog();
                }
            }
        }

        private void btnGelenDosyayiAc_Click(object sender, EventArgs e)
        {
            Package_Movement_Master_BrowseResult Row = grdRaporlarView.GetFocusedRow() as Package_Movement_Master_BrowseResult;
            if (Row == null) return;

            if (Row.pmm_coming_file_name != null)
            {
                using (XMLDosyasiGoster frmXMLDosyasiGoster = new XMLDosyasiGoster(Settings.Directory.Incoming + @"\" + Row.pmm_coming_file_name.ToString()))
                {
                    frmXMLDosyasiGoster.ShowDialog();
                }
            }
        }

        private int iGKullaniciId = 0;
        private int iGFonksiyonId = 0;
        private int iFokusSahibi = 0; // 1; Fonksiyon listesi, 2: Kullanici listesi, 3: Yetki listesi

        private void YetkiListesiniGuncelle()
        {
            SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
            conITS.Open();

            try
            {
                SqlCommand scmData = new SqlCommand();
                scmData.Connection = conITS;
                scmData.CommandText = "User_Rights_Browse;1";
                scmData.CommandType = CommandType.StoredProcedure;
                scmData.Parameters.Clear();
                if (iGKullaniciId > 0)
                    scmData.Parameters.Add(new SqlParameter("@usr_id", iGKullaniciId));

                if (iGFonksiyonId > 0)
                    scmData.Parameters.Add(new SqlParameter("@fun_id", iGFonksiyonId));

                SqlDataAdapter sdaYetkiler = new SqlDataAdapter(scmData);
                DataSet dsYetkiler = new DataSet();
                sdaYetkiler.Fill(dsYetkiler, "Yetkiler");
                dgvYetkiListesi.DataSource = dsYetkiler.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                conITS.Close();
            }
        }

        private void btnYetkiKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
            conITS.Open();
            try
            {
                using (SqlCommand scmData = new SqlCommand() { Connection = conITS, CommandText = "User_Rights_Insert_Or_Update;1", CommandType = CommandType.StoredProcedure })
                {
                    if (iFokusSahibi == 3)
                    {
                        scmData.Parameters.Add(new SqlParameter("@usr_id", Convert.ToInt32(dgvYetkiListesi.SelectedRows[0].Cells[0].Value)));
                        scmData.Parameters.Add(new SqlParameter("@fun_id", Convert.ToInt32(dgvYetkiListesi.SelectedRows[0].Cells[1].Value)));
                    }
                    else
                    {
                        scmData.Parameters.Add(new SqlParameter("@usr_id", Convert.ToInt32(dgvKullaniciListesi.SelectedRows[0].Cells[0].Value)));
                        scmData.Parameters.Add(new SqlParameter("@fun_id", Convert.ToInt32(dgvFonksiyonListesi.SelectedRows[0].Cells[0].Value)));
                    }

                    scmData.Parameters.Add(new SqlParameter("@rgh_read", cheKayitOkuma.Checked));
                    scmData.Parameters.Add(new SqlParameter("@rgh_insert", cheKayitEkleme.Checked));
                    scmData.Parameters.Add(new SqlParameter("@rgh_update", cheKayitGuncelleme.Checked));
                    scmData.Parameters.Add(new SqlParameter("@rgh_delete", cheKayitSilme.Checked));
                    scmData.Parameters.Add(new SqlParameter("@rgh_export", cheAktarma.Checked));
                    scmData.Parameters.Add(new SqlParameter("@rgh_print", cheYazdirma.Checked));
                    scmData.Parameters.Add(new SqlParameter("@mdf_usr_id", Global.UsrId));
                    scmData.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                conITS.Close();
            }

            YetkiListesiniGuncelle();
        }


        private void dgvFonksiyonListesi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFonksiyonListesi.SelectedRows.Count > 0)
            {
                iGKullaniciId = 0;
                iGFonksiyonId = 0;
                iGFonksiyonId = Convert.ToInt32(dgvFonksiyonListesi.SelectedRows[0].Cells[0].Value);

                YetkiListesiniGuncelle();
            }

            if (dgvYetkiListesi.SelectedRows.Count > 0)
                dgvYetkiListesi.SelectedRows[0].Selected = false;
        }

        private void dgvKullaniciListesi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKullaniciListesi.SelectedRows.Count > 0)
            {
                iGKullaniciId = 0;
                iGFonksiyonId = 0;
                iGKullaniciId = Convert.ToInt32(dgvKullaniciListesi.SelectedRows[0].Cells[0].Value);

                YetkiListesiniGuncelle();
            }

            if (dgvYetkiListesi.SelectedRows.Count > 0)
                dgvYetkiListesi.SelectedRows[0].Selected = false;
        }

        private void btnYetkiSil_Click(object sender, EventArgs e)
        {
            if (dgvYetkiListesi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Öncelikle silinecek yetki kaydını seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("Kullanıcı yetki kaydı silinecektir. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
            conITS.Open();

            try
            {
                using (SqlCommand scmData = new SqlCommand() { Connection = conITS, CommandText = "User_Rights_Delete;1", CommandType = CommandType.StoredProcedure })
                {
                    scmData.Parameters.Add(new SqlParameter("@usr_id", Convert.ToInt32(dgvYetkiListesi.SelectedRows[0].Cells[0].Value)));
                    scmData.Parameters.Add(new SqlParameter("@fun_id", Convert.ToInt32(dgvYetkiListesi.SelectedRows[0].Cells[1].Value)));
                    scmData.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                conITS.Close();
            }

            YetkiListesiniGuncelle();
        }

        private void dgvYetkiListesi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvYetkiListesi.SelectedRows.Count == 0)
            {
                cheKayitOkuma.Checked = false;
                cheKayitEkleme.Checked = false;
                cheKayitGuncelleme.Checked = false;
                cheKayitSilme.Checked = false;
                cheAktarma.Checked = false;
                cheYazdirma.Checked = false;
            }
            else
            {
                cheKayitOkuma.Checked = Convert.ToBoolean(dgvYetkiListesi.SelectedRows[0].Cells[4].Value);
                cheKayitEkleme.Checked = Convert.ToBoolean(dgvYetkiListesi.SelectedRows[0].Cells[5].Value);
                cheKayitGuncelleme.Checked = Convert.ToBoolean(dgvYetkiListesi.SelectedRows[0].Cells[6].Value);
                cheKayitSilme.Checked = Convert.ToBoolean(dgvYetkiListesi.SelectedRows[0].Cells[7].Value);
                cheAktarma.Checked = Convert.ToBoolean(dgvYetkiListesi.SelectedRows[0].Cells[8].Value);
                cheYazdirma.Checked = Convert.ToBoolean(dgvYetkiListesi.SelectedRows[0].Cells[9].Value);
            }
        }

        private void dgvFonksiyonListesi_Enter(object sender, EventArgs e)
        {
            iFokusSahibi = 1;
        }

        private void dgvKullaniciListesi_Enter(object sender, EventArgs e)
        {
            iFokusSahibi = 2;
        }

        private void dgvYetkiListesi_Enter(object sender, EventArgs e)
        {
            iFokusSahibi = 3;

            if (dgvKullaniciListesi.SelectedRows.Count > 0)
                dgvKullaniciListesi.SelectedRows[0].Selected = false;

            if (dgvFonksiyonListesi.SelectedRows.Count > 0)
                dgvFonksiyonListesi.SelectedRows[0].Selected = false;
        }

        private void edtRaporMalzemeAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnRaporuCalistir_Click(sender, e);
        }

        private void edtRaporUretimEmriNumarasi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnRaporuCalistir_Click(sender, e);
        }

        private void UrunDogrulamaTamamlandi(object sender, EczaneDogrulamaBildirCompletedEventArgs e)
        {
            string sonuc = "";

            try
            {
                sonuc += e.Result.BILDIRIMID + " - ";

                for (int i = 0; i < e.Result.URUNLER.Length; i++)
                {
                    sonuc += e.Result.URUNLER[i].UC + " / " + Settings.GetErrorMessage(e.Result.URUNLER[i].UC) + " ::: ";
                }
            }
            catch (Exception ex)
            {
                if (e.Error.Message != "")
                    sonuc = "FC :: " + e.Error.Message;
                else
                    sonuc = "EX :: " + ex.Message;
            }
            MessageBox.Show(sonuc);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            /*
            EczaneDogrulamaReceiverService EDS = new EczaneDogrulamaReceiverService();
            EDS.EczaneDogrulamaBildirCompleted += new EczaneDogrulamaBildirCompletedEventHandler(UrunDogrulamaTamamlandi);

            EDS.Credentials = new NetworkCredential("18345668", "03030303");
            if (Settings.ProxyAddress != "")
              EDS.Proxy = new WebProxy(Settings.ProxyAddress, Convert.ToInt32(Settings.ProxyPort));

            EczaneDogrulamaBildirimType EDT = new EczaneDogrulamaBildirimType();
            EDT.DT = "V";
            EDT.FR = "8680001315796";
            ArrayList alEDTU = new ArrayList();

            for (int i = 0; i < 1; i++)
            {
              EczaneDogrulamaBildirimTypeURUN EDTU = new EczaneDogrulamaBildirimTypeURUN();
              EDTU.GTIN = edtKontrolGTIN.Text;
              EDTU.XD = Convert.ToDateTime(edtKontrolSKT.Text);
              EDTU.BN = edtKontrolSeri.Text;
              EDTU.SN = edtKontrolAmbalaj.Text;

              alEDTU.Add(EDTU);
            }

            EczaneDogrulamaBildirimTypeURUN[] aEDTU = alEDTU.ToArray(typeof(EczaneDogrulamaBildirimTypeURUN)) as EczaneDogrulamaBildirimTypeURUN[];
            EDT.URUNLER = aEDTU;

            EDS.EczaneDogrulamaBildirAsync(EDT);
            */
        }

        private void edtDUretimEmriNumarasi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DeaktiveIcinUretimDetaylariListesiniYenile();
        }


        private void btnTumSeriDeaktiveEdilsin_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnTumSeriDeaktiveEdilsin.Enabled = false;
            btnDeaktivasyonBildirimi.Enabled = false;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
                    try
                    {
                        lITS.Package_List_All_Update_For_Deactivation(edtDUretimEmriNumarasi.Text);
                    }
                    finally
                    {
                        SplashScreenManager.CloseForm();
                    }
                    DeaktiveIcinUretimDetaylariListesiniYenile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                btnTumSeriDeaktiveEdilsin.Enabled = true;
                btnDeaktivasyonBildirimi.Enabled = true;
            }
        }

        private void btnDeaktivasyonBildirimi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deaktivasyon bildirimi yapılacaktır. Bu işlemin iptali yoktur. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Cursor = Cursors.WaitCursor;
            SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
            btnDeaktivasyonBildirimi.Enabled = false;
            btnTumSeriDeaktiveEdilsin.Enabled = false;
            bKapanamaz = true;

            try
            {
                sstMain.Items[0].Text = "Deaktivasyon bildirimleri gönderiliyor...";
                sstMain.Items[0].Image = ITS.Properties.Resources.kaboodleloop;

                int iKayitAdedi = Convert.ToInt32(edtDDeaktiveEdilecekMiktar.Text);
                int iTekSeferdeGonderilecekKayitAdedi = Settings.DeclarationCount;
                string sUretimEmriNo = edtDUretimEmriNumarasi.Text;

                DeclarationServices.SendDeactivation UB = new DeclarationServices.SendDeactivation(Global.UsrId,
                                                                                                   Global.Environment,
                                                                                                   Global.ITSConnectionString);

                iHareketParentID = UB.DeaktivasyonBildirimineBasla(iKayitAdedi,
                                                                   iTekSeferdeGonderilecekKayitAdedi,
                                                                   sUretimEmriNo);

                sstMain.Items[0].Text = "Deaktivasyon bildirimleri gönderildi.";
                sstMain.Items[0].Image = ITS.Properties.Resources.accept;

             

                if (iHareketParentID > 0)
                {
                    // grid refresh edilecek
                    Application.DoEvents();

                    using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                    {
                        grdRaporlar.DataSource = lITS.Package_Movement_Master_Browse(null,
                                                                                     null,
                                                                                     null,
                                                                                     null,
                                                                                     null,
                                                                                     iHareketParentID,
                                                                                     null,
                                                                                     null,
                                                                                     null).ToList();
                    }

                    Application.DoEvents();
                    edtSource.SelectedTabPage = tbpRaporlar;
                    tbcRaporlar.SelectedTabPage = tbpBildirimDetayRaporu;
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                sstMain.Items[0].Text = "Deaktivasyon bildirimleri gönderilemedi! Hata: " + ex.Message;
                sstMain.Items[0].Image = ITS.Properties.Resources.important;
                MessageBox.Show("Deaktivasyon bildirimleri gönderilemedi! Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                bKapanamaz = false;
                tmrStatus.Start();
                SplashScreenManager.CloseForm();
                btnDeaktivasyonBildirimi.Enabled = true;
                btnTumSeriDeaktiveEdilsin.Enabled = true;
            }
        }


        private void edtKontrolBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 8)
            {
                edtKontrolBarkod.Text = "";
                sBarkod = "";
            }
            else
                if (e.KeyValue == 13)
            {
                if (sBarkod.Length > 2 && sBarkod.Substring(0, 2) == "00" && sBarkod.Length == 20) // SSCC
                {
                    edtKontrolAmbalaj.Text = sBarkod;
                }
                else
                {
                    KareKod kkBarkod = new KareKod(sBarkod, 'D');
                    edtKontrolAmbalaj.Text = kkBarkod.PackageCode;
                }

                edtKontrolBarkod.Text = "";
                sBarkod = "";

                UrunDogrulamaAmbalajArama();
            }
            else
                sBarkod += (char)e.KeyValue;
        }

        private void TopluUrunDogrulamaTamamlandi(object sender, UreticiDogrulamaBildirCompletedEventArgs e)
        {
            try
            {
                for (int i = 0; i < e.Result.URUNLER.Length; i++)
                {
                    if (e.Result.URUNLER[i].UC != "00000")
                        lbcKontrolSonucu.Items.Add(e.Result.URUNLER[i].GTIN
                                                   + "::"
                                                   + e.Result.URUNLER[i].SN
                                                   + "::"
                                                   + e.Result.URUNLER[i].UC
                                                   + "::"
                                                   + Settings.GetErrorMessage(e.Result.URUNLER[i].UC));
                }
            }
            catch (Exception ex)
            {
                if (e.Error.Message != "")
                    lbcKontrolSonucu.Items.Add("FC :: " + e.Error.Message);
                else
                    lbcKontrolSonucu.Items.Add("EX :: " + ex.Message);
            }
        }

        private void btnTumUretimleriDogrula_Click(object sender, EventArgs e)
        {
            /*
            UreticiDogrulamaReceiverService EDS = new UreticiDogrulamaReceiverService();
            EDS.UreticiDogrulamaBildirCompleted += new UreticiDogrulamaBildirCompletedEventHandler(TopluUrunDogrulamaTamamlandi);

            EDS.Credentials = new NetworkCredential("sanovel", "sn86800158");
            EDS.Proxy = new WebProxy(Settings.ProxyAddress, Convert.ToInt32(Settings.ProxyPort));

            UreticiDogrulamaBildirimType EDT = new UreticiDogrulamaBildirimType();

            EDT.DT = "V";
            EDT.FR = "8699536000015";

            ArrayList alEDTU = new ArrayList();
            SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
            conITS.Open();
            try
            {
              SqlCommand scmData = new SqlCommand();
              scmData.Connection = conITS;
              scmData.CommandText = "Order_List_Browse_For_Control";
              scmData.CommandType = CommandType.StoredProcedure;
              SqlDataReader sdrData = scmData.ExecuteReader();
              while (sdrData.Read())
              {
                UreticiDogrulamaBildirimTypeURUN EDTU = new UreticiDogrulamaBildirimTypeURUN();
                EDTU.GTIN = sdrData["mmr_gtin"].ToString();
                EDTU.XD = Convert.ToDateTime(sdrData["expiry_date"]);
                EDTU.BN = sdrData["ord_batch_no"].ToString();
                EDTU.SN = sdrData["pck_code"].ToString();

                alEDTU.Add(EDTU);
              }
              sdrData.Close();
            }
            finally
            {
              conITS.Close();
            }


            UreticiDogrulamaBildirimTypeURUN[] aEDTU = alEDTU.ToArray(typeof(UreticiDogrulamaBildirimTypeURUN)) as UreticiDogrulamaBildirimTypeURUN[];
            EDT.URUNLER = aEDTU;

            EDS.UreticiDogrulamaBildirAsync(EDT);
            */
        }


        private void edtUretimMiktari_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.KeyChar = (char)0;
        }

        private void btnSeciliUretimiAGEyeGonder_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            bKapanamaz = true;
            if (this.cbeAgeUretimHatti.SelectedIndex == -1)
            {
                int num = (int)MessageBox.Show("Üretim hattı boş geçilemez!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            int selectedLine = Convert.ToInt32((((main.UretimHattiDetayi)this.cbeAgeUretimHatti.SelectedItem).Value));
            string currentGtinNumber = string.Empty;
            try
            {
                string urlServerEndPoint = "";        //"https://localhost:7017/Service.asmx"
                string actionMethod = "";     //"PostWorkOrder"
                //string sITSConnectionStringDev = String.Format("Data Source=172.16.110.55;Initial Catalog=ITS_DEV;Persist Security Info=True;User ID=ITS_USER;Password=fast;Application Name=ITS;");


                //string testsstring = Global.ITSConnectionString;

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                //using (var lITS = new ITSDataContext(sITSConnectionStringDev) { CommandTimeout = 120000 })
                {
                    string OrderId = grdAGEyeGonderilebilirUretimEmirleriView.GetFocusedRowCellValue(grdAGEyeGonderilebilirUretimEmirleriOrderId).ToString();


                    #region Eski Age iş emri işlemleri

                    var farmakodWmsOrderList = lITS.WMS_Production_Order_Browse().ToList();

                    var currentWmsOrder = farmakodWmsOrderList.Where(m => m.pom_id == Convert.ToInt32(OrderId)).First();
                    currentGtinNumber = "0" + currentWmsOrder.barcode.ToString();
                    oGenericWorkOrderInput workOrderInput = new oGenericWorkOrderInput()
                    {
                        WorkOrderID = OrderId,
                        ProductCode = currentWmsOrder.barcode.ToString(),
                        BatchNumber = currentWmsOrder.pom_supplier_batch_number.ToString(),
                        ExpiryDate = Convert.ToDateTime(currentWmsOrder.expiry_date),    // ?? Convert.ToDateTime(currentOrder.ExpiryDate),
                        MfgDate = Convert.ToDateTime(currentWmsOrder.pom_production_start_date), // ?? Convert.ToDateTime(currentOrder.StartDate),
                        Quantity = (int)currentWmsOrder.calculated_pom_amount, //Hesaplanmış üretim miktarı
                        WorkOrderType = 6, //iş emrinde serileştirme ve hiyerarşi 
                        LineID = selectedLine.ToString(),
                    };

                    #endregion

                    #region Eski Age iş emri işlemleri
                    //var currentOrder = lITS.Get_Production_Order_To_Insert_AGE_New(OrderId).FirstOrDefault(); // @bilgehan bu kısım wms de ki production order               
                    //oGenericWorkOrderInput workOrderInput = new oGenericWorkOrderInput()
                    //{
                    //    WorkOrderID = OrderId,
                    //    ProductCode = currentOrder.Gtin.ToString(),
                    //    BatchNumber = currentOrder.BatchNo.ToString(),
                    //    ExpiryDate = currentOrder.ExpiryDate ?? Convert.ToDateTime(currentOrder.ExpiryDate),
                    //    MfgDate = currentOrder.StartDate ?? Convert.ToDateTime(currentOrder.StartDate),
                    //    Quantity = (int)currentOrder.Quantity,
                    //    WorkOrderType = 6, //iş emrini serileştirme ve hiyerarşi 
                    //    LineID = selectedLine.ToString(),
                    //};

                    #endregion



                    var serviceInfo = lITS.Get_Age_Line_Info(1).FirstOrDefault();



                    urlServerEndPoint = serviceInfo.ServerEndPoint.ToString().Trim();
                    actionMethod = serviceInfo.Method.ToString().Trim();

                    XmlDocument soapEnvelopeXml = Repository.CreateSoapEnvelope(workOrderInput);
                    HttpWebRequest webRequest = Repository.CreateWebRequest(urlServerEndPoint, actionMethod);

                    Repository.InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

                    string result;
                    using (WebResponse response = webRequest.GetResponse())
                    {
                        using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                        {
                            result = rd.ReadToEnd();
                        }
                    }


                    var serializer = new XmlSerializer(typeof(Envelope));
                    WorkOrderResult woResult = new WorkOrderResult();

                    using (var reader = new StringReader(result))
                    {
                        var envelope = (Envelope)serializer.Deserialize(reader);

                        woResult.IsSucceed = envelope.Body.PostWorkOrderResponse.PostWorkOrderResult.IsSucceed;
                        woResult.WorkOrderID = envelope.Body.PostWorkOrderResponse.PostWorkOrderResult.WorkOrderID.ToString();
                        woResult.ErrorMessage = string.IsNullOrEmpty(envelope.Body.PostWorkOrderResponse.PostWorkOrderResult.ErrorMessage) ? "İş emri paketeleme sistemine aktarıldı." : envelope.Body.PostWorkOrderResponse.PostWorkOrderResult.ErrorMessage.ToString();

                    }

                    //      [dbo].[Order_Insert] SP

                    //      @order_id VARCHAR(20),
                    //@batch_no VARCHAR(20),
                    //@line_id INT,
                    //      @gtin_no                                VARCHAR(14),
                    //@quantity INT,
                    //      @start_date                         DATETIME,
                    //@expiry_date DATETIME,
                    //      @ord_integrated_system          INT

                    //lITS.Order_Insert(
                    //      workOrderInput.WorkOrderID,
                    //      workOrderInput.BatchNumber,
                    //      Convert.ToInt32(workOrderInput.LineID),
                    //      currentGtinNumber,
                    //      workOrderInput.Quantity,
                    //      workOrderInput.MfgDate,
                    //      workOrderInput.ExpiryDate,
                    //      2 // Age 2
                    //    );

                    string msg = string.Empty;

                    lITS.Order_List_Log_Insert(
                             woResult.WorkOrderID.ToString(),
                            workOrderInput.BatchNumber,
                            Convert.ToInt32(workOrderInput.LineID),
                            workOrderInput.Quantity,
                            workOrderInput.MfgDate,
                            workOrderInput.ExpiryDate,
                            woResult.ErrorMessage,
                            2,
                            currentGtinNumber);

                    //lITS.Order_Insert(
                    //    woResult.WorkOrderID.ToString(),
                    //    workOrderInput.BatchNumber,
                    //    Convert.ToInt32(workOrderInput.LineID),
                    //    currentGtinNumber,
                    //    workOrderInput.Quantity,
                    //    workOrderInput.MfgDate,
                    //    workOrderInput.ExpiryDate,
                    //    2 // Age 2
                    //  );

                    if (woResult.IsSucceed)
                    {
                        lITS.Order_Insert(
                         woResult.WorkOrderID,
                         workOrderInput.BatchNumber,
                         Convert.ToInt32(workOrderInput.LineID),
                         currentGtinNumber,
                         workOrderInput.Quantity,
                         workOrderInput.MfgDate,
                         workOrderInput.ExpiryDate,
                         2 // Age 2
                       );

                        msg = woResult.WorkOrderID.ToString() + " nolu üretim emri Age sistemine başarılı bir şekilde gönderilmiştir.";

                        MessageBox.Show(msg, "İşlem Gerçekleşti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        msg = woResult.WorkOrderID.ToString() + " " + woResult.ErrorMessage;

                        MessageBox.Show(msg, "Hata!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                bKapanamaz = false;
            }
            btnAGEyeGonderilebilirUretimEmirleriniGetir_Click(sender, e);
        }
        #region AGE yeni üretim bandı entegras




        #endregion
        private void btnAGEyeGonderilebilirUretimEmirleriniGetir_Click(object sender, EventArgs e)
        {
            //if (edtAGEUretimEmriGunSayisi.Text == "")
            //    return;
            cbeAgeUretimHatti.SelectedIndex = -1;
            Cursor = Cursors.WaitCursor;
            btnAGEyeGonderilebilirUretimEmirleriniGetir.Enabled = false;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    List<LINQ.Order_List_Browse_For_Referable_To_AGEResult> wmsOrderList = new List<LINQ.Order_List_Browse_For_Referable_To_AGEResult>();


                    //grdAGEyeGonderilebilirUretimEmirleri.DataSource = lITS.Order_List_Browse_For_Referable_To_AGE(Convert.ToByte(edtAGEUretimEmriGunSayisi.Text)).ToList(); //Eski Age üretim emri list


                    var farmakodWmsOrderList = lITS.WMS_Production_Order_Browse().ToList();

                    foreach (var item in farmakodWmsOrderList)
                    {
                        LINQ.Order_List_Browse_For_Referable_To_AGEResult wmsOrder = new LINQ.Order_List_Browse_For_Referable_To_AGEResult();

                        wmsOrder.TB022_ORDER_ID = item.pom_id.ToString();
                        wmsOrder.mmr_item_no = item.mmr_item_no;
                        wmsOrder.mmr_item_name = item.mmr_sanovel_material_name;
                        wmsOrder.mmr_gtin = item.barcode;
                        //wmsOrder.created_usc_count = Convert.ToInt32(item.calculated_pom_amount); // Gönderilecek kod miktarı kısmı
                        wmsOrder.TB022_TARGET_QTY = Convert.ToInt32(item.pom_amount);
                        wmsOrder.TB022_PK_BATCH_NO = item.pom_supplier_batch_number;
                        wmsOrder.TB022_EXPIRY_DATE = item.expiry_date;

                        wmsOrderList.Add(wmsOrder);

                    }




                    //grdAGEyeGonderilebilirUretimEmirleri.DataSource = lITS.WMS_Production_Order_Browse().ToList(); //Aktif farmakod işlemi
                    grdAGEyeGonderilebilirUretimEmirleri.DataSource = wmsOrderList; //Aktif farmakod işlemi





                    var tLineList = lITS.Line_Lists.Where(l => l.lin_type_id == 34 && l.lin_phase == cbeTTSSistemi.SelectedIndex + 1).OrderBy(d => d.lin_description).ToList();
                    cbeAgeUretimHatti.Properties.Items.Clear();

                    foreach (var Line in tLineList)
                    {
                        cbeAgeUretimHatti.Properties.Items.Add(new UretimHattiDetayi(Line.lin_id.ToString(),
                                                            Line.lin_description));
                    }



                }
            }
            finally
            {
                btnAGEyeGonderilebilirUretimEmirleriniGetir.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnLeatusaGonderilecekPaketListesineAitUretimEmirleriniGetir_Click(object sender, EventArgs e)
        {

            cbeAgeUretimHatti.SelectedIndex = -1;
            Cursor = Cursors.WaitCursor;
            //btnAGEyeGonderilebilirUretimEmirleriniGetir.Enabled = false;
            //btnSeciliUretimiAGEyeGonder.Enabled = false;
            btnPaketListesiniLeatusaGonder.Enabled = false;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdAGEyeGonderilebilirUretimEmirleri.DataSource = null;
                    grdAGEyeGonderilebilirUretimEmirleri.DataSource = lITS.sp_Production_Order_For_Sending_PackageList_For_Leatus().ToList();
                }
            }
            finally
            {
                btnPaketListesiniLeatusaGonder.Enabled = true;
                Cursor = Cursors.Default;
            }


        }
        private void btnPaketListesiniLeatusaGonder_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            bKapanamaz = true;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    string OrderId = grdAGEyeGonderilebilirUretimEmirleriView.GetFocusedRowCellValue(grdAGEyeGonderilebilirUretimEmirleriOrderId).ToString();
                    if (String.IsNullOrEmpty(OrderId))
                    {
                        MessageBox.Show("Uygun bir üretim emri seçmelisiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    try
                    {
                        lITS.sp_Printed_Packages_Code_Transfer_To_Leatus_New(OrderId); //@bilgehan canlıda commenti kaldır
                        lITS.sp_Order_List_Log_Update_Status(OrderId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            finally
            {

                Cursor = Cursors.Default;
            }
            btnLeatusaGonderilecekPaketListesineAitUretimEmirleriniGetir_Click(sender, e);
        }

        private void cheDegistirButton_Click(Object sender, EventArgs e)
        {


            if (cheDegistirButton.Checked == false)
            {
                cheDegistirButton.Checked = true;

                btnPaketListesiniLeatusaGonder.Enabled = true;
                btnLeatusaGonderilecekPaketListesineAitUretimEmirleriniGetir.Enabled = true;

                btnAGEyeGonderilebilirUretimEmirleriniGetir.Enabled = false;
                btnSeciliUretimiAGEyeGonder.Enabled = false;
                cbeAgeUretimHatti.Enabled = false;
                lblAgeUretimHatti.Enabled = false;

            }
            else
            {
                cheDegistirButton.Checked = false;

                btnPaketListesiniLeatusaGonder.Enabled = false;
                btnLeatusaGonderilecekPaketListesineAitUretimEmirleriniGetir.Enabled = false;

                btnAGEyeGonderilebilirUretimEmirleriniGetir.Enabled = true;
                btnSeciliUretimiAGEyeGonder.Enabled = true;
                cbeAgeUretimHatti.Enabled = true;
                lblAgeUretimHatti.Enabled = true;
            }
            grdAGEyeGonderilebilirUretimEmirleri.DataSource = null;

        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Package_Movement_Master_BrowseResult Row = grdRaporlarView.GetFocusedRow() as Package_Movement_Master_BrowseResult;
            if (Row == null) return;

            using (UretimBildirimRaporu frmUretimBildirimRaporu = new UretimBildirimRaporu(Row.pmm_order_id.ToString()))
            {
                frmUretimBildirimRaporu.ShowDialog(this);
            }
        }


        private void DepoUrunDogrulamaTamamlandi(object sender, DepoDogrulamaBildirCompletedEventArgs e)
        {
            string sonuc = "";

            try
            {
                sonuc += e.Result.BILDIRIMID + " - ";

                for (int i = 0; i < e.Result.URUNLER.Length; i++)
                {
                    sonuc += String.Format("{0} / {1} ::: ", e.Result.URUNLER[i].UC, Settings.GetErrorMessage(e.Result.URUNLER[i].UC));
                }
            }
            catch (Exception ex)
            {
                if (e.Error.Message != "")
                    sonuc = "FC :: " + e.Error.Message;
                else
                    sonuc = "EX :: " + ex.Message;
            }

            MessageBox.Show(sonuc);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            /*
            DepoDogrulamaReceiverService EDS = new DepoDogrulamaReceiverService();
            EDS.DepoDogrulamaBildirCompleted += new DepoDogrulamaBildirCompletedEventHandler(DepoUrunDogrulamaTamamlandi);
            EDS.Credentials = new NetworkCredential("econgar", "mar1mara2");
            EDS.Proxy = new WebProxy(Settings.ProxyAddress, Convert.ToInt32(Settings.ProxyPort));

            DepoDogrulamaBildirimType EDT = new DepoDogrulamaBildirimType();

            EDT.DT = "V";
            EDT.FR = "8680001083121";

            ArrayList alEDTU = new ArrayList();
            for (int i = 0; i < 1; i++)
            {
              DepoDogrulamaBildirimTypeURUN EDTU = new DepoDogrulamaBildirimTypeURUN();
              EDTU.GTIN = edtKontrolGTIN.Text;
              EDTU.XD = Convert.ToDateTime(edtKontrolSKT.Text);
              EDTU.BN = edtKontrolSeri.Text;
              EDTU.SN = edtKontrolAmbalaj.Text;

              alEDTU.Add(EDTU);
            }


            DepoDogrulamaBildirimTypeURUN[] aEDTU = alEDTU.ToArray(typeof(DepoDogrulamaBildirimTypeURUN)) as DepoDogrulamaBildirimTypeURUN[];
            EDT.URUNLER = aEDTU;

            EDS.DepoDogrulamaBildirAsync(EDT);
            */
        }

        private class BDepoDogrulamaReceiverService : DepoDogrulamaReceiverService
        {
            public string Aralik;
        }

        private void TumAmbalajlariDogrulamaTamamlandi(object sender, DepoDogrulamaBildirCompletedEventArgs e)
        {
            Application.DoEvents();
            try
            {
                lbcKontrolSonucu.Items.Add(lbcKontrolSonucu.Items.Count.ToString()
                                           + " :: "
                                           + ((BDepoDogrulamaReceiverService)(sender)).Aralik
                                           + " :: Toplam kontrol edilen ambalaj = "
                                           + e.Result.URUNLER.Length.ToString());

                for (int i = 0; i < e.Result.URUNLER.Length; i++)
                {
                    if (e.Result.URUNLER[i].UC != "00000")
                        lbcKontrolSonucu.Items.Add("DİKKAT!!! "
                                                   + e.Result.URUNLER[i].GTIN
                                                   + "::"
                                                   + e.Result.URUNLER[i].SN
                                                   + "::" + e.Result.URUNLER[i].UC
                                                   + "::"
                                                   + Settings.GetErrorMessage(e.Result.URUNLER[i].UC));
                }
            }
            catch (Exception ex)
            {
                if (e.Error.Message != "")
                    lbcKontrolSonucu.Items.Add(((BDepoDogrulamaReceiverService)(sender)).Aralik
                                               + " :: FC :: "
                                               + e.Error.Message);
                else
                    lbcKontrolSonucu.Items.Add(((BDepoDogrulamaReceiverService)(sender)).Aralik
                                               + " :: EX :: "
                                               + ex.Message);
            }
        }

        private void TumAmbalajlariKontrolEt(object P)
        {
            BDepoDogrulamaReceiverService EDS = new BDepoDogrulamaReceiverService();
            EDS.DepoDogrulamaBildirCompleted += new DepoDogrulamaBildirCompletedEventHandler(TumAmbalajlariDogrulamaTamamlandi);

            EDS.Aralik = ((TumAmbalajlariKontrolParametreleri)P).SiraNumarasi.ToString();
            EDS.Credentials = new NetworkCredential("econgar", "mar1mara2");

            if (Settings.ProxyAddress != "")
                EDS.Proxy = new WebProxy(Settings.ProxyAddress, Convert.ToInt32(Settings.ProxyPort));

            DepoDogrulamaBildirimType EDT = new DepoDogrulamaBildirimType() { DT = "V", FR = "8680001083121" };

            ArrayList alEDTU = new ArrayList();

            SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
            conITS.Open();

            try
            {
                SqlCommand scmData = new SqlCommand() { Connection = conITS, CommandText = "ITS_Sales_Control", CommandType = CommandType.StoredProcedure };
                scmData.Parameters.Add(new SqlParameter("@gtin", edtTopluDogrulamaGTIN.Text));
                scmData.Parameters.Add(new SqlParameter("@batch_no", edtTopluDogrulamaSeri.Text));
                scmData.Parameters.Add(new SqlParameter("@origin", ((TumAmbalajlariKontrolParametreleri)P).BaslangicId + 1));
                scmData.Parameters.Add(new SqlParameter("@rowcount", ((TumAmbalajlariKontrolParametreleri)P).KayitAdedi));

                SqlDataReader sdrData = scmData.ExecuteReader();
                while (sdrData.Read())
                {
                    DepoDogrulamaBildirimTypeURUN EDTU = new DepoDogrulamaBildirimTypeURUN();
                    EDTU.GTIN = sdrData["mmr_gtin"].ToString();
                    EDTU.XD = Convert.ToDateTime(sdrData["expiry_date"]);
                    EDTU.BN = sdrData["ord_batch_no"].ToString();
                    EDTU.SN = sdrData["pck_code"].ToString();

                    alEDTU.Add(EDTU);
                }
                sdrData.Close();
            }
            finally
            {
                conITS.Close();
            }

            DepoDogrulamaBildirimTypeURUN[] aEDTU = alEDTU.ToArray(typeof(DepoDogrulamaBildirimTypeURUN)) as DepoDogrulamaBildirimTypeURUN[];
            EDT.URUNLER = aEDTU;

            EDS.DepoDogrulamaBildirAsync(EDT);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            lblTumAmbalajlariKontrolAdet.Text = "";
            lbcKontrolSonucu.Items.Clear();

            if (edtTopluDogrulamaBaslangic.Text == "")
            {
                int iKayitAdedi;
                SqlConnection conITS = new SqlConnection(Global.ITSConnectionString);
                conITS.Open();

                try
                {
                    SqlCommand scmData = new SqlCommand() { Connection = conITS, CommandText = "ITS_Sales_Control_Count", CommandType = CommandType.StoredProcedure };
                    scmData.Parameters.Add(new SqlParameter("@gtin", edtTopluDogrulamaGTIN.Text));
                    scmData.Parameters.Add(new SqlParameter("@batch_no", edtTopluDogrulamaSeri.Text));

                    SqlDataReader sdrData = scmData.ExecuteReader();
                    sdrData.Read();
                    iKayitAdedi = Convert.ToInt32(sdrData["count_of_package"]);
                    sdrData.Close();
                }
                finally
                {
                    conITS.Close();
                }

                lblTumAmbalajlariKontrolAdet.Text = iKayitAdedi.ToString();

                int iTekSeferdeGonderilecekKayitAdedi = Settings.DeclarationCount;
                int iDonguAdedi = (iKayitAdedi / iTekSeferdeGonderilecekKayitAdedi) + 1;

                DogrulamaIcinCalisanThreadSayisi = iDonguAdedi;

                for (int i = 90; i < iDonguAdedi; i++)
                {
                    Thread thrTumAmbalajlariKontrol = new Thread(new ParameterizedThreadStart(TumAmbalajlariKontrolEt));
                    thrTumAmbalajlariKontrol.Start(new TumAmbalajlariKontrolParametreleri(i, iTekSeferdeGonderilecekKayitAdedi));
                }
            }
            else
            {
                Thread thrTumAmbalajlariKontrol = new Thread(new ParameterizedThreadStart(TumAmbalajlariKontrolEt));
                thrTumAmbalajlariKontrol.Start(new TumAmbalajlariKontrolParametreleri(Convert.ToInt32(edtTopluDogrulamaBaslangic.Text), Settings.DeclarationCount));
            }
        }

        private void btnPTSSatisBilgileriniGetir_Click(object sender, EventArgs e)
        {
            using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
            {
                grdPTSBildirimiYapilmamisSatisKayitlari.DataSource = lITS.Shipping_Order_List_Browse_For_PTS().ToList();
            }
        }

        private void btnPTSBildirimleriniZamanla_Click(object sender, EventArgs e)
        {
            using (BildirimZamanlama frmBildirimZamanlama = new BildirimZamanlama())
            {
                switch (frmBildirimZamanlama.ShowDialog())
                {
                    case DialogResult.OK:
                        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                        {
                            for (int i = 0; i < grdPTSBildirimiYapilmamisSatisKayitlariView.RowCount; i++)
                            {
                                if (grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(i, grdPTSBildirimiYapilmamisSatisKayitlariChecked) != null
                                    && Convert.ToBoolean(grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(i, grdPTSBildirimiYapilmamisSatisKayitlariChecked)) == true)
                                {
                                    try
                                    {
                                        lITS.Scheduled_Declaration_Insert(grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(i, grdPTSBildirimiYapilmamisSatisKayitlariOrderNumber).ToString(),
                                                                          'C',
                                                                          frmBildirimZamanlama.dteBildirimZamani.DateTime,
                                                                          Global.UsrId, null, null);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }

                            grdPTSBildirimiYapilmamisSatisKayitlari.DataSource = lITS.Shipping_Order_List_Browse_For_PTS().ToList();
                        }
                        break;

                    case DialogResult.Abort:
                        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                        {
                            for (int i = 0; i < grdPTSBildirimiYapilmamisSatisKayitlariView.RowCount; i++)
                            {
                                if (grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(i, grdPTSBildirimiYapilmamisSatisKayitlariChecked) != null
                                    && Convert.ToBoolean(grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(i, grdPTSBildirimiYapilmamisSatisKayitlariChecked)) == true)
                                {
                                    try
                                    {
                                        lITS.Scheduled_Declaration_Delete(grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(i, grdPTSBildirimiYapilmamisSatisKayitlariOrderNumber).ToString(),
                                                                          'C');
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }

                            grdPTSBildirimiYapilmamisSatisKayitlari.DataSource = lITS.Shipping_Order_List_Browse_For_PTS().ToList();
                        }
                        break;
                }
            }
        }

        private void SendPTS(object OrderNumber)
        {
            try
            {
                DeclarationServices.SendPTS PTS = new DeclarationServices.SendPTS(Global.UsrId, Global.Environment, Global.ITSConnectionString);
                PTS.GonderAsync(OrderNumber.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSeciliPTSSatislarinBildiriminiYap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili satış bilgilerinin PTS bildirimi yapılacaktır. Bu işlemin iptali yoktur. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Cursor = Cursors.WaitCursor;

            try
            {
                SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);

                bKapanamaz = true;
                btnPTSSatisBilgileriniGetir.Enabled = false;
                btnPTSBildirimleriniZamanla.Enabled = false;
                btnSeciliPTSSatislarinBildiriminiYap.Enabled = false;
                grdPTSBildirimiYapilmamisSatisKayitlari.Enabled = false;

                DeclarationServices.SendPTS PTS = new DeclarationServices.SendPTS(Global.UsrId, Global.Environment, Global.ITSConnectionString);

                for (int i = 0; i < grdPTSBildirimiYapilmamisSatisKayitlariView.RowCount; i++)
                {
                    if (grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(i, grdPTSBildirimiYapilmamisSatisKayitlariChecked) != null
                       && Convert.ToBoolean(grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(i, grdPTSBildirimiYapilmamisSatisKayitlariChecked)) == true)
                    {
                        //Thread thrPTS = new Thread(new ParameterizedThreadStart(SendPTS));
                        //thrPTS.Start(grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(i, grdPTSBildirimiYapilmamisSatisKayitlariOrderNumber));
                        PTS.GonderAsync(grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(i, grdPTSBildirimiYapilmamisSatisKayitlariOrderNumber).ToString());
                        Application.DoEvents();
                    }
                }

                Application.DoEvents();
                sstMain.Items[0].Text = "PTS bildirimleri gönderildi.";
                sstMain.Items[0].Image = ITS.Properties.Resources.accept;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PTS bildirimleri gönderilemedi! Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bKapanamaz = false;

                tmrStatus.Start();
                btnPTSSatisBilgileriniGetir.Enabled = true;
                grdPTSBildirimiYapilmamisSatisKayitlari.Enabled = true;

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdPTSBildirimiYapilmamisSatisKayitlari.DataSource = lITS.Shipping_Order_List_Browse_For_PTS().ToList();
                }

                btnPTSBildirimleriniZamanla.Enabled = false;
                btnSeciliPTSSatislarinBildiriminiYap.Enabled = false;

                Cursor = Cursors.Default;
                SplashScreenManager.CloseForm();
            }
        }

        private void SatisBilgileriniYenile()
        {
            Cursor = Cursors.WaitCursor;
            //SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
            btnSatisBilgileriniGetir.Enabled = false;
            btnSatisVerisiAl.Enabled = false;
            grdSatisBildirimiYapilmamisKayitlar.Enabled = false;
            btnSeciliSatisBildirimleriniZamanla.Enabled = false;
            btnSeciliSatisBildirimleriniYap.Enabled = false;
            Application.DoEvents();

            try
            {

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdSatisBildirimiYapilmamisKayitlar.DataSource = lITS.Shipping_Order_List_Browse_For_Declaration().ToList();
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                btnSatisBilgileriniGetir.Enabled = true;
                btnSatisVerisiAl.Enabled = true;
                grdSatisBildirimiYapilmamisKayitlar.Enabled = true;
                //SplashScreenManager.CloseForm();
            }
        }

        private void btnSatisBilgileriniGetir_Click(object sender, EventArgs e)
        {
            SatisBilgileriniYenile();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            PackageReceiverWebService PRS = new PackageReceiverWebService();
            PRS.Url = "http://pts.saglik.gov.tr/PTS/PackageReceiverWebService";
            PRS.Timeout = 15000;

            PRS.PreAuthenticate = true;
            PRS.Credentials = new NetworkCredential("86800010864430000", "mer1kez2");

            if (Settings.ProxyAddress != "")
                PRS.Proxy = new WebProxy(Settings.ProxyAddress, Convert.ToInt32(Settings.ProxyPort));

            receiveFileParametersType RFP = new receiveFileParametersType();
            RFP.sourceGLN = "8680001086443";
            RFP.transferId = 10021659;

            byte[] bFile = PRS.receiveFileStream(RFP);
            //File.WriteAllBytes("Temp/gelen2.zip", bFile);
            FileStream fsOutput = new FileStream("Temp/gelen_pts.zip", FileMode.Create);
            fsOutput.Write(bFile, 0, bFile.Length);
            fsOutput.Flush();
        }

        private void SendSales(object OrderNumber)
        {
            try
            {
                DeclarationServices.SendSales SB = new DeclarationServices.SendSales(Global.UsrId, Global.Environment, Global.ITSConnectionString);
                SB.SendAsync(OrderNumber.ToString(), 1, null, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSeciliSatisBildirimleriniYap_Click(object sender, EventArgs e)
        {
            ClickedButton = 4;
            mnuShippingOrderDeclarationSales.Enabled = true;
            btnSeciliSatisBildirimleriniYap.ContextMenuStrip.Show(btnSeciliSatisBildirimleriniYap, new System.Drawing.Point(0, btnSeciliSatisBildirimleriniYap.Height));
        }

        private void btnSeciliSatisBildirimleriniZamanla_Click(object sender, EventArgs e)
        {
            ClickedButton = 3;
            mnuShippingOrderDeclarationSales.Enabled = true;
            btnSeciliSatisBildirimleriniZamanla.ContextMenuStrip.Show(btnSeciliSatisBildirimleriniZamanla, new System.Drawing.Point(0, btnSeciliSatisBildirimleriniZamanla.Height));
        }

        //  private List<Shipping_Order_Detail_Packages_BrowseResult> tShippingOrderDetailPackages;
        private List<Shipping_Order_Detail_Packages_Browse_NEWResult> tShippingOrderDetailPackages;

        public void RefreshShippingDetails(byte SearchType)
        {
            using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
            {
                List<Shipping_Order_BrowseResult> tShippingOrders = null;

                if (SearchType == 1)
                    tShippingOrders = lITS.Shipping_Order_Browse(edtShippingOrderIPTSNumber.Text, null).ToList();
                else
                    if (SearchType == 2)
                    tShippingOrders = lITS.Shipping_Order_Browse(null, edtShippingOrderIInvoiceNumber.Text).ToList();

                if (tShippingOrders == null)
                    return;

                if (tShippingOrders.Count == 0)
                {
                    MessageBox.Show("Aranan kayıt bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                edtShippingOrderIAccountInformations.Text = tShippingOrders.First().account_name;

                if (SearchType == 1)
                    edtShippingOrderIInvoiceNumber.Text = tShippingOrders.First().sor_invoice_number;
                else
                    if (SearchType == 2)
                    edtShippingOrderIPTSNumber.Text = tShippingOrders.First().sor_order_number;

                if (tShippingOrders.First().sor_invoice_date.HasValue)
                    edtShippingOrderIInvoiceDate.Text = tShippingOrders.First().sor_invoice_date.Value.ToString("g");

                if (tShippingOrders.First().sor_pts_transfered_date.HasValue)
                {
                    edtShippingOrderIPTSDecDate.Text = tShippingOrders.First().sor_pts_transfered_date.Value.ToString("g");
                    edtShippingOrderIPTSDecDate.ForeColor = Color.Black;
                }
                else
                    if (tShippingOrders.First().pts_scheduled_time.HasValue)
                {
                    edtShippingOrderIPTSDecDate.Text = tShippingOrders.First().pts_scheduled_time.Value.ToString("g");
                    edtShippingOrderIPTSDecDate.ForeColor = Color.Green;
                }
                else
                    edtShippingOrderIPTSDecDate.Text = "";

                mnuShippingOrderDeclarationSales.Enabled = true;

                if (tShippingOrders.First().sales_declaration_date.HasValue)
                {
                    edtShippingOrderISalesDecDate.Text = tShippingOrders.First().sales_declaration_date.Value.ToString("g");
                    edtShippingOrderISalesDecDate.ForeColor = Color.Black;
                    mnuShippingOrderDeclarationSales.Enabled = false;
                }
                else
                    if (tShippingOrders.First().sales_scheduled_time.HasValue)
                {
                    edtShippingOrderISalesDecDate.Text = tShippingOrders.First().sales_scheduled_time.Value.ToString("g");
                    edtShippingOrderISalesDecDate.ForeColor = Color.Green;
                }
                else
                    edtShippingOrderISalesDecDate.Text = "";

                edtShippingOrderIPackageCount.Text = tShippingOrders.First().package_count_of_shipping.ToString();
                edtShippingOrderICaseCount.Text = tShippingOrders.First().case_count_of_shipping.ToString();
                edtShippingOrderIID.Text = tShippingOrders.First().sor_id.ToString();
                //edtShippingOrderIComID.Text = tShippingOrders.First().sor_com_id.ToString();
                //edtShippingOrderIStatus.Text = tShippingOrders.First().sor_status.ToString();
                edtShippingOrderITransferId.Text = tShippingOrders.First().sor_pts_transfer_id.ToString();

                grdSalesDetailsPackageList.DataSource = null;
                tShippingOrderDetailPackages = lITS.Shipping_Order_Detail_Packages_Browse_NEW(edtShippingOrderIPTSNumber.Text).ToList();
                trlSalesDetailsSSCC.DataSource = lITS.Shipping_Order_Detail_SSCC_Browse(edtShippingOrderIPTSNumber.Text).ToList();
                btnShippingOrderIScheduledDeclaration.Enabled = true;
                btnShippingOrderIDeclarationNow.Enabled = true;
                btnSatisDetayAmbalajEkle.Enabled = true;
                btnSatisIptalOlustur.Enabled = true;
            }
        }

        private void edtShippingOrderIPTSNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshShippingDetails(1);
            }
        }

        private void trlSalesDetailsSSCC_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            grdSalesDetailsPackageList.DataSource = tShippingOrderDetailPackages.Where(p =>
                                                                                       p.package_sscc == e.Node.GetValue("package_sscc").ToString()).ToList();
        }

        private void edtShippingOrderIInvoiceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshShippingDetails(2);
            }
        }

        protected internal void edtShippingSearchCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (edtShippingSearchCode.Text == "")
                {
                    grdSalesDetailsPackageList.DataSource = tShippingOrderDetailPackages.Where(p =>
                                                                                               p.package_sscc == trlSalesDetailsSSCC.FocusedNode.GetValue("package_sscc").ToString()).ToList();
                }
                else
                {
                    using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                    {
                        var tShippingOrder = lITS.Shipping_Order_Search(edtShippingSearchCode.Text).ToList();

                        if (tShippingOrder.Count == 0)
                        {
                            MessageBox.Show("Aranan kayıt bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        edtShippingOrderIPTSNumber.Text = tShippingOrder.First().sor_order_number;
                        RefreshShippingDetails(1);
                        grdSalesDetailsPackageList.DataSource = tShippingOrderDetailPackages.Where(p =>
                                                                                                   p.package_code.Substring(0, edtShippingSearchCode.Text.Length) == edtShippingSearchCode.Text.ToUpper()).ToList();
                    }
                }
            }
        }

        private void grdPTSBildirimiYapilmamisSatisKayitlariView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.VisibleIndex == 0)
            {
                btnSeciliPTSSatislarinBildiriminiYap.Enabled = false;
                btnPTSBildirimleriniZamanla.Enabled = false;

                for (int i = 0; i < grdPTSBildirimiYapilmamisSatisKayitlariView.RowCount; i++)
                {
                    if (grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(i, grdPTSBildirimiYapilmamisSatisKayitlariChecked) != null
                        && Convert.ToBoolean(grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(i, grdPTSBildirimiYapilmamisSatisKayitlariChecked)) == true)
                    {
                        btnSeciliPTSSatislarinBildiriminiYap.Enabled = true;
                        btnPTSBildirimleriniZamanla.Enabled = true;
                    }
                }
            }
        }

        private void grdPTSBildirimiYapilmamisSatisKayitlariCheckedRepository_EditValueChanged(object sender, EventArgs e)
        {
            grdPTSBildirimiYapilmamisSatisKayitlariView.PostEditor();
        }

        private void grdPTSBildirimiYapilmamisSatisKayitlariView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if ((Boolean)grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(e.RowHandle, grdPTSBildirimiYapilmamisSatisKayitlariChecked))
            {
                e.Appearance.BackColor = Color.PapayaWhip;
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void grdPTSBildirimiYapilmamisSatisKayitlari_DoubleClick(object sender, EventArgs e)
        {
            edtSource.SelectedTabPageIndex = 6;
            edtShippingOrderIPTSNumber.Text = grdPTSBildirimiYapilmamisSatisKayitlariView.GetRowCellValue(grdPTSBildirimiYapilmamisSatisKayitlariView.FocusedRowHandle, grdPTSBildirimiYapilmamisSatisKayitlariOrderNumber).ToString();
            RefreshShippingDetails(1);
        }

        private void grdSatisBildirimiYapilmamisKayitlarView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if ((Boolean)grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(e.RowHandle, grdSatisBildirimiYapilmamisKayitlarChecked))
            {
                e.Appearance.BackColor = Color.PapayaWhip;
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void grdSatisBildirimiYapilmamisKayitlarView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.VisibleIndex == 0)
            {
                btnSeciliSatisBildirimleriniZamanla.Enabled = false;
                btnSeciliSatisBildirimleriniYap.Enabled = false;

                mnuShippingOrderDeclarationSales.Enabled = false;
                mnuShippingOrderDeclarationPTS.Enabled = false;

                for (int i = 0; i < grdSatisBildirimiYapilmamisKayitlarView.RowCount; i++)
                {
                    if (grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked) != null
                        && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked)) == true)
                    {
                        if (Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarSatisBildirimi)) == true)
                            mnuShippingOrderDeclarationSales.Enabled = true;

                        if (Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarPTSBildirimi)) == true)
                            mnuShippingOrderDeclarationPTS.Enabled = true;

                        btnSeciliSatisBildirimleriniZamanla.Enabled = true;
                        btnSeciliSatisBildirimleriniYap.Enabled = true;
                    }
                }
            }
        }

        private void grdSatisBildirimiYapilmamisKayitlarCheckedRepository_EditValueChanged(object sender, EventArgs e)
        {
            grdSatisBildirimiYapilmamisKayitlarView.PostEditor();
        }

        private void grdSatisBildirimiYapilmamisKayitlar_DoubleClick(object sender, EventArgs e)
        {
            edtSource.SelectedTabPageIndex = 7;
            edtShippingOrderIPTSNumber.Text = grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(grdSatisBildirimiYapilmamisKayitlarView.FocusedRowHandle, grdSatisBildirimiYapilmamisKayitlarOrderNumber).ToString();
            RefreshShippingDetails(1);
        }

        private void edtShippingSearchBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 8)
            {
                edtShippingSearchBarcode.Text = "";
                sBarkod = "";
            }
            else
                if (e.KeyValue == 13)
            {
                try
                {
                    if (sBarkod.Length == 20) // SSCC
                    {
                        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                        {
                            var tShippingOrder = lITS.Shipping_Order_Search(sBarkod).ToList();
                            if (tShippingOrder.Count == 0)
                            {
                                MessageBox.Show("Aranan kayıt bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            edtShippingOrderIPTSNumber.Text = tShippingOrder.First().sor_order_number;
                            RefreshShippingDetails(1);
                        }
                    }
                    else
                    {
                        KareKod kkBarkod = new KareKod(sBarkod, 'D');
                        edtShippingSearchCode.Text = kkBarkod.PackageCode;

                        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                        {
                            var tShippingOrder = lITS.Shipping_Order_Search(edtShippingSearchCode.Text).ToList();
                            if (tShippingOrder.Count == 0)
                            {
                                MessageBox.Show("Aranan kayıt bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            edtShippingOrderIPTSNumber.Text = tShippingOrder.First().sor_order_number;
                            RefreshShippingDetails(1);
                            grdSalesDetailsPackageList.DataSource = tShippingOrderDetailPackages.Where(p => p.package_code.Substring(0, edtShippingSearchCode.Text.Length) == edtShippingSearchCode.Text.ToUpper()).ToList();
                        }
                    }
                }
                finally
                {
                    edtShippingSearchBarcode.SelectAll();
                    sBarkod = "";
                }
            }
            else
                sBarkod += (char)e.KeyValue;
        }

        private void btnShippingOrderIScheduledDeclaration_Click(object sender, EventArgs e)
        {
            ClickedButton = 1;
            mnuShippingOrderDeclarationPTS.Enabled = true;
            mnuShippingOrderDeclarationSales.Enabled = true;
            btnShippingOrderIScheduledDeclaration.ContextMenuStrip.Show(btnShippingOrderIScheduledDeclaration, new System.Drawing.Point(0, btnShippingOrderIScheduledDeclaration.Height));
        }

        private void btnShippingOrderIDeclarationNow_Click(object sender, EventArgs e)
        {
            ClickedButton = 2;
            mnuShippingOrderDeclarationPTS.Enabled = true;
            mnuShippingOrderDeclarationSales.Enabled = true;
            btnShippingOrderIDeclarationNow.ContextMenuStrip.Show(btnShippingOrderIDeclarationNow, new System.Drawing.Point(0, btnShippingOrderIDeclarationNow.Height));
        }

        private void mnuShippingOrderDeclarationSales_Click(object sender, EventArgs e)
        {
            switch (ClickedButton)
            {
                case 1:
                    using (BildirimZamanlama frmBildirimZamanlama = new BildirimZamanlama())
                    {
                        switch (frmBildirimZamanlama.ShowDialog())
                        {
                            case DialogResult.OK:
                                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                                {
                                    try
                                    {
                                        lITS.Scheduled_Declaration_Insert(edtShippingOrderIPTSNumber.Text,
                                                                          'S',
                                                                          frmBildirimZamanlama.dteBildirimZamani.DateTime,
                                                                          Global.UsrId, null, null);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;

                            case DialogResult.Abort:
                                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                                {
                                    try
                                    {
                                        lITS.Scheduled_Declaration_Delete(edtShippingOrderIPTSNumber.Text,
                                                                          'S');
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;
                        }
                    }

                    RefreshShippingDetails(1);
                    break;

                case 2:
                    if (MessageBox.Show("Satış bildirimi yapılacaktır. Bu işlemin iptali yoktur. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    Cursor = Cursors.WaitCursor;

                    try
                    {
                        SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);

                        bKapanamaz = true;

                        DeclarationServices.SendSales SB = new DeclarationServices.SendSales(Global.UsrId, Global.Environment, Global.ITSConnectionString);
                        SB.SendAsync(edtShippingOrderIPTSNumber.Text,
                                1,
                                null,
                                null);
                        RefreshShippingDetails(1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Satış bildirimleri gönderilemedi! Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        bKapanamaz = false;
                        Cursor = Cursors.Default;
                        SplashScreenManager.CloseForm();
                    }
                    break;

                case 3:
                    using (BildirimZamanlama frmBildirimZamanlama = new BildirimZamanlama())
                    {
                        switch (frmBildirimZamanlama.ShowDialog())
                        {
                            case DialogResult.OK:
                                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                                {
                                    for (int i = 0; i < grdSatisBildirimiYapilmamisKayitlarView.RowCount; i++)
                                    {
                                        if (grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked) != null
                                           && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked)) == true
                                           && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarSatisBildirimi)) == true)
                                        {
                                            try
                                            {
                                                lITS.Scheduled_Declaration_Insert(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarOrderNumber).ToString(),
                                                                                  'S',
                                                                                  frmBildirimZamanlama.dteBildirimZamani.DateTime,
                                                                                  Global.UsrId, null, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }

                                    SatisBilgileriniYenile();
                                }
                                break;

                            case DialogResult.Abort:
                                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                                {
                                    for (int i = 0; i < grdSatisBildirimiYapilmamisKayitlarView.RowCount; i++)
                                    {
                                        if (grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked) != null
                                            && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked)) == true
                                            && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarSatisBildirimi)) == true)
                                        {
                                            try
                                            {
                                                lITS.Scheduled_Declaration_Delete(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarOrderNumber).ToString(),
                                                                                  'S');
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }

                                    SatisBilgileriniYenile();
                                }
                                break;
                        }
                    }
                    break;
                case 4:
                    if (MessageBox.Show("Seçili satış bilgilerinin İTS bildirimi yapılacaktır. Bu işlemin iptali yoktur. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);

                        bKapanamaz = true;
                        btnSatisBilgileriniGetir.Enabled = false;
                        btnSatisVerisiAl.Enabled = false;
                        btnSeciliSatisBildirimleriniZamanla.Enabled = false;
                        btnSeciliSatisBildirimleriniYap.Enabled = false;
                        grdSatisBildirimiYapilmamisKayitlar.Enabled = false;
                        Application.DoEvents();

                        DeclarationServices.SendSales SB2 = new DeclarationServices.SendSales(Global.UsrId, Global.Environment, Global.ITSConnectionString);

                        for (int i = 0; i < grdSatisBildirimiYapilmamisKayitlarView.RowCount; i++)
                        {
                            if (grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked) != null
                                && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked)) == true
                                && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarSatisBildirimi)) == true)
                            {
                                SB2.SendAsync(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarOrderNumber).ToString(), 1, null, null);
                            }
                        }
                        sstMain.Items[0].Text = "Satış bildirimleri gönderildi.";
                        sstMain.Items[0].Image = ITS.Properties.Resources.accept;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Satış bildirimleri gönderilemedi! Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        bKapanamaz = false;

                        tmrStatus.Start();

                        btnSatisBilgileriniGetir.Enabled = true;
                        btnSatisVerisiAl.Enabled = true;
                        grdSatisBildirimiYapilmamisKayitlar.Enabled = true;

                        btnSeciliSatisBildirimleriniZamanla.Enabled = false;
                        btnSeciliSatisBildirimleriniYap.Enabled = false;

                        Cursor = Cursors.Default;
                        SplashScreenManager.CloseForm();
                        SatisBilgileriniYenile();
                    }
                    break;
            }
        }

        private void mnuShippingOrderDeclarationPTS_Click(object sender, EventArgs e)
        {
            switch (ClickedButton)
            {
                case 1:
                    using (BildirimZamanlama frmBildirimZamanlama = new BildirimZamanlama())
                    {
                        switch (frmBildirimZamanlama.ShowDialog())
                        {
                            case DialogResult.OK:
                                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                                {
                                    try
                                    {
                                        lITS.Scheduled_Declaration_Insert(edtShippingOrderIPTSNumber.Text,
                                                                          'C',
                                                                          frmBildirimZamanlama.dteBildirimZamani.DateTime,
                                                                          Global.UsrId, null, null);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;

                            case DialogResult.Abort:
                                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                                {
                                    try
                                    {
                                        lITS.Scheduled_Declaration_Delete(edtShippingOrderIPTSNumber.Text,
                                                                          'C');
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;
                        }
                    }
                    RefreshShippingDetails(1);
                    break;

                case 2:
                    if (MessageBox.Show("PTS bildirimi yapılacaktır. Bu işlemin iptali yoktur. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);

                        DeclarationServices.SendPTS PTS = new DeclarationServices.SendPTS(Global.UsrId, Global.Environment, Global.ITSConnectionString);
                        PTS.GonderAsync(edtShippingOrderIPTSNumber.Text);
                        RefreshShippingDetails(1);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        SplashScreenManager.CloseForm();
                    }
                    break;

                case 3:
                    using (BildirimZamanlama frmBildirimZamanlama = new BildirimZamanlama())
                    {
                        switch (frmBildirimZamanlama.ShowDialog())
                        {
                            case DialogResult.OK:
                                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                                {
                                    for (int i = 0; i < grdSatisBildirimiYapilmamisKayitlarView.RowCount; i++)
                                    {
                                        if (grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked) != null
                                            && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked)) == true
                                            && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarPTSBildirimi)) == true)
                                        {
                                            try
                                            {
                                                lITS.Scheduled_Declaration_Insert(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarOrderNumber).ToString(),
                                                                                  'C',
                                                                                  frmBildirimZamanlama.dteBildirimZamani.DateTime,
                                                                                  Global.UsrId, null, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }

                                    SatisBilgileriniYenile();
                                }
                                break;

                            case DialogResult.Abort:
                                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                                {
                                    for (int i = 0; i < grdSatisBildirimiYapilmamisKayitlarView.RowCount; i++)
                                    {
                                        if (grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked) != null
                                           && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked)) == true
                                           && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarPTSBildirimi)) == true)
                                        {
                                            try
                                            {
                                                lITS.Scheduled_Declaration_Delete(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarOrderNumber).ToString(),
                                                                                  'C');
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                    SatisBilgileriniYenile();
                                }
                                break;
                        }
                    }
                    break;

                case 4:
                    if (MessageBox.Show("Seçili satış bilgilerinin PTS bildirimi yapılacaktır. Bu işlemin iptali yoktur. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);

                        bKapanamaz = true;
                        btnSatisBilgileriniGetir.Enabled = false;
                        btnSatisVerisiAl.Enabled = false;
                        btnSeciliSatisBildirimleriniZamanla.Enabled = false;
                        btnSeciliSatisBildirimleriniYap.Enabled = false;
                        grdSatisBildirimiYapilmamisKayitlar.Enabled = false;
                        Application.DoEvents();

                        DeclarationServices.SendPTS PTS2 = new DeclarationServices.SendPTS(Global.UsrId, Global.Environment, Global.ITSConnectionString);

                        for (int i = 0; i < grdSatisBildirimiYapilmamisKayitlarView.RowCount; i++)
                        {
                            if (grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked) != null
                                && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarChecked)) == true
                                && Convert.ToBoolean(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarPTSBildirimi)) == true)
                            {
                                PTS2.GonderAsync(grdSatisBildirimiYapilmamisKayitlarView.GetRowCellValue(i, grdSatisBildirimiYapilmamisKayitlarOrderNumber).ToString());
                                Application.DoEvents();
                            }
                        }

                        Application.DoEvents();
                        sstMain.Items[0].Text = "PTS bildirimleri gönderildi.";
                        sstMain.Items[0].Image = ITS.Properties.Resources.accept;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("PTS bildirimleri gönderilemedi! Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        bKapanamaz = false;

                        tmrStatus.Start();

                        btnSatisBilgileriniGetir.Enabled = true;
                        btnSatisVerisiAl.Enabled = true;
                        grdSatisBildirimiYapilmamisKayitlar.Enabled = true;

                        btnSeciliSatisBildirimleriniZamanla.Enabled = false;
                        btnSeciliSatisBildirimleriniYap.Enabled = false;

                        Cursor = Cursors.Default;
                        SplashScreenManager.CloseForm();
                        SatisBilgileriniYenile();
                    }
                    break;
            }
        }

        private void grdAmbalajDetayiDeleteRep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!Guvenlik.GuvenlikKontrol(edtSource.SelectedTabPage.Name, Guvenlik.Yetkiler.KayitGuncelleme))
            {
                MessageBox.Show("Güncelleme yetkiniz olmadığından dolayı bu işlemi gerçekleştiremezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdAmbalajDetayiView.SetFocusedRowCellValue(grdAmbalajDetayiChecked, true);

                    for (int i = 0; i < grdAmbalajDetayiView.RowCount; i++)
                    {
                        if (grdAmbalajDetayiView.GetRowCellValue(i, grdAmbalajDetayiChecked) != null
                            && Convert.ToBoolean(grdAmbalajDetayiView.GetRowCellValue(i, grdAmbalajDetayiChecked)) == true)
                        {
                            if (grdAmbalajDetayiView.GetRow(i).GetType().Name == "Package_List_BrowseResult")
                            {
                                Package_List_BrowseResult Row = (Package_List_BrowseResult)grdAmbalajDetayiView.GetRow(i);

                                if (Row.pck_status_id == 99)
                                {
                                    lITS.Package_List_Update(Row.pck_id, 10);
                                    Row.pck_status_id = 10;
                                    Row.pst_description = "İYİ DURUMDA";
                                }
                                else
                                {
                                    lITS.Package_List_Update(Row.pck_id, 99);
                                    Row.pck_status_id = 99;
                                    Row.pst_description = "BİLDİRİLMEYECEK";
                                }
                            }
                            else
                                if (grdAmbalajDetayiView.GetRow(i).GetType().Name == "Package_List_Browse_For_Production_DetailResult")
                            {
                                Package_List_Browse_For_Production_DetailResult Row = (Package_List_Browse_For_Production_DetailResult)grdAmbalajDetayiView.GetRow(i);

                                if (Row.pck_status_id == 99)
                                {
                                    lITS.Package_List_Update(Row.pck_id, 10);
                                    Row.pck_status_id = 10;
                                    Row.pst_description = "İYİ DURUMDA";
                                }
                                else
                                {
                                    lITS.Package_List_Update(Row.pck_id, 99);
                                    Row.pck_status_id = 99;
                                    Row.pst_description = "BİLDİRİLMEYECEK";
                                }
                            }

                            grdAmbalajDetayiView.FocusedRowHandle = i;
                            grdAmbalajDetayiView.UpdateCurrentRow();
                            grdAmbalajDetayiView.SetRowCellValue(i, grdAmbalajDetayiChecked, false);
                        }
                    }

                    grdAmbalajDetayiView.FocusedRowHandle = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void grdAmbalajDetayiUpdateRep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!Guvenlik.GuvenlikKontrol(edtSource.SelectedTabPage.Name, Guvenlik.Yetkiler.KayitGuncelleme))
            {
                MessageBox.Show("Güncelleme yetkiniz olmadığından dolayı bu işlemi gerçekleştiremezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (AmbalajGecerlilikDurumuDegistir frmAmbalajGecerlilikDurumuDegistir = new AmbalajGecerlilikDurumuDegistir())
            {
                for (int i = 0; i < cbeGecerlilikDurumu.Properties.Items.Count; i++)
                    frmAmbalajGecerlilikDurumuDegistir.cbeGecerlilikDurumu.Properties.Items.Add(cbeGecerlilikDurumu.Properties.Items[i]);

                if (frmAmbalajGecerlilikDurumuDegistir.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                        {
                            grdAmbalajDetayiView.SetFocusedRowCellValue(grdAmbalajDetayiChecked, true);

                            for (int i = 0; i < grdAmbalajDetayiView.RowCount; i++)
                            {
                                if (grdAmbalajDetayiView.GetRowCellValue(i, grdAmbalajDetayiChecked) != null
                                    && Convert.ToBoolean(grdAmbalajDetayiView.GetRowCellValue(i, grdAmbalajDetayiChecked)) == true)
                                {
                                    if (grdAmbalajDetayiView.GetRow(i).GetType().Name == "Package_List_BrowseResult")
                                    {
                                        Package_List_BrowseResult Row = (Package_List_BrowseResult)grdAmbalajDetayiView.GetRow(i);
                                        lITS.Package_List_Update(Row.pck_id, ((GecerlilikDurumuDetayi)frmAmbalajGecerlilikDurumuDegistir.cbeGecerlilikDurumu.SelectedItem).Value);
                                        Row.pck_status_id = ((GecerlilikDurumuDetayi)frmAmbalajGecerlilikDurumuDegistir.cbeGecerlilikDurumu.SelectedItem).Value;
                                        Row.pst_description = ((GecerlilikDurumuDetayi)frmAmbalajGecerlilikDurumuDegistir.cbeGecerlilikDurumu.SelectedItem).ToString();
                                    }
                                    else
                                        if (grdAmbalajDetayiView.GetRow(i).GetType().Name == "Package_List_Browse_For_Production_DetailResult")
                                    {
                                        Package_List_Browse_For_Production_DetailResult Row = (Package_List_Browse_For_Production_DetailResult)grdAmbalajDetayiView.GetRow(i);
                                        lITS.Package_List_Update(Row.pck_id, ((GecerlilikDurumuDetayi)frmAmbalajGecerlilikDurumuDegistir.cbeGecerlilikDurumu.SelectedItem).Value);
                                        Row.pck_status_id = ((GecerlilikDurumuDetayi)frmAmbalajGecerlilikDurumuDegistir.cbeGecerlilikDurumu.SelectedItem).Value;
                                        Row.pst_description = ((GecerlilikDurumuDetayi)frmAmbalajGecerlilikDurumuDegistir.cbeGecerlilikDurumu.SelectedItem).ToString();
                                    }

                                    grdAmbalajDetayiView.FocusedRowHandle = i;
                                    grdAmbalajDetayiView.UpdateCurrentRow();
                                    grdAmbalajDetayiView.SetRowCellValue(i, grdAmbalajDetayiChecked, false);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void grdUretimBildirimiView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if ((Boolean)grdUretimBildirimiView.GetRowCellValue(e.RowHandle, grdUretimBildirimiChecked))
            {
                e.Appearance.BackColor = Color.PapayaWhip;
                e.Appearance.ForeColor = Color.Black;
            }

            if (grdUretimBildirimiView.GetRowCellValue(e.RowHandle, grdUretimBildirimiScheduledTime) != null)
            {
                e.Appearance.ForeColor = Color.Green;
            }
        }

        private void grdUretimBildirimiView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.VisibleIndex == 0)
            {
                btnUretimBildirimi.Enabled = false;
                btnSeciliUretimleinBildirimleriniZamanla.Enabled = false;
                string sType = "";
                int iCheckedCount = 0;

                for (int i = 0; i < grdUretimBildirimiView.RowCount; i++)
                {
                    if (grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiChecked) != null
                        && Convert.ToBoolean(grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiChecked)) == true)
                    {
                        if (sType == "")
                            sType = grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiProductionType).ToString();

                        iCheckedCount++;
                        btnUretimBildirimi.Enabled = (sType == grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiProductionType).ToString());
                        btnSeciliUretimleinBildirimleriniZamanla.Enabled = (sType == grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiProductionType).ToString());

                        if (!btnUretimBildirimi.Enabled) break;
                    }
                }

                if (sType == "Fason" && btnUretimBildirimi.Enabled)
                {
                    if (iCheckedCount > 1)
                    {
                        btnUretimBildirimi.Enabled = false;
                        btnSeciliUretimleinBildirimleriniZamanla.Enabled = false;
                        btnUretimBildirimi.Text = "Seçili Üretimlerin Bildirimini Yap";
                    }
                    else
                    {
                        btnUretimBildirimi.Text = "Seçili Üretimin PTS Bildirimini Yap";
                        btnSeciliUretimleinBildirimleriniZamanla.Enabled = false;
                    }
                }
                else
                    btnUretimBildirimi.Text = "Seçili Üretimlerin Bildirimini Yap";
            }
        }

        private void grdUretimBildirimiView_DoubleClick(object sender, EventArgs e)
        {
            edtSource.SelectedTabPage.Name = "tbpUretimDetaylari";
            edtUDUretimEmriNo.Text = grdUretimBildirimiView.GetFocusedRowCellValue(grdUretimBildirimiOrderId).ToString();
            UretimDetaylariListesiniYenile();
        }

        private void grdUretimBildirimiCheckedRepository_EditValueChanged(object sender, EventArgs e)
        {
            grdUretimBildirimiView.PostEditor();
        }

        private void grdUretimArkaPlanAmbalajlarAddRepository_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!Guvenlik.GuvenlikKontrol(edtSource.SelectedTabPage.Name, Guvenlik.Yetkiler.KayitEkleme))
            {
                MessageBox.Show("Kayıt ekleme yetkiniz olmadığından dolayı bu işlemi gerçekleştiremezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdUretimArkaPlanAmbalajlarView.SetFocusedRowCellValue(grdUretimArkaPlanAmbalajlarChecked, true);

                    for (int i = 0; i < grdUretimArkaPlanAmbalajlarView.RowCount; i++)
                    {
                        if (grdUretimArkaPlanAmbalajlarView.GetRowCellValue(i, grdUretimArkaPlanAmbalajlarChecked) != null
                            && Convert.ToBoolean(grdUretimArkaPlanAmbalajlarView.GetRowCellValue(i, grdUretimArkaPlanAmbalajlarChecked)) == true)
                        {
                            if (grdUretimArkaPlanAmbalajlarView.GetRow(i).GetType().Name == "Package_List_Not_Printed_BrowseResult")
                            {
                                Package_List_Not_Printed_BrowseResult Row = (Package_List_Not_Printed_BrowseResult)grdUretimArkaPlanAmbalajlarView.GetRow(i);
                                lITS.Package_List_Insert(edtUDUretimEmriNoPerm.Text,
                                                         Row.pcp_code,
                                                         Global.UsrId,
                                                         Row.pcp_order_id,
                                                         "TTS");
                            }
                            else
                                if (grdUretimArkaPlanAmbalajlarView.GetRow(i).GetType().Name == "Package_List_Not_Printed_Browse_For_Production_DetailResult")
                            {
                                Package_List_Not_Printed_Browse_For_Production_DetailResult Row = (Package_List_Not_Printed_Browse_For_Production_DetailResult)grdUretimArkaPlanAmbalajlarView.GetRow(i);
                                lITS.Package_List_Insert(Row.pcp_order_id,
                                                         Row.pcp_code,
                                                         Global.UsrId,
                                                         Row.pcp_order_id,
                                                         "TTS");
                            }
                        }
                    }

                    int iFocusedRowHandle = grdUretimArkaPlanAmbalajlarView.FocusedRowHandle;

                    if (!bUDSeriBazindaAmbalaj)
                        grdUretimArkaPlanAmbalajlar.DataSource = lITS.Package_List_Not_Printed_Browse(edtUDUretimEmriNoPerm.Text);
                    else
                        grdUretimArkaPlanAmbalajlar.DataSource = lITS.Package_List_Not_Printed_Browse_For_Production_Detail((cheUruneGoreListele.Checked ? edtUDMalzemeKodu.Text : null),
                                                                                                                            edtUDSeriTakipNumarasi.Text).ToList();

                    grdUretimArkaPlanAmbalajlarView.FocusedRowHandle = iFocusedRowHandle;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cbeTTSSistemi_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
            {
                var tLineList = lITS.Line_Lists.Where(l =>
                                                      l.lin_type_id == 34
                                                      && l.lin_phase == cbeTTSSistemi.SelectedIndex + 1).OrderBy(d => d.lin_description).ToList();
                cbeUretimHatti.Properties.Items.Clear();

                foreach (var Line in tLineList)
                {
                    cbeUretimHatti.Properties.Items.Add(new UretimHattiDetayi(Line.lin_id.ToString(),
                                                        Line.lin_description));
                }
            }

            cbeCaseCode.Enabled = (cbeTTSSistemi.SelectedIndex == 1);
            cheKolilemeYapilacak.Enabled = (cbeTTSSistemi.SelectedIndex == 1);
        }

        private void grdProductionOrderInsertSettingsView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                if (!(grdProductionOrderInsertSettingsView.PostEditor()
                    && grdProductionOrderInsertSettingsView.UpdateCurrentRow()))
                    return;

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    Production_Order_Insert_Setting Row = ((Production_Order_Insert_Setting)e.Row);

                    if (Row.pos_min >= Row.pos_max)
                    {
                        MessageBox.Show("Son değer, ilk değerden büyük olmalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (Row.pos_parameter <= 0)
                    {
                        MessageBox.Show("Katsayı sıfırdan büyük bir değer olmalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int iPosId = ((Production_Order_Insert_Setting)e.Row).pos_id;

                    if (iPosId == 0) // insert
                    {
                        var iMaxValue = lITS.Production_Order_Insert_Settings.OrderByDescending(p => p.pos_max).First().pos_max;

                        if (iMaxValue >= Row.pos_max)
                        {
                            MessageBox.Show("Son değer, ilk değerden büyük olmalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        Production_Order_Insert_Setting newRow = new Production_Order_Insert_Setting();
                        newRow.pos_min = iMaxValue;
                        newRow.pos_max = Row.pos_max;
                        newRow.pos_parameter = Row.pos_parameter;
                        newRow.pos_last_updated_usr_id = Global.UsrId;
                        newRow.pos_last_updated_datetime = DateTime.Now;
                        lITS.Production_Order_Insert_Settings.InsertOnSubmit(newRow);
                    }
                    else
                    {
                        var updatedRow = lITS.Production_Order_Insert_Settings.Where(p => p.pos_id == iPosId).First();
                        var iOldMaxValue = updatedRow.pos_max;

                        if (lITS.Production_Order_Insert_Settings.Where(p => p.pos_min == iOldMaxValue && p.pos_max < Row.pos_max).ToList().Count > 0)
                        {
                            MessageBox.Show("Son değer verisini hatalı girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        updatedRow.pos_max = Row.pos_max;
                        updatedRow.pos_parameter = Row.pos_parameter;
                        updatedRow.pos_last_updated_usr_id = Global.UsrId;
                        updatedRow.pos_last_updated_datetime = DateTime.Now;

                        try
                        {
                            var updatedRow2 = lITS.Production_Order_Insert_Settings.Where(p => p.pos_min == iOldMaxValue).First();
                            updatedRow2.pos_min = Row.pos_max;
                            updatedRow2.pos_last_updated_usr_id = Global.UsrId;
                            updatedRow2.pos_last_updated_datetime = DateTime.Now;
                        }
                        catch
                        {
                        }
                    }

                    lITS.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                grdProductionOrderInsertSettings.DataSource = new ITSDataContext(Global.ITSConnectionString).Production_Order_Insert_Settings.OrderBy(p => p.pos_min);
            }
        }

        private void grdProductionOrderInsertSettingsView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Kayıt silinecek, emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                try
                {
                    GridView view = sender as GridView;

                    using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                    {
                        int iPosId = ((Production_Order_Insert_Setting)view.GetFocusedRow()).pos_id;

                        var Row = lITS.Production_Order_Insert_Settings.Where(p => p.pos_id == iPosId).SingleOrDefault();
                        lITS.Production_Order_Insert_Settings.DeleteOnSubmit(Row);
                        lITS.SubmitChanges();
                    }

                    grdProductionOrderInsertSettings.DataSource = new ITSDataContext(Global.ITSConnectionString).Production_Order_Insert_Settings.OrderBy(p => p.pos_min);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (e.KeyCode == Keys.Insert)
                (sender as GridView).AddNewRow();
        }

        private void RefreshProductionDetail()
        {
            using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
            {
                var ProductionDetail = lITS.Production_Detail((cheUruneGoreListele.Checked ? edtUDMalzemeKodu.Text : null),
                                                              edtUDSeriTakipNumarasi.Text).First();

                edtUDUretimMiktari.Text = ProductionDetail.ord_target_quantity.ToString();
                edtUDUretilenMiktar.Text = ProductionDetail.total_package_quantity.ToString();
                edtUDGonderilecekMiktar.Text = ProductionDetail.approval_quantity.ToString();
                edtUDGonderilmeyecekMiktar.Text = ProductionDetail.disapproval_quantity.ToString();
                edtUDGonderilenMiktar.Text = ProductionDetail.sent_quantity.ToString();

                grdAmbalajDetayiSSCC.Visible = (ProductionDetail.sscc_found == 1);
            }
        }

        private void mnuAPAKTumunuSec_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdUretimArkaPlanAmbalajlarView.RowCount; i++)
            {
                grdUretimArkaPlanAmbalajlarView.SetRowCellValue(i, grdUretimArkaPlanAmbalajlarChecked, true);
            }
        }

        private void mnuAPAKHicbiriniSecme_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdUretimArkaPlanAmbalajlarView.RowCount; i++)
            {
                grdUretimArkaPlanAmbalajlarView.SetRowCellValue(i, grdUretimArkaPlanAmbalajlarChecked, false);
            }
        }

        private void UrunDogrulamaAmbalajArama()
        {
            if (edtKontrolAmbalaj.Text.Length < 3) return;

            Cursor = Cursors.WaitCursor;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    if (edtKontrolAmbalaj.Text.Substring(0, 2) == "00" && edtKontrolAmbalaj.Text.Length == 20) //SSCC
                        grdUrunDogrulamaAramaSonucu.DataSource = lITS.Package_Search("", edtKontrolAmbalaj.Text).ToList();
                    else
                        grdUrunDogrulamaAramaSonucu.DataSource = lITS.Package_Search(edtKontrolAmbalaj.Text, "").ToList();

                    btnUrunDogrulama.Enabled = (grdUrunDogrulamaAramaSonucuView.RowCount > 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void edtKontrolAmbalaj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (edtKontrolAmbalaj.Text != "" && edtKontrolAmbalaj.Text.Length > 4)
                    UrunDogrulamaAmbalajArama();
        }

        private class BUrunDogrulamaReceiverService : UrunDogrulamaReceiverService
        {

            protected override System.Net.WebRequest GetWebRequest(Uri uri)
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
                request.KeepAlive = false;

                if (PreAuthenticate)
                {
                    NetworkCredential networkCredentials = Credentials.GetCredential(uri, "Basic");

                    if (networkCredentials != null)
                    {
                        byte[] credentialBuffer = new UTF8Encoding().GetBytes(networkCredentials.UserName + ":" + networkCredentials.Password);
                        request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
                    }
                }
                return request;
            }
        }

        private void btnUrunDogrulama_Click(object sender, EventArgs e)
        {
            btnUrunDogrulama.Enabled = false;
            Cursor = Cursors.WaitCursor;
            SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);

            try
            {
                BUrunDogrulamaReceiverService UDS = new BUrunDogrulamaReceiverService();
                UDS.Url = Settings.Services.Confirmation;

                UDS.PreAuthenticate = true;
                UDS.Credentials = new NetworkCredential(Settings.Security.SanovelUser, Settings.Security.SanovelPassword);

                if (Settings.ProxyAddress != "")
                    UDS.Proxy = new WebProxy(Settings.ProxyAddress, Convert.ToInt32(Settings.ProxyPort));

                UrunDogrulamaBildirimType UDT = new UrunDogrulamaBildirimType();
                UDT.DT = "V";
                UDT.FR = Settings.Security.SanovelGLN;

                Package_SearchResult Row = (Package_SearchResult)grdUrunDogrulamaAramaSonucuView.GetFocusedRow();

                UrunDogrulamaBildirimTypeURUN UDTU = new UrunDogrulamaBildirimTypeURUN();
                UDTU.GTIN = Row.mmr_gtin;
                UDTU.BN = Row.ord_batch_no;
                UDTU.XD = Convert.ToDateTime(Row.expiry_date);
                UDTU.SN = Row.pck_code;

                ArrayList alUDTU = new ArrayList();
                alUDTU.Add(UDTU);

                UrunDogrulamaBildirimTypeURUN[] aUDTU = alUDTU.ToArray(typeof(UrunDogrulamaBildirimTypeURUN)) as UrunDogrulamaBildirimTypeURUN[];
                UDT.URUNLER = aUDTU;

                UrunDogrulamaBildirimCevapType UDCT = UDS.UrunDogrulamaBildir(UDT);

                lblUrunDogrulamaSonuc.Text = String.Format("{0} / {1}", UDCT.URUNLER[0].UC, Settings.GetErrorMessage(UDCT.URUNLER[0].UC));
                lblUrunDogrulamaSonuc.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                lblUrunDogrulamaSonuc.Text = "Hata: " + ex.Message;
                lblUrunDogrulamaSonuc.ForeColor = Color.Red;
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                SplashScreenManager.CloseForm();
                btnUrunDogrulama.Enabled = true;
            }
        }

        private void grdDAmbalajDetayiDeakRep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!Guvenlik.GuvenlikKontrol(edtSource.SelectedTabPage.Name, Guvenlik.Yetkiler.KayitGuncelleme))
            {
                MessageBox.Show("Güncelleme yetkiniz olmadığından dolayı bu işlemi gerçekleştiremezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdDAmbalajDetayiView.SetFocusedRowCellValue(grdDAmbalajDetayiChecked, true);

                    for (int i = 0; i < grdDAmbalajDetayiView.RowCount; i++)
                    {
                        if (grdDAmbalajDetayiView.GetRowCellValue(i, grdDAmbalajDetayiChecked) != null
                            && Convert.ToBoolean(grdDAmbalajDetayiView.GetRowCellValue(i, grdDAmbalajDetayiChecked)) == true)
                        {
                            Package_List_BrowseResult Row = (Package_List_BrowseResult)grdDAmbalajDetayiView.GetRow(i);

                            if (Row.pck_status_id == 98)
                            {
                                lITS.Package_List_Update(Row.pck_id, 10);
                                Row.pck_status_id = 10;
                                Row.pst_description = "İYİ DURUMDA";
                            }
                            else
                            {
                                lITS.Package_List_Update(Row.pck_id, 98);
                                Row.pck_status_id = 98;
                                Row.pst_description = "DEAKTİVE EDİLECEK";
                            }

                            grdDAmbalajDetayiView.FocusedRowHandle = i;
                            grdDAmbalajDetayiView.UpdateCurrentRow();
                            grdDAmbalajDetayiView.SetRowCellValue(i, grdDAmbalajDetayiChecked, false);
                        }
                    }

                    grdDAmbalajDetayiView.FocusedRowHandle = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void edtDAmbalajKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DeaktiveIcinUretimDetaylariListesiniYenile();
                AmbalajDurumuOtomatikDeaktiveEdilsin();
            }
        }

        private void edtDListelenecekKayitAdedi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DeaktiveIcinUretimDetaylariListesiniYenile();
        }

        private void cbeDGecerlilikDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeaktiveIcinUretimDetaylariListesiniYenile();
        }

        private void edtDAmbalajBarkodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 8)
            {
                edtDAmbalajBarkodu.Text = "";
                sBarkod = "";
            }
            else
                if (e.KeyValue == 13)
            {
                KareKod kkBarkod = new KareKod(sBarkod, 'D');
                edtDAmbalajKodu.Text = kkBarkod.PackageCode;
                DeaktiveIcinUretimDetaylariListesiniYenile();
                edtDAmbalajBarkodu.SelectAll();
                sBarkod = "";

                AmbalajDurumuOtomatikDeaktiveEdilsin();
            }
            else
                sBarkod += (char)e.KeyValue;
        }

        private void tbcSettings_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            btnAyarlariGeriAl.Visible = (e.Page != tbpProductionOrderInsertSettings);
            btnAyarlariKaydet.Visible = (e.Page != tbpProductionOrderInsertSettings);
            btnGetErrorCodes.Visible = (e.Page == tbpErrorCodes);

            if (e.Page == tbpErrorCodes)
                grdErrorCodes.DataSource = new ITSDataContext(Global.ITSConnectionString).Global_Error_Lists.OrderBy(r => r.erl_error_code).ToList();
        }

        private void btnSeciliUretimleinBildirimleriniZamanla_Click(object sender, EventArgs e)
        {
            using (BildirimZamanlama frmBildirimZamanlama = new BildirimZamanlama())
            {
                switch (frmBildirimZamanlama.ShowDialog())
                {
                    case DialogResult.OK:
                        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                        {
                            for (int i = 0; i < grdUretimBildirimiView.RowCount; i++)
                            {
                                if (grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiChecked) != null
                                    && Convert.ToBoolean(grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiChecked)) == true)
                                {
                                    try
                                    {
                                        lITS.Scheduled_Declaration_Insert(grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiOrderId).ToString(),
                                                                          'P',
                                                                          frmBildirimZamanlama.dteBildirimZamani.DateTime,
                                                                          Global.UsrId, null, null);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        break;

                    case DialogResult.Abort:
                        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                        {
                            for (int i = 0; i < grdUretimBildirimiView.RowCount; i++)
                            {
                                if (grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiChecked) != null
                                   && Convert.ToBoolean(grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiChecked)) == true)
                                {
                                    try
                                    {
                                        lITS.Scheduled_Declaration_Delete(grdUretimBildirimiView.GetRowCellValue(i, grdUretimBildirimiOrderId).ToString(),
                                                                          'P');
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        break;
                }

                btnUretimBilgileriniGetir_Click(sender, e);
            }
        }

        private void ttcUretimBilgileri_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != grdUretimBildirimi) return;

            ToolTipControlInfo info = null;
            GridView view = grdUretimBildirimi.GetViewAt(e.ControlMousePosition) as GridView;

            if (view == null) return;

            GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);

            if (hi.InRowCell)
            {
                Order_List_BrowseResult Row = (Order_List_BrowseResult)view.GetRow(hi.RowHandle);

                if (Row.scheduled_time.HasValue)
                {
                    string cellKey = String.Format("{0} - {1}", hi.RowHandle, hi.Column);
                    string text = "Zamanlanmış bildirim zamanı: " + Row.scheduled_time.Value.ToString();
                    info = new ToolTipControlInfo(cellKey, text);
                }
            }

            if (info != null)
                e.Info = info;
        }

        private void RaporDetayiGoster()
        {
            Package_Movement_Master_BrowseResult Row = grdRaporlarView.GetFocusedRow() as Package_Movement_Master_BrowseResult;

            if (Row == null)
            {
                edtGonderilenParcaAdedi.Text = "";
                edtCevaplananParcaAdedi.Text = "";
                edtGonderilenAmbalajAdedi.Text = "";
                edtKabulEdilenAmbalajAdedi.Text = "";
                edtKabulEdilmeyenAmbalajAdedi.Text = "";
                edtDahaOnceKaydedilmisAmbalajAdedi.Text = "";
                memHata.Text = "";
                edtRaporCari.Text = "";
                memHata.Visible = false;
                lblHata.Visible = false;
                btnGonderilenDosyayiAc.Enabled = false;
                btnGelenDosyayiAc.Enabled = false;
                btnRaporGoruntule.Enabled = false;
                return;
            }

            edtGonderilenParcaAdedi.Text = Row.gonderilen_parca_adedi.ToString();
            edtCevaplananParcaAdedi.Text = Row.cevaplanan_parca_adedi.ToString();
            edtGonderilenAmbalajAdedi.Text = Row.toplam_gonderilen_ambalaj_adedi.ToString();
            edtKabulEdilenAmbalajAdedi.Text = Row.kabul_edilen_ambalaj_adedi.ToString();
            edtKabulEdilmeyenAmbalajAdedi.Text = Row.kabul_edilmeyen_ambalaj_adedi.ToString();
            edtDahaOnceKaydedilmisAmbalajAdedi.Text = Row.daha_once_kaydedilmis_ambalaj_adedi.ToString();

            if (Row.err_error_message != null)
                memHata.Text = Row.err_error_message.ToString();
            else memHata.Text = "";

            memHata.Visible = (memHata.Text != "");
            lblHata.Visible = (memHata.Text != "");
            btnGonderilenDosyayiAc.Enabled = (Row.pmm_sending_file_name != null);
            btnGelenDosyayiAc.Enabled = (Row.pmm_coming_file_name != null);
            btnRaporGoruntule.Enabled = (Row.type == "Üretim");
        }

        private void dgvRaporlarView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RaporDetayiGoster();
        }

        private void btnZamanlanmisRaporuCalistir_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                if (dteZamanlanmisBaslangicTarihi.Text == "")
                    dteZamanlanmisBaslangicTarihi.DateTime = DateTime.Today.AddDays(-7);

                if (dteZamanlanmisBitisTarihi.Text == "")
                    dteZamanlanmisBitisTarihi.DateTime = DateTime.Today;

                string sTypes = "";

                if (cheZamanlanmisUretim.Checked) sTypes += "P,";
                if (cheZamanlanmisSatis.Checked) sTypes += "S,";
                if (cheZamanlanmisPTS.Checked) sTypes += "C,";

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdZamanlanmisBildirimlerRaporu.DataSource = lITS.Scheduled_Declaration_Browse_For_Report(dteZamanlanmisBaslangicTarihi.DateTime,
                                                                                                               dteZamanlanmisBitisTarihi.DateTime,
                                                                                                               edtZamanlanmisMalzemeAdi.Text,
                                                                                                               edtZamanlanmisIsEmriNumarasi.Text,
                                                                                                               (edtZamanlanmisKayitAdedi.Text != "" ? Convert.ToInt32(edtZamanlanmisKayitAdedi.Text) : (int?)null),
                                                                                                               sTypes).ToList();
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void grdZamanlanmisBildirimlerRaporuView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Scheduled_Declaration_Browse_For_ReportResult Row = grdZamanlanmisBildirimlerRaporuView.GetFocusedRow() as Scheduled_Declaration_Browse_For_ReportResult;

            if (Row == null) return;

            if (Row.mmr_item_no != null)
            {
                pnlZamanlanmisDetayUretim.Visible = true;
                pnlZamanlanmisDetaySatis.Visible = false;

                edtZamanlanmisDetayMalzeme.Text = Row.item_desc;
                edtZamanlanmisDetaySeri.Text = Row.ord_batch_no;
                edtZamanlanmisDetaySKT.Text = Row.ord_expiry_date.Value.ToString("d");
            }
            else if (Row.amr_account_code != null)
            {
                pnlZamanlanmisDetayUretim.Visible = false;
                pnlZamanlanmisDetaySatis.Visible = true;

                edtZamanlanmisDetayCari.Text = Row.account_desc;
                edtZamanlanmisDetayFaturaNumarasi.Text = Row.sor_invoice_number;
                edtZamanlanmisDetayFaturaTarihi.Text = Row.sor_invoice_date.Value.ToString("d");
            }

            using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
            {
                grdZamanlanmisBildirimDetayi.DataSource = lITS.Package_Movement_Master_Browse(null,
                                                                                              null,
                                                                                              null,
                                                                                              Row.sch_order_id,
                                                                                              null,
                                                                                              null,
                                                                                              null,
                                                                                              Row.sch_type + ",",
                                                                                              null).ToList();
            }

            btnZamanlamayiIptalEt.Enabled = (Row.sch_declaration_time == null);
        }

        private void grdZamanlanmisBildirimDetayiView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (grdZamanlanmisBildirimDetayiView.GetRowCellValue(e.RowHandle, grdZamanlanmisBildirimDetayiKullanici) != null)
            {
                e.Appearance.ForeColor = Color.Blue;
            }
        }

        private void btnZamanlamayiIptalEt_Click(object sender, EventArgs e)
        {
            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    Scheduled_Declaration_Browse_For_ReportResult Row = grdZamanlanmisBildirimlerRaporuView.GetFocusedRow() as Scheduled_Declaration_Browse_For_ReportResult;
                    lITS.Scheduled_Declaration_Delete(Row.sch_order_id,
                                                      Row.sch_type);
                    btnZamanlanmisRaporuCalistir_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void edtZamanlanmisMalzemeAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnZamanlanmisRaporuCalistir_Click(sender, e);
        }

        private void edtZamanlanmisIsEmriNumarasi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnZamanlanmisRaporuCalistir_Click(sender, e);
        }

        private void YeniSatisIptalBilgileriniYenile(int? CsmId)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    var tMaster = lITS.Cancelled_Sales_Master_Browse(CsmId).ToList();

                    if (tMaster.Count == 0) throw new Exception("Kayıt bulunamadı!");

                    edtSatisIptalYeniBelgeNo.Text = tMaster.First().csm_document_number;
                    edtSatisIptalYeniBelgeTarihi.Text = tMaster.First().csm_creation_date.ToString("g");
                    edtSatisIptalYeniCSMID.Text = tMaster.First().csm_id.ToString();

                    sleSatisIptalYeniCari.Properties.ReadOnly = true;

                    grdSatisIptalYeni.DataSource = lITS.Cancelled_Sales_Detail_Browse(CsmId).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void edtSatisIptalYeniAmbalajBarkodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 8)
            {
                edtAmbalajBarkodu.Text = "";
                sBarkod = "";
            }
            else
                if (e.KeyValue == 13)
            {
                if (!Guvenlik.GuvenlikKontrol(edtSource.SelectedTabPage.Name, Guvenlik.Yetkiler.KayitEkleme))
                {
                    MessageBox.Show("Kayıt ekleme yetkiniz olmadığından dolayı bu işlemi gerçekleştiremezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int? CsmId = null;

                if (edtSatisIptalYeniCSMID.Text != "") CsmId = Convert.ToInt32(edtSatisIptalYeniCSMID.Text);

                string AccountCode = sleSatisIptalYeniCariView.GetFocusedRowCellValue(sleSatisIptalYeniCariKod).ToString();

                if (sBarkod.Length == 20) // SSCC
                {
                    Cursor = Cursors.WaitCursor;

                    try
                    {
                        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                        {
                            var tPackages = lITS.Package_And_SSCC_Search(null, null, sBarkod).ToList();

                            if (tPackages.Count == 0) throw new Exception("Kayıt bulunamadı!");

                            foreach (var P in tPackages)
                            {
                                CsmId = lITS.Cancelled_Sales_Detail_Insert(AccountCode, CsmId, P.pck_id, Global.UsrId);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    KareKod kkBarkod = new KareKod(sBarkod, 'D');
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                        {
                            var tPackages = lITS.Package_And_SSCC_Search(kkBarkod.GTIN,
                                                                         kkBarkod.PackageCode,
                                                                         null).ToList();

                            if (tPackages.Count == 0) throw new Exception("Kayıt bulunamadı!");

                            foreach (var P in tPackages)
                            {
                                CsmId = lITS.Cancelled_Sales_Detail_Insert(AccountCode,
                                                                           CsmId,
                                                                           P.pck_id,
                                                                           Global.UsrId);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sBarkod = "";
                        return;
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }

                sBarkod = "";
                edtSatisIptalYeniAmbalajBarkodu.Text = "";
                btnSatisIptalBildirimiYap.Enabled = true;

                YeniSatisIptalBilgileriniYenile(CsmId);
            }
            else
                sBarkod += (char)e.KeyValue;
        }

        private void sleSatisIptalYeniCari_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (e.CloseMode == DevExpress.XtraEditors.PopupCloseMode.Normal)
                edtSatisIptalYeniAmbalajBarkodu.Enabled = (sleSatisIptalYeniCari.Text != "");
        }

        private void grdSatisIptalYeniSilRep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!Guvenlik.GuvenlikKontrol(edtSource.SelectedTabPage.Name, Guvenlik.Yetkiler.KayitSilme))
            {
                MessageBox.Show("Kayıt silme yetkiniz olmadığından dolayı bu işlemi gerçekleştiremezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cursor = Cursors.WaitCursor;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    Cancelled_Sales_Detail_BrowseResult Row = grdSatisIptalYeniView.GetFocusedRow() as Cancelled_Sales_Detail_BrowseResult;
                    lITS.Cancelled_Sales_Detail_Delete(Row.csd_id);
                    grdSatisIptalYeni.DataSource = lITS.Cancelled_Sales_Detail_Browse(Convert.ToInt32(edtSatisIptalYeniCSMID.Text)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnSatisIptalYeni_Click(object sender, EventArgs e)
        {
            sleSatisIptalYeniCari.Text = "";
            edtSatisIptalYeniBelgeNo.Text = "";
            edtSatisIptalYeniBelgeTarihi.Text = "";
            edtSatisIptalYeniCSMID.Text = "";

            edtSatisIptalYeniAmbalajBarkodu.Text = "";

            sleSatisIptalYeniCari.Properties.ReadOnly = false;
            grdSatisIptalYeni.DataSource = null;

            btnSatisIptalBildirimiYap.Enabled = true;
        }

        private void btnSatisIptalBildirimiYap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Satış iptal bildirimi yapılacaktır. Bu işlemin iptali yoktur. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            btnSatisIptalBildirimiYap.Enabled = false;
            Cursor = Cursors.WaitCursor;
            SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);

            try
            {
                DeclarationServices.SendSalesCancel SIB = new DeclarationServices.SendSalesCancel(Global.UsrId, Global.Environment, Global.ITSConnectionString);
                SIB.SendAsync(Convert.ToInt32(edtSatisIptalYeniCSMID.Text));

                Application.DoEvents();
                edtSource.SelectedTabPage = tbpRaporlar;
                tbcRaporlar.SelectedTabPage = tbpBildirimDetayRaporu;
                cheRaporUretim.Checked = false;
                cheRaporDeaktivasyon.Checked = false;
                cheRaporSatis.Checked = false;
                cheRaporPTS.Checked = false;
                cheRaporSatisIptal.Checked = true;
                edtRaporUretimEmriNumarasi.Text = edtSatisIptalYeniBelgeNo.Text;
                btnRaporuCalistir_Click(sender, e);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                SplashScreenManager.CloseForm();
                btnSatisIptalBildirimiYap.Enabled = true;
            }
        }

        private void tbcSatisIptalBildirimi_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tbcSatisIptalBildirimi.SelectedTabPage == tbpOncekiSatisIptaller)
                grdSatisIptalKayitlari.DataSource = new ITSDataContext(Global.ITSConnectionString).Cancelled_Sales_Browse().ToList();
        }

        private void grdSatisIptalKayitlariView_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            //Cancelled_Sales_BrowseResult Row = (Cancelled_Sales_BrowseResult)grdSatisIptalKayitlariView.GetRow(e.RowHandle);
            //e.ChildList = new ITSDataContext(Global.ITSConnectionString).Cancelled_Sales_Detail_Browse(Row.csm_id).ToList();
        }

        private void grdSatisIptalKayitlariView_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            //Cancelled_Sales_BrowseResult Row = (Cancelled_Sales_BrowseResult)grdSatisIptalKayitlariView.GetRow(e.RowHandle);
            //e.IsEmpty = new ITSDataContext(Global.ITSConnectionString).Cancelled_Sales_Detail_Browse(Row.csm_id).ToList().Count == 0;
        }

        private void grdSatisIptalKayitlariView_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            //e.RelationCount = 1;
        }

        private void grdSatisIptalKayitlariView_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            //e.RelationName = "Detail";
        }

        private void grdSatisIptalKayitlariView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.Name == "grdSatisIptalKayitlariSil")
            {
                Cancelled_Sales_BrowseResult Row = (Cancelled_Sales_BrowseResult)grdSatisIptalKayitlariView.GetRow(e.RowHandle);

                if (Row.declaration_datetime.HasValue)
                    e.RepositoryItem = null;
            }
        }

        public int iRecNo = 0;

        private void grdSatisIptalKayitlariSilRep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Satış iptal bildirim kaydı silinecektir. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (!Guvenlik.GuvenlikKontrol(edtSource.SelectedTabPage.Name, Guvenlik.Yetkiler.KayitSilme))
            {
                MessageBox.Show("Kayıt silme yetkiniz olmadığından dolayı bu işlemi gerçekleştiremezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cursor = Cursors.WaitCursor;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    Cancelled_Sales_BrowseResult Row = grdSatisIptalKayitlariView.GetFocusedRow() as Cancelled_Sales_BrowseResult;
                    iRecNo = grdSatisIptalKayitlariView.FocusedRowHandle;
                    lITS.Cancelled_Sales_Master_Delete(Row.csm_id);
                    grdSatisIptalKayitlari.DataSource = lITS.Cancelled_Sales_Browse().ToList();
                    grdSatisIptalKayitlariView.FocusedRowHandle = iRecNo - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnSatisIptalBildirimiYap2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Satış iptal bildirimi yapılacaktır. Bu işlemin iptali yoktur. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Cursor = Cursors.WaitCursor;

            try
            {
                Cancelled_Sales_BrowseResult Row = grdSatisIptalKayitlariView.GetFocusedRow() as Cancelled_Sales_BrowseResult;

                DeclarationServices.SendSalesCancel SIB = new DeclarationServices.SendSalesCancel(Global.UsrId, Global.Environment, Global.ITSConnectionString);
                SIB.SendAsync(Row.csm_id);

                Application.DoEvents();
                edtSource.SelectedTabPage = tbpRaporlar;
                tbcRaporlar.SelectedTabPage = tbpBildirimDetayRaporu;
                cheRaporUretim.Checked = false;
                cheRaporDeaktivasyon.Checked = false;
                cheRaporSatis.Checked = false;
                cheRaporPTS.Checked = false;
                cheRaporSatisIptal.Checked = true;
                edtRaporUretimEmriNumarasi.Text = Row.csm_document_number;
                btnRaporuCalistir_Click(sender, e);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnSatisIptalOlustur_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    int CsmId = lITS.Cancelled_Sales_Insert_From_Shipping(Convert.ToInt32(edtShippingOrderIID.Text),
                                                                          Global.UsrId);

                    edtSource.SelectedTabPage = tbpSatisIptalBildirimi;
                    tbcSatisIptalBildirimi.SelectedTabPage = tbpYeniSatisIptalOlusturma;

                    var tMaster = lITS.Cancelled_Sales_Master_Browse(CsmId).ToList();

                    if (tMaster.Count == 0) throw new Exception("Kayıt bulunamadı!");

                    edtSatisIptalYeniBelgeNo.Text = tMaster.First().csm_document_number;
                    edtSatisIptalYeniBelgeTarihi.Text = tMaster.First().csm_creation_date.ToString("g");
                    edtSatisIptalYeniCSMID.Text = tMaster.First().csm_id.ToString();
                    sleSatisIptalYeniCari.Text = tMaster.First().amr_account_code.ToString();
                    sleSatisIptalYeniCari.Properties.ReadOnly = true;
                    btnSatisIptalBildirimiYap.Enabled = true;

                    grdSatisIptalYeni.DataSource = lITS.Cancelled_Sales_Detail_Browse(CsmId).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnGetErrorCodes_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
            Cursor = Cursors.WaitCursor;

            try
            {
                DeclarationServices.GetErrorCodes GEC = new DeclarationServices.GetErrorCodes(Global.UsrId, Global.Environment, Global.ITSConnectionString);
                GEC.Get();
                grdErrorCodes.DataSource = new ITSDataContext(Global.ITSConnectionString).Global_Error_Lists.OrderBy(r => r.erl_error_code).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                SplashScreenManager.CloseForm();
                Cursor = Cursors.Default;
            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "Tamam";
            buttonCancel.Text = "İptal";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void btnSatisVerisiAl_Click(object sender, EventArgs e)
        {
            string sOrderNumber = "";

            if (InputBox("Evrak Numarası", "Lütfen evrak numarasını girin:", ref sOrderNumber) == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                btnSatisVerisiAl.Enabled = false;

                try
                {
                    using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 1200000 })
                    {
                        SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
                        try
                        {
                            lITS.Get_Shipping_Data_From_TTSV2(sOrderNumber);
                        }
                        finally
                        {
                            SplashScreenManager.CloseForm();
                        }

                        SatisBilgileriniYenile();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    Cursor = Cursors.Default;
                    btnSatisVerisiAl.Enabled = true;
                }
            }
        }

        private void btnDFiltreyiTemizle_Click(object sender, EventArgs e)
        {
            edtDListelenecekKayitAdedi.Text = "1000";
            edtDAmbalajKodu.Text = "";
            edtDAmbalajBarkodu.Text = "";
            sBarkod = "";
            cbeDGecerlilikDurumu.SelectedIndex = -1;

            cheOtomatikDeaktiveEdilsin.Checked = false;
            DeaktiveIcinUretimDetaylariListesiniYenile();
        }

        private void mnuBYATumunuSec_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdAmbalajDetayiView.RowCount; i++)
            {
                grdAmbalajDetayiView.SetRowCellValue(i, grdAmbalajDetayiChecked, true);
            }
        }

        private void mnuBYAHicbiriniSecme_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdAmbalajDetayiView.RowCount; i++)
            {
                grdAmbalajDetayiView.SetRowCellValue(i, grdAmbalajDetayiChecked, false);
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.T && edtSource.SelectedTabPage == tbpSatisBildirimi)
            {
                string sOrderNumber = "";

                if (InputBox("Üretim Emri Numarası", "Lütfen üretim emri numarasını girin:", ref sOrderNumber) == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;

                    try
                    {
                        using (var lTTS = new TTSDataContext() { CommandTimeout = 1200000 })
                        {
                            SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
                            try
                            {
                                var tResult = lTTS.sp_wms_MoveOrderToOldWarehouseDB(sOrderNumber).ToList();
                                if (tResult.Count > 0 && tResult.First().Column1 != null)
                                    MessageBox.Show(tResult.First().Column1.ToString(), "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                SplashScreenManager.CloseForm();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }

            //if (e.Control && e.KeyCode == Keys.M && tbcMain.SelectedTabPage == tbpSatisDetaylari &&
            //  edtShippingOrderIPTSNumber.Text != "" && edtShippingOrderIAccountInformations.Text != "")
            //{
            //  Cursor = Cursors.WaitCursor;
            //  SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
            //  try
            //  {
            //    DeclarationServices.SendReceipt SB = new DeclarationServices.SendReceipt(Global.UsrId, Global.Environment, Global.ITSConnectionString);
            //    SB.Send(edtShippingOrderIPTSNumber.Text, "8699536000015");
            //  }
            //  catch (Exception ex)
            //  {
            //    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //  }
            //  finally
            //  {
            //    Cursor = Cursors.Default;
            //    SplashScreenManager.CloseForm();
            //  }
            //}
        }

        private void btnUDExcel_Click(object sender, EventArgs e)
        {
            sfdExcel.Filter = "Excel Dosyası (*.xls)|*.xls";
            if (sfdExcel.ShowDialog() == DialogResult.OK)
            {
                string sFileName = sfdExcel.FileName;

                ExportXmlProvider pro = new ExportXmlProvider(sFileName);
                BaseExportLink link = grdUrunDogrulamaAramaSonucuView.CreateExportLink(pro);
                link.ExportTo(true);
            }
        }

        private void mnuSatisVerisiniYenile_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnSatisVerisiAl.Enabled = false;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 1200000 })
                {
                    SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
                    try
                    {
                        lITS.Refresh_Shipping_Data(grdSatisBildirimiYapilmamisKayitlarView.GetFocusedRowCellValue("sor_order_number").ToString());
                    }
                    finally
                    {
                        SplashScreenManager.CloseForm();
                    }

                    SatisBilgileriniYenile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
                btnSatisVerisiAl.Enabled = true;
            }
        }

        private void btnSatisDetayAmbalajEkle_Click(object sender, EventArgs e)
        {
            if (edtShippingOrderIPTSNumber.Text != "" && edtShippingOrderIAccountInformations.Text != "")
                using (SatisDetayinaAmbalajEkleme frmSatisDetayinaAmbalajEkleme = new SatisDetayinaAmbalajEkleme())
                {
                    frmSatisDetayinaAmbalajEkleme.ShowDialog(this);
                }
        }

        private void btnSatisAktarimSorunlari_Click(object sender, EventArgs e)
        {
            if (edtShippingOrderIPTSNumber.Text != "" && edtShippingOrderIAccountInformations.Text != "")
                using (SatisAktarimSorunlari frmSatisAktarimSorunlari = new SatisAktarimSorunlari())
                {
                    frmSatisAktarimSorunlari.edtBelgeNumarasi.Text = edtShippingOrderIPTSNumber.Text;
                    frmSatisAktarimSorunlari.ShowDialog(this);
                }
        }

        private void btnKoliYerDegistirme_Click(object sender, EventArgs e)
        {
            using (KolileriYerDegistirme frmKolileriYerDegistirme = new KolileriYerDegistirme() { OrderNumber = edtShippingOrderIPTSNumber.Text })
            {
                frmKolileriYerDegistirme.ShowDialog(this);
            }
        }

        private void btnSatisVerisiOlusturma_Click(object sender, EventArgs e)
        {
            // @bilgehan Satış verisi oluşturma excel
            using (SatisVerisiOlusturma frmSatisVerisiOlusturma = new SatisVerisiOlusturma())
            {
                frmSatisVerisiOlusturma.ShowDialog(this);
            }
        }

        private void btnEczaneSatisKaydiOlustur_Click(object sender, EventArgs e)
        {
            using (EczaneyeSatisKaydiOlusturma frmEczaneyeSatisKaydiOlusturma = new EczaneyeSatisKaydiOlusturma())
            {
                frmEczaneyeSatisKaydiOlusturma.ShowDialog(this);
            }
        }

        private void btnGrupiciSatisAlisBildirimi_Click(object sender, EventArgs e)
        {
            using (GrupIciSatisAlisIslemleri frmGrupIciSatisAlisIslemleri = new GrupIciSatisAlisIslemleri(this))
            {
                frmGrupIciSatisAlisIslemleri.ShowDialog(this);
            }
        }

        private void bedSelectPTSFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ofdPTSFile.ShowDialog();
            bedSelectPTSFile.Text = ofdPTSFile.FileName;
        }

        private string sPalletSSCC = "";
        private string sPackageSSCC = "";
        private string sDocumentNumber = "";
        private int iRtpId = 0;
        private DateTime dDocumentDate;
        private string sSourceGLN = "";
        private string sDestGLN = "";
        private string sShipToGLN = "";
        private string sActionType = "";
        private string sNote = "";
        private string sFileVersion = "";

        private int iTransferId = 0;
        //private DataTable dt;
        private void loadCarriers(object[] carrier)
        {
            if (carrier == null) return;

            if (carrier[0].GetType() == typeof(carrierType))
            {
                foreach (carrierType c in carrier)
                {
                    if (c.containerType == "P")
                        sPalletSSCC = c.carrierLabel;
                    else if (c.containerType == "C")
                        sPackageSSCC = c.carrierLabel;

                    loadCarriers(c.Items);
                }
            }
            else if (carrier[0].GetType() == typeof(productListType))
            {
                foreach (productListType p in carrier)
                {
                    foreach (var s in p.serialNumber)
                    {
                        //DataRow dr = dt.NewRow();

                        //dr[0] = s;
                        //dr[1] = p.GTIN;
                        //dr[2] = p.lotNumber;
                        //dr[3] = p.productionDate;
                        //dr[4] = p.expirationDate;
                        //dr[5] = sPackageSSCC;
                        //dr[6] = sPalletSSCC;
                        //dt.Rows.Add(dr);
                        if (p.productionDate.Year == 1)
                            p.productionDate = dDocumentDate;

                        try
                        {
                            using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                            {
                                lITS.Receiving_Thirdparty_Packages(sDocumentNumber,
                                                                   dDocumentDate,
                                                                   sSourceGLN,
                                                                   sDestGLN,
                                                                   sShipToGLN,
                                                                   sActionType[0],
                                                                   sNote,
                                                                   sFileVersion,
                                                                   iTransferId,//null,
                                                                   Global.UsrId,
                                                                   s,
                                                                   p.GTIN,
                                                                   p.lotNumber,
                                                                   p.productionDate,
                                                                   p.expirationDate,
                                                                   "",
                                                                   sPackageSSCC,
                                                                   sPalletSSCC,
                                                                   "",
                                                                   Global.UsrId);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("İşlem esnasında hata oluştu. Hata = " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        finally
                        {
                        }
                    }
                }
            }
        }

        protected void btnPTSLoad_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
                btnPTSLoad.Enabled = false;

                //dt = new DataTable();
                //dt.Columns.Add("rtd_serial_number");
                //dt.Columns.Add("rtd_gtin");
                //dt.Columns.Add("rtd_lot_number");
                //dt.Columns.Add("rtd_production_date");
                //dt.Columns.Add("rtd_expiration_date");
                //dt.Columns.Add("rtd_package_sscc");
                //dt.Columns.Add("rtd_pallet_sscc");
                //grdPTSKontrol.DataSource = dt;

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(transfer));
                StreamReader streamReader = new StreamReader(bedSelectPTSFile.Text);

                transfer PTSDosyasi = null;

                PTSDosyasi = (transfer)xmlSerializer.Deserialize(streamReader);

                sDocumentNumber = PTSDosyasi.documentNumber;
                dDocumentDate = PTSDosyasi.documentDate;
                sSourceGLN = PTSDosyasi.sourceGLN;
                sDestGLN = PTSDosyasi.destinationGLN;
                sShipToGLN = PTSDosyasi.shipTo;
                sActionType = PTSDosyasi.actionType;
                sNote = PTSDosyasi.note;
                sFileVersion = PTSDosyasi.version;

                if (sActionType != "M")
                {
                    MessageBox.Show("Fason üretim için alım yapılmaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                /*
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    List<Receiving_Thirdparty_Packages_Master_Exists_ControlResult> tList;
                    tList = lITS.Receiving_Thirdparty_Packages_Master_Exists_Control(iTransferId, sDocumentNumber).ToList();
                    if (tList.Count > 0)
                    {
                        MessageBox.Show("PTS daha önce yüklenmiştir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                */
                loadCarriers(PTSDosyasi.carrier);

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    List<Receiving_Thirdparty_Packages_Master_Exists_ControlResult> tList;
                    tList = lITS.Receiving_Thirdparty_Packages_Master_Exists_Control(iTransferId, sDocumentNumber).ToList();
                    if (tList.Count > 0)
                    {
                        grdPTSKontrol.DataSource = lITS.Receiving_Thirdparty_Packages_Detail_Browse(tList.First().rtp_id).ToList();

                        var data = new ITSDataContext(Global.ITSConnectionString).Receiving_Thirdparty_Packages_Master_Browse().ToList();
                        slePTSKontrolDocumentNumber.Properties.DataSource = data;
                        slePTSKontrolDocumentNumber.EditValue = iTransferId;//sDocumentNumber;
                        //iRtpId = data.Where(s => s.rtp_document_number == sDocumentNumber && s.rtp_source_gln == sSourceGLN).First().rtp_id;
                        iRtpId = data.Where(s => s.rtp_transfer_id == iTransferId).First().rtp_id;

                        btnPTSAktar.Enabled = true;
                        btnPTSSil.Enabled = true;
                        edtPTSKontrolAmbalaj.Text = "";
                        edtPTSKontrolBarkod.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                SplashScreenManager.CloseForm();
                Cursor = Cursors.Default;
                btnPTSLoad.Enabled = true;
            }
        }

        private void slePTSKontrolDocumentNumber_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (e.CloseMode == DevExpress.XtraEditors.PopupCloseMode.Normal)
            {
                Receiving_Thirdparty_Packages_Master_BrowseResult Row = (Receiving_Thirdparty_Packages_Master_BrowseResult)slePTSKontrolDocumentNumberView.GetFocusedRow();

                if (Row == null) return;

                sDocumentNumber = Row.rtp_document_number;
                dDocumentDate = Row.rtp_document_date;
                sSourceGLN = Row.rtp_source_gln;
                sDestGLN = Row.rtp_destination_gln;
                sShipToGLN = Row.rtp_shipto_gln;
                sActionType = Row.rtp_action_type.ToString();
                sNote = Row.rtp_note;
                sFileVersion = Row.rtp_file_version;
                iRtpId = Row.rtp_id;

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdPTSKontrol.DataSource = lITS.Receiving_Thirdparty_Packages_Detail_Browse(Convert.ToInt32(Row.rtp_id)).ToList();
                }

                btnPTSAktar.Enabled = true;
                btnPTSSil.Enabled = true;
            }
        }

        private void edtPTSKontrolBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 8)
            {
                edtPTSKontrolBarkod.Text = "";
                sBarkod = "";
            }
            else
                if (e.KeyValue == 13)
            {
                if (sBarkod.Length > 2 && sBarkod.Substring(0, 2) == "00" && sBarkod.Length == 20) // SSCC
                {
                    edtPTSKontrolAmbalaj.Text = sBarkod;
                }
                else
                {
                    KareKod kkBarkod = new KareKod(sBarkod, 'D');
                    edtPTSKontrolAmbalaj.Text = kkBarkod.PackageCode;
                }

                edtPTSKontrolBarkod.Text = "";
                sBarkod = "";

                PTSKontrolAmbalajArama();
            }
            else
                sBarkod += (char)e.KeyValue;
        }

        private void edtPTSKontrolAmbalaj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (edtPTSKontrolAmbalaj.Text != "" && edtPTSKontrolAmbalaj.Text.Length > 4)
                    PTSKontrolAmbalajArama();
        }

        private void PTSKontrolAmbalajArama()
        {
            if (edtPTSKontrolAmbalaj.Text.Length < 3) return;

            Cursor = Cursors.WaitCursor;

            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    if (edtPTSKontrolAmbalaj.Text.Substring(0, 2) == "00" && edtPTSKontrolAmbalaj.Text.Length == 20) //SSCC
                    {
                        grdPTSKontrol.DataSource = lITS.Receiving_Thirdparty_Packages_Detail_Browse_BySSCC("", edtPTSKontrolAmbalaj.Text).ToList();
                        lITS.Receiving_Thirdparty_Packages_Detail_Update("", edtPTSKontrolAmbalaj.Text, Global.UsrId);
                    }
                    else
                    {
                        grdPTSKontrol.DataSource = lITS.Receiving_Thirdparty_Packages_Detail_Browse_BySSCC(edtPTSKontrolAmbalaj.Text, "").ToList();
                        lITS.Receiving_Thirdparty_Packages_Detail_Update(edtPTSKontrolAmbalaj.Text, "", Global.UsrId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnPTSAktar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string OrderlistnumberID = "";
            SplashScreenManager.ShowForm(typeof(WaitForm1), false, false);
            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    string Orderlistnumber = "";
                    lITS.Package_List_Insert_From_Thirdparty_Packages(iRtpId, sDocumentNumber, Global.UsrId, ref Orderlistnumber);
                    OrderlistnumberID = Orderlistnumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem esnasında hata oluştu. Hata = " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                btnPTSAktar.Enabled = false;
                SplashScreenManager.CloseForm();
                Cursor = Cursors.Default;
            }

            slePTSKontrolDocumentNumber.Properties.DataSource = new ITSDataContext(Global.ITSConnectionString).Receiving_Thirdparty_Packages_Master_Browse().ToList();
            grdPTSKontrol.DataSource = null;
            edtSource.SelectedTabPage = tbpUretimDetaylari;
            edtUDUretimEmriNo.Focus();
            edtUDUretimEmriNo.Text = OrderlistnumberID.ToString();
            bUDSeriBazindaAmbalaj = false;
            cheUruneGoreListele.Enabled = false;
            UretimDetaylariListesiniYenile();
        }

        private void btnPTSSil_Click(object sender, EventArgs e)
        {
            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    lITS.Receiving_Thirdparty_Packages_Delete(iRtpId, sDocumentNumber);
                    slePTSKontrolDocumentNumber.Properties.DataSource = new ITSDataContext(Global.ITSConnectionString).Receiving_Thirdparty_Packages_Master_Browse().ToList();
                    grdPTSKontrol.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnPTSSil.Enabled = false;
            }
        }


        private void btnPTSTransferBilgileri_Click(object sender, EventArgs e)
        {
            try
            {
                DeclarationServices.TransferHelper PTSTHS = new DeclarationServices.TransferHelper(Global.UsrId, Global.Environment, Global.ITSConnectionString);
                bool bAlinmislariGoster = !chkAlinmislariGoster.Checked;
                int iGunSayisi = Convert.ToInt32(edtGunSayisi.Text);

                PTSTHS.TransferHelperBrowse(bAlinmislariGoster, iGunSayisi);
                grdTransferBilgileri.DataSource = PTSTHS.dtTransferBilgileri;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnPTSPaketAlma_Click(object sender, EventArgs e)
        {
            try
            {
                DeclarationServices.ReceivePTS PTSTHS = new DeclarationServices.ReceivePTS(Global.UsrId, Global.Environment, Global.ITSConnectionString);

                for (int i = 0; i < grdTransferBilgileriView.RowCount; i++)
                {
                    if (grdTransferBilgileriView.GetRowCellValue(i, grdTransferBilgileriChecked) != null
                        && Convert.ToBoolean(grdTransferBilgileriView.GetRowCellValue(i, grdTransferBilgileriChecked)) == true)
                    {
                        string targetdir = PTSTHS.Receive(Convert.ToInt32(grdTransferBilgileriView.GetRowCellValue(i, grdTransferBilgileriTransfer_Id).ToString()), grdTransferBilgileriView.GetRowCellValue(i, grdTransferBilgileriSource_Gln).ToString(), grdTransferBilgileriView.GetRowCellValue(i, grdTransferBilgileriDestination_Gln).ToString());
                        iTransferId = Convert.ToInt32(grdTransferBilgileriView.GetRowCellValue(i, grdTransferBilgileriTransfer_Id).ToString());
                        xtraTabControl1.SelectedTabPage = xtraTabPage2;
                        bedSelectPTSFile.Focus();
                        bedSelectPTSFile.Text = String.Format("{0}\\{1}", Application.StartupPath, targetdir);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnReceivePTSManuel_Click(object sender, EventArgs e)
        {
            try
            {
                DeclarationServices.ReceivePTS PTSTHS = new DeclarationServices.ReceivePTS(Global.UsrId, Global.Environment, Global.ITSConnectionString);

                string targetdir = PTSTHS.Receive(Convert.ToInt32(edtTransferID.Text), slePTSSenderCompany.EditValue.ToString(), slePTSReceiverCompany.EditValue.ToString());
                iTransferId = Convert.ToInt32(edtTransferID.Text);
                xtraTabControl1.SelectedTabPage = xtraTabPage2;
                bedSelectPTSFile.Focus();
                bedSelectPTSFile.Text = Application.StartupPath + "\\" + targetdir;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        int checkedRowIndex = -1;

        private void grdTransferBilgileriView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "checked" && (bool)e.Value)
            {
                int rowHandle = view.GetRowHandle(checkedRowIndex);
                view.SetRowCellValue(rowHandle, "checked", false);
                checkedRowIndex = view.GetDataSourceRowIndex(e.RowHandle);
            }
        }

        private void btnPTSYenile_Click(object sender, EventArgs e)
        {
            slePTSKontrolDocumentNumber.Properties.DataSource = new ITSDataContext(Global.ITSConnectionString).Receiving_Thirdparty_Packages_Master_Browse().ToList();
        }

        private void grdAmbalajDetayi_Click(object sender, EventArgs e)
        {

        }

        private void mnuShippingOrderDeclaration_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void grdSatisIptalKayitlariView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 240000 })
                {
                    Cancelled_Sales_BrowseResult Row = (Cancelled_Sales_BrowseResult)grdSatisIptalKayitlariView.GetRow(e.FocusedRowHandle);

                    if (Row.csm_id > 0)
                    {
                        grdSatisIptalKayitlariDetay.DataSource = lITS.Cancelled_Sales_Detail_Browse(Row.csm_id).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }

        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            mnuExportToExcelMaster.Enabled = true;
            mnuExportToExcelDetail.Enabled = true;
            btnExportToExcel.ContextMenuStrip.Show(btnExportToExcel, new System.Drawing.Point(0, btnExportToExcel.Height));
        }

        private void mnuExportToExcelMaster_Click(object sender, EventArgs e)
        {
            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdSSCCMaster.DataSource = null;
                    grdSSCCMaster.DataSource = lITS.Shipping_Order_Detail_SSCC_Browse(edtShippingOrderIPTSNumber.Text).ToList();
                }
                if (grdSSCCMasterView.RowCount > 0)
                {
                    sfdExcel.Filter = "Excel Dosyası (*.xls)|*.xls";
                    if (sfdExcel.ShowDialog() == DialogResult.OK)
                    {
                        string sFileName = sfdExcel.FileName;

                        ExportXmlProvider pro = new ExportXmlProvider(sFileName);
                        BaseExportLink link = grdSSCCMasterView.CreateExportLink(pro);
                        link.ExportTo(true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void mnuExportToExcelDetail_Click(object sender, EventArgs e)
        {
            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdSSCCDetail.DataSource = null;
                    grdSSCCDetail.DataSource = lITS.Shipping_Order_Detail_Packages_Browse(edtShippingOrderIPTSNumber.Text).ToList();
                }
                if (grdSSCCDetailView.RowCount > 0)
                {
                    sfdExcel.Filter = "Excel Dosyası (*.xls)|*.xls";
                    if (sfdExcel.ShowDialog() == DialogResult.OK)
                    {
                        string sFileName = sfdExcel.FileName;

                        ExportXmlProvider pro = new ExportXmlProvider(sFileName);
                        BaseExportLink link = grdSSCCDetailView.CreateExportLink(pro);
                        link.ExportTo(true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnMoveData_Click(object sender, EventArgs e)
        {
            using (VeriTasima frmVeriTasima = new VeriTasima() { sComID = edtShippingOrderIComID.Text, sStatus = edtShippingOrderIStatus.Text, sOrderIID = edtShippingOrderIID.Text })
            {
                frmVeriTasima.ShowDialog(this);
                RefreshShippingDetails(1);
            }
        }
    }
}

