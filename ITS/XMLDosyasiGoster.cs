using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ITS
{
  public partial class XMLDosyasiGoster : Form
  {
    private string sDosyaAdi = "";
    public XMLDosyasiGoster(string DosyaAdi)
    {
      InitializeComponent();           
      sDosyaAdi = DosyaAdi;
    }

    private void XMLDosyasiGoster_Load(object sender, EventArgs e)
    {      
      bedXMLDosyasi.Text = sDosyaAdi;
      webXML.Navigate(new Uri("file:///" + sDosyaAdi));      
    }

    private void bedXMLDosyasi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
      ofdXML.ShowDialog();
      webXML.Navigate(new Uri("file:///" + ofdXML.FileName)); 

    }
  }
}
