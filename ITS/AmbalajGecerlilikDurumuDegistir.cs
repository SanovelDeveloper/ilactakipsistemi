/*******************************************************************************/
/*  Copyright (c) 2009 SANOVEL A.Ş.  / bilsis@sanovel.com.tr                   */
/*  All rights reserved.                                                       */
/*                                                                             */
/*  Tanım    : İTS uygulamasının ambalaj geçerlilik durumu değiştirme ekranıdır*/
/*  Amaç     : İTS uygulamasında bir ambalajın geçerlilik durumunu değiştirmek */
/*  Kısıtlar :  -                                                              */
/*                                                                             */
/*  Düzenleme Tarihçesi:                                                       */
/*  Versiyon  Tarih       Kişi     Açıklama                                    */
/*    1.0     11/01/2010  AY       Başlandı.                                   */
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
using System.Windows.Forms;

namespace ITS
{
  public partial class AmbalajGecerlilikDurumuDegistir : Form
  {
    public AmbalajGecerlilikDurumuDegistir()
    {
      InitializeComponent();
    }
    
    public class GecerlilikDurumuDetayi
    {
      private string sValue;
      private string sDisplayText;

      public GecerlilikDurumuDetayi(string sv, string sd)
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
  }
}
