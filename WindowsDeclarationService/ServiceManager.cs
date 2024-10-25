using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using LINQ;

namespace WindowsDeclarationService
{
  class ServiceManager
  {
    private Thread Service;
    private bool isPaused = false;
    private string SQLAlias = "WMSDEV";
    private char Environment = 'G'; 
    private String sConnString;

    internal ServiceManager()
    {
      Service = new Thread(Execute);
    }

    internal void Execute()
    {
      try
      {
        while (true)
        {
          if (isPaused)
          {
            Thread.Sleep(500);
            continue;
          }
          Thread thrControl = new Thread(new ThreadStart(Control));
          thrControl.Start();
          //Control();

          Thread.Sleep(60000); // 1 dakikada bir kontrol yapacak
        }
      }
      catch (Exception E)
      {
        EventLogger.AddException(E.Message);
        Service.Abort();
        Service.Start();
      }
    }

    internal void Start()
    {
      string path = Process.GetCurrentProcess().MainModule.FileName;
      path = path.Substring(0, path.LastIndexOf("\\"));

      INIFile INI = new INIFile(path + @"\config.ini");
      SQLAlias = INI.IniReadValue("StartUp", "SQLALIAS");
      Environment = INI.IniReadValue("StartUp", "Environment")[0];

      sConnString = String.Format("Data Source={0};Initial Catalog=ITS;Persist Security Info=True;User ID=ITS_USER;Password=fast", SQLAlias);

      Service.Start();
    }

    internal void Stop()
    {
      Service.Abort();
    }

    internal void Pause()
    {
      isPaused = true;
    }

    internal void Continue()
    {
      isPaused = false;
    }

    private void Control()
    {

      using (var lITS = new ITSDataContext(sConnString))
      {
        var tSD = lITS.Scheduled_Declarations.Where(s => s.sch_status == 'W' && s.sch_scheduled_time <= DateTime.Now).ToList();

        foreach (var SD in tSD)
        {
          try
          {
            //lITS.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, SD);
            SD.sch_status = 'R';
            lITS.SubmitChanges();

            switch (SD.sch_type)
            {
              case 'P': // Üretim
                int iRecordCount = (int)lITS.Order_List_Browse().Where(o => o.ord_order_id == SD.sch_order_id).First().unsent_quantity;

                DeclarationServices.SendProduction UB = new DeclarationServices.SendProduction(-1, Environment, sConnString);
                int iID = UB.UretimBildirimineBasla(iRecordCount, SD.sch_order_id);

                EventLogger.AddEvent(SD.sch_order_id + " numaralı üretim emrinin Üretim bildirimi yapıldı.");
                break;
              case 'S': // Satış
                DeclarationServices.SendSales SB = new DeclarationServices.SendSales(-1, Environment, sConnString);
                SB.SendAsync(SD.sch_order_id, 1, null, null);

                EventLogger.AddEvent(SD.sch_order_id + " numaralı iş emrinin satış bildirimi yapıldı.");
                break;
              case 'C': // PTS
                DeclarationServices.SendPTS PTS = new DeclarationServices.SendPTS(-1, Environment, sConnString);
                PTS.GonderAsync(SD.sch_order_id);

                EventLogger.AddEvent(SD.sch_order_id + " numaralı iş emrinin PTS bildirimi yapıldı.");                
                break;
              case 'G': // Grup içi satış - alış
                DeclarationServices.SendSales SBG = new DeclarationServices.SendSales(-1, Environment, sConnString);
                SBG.SendAsync(SD.sch_order_id, 2, SD.sch_seller_gln, SD.sch_buyer_gln);

                DeclarationServices.SendReceipt SR = new DeclarationServices.SendReceipt(-1, Environment, sConnString);
                SR.Send(SD.sch_order_id, null);          

                EventLogger.AddEvent(SD.sch_order_id + " numaralı iş emrinin grup içi satış - alış bildirimi yapıldı.");
                break;
              case 'E': // İhracat
                break;
            }

            //lITS.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, SD);
            SD.sch_status = 'F';
            SD.sch_declaration_time = DateTime.Now;
            lITS.SubmitChanges();
          }
          catch (Exception E)
          {
            SD.sch_status = 'W';
            lITS.SubmitChanges();
            EventLogger.AddException(SD.sch_order_id + " - " + E.Message);
          }
        }

        
      }
    }
  }
}
