using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WindowsDeclarationService
{
    public partial class Service : ServiceBase
    {
        private ServiceManager serviceManager;

        public Service()
        {
            InitializeComponent();

            if (!System.Diagnostics.EventLog.SourceExists("ITS Declaration Service"))
                System.Diagnostics.EventLog.CreateEventSource("ITS Declaration Service", "Application");

            eventLog1.Source = "ITS Declaration Service";
            eventLog1.Log = "Application";

            serviceManager = new ServiceManager();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                serviceManager.Start();
            }
            catch (Exception E)
            {
                eventLog1.WriteEntry("Hata: " + E.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            serviceManager.Stop();
            serviceManager = null;
        }

        protected override void OnPause()
        {
            serviceManager.Pause();
        }

        protected override void OnContinue()
        {
            serviceManager.Continue();
        }
    }
}
