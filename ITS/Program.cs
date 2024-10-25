using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace ITS
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {      
      DevExpress.UserSkins.BonusSkins.Register();      
      SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.BonusSkins).Assembly);
      //DevExpress.Skins.SkinManager.EnableFormSkins();
      DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Caramel");      

      // The following line provides localization for data formats. 
      System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");

      // The following line provides localization for the application's user interface. 
      System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");

      Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      using (Giris frmGiris = new Giris())
      {
        if (frmGiris.ShowDialog() == DialogResult.OK)
        {
          SplashScreenManager.ShowForm(typeof(SplashScreen1), false, false);
          Application.Run(new main());
        }
      }
    }

    static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      MessageBox.Show(e.Exception.Message, "Hata");
      // here you can log the exception ...
    }

    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      MessageBox.Show((e.ExceptionObject as Exception).Message, "Hata");
      // here you can log the exception ...
    }
  }
}
