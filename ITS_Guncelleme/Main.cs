using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace ITS_Guncelleme
{
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
    }

    private void Main_Load(object sender, EventArgs e)
    {

      Process[] pArry = Process.GetProcesses();

      foreach (Process p in pArry)
      {
        string s = p.ProcessName;
        s = s.ToLower();
        if (s.CompareTo("ıts") == 0)
        {
          if (MessageBox.Show("Güncelleme yapılabilmesi için çalışan ITS uygulaması kapatılacaktır. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            p.Kill();
          else {
            Close();
            return;
          }
        }
      } 
                  
      try
      {
        btnDurdur.Enabled = true;

        File.Move(Application.StartupPath + @"\ITS.exe", Application.StartupPath + @"\ITS_B.exe");
              
        WebClient webClient = new WebClient();
        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
        webClient.DownloadFileAsync(new Uri("http://sim.sanovel.com.tr/itsupdate/ITS.exe"), Application.StartupPath + @"\ITS.exe");
      }
      catch {}
    }
    private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
      pbcIndiriliyor.EditValue = e.ProgressPercentage;
    }

    private void Completed(object sender, AsyncCompletedEventArgs e)
    {
      pbcIndiriliyor.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
      pbcIndiriliyor.Properties.DisplayFormat.FormatString = "Güncel uygulama yüklendi";
      btnDurdur.Enabled = false;
      File.Delete(Application.StartupPath + @"\ITS_B.exe");
      
    }

    private void btnDurdur_Click(object sender, EventArgs e)
    {
      if (File.Exists(Application.StartupPath + @"\ITS_B.exe"))
      {
        File.Delete(Application.StartupPath + @"\ITS.exe");
        File.Move(Application.StartupPath + @"\ITS_B.exe", Application.StartupPath + @"\ITS.exe");
      }
      Close();
    }  
     
  }
  
}
