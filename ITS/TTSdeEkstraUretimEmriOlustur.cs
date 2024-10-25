/*******************************************************************************/
/*  Copyright (c) 2010 SANOVEL A.Ş.  / bilsis@sanovel.com.tr                   */
/*  All rights reserved.                                                       */
/*                                                                             */
/*  Tanım    : İTS uygulamasının TTS sisteminde ekstra üretim emri             */
/*             oluşturulması için kullanılan ekrandır.                         */
/*  Amaç     : TTS sisteminde _ li üretimlerin doğru bilgilerle İTS üzerinden  */
/*             oluşturulmasının sağlanması.                                    */
/*  Kısıtlar :  -                                                              */
/*                                                                             */
/*  Düzenleme Tarihçesi:                                                       */
/*  Versiyon  Tarih       Kişi     Açıklama                                    */
/*    1.0     25/08/2010  AY       Başlandı.                                   */
/*                                                                             */
/*                                                                             */
/*  Açıklama ve Yorumlar:                                                      */
/*                                                                             */
/*                                                                             */
/*  Kısaltmalar:                                                               */
/*  AY : Ali YAZICI                                                            */
/*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LINQ;

namespace ITS
{
    public partial class TTSdeEkstraUretimEmriOlustur : Form
    {
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
                get { return sValue; }
            }
        }

        IList<Production_Order_Insert_Setting> tProductionOrderInsertSettings;

        public TTSdeEkstraUretimEmriOlustur()
        {
            InitializeComponent();

            tProductionOrderInsertSettings = new ITSDataContext(Global.ITSConnectionString).Production_Order_Insert_Settings.ToList();
        }

        private void btnAGEyeGonderilebilirUretimEmirleriniGetir_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdTTSdeEkstraOlusturulabilirUretimEmirleri.DataSource = lITS.Order_List_Browse_For_Additional_Production_Order_Insert(Convert.ToInt32(edtUretimEmriGunSayisi.Text),
                                                                                                                                           null,
                                                                                                                                           Convert.ToByte(cbeTTSSistemi.SelectedIndex + 1)).ToList();
                }

                edtUretimMiktari.Enabled = (grdTTSdeEkstraOlusturulabilirUretimEmirleriView.RowCount > 0);
                cbeUretimHatti.Enabled = edtUretimMiktari.Enabled;
                btnEkstraUretimEmriOlustur.Enabled = edtUretimMiktari.Enabled && Guvenlik.GuvenlikKontrol("tbpUretimEmriEkleme", Guvenlik.Yetkiler.KayitEkleme); ;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnEkstraUretimEmriOlustur_Click(object sender, EventArgs e)
        {
            if (grdTTSdeEkstraOlusturulabilirUretimEmirleriView.SelectedRowsCount == 0) return;

            Order_List_Browse_For_Additional_Production_Order_InsertResult Row = (Order_List_Browse_For_Additional_Production_Order_InsertResult)grdTTSdeEkstraOlusturulabilirUretimEmirleriView.GetFocusedRow();

            string sUretimEmriNo = Row.TB022_ORDER_ID;
            string sUretimEmriAdedi = Row.count_of_order.ToString();
            string sGTIN = Row.mmr_gtin;
            string sBatchNo = Row.TB022_PK_BATCH_NO;
            DateTime tSKT = (DateTime)Row.TB022_EXPIRY_DATE;

            if (cbeUretimHatti.SelectedIndex == -1)
            {
                MessageBox.Show("Üretim hattı boş geçilemez!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbeUretimHatti.Focus();
                return;
            }

            if (edtEkstraOlusturulacakKodAdedi.Text == "")
            {
                MessageBox.Show("Ekstra oluşturulacak kod adedi boş geçilemez!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edtEkstraOlusturulacakKodAdedi.Focus();
                return;
            }

            if (cheKolilemeYapilacak.Checked && cbeCaseCode.SelectedIndex == -1)
            {
                MessageBox.Show("Kolileme yapılacak ise koli kodu seçimi zorunludur!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor = Cursors.WaitCursor;
            mpbUretimEmriniGonder.Visible = true;
            Application.DoEvents();
            try
            {
                if (cbeTTSSistemi.SelectedIndex == 0)
                {
                    using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                    {
                        lITS.WMS_Production_Order_Insert_To_TTS(String.Format("{0}_{1}", sUretimEmriNo, sUretimEmriAdedi),
                                                                sBatchNo,
                                                                Convert.ToInt32(((UretimHattiDetayi)cbeUretimHatti.SelectedItem).Value),
                                                                sGTIN,
                                                                Convert.ToInt32(edtEkstraOlusturulacakKodAdedi.Text),
                                                                DateTime.Now,
                                                                tSKT);
                    }
                }
                else if (cbeTTSSistemi.SelectedIndex == 1)
                {
                    TTS.Main CBO = new ITS.TTS.Main();
                    string sResult = CBO.CreateBatchOrder("itsup",
                                                          "poins1",
                                                          String.Format("{0}_{1}", sUretimEmriNo, sUretimEmriAdedi), // order id
                                                          sBatchNo,  // batch no
                                                          Convert.ToInt32(((UretimHattiDetayi)(cbeUretimHatti.SelectedItem)).Value), // üretim bandı
                                                          5,
                                                          "TR",
                                                          DateTime.Now,
                                                          tSKT, // SKT
                                                          sGTIN, // GTIN 
                                                          "",
                                                          Convert.ToInt32(edtEkstraOlusturulacakKodAdedi.Text), // üretim miktarı
                                                          "",
                                                          "",
                                                          (cheKolilemeYapilacak.Checked ? cbeCaseCode.Text : ""), // sscc icin ürün kodu
                                                          "",
                                                          "",
                                                          true);

                    if (sResult == "FUNCTION PERFORMED") // ekleme başarılı
                    {
                        using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                        {
                            lITS.WMS_Production_Order_Insert_To_TTSV2(String.Format("{0}_{1}", sUretimEmriNo, sUretimEmriAdedi),
                                                                      sBatchNo,
                                                                      Convert.ToInt32(((UretimHattiDetayi)cbeUretimHatti.SelectedItem).Value),
                                                                      sGTIN,
                                                                      Convert.ToInt32(edtEkstraOlusturulacakKodAdedi.Text),
                                                                      DateTime.Now,
                                                                      tSKT);
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
                mpbUretimEmriniGonder.Visible = false;
                Application.DoEvents();
            }

            lblOlusturulanUretimEmriNumarasi.Text = "Oluşturulan üretim emri numarası: " + sUretimEmriNo + "_" + sUretimEmriAdedi;
            cbeUretimHatti.Text = "";
            edtEkstraOlusturulacakKodAdedi.Text = "";
        }

        private void btnUretimEmriniGetir_Click(object sender, EventArgs e)
        {
            if (edtUretimEmriNumarasi.Text == "") return;

            Cursor = Cursors.WaitCursor;
            try
            {

                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    grdTTSdeEkstraOlusturulabilirUretimEmirleri.DataSource = lITS.Order_List_Browse_For_Additional_Production_Order_Insert(null,
                                                                                                                                           edtUretimEmriNumarasi.Text,
                                                                                                                                           Convert.ToByte(cbeTTSSistemi.SelectedIndex + 1)).ToList();
                }

                edtUretimMiktari.Enabled = (grdTTSdeEkstraOlusturulabilirUretimEmirleriView.RowCount > 0);
                cbeUretimHatti.Enabled = edtUretimMiktari.Enabled;
                btnEkstraUretimEmriOlustur.Enabled = edtUretimMiktari.Enabled && Guvenlik.GuvenlikKontrol("tbpUretimEmriEkleme", Guvenlik.Yetkiler.KayitEkleme); ;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void edtUretimEmriNumarasi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnUretimEmriniGetir_Click(sender, null);
            }
        }

        private void edtUretimEmriGunSayisi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAGEyeGonderilebilirUretimEmirleriniGetir_Click(sender, null);
            }
        }

        private void cbeTTSSistemi_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
            {
                var tLineList = lITS.Line_Lists.Where(l => l.lin_type_id == 34
                                                      && l.lin_phase == cbeTTSSistemi.SelectedIndex + 1).OrderBy(d => d.lin_description).ToList();
                cbeUretimHatti.Properties.Items.Clear();

                foreach (var Line in tLineList)
                {
                    cbeUretimHatti.Properties.Items.Add(new UretimHattiDetayi(Line.lin_id.ToString(), Line.lin_description));
                }
            }

            cheKolilemeYapilacak.Enabled = (cbeTTSSistemi.SelectedIndex == 1);
        }

        private void edtUretimMiktari_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int iUM = Convert.ToInt32(edtUretimMiktari.Text);
                edtEkstraOlusturulacakKodAdedi.Text = Math.Round(iUM * tProductionOrderInsertSettings.Where(p => p.pos_min <= iUM
                                                                                                            && p.pos_max > iUM).First().pos_parameter / Convert.ToDecimal(1.05)).ToString();
            }
            catch { }
        }

        private void grdTTSdeEkstraOlusturulabilirUretimEmirleriView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Order_List_Browse_For_Additional_Production_Order_InsertResult Row = (Order_List_Browse_For_Additional_Production_Order_InsertResult)grdTTSdeEkstraOlusturulabilirUretimEmirleriView.GetFocusedRow();

            using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
            {
                var tCaseList = lITS.Material_Master_Cases_Browse(Row.mmr_gtin).ToList();
                cbeCaseCode.Properties.Items.Clear();
                foreach (var Code in tCaseList)
                {
                    cbeCaseCode.Properties.Items.Add(Code.TB020_GTIN);
                }
            }
            cbeCaseCode.SelectedIndex = 0;
        }

        private void TTSdeEkstraUretimEmriOlustur_Load(object sender, EventArgs e)
        {
            cbeTTSSistemi.SelectedIndex = 1;
        }

    }
}
