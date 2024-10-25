using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LINQ;
using DevExpress.XtraSplashScreen;

namespace ITS
{
    public partial class VeriTasima : Form
    {
        public string sComID = "";
        public string sStatus = "";    
        public string sOrderIID = "";

        public VeriTasima()
        {
            InitializeComponent();
        }

        private void VeriTasima_Load(object sender, EventArgs e)
        {
            sleTargetAccount.Properties.DataSource = new ITSDataContext(Global.ITSConnectionString).vAccount_Masters.ToList();                
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
          /*
            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    string AccountCode = sleTargetAccountView.GetFocusedRowCellValue(sleTargetAccountamr_account_code).ToString();

                    int iShippingOrderITargetID = lITS.Move_Shipping_Order(edtTargetShippingOrderIPTSNumber.Text,
                                             AccountCode,
                                             Convert.ToByte(sComID),
                                             Convert.ToChar(sStatus));

                    lITS.Move_Shipping_Order_Detail(Convert.ToInt32(sOrderIID),
                                                    iShippingOrderITargetID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                btnOnayla.Enabled = false;
                MessageBox.Show("Veri taşıma işlemi yapılmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           */
        }      
    }
}
