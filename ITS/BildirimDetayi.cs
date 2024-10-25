using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ITS
{
  public partial class BildirimDetayi : Form
  {
    public BildirimDetayi()
    {
      InitializeComponent();
    }
    
    public void DetayEkle(int i, string OrderId, string AmbalajKodu, string Mesaj)
    {
      lstBildirimDetayi.Items.Add(i.ToString() + "-" + OrderId + " numaralı üretim için gönderilen " + AmbalajKodu + " kodlu ambalaj için dönen bilgi: " + Mesaj);  
    }
  }
}
