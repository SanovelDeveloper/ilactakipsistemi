using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace ITS
{
  public partial class SplashScreen1 : SplashScreen
  {
    public SplashScreen1()
    {
      InitializeComponent();
      lblSurum.Text = "Sürüm " + Application.ProductVersion.Substring(0, Application.ProductVersion.Length - 2);
    }

    #region Overrides

    public override void ProcessCommand(Enum cmd, object arg)
    {
      base.ProcessCommand(cmd, arg);
    }

    #endregion

    public enum SplashScreenCommand
    {
    }
  }
}