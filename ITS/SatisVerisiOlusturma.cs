using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using LINQ;
using System.IO;
using ExcelDataReader;
using System.Data.Linq.Mapping;

namespace ITS
{
    public partial class SatisVerisiOlusturma : Form
    {
        public SatisVerisiOlusturma()
        {
            InitializeComponent();
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                bedVeriDosyasi.Text = openFileDialog1.FileName;

        }

        public static List<string> ReadDataFromExcelXLS(string filePath)
        {

            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader;
            List<string> codeList = new List<string>();

            if (Path.GetExtension(filePath).ToUpper() == ".XLS")
            {
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else
            {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }

            while (excelReader.Read())
            {
                codeList.Add(excelReader.GetString(0));
            }
            excelReader.Close();

            return codeList;
        }

        public static DataSet ImportExcelXLS(string FileName, bool hasHeaders)
        {
            string HDR = hasHeaders ? "YES" : "NO";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + "\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + "\"";

            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Persist Security Info=False;";

            DataSet output = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    if (!sheet.EndsWith("_"))
                    {
                        try
                        {
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                            cmd.CommandType = CommandType.Text;

                            DataTable outputTable = new DataTable(sheet);
                            output.Tables.Add(outputTable);
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }
                }
            }
            return output;
        }

        private void btnVeriyiKaydet_Click(object sender, EventArgs e)
        {
            //@bilgehan Satış Verisi Oluşturma ve excelden veri aktarma
            if (edtFaturaNumarasi.Text == "")
            {
                MessageBox.Show("Fatura numarasını giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edtFaturaNumarasi.Focus();
                return;
            }

            //DataSet Excel = ImportExcelXLS(bedVeriDosyasi.Text, false);
            List<string> Excel = ReadDataFromExcelXLS(bedVeriDosyasi.Text);
            int? iSorId = 0;

            Cursor = Cursors.WaitCursor;
            try
            {
                using (var lITS = new ITSDataContext(Global.ITSConnectionString) { CommandTimeout = 120000 })
                {
                    for (int i = 0; i < Excel.Count; i++)
                    {
                        string sPackageCode = Excel[0].ToString();
                        if (sPackageCode == "") break;

                        if (sPackageCode.Length > 16 && sPackageCode.Substring(0, 2) == "01")
                            sPackageCode = sPackageCode.Substring(18, 16);

                        iSorId = lITS.Create_Sales_Data_From_Excel(edtFaturaNumarasi.Text, sPackageCode, (int?)(iSorId == 0 ? null : iSorId));
                        if (iSorId == 0) return;
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

            MessageBox.Show("Veriler başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
