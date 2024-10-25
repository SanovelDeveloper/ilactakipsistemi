<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITS_CRM._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>Sanovel İTS Uygulaması Eczane Çağrıları Yönetim Sistemi</title>
  <link href="style.css" rel="stylesheet" type="text/css" /> 
  <link href="autocomplete.css" rel="stylesheet" type="text/css" /> 
  <style type="text/css"> 
  div#tipDiv {
      padding:4px;
      color:#000; font-size:11px; line-height:1.2;
      background-color:#E1E5F1; border:1px solid #FFD284; 
      width:210px; 
  } 
  </style>   
  <script src="js/ajax.js" type="text/javascript"></script> 
  <script src="js/tooltip.js" type="text/javascript"></script> 
	<script src="js/jquery.js" type="text/javascript"></script> 
  <script src="js/jquery.autocomplete.js" type="text/javascript"></script> 
	
	  
  <script type="text/javascript">
  
    function KayitGirisAlaniGoster(id, gizle, herzamangoster)
    {
      if (herzamangoster == 0)
      {
        if (document.getElementById(id).style.visibility == 'hidden')
        {
          document.getElementById(id).style.visibility='visible';
          document.getElementById(id).style.position='relative'; 
          
          // diğer tüm trler kapatılacak      
          if (gizle == 1) 
          {
            var table = document.getElementById("tblMenu");         
            var arrayOfTrs = table.getElementsByTagName('tr');        
            for (i = 0; i < arrayOfTrs.length - 1; i++) 
            {
              var thisTR = arrayOfTrs[i];          
              if (thisTR.id.substring(0, 3) == "gtr" && thisTR.id != id)
              {
                document.getElementById(thisTR.id).style.visibility='hidden';
                document.getElementById(thisTR.id).style.position='absolute';          
              }
            }
          }
        }
        else
        {
          document.getElementById(id).style.visibility='hidden';
          document.getElementById(id).style.position='absolute';
        }
      }  
      else 
      {
        document.getElementById(id).style.visibility='visible';
        document.getElementById(id).style.position='relative'; 
      }    
    }
    
        
	  var OncekiClass1 = null;
	  var OncekiObj1 = null;	
	  var OncekiClass2 = null;
	  var OncekiObj2 = null;		  
   
	  function highlight(obj, id, tablo) {
	    if (tablo == 1)
	    {
	      var not = document.getElementById('not' + id).innerHTML;
	      not = not.replace(/<br>/g, "\r\n");
	      not = not.replace(/<BR>/g, "\r\n"); // ie için
	      document.forms[0].edtNot.value = not;
	      document.forms[0].hidTckId.value = id;
	      document.forms[0].edtMailBaslik.value = document.getElementById('trListe' + id).getElementsByTagName("td")[0].innerHTML;
	      
		    if (OncekiObj1)
			    OncekiObj1.className = OncekiClass1;
    			
		    OncekiObj1 = obj;
		    OncekiClass1 = obj.className;
		    
		    mailIcineEkle(null, null);
  		}
  		else if (tablo == 2)
  	  {
		    if (OncekiObj2)
			    OncekiObj2.className = OncekiClass2;
    			
		    OncekiObj2 = obj;
		    OncekiClass2 = obj.className;
  	  }
  	  
		  obj.className = 'select';			  		
	  }
	  
	  var IlacAdi = null;
	  var GTIN = null;
	  var BatchNo = null;
	  var ExpiryDate = null;
	  var PackageCode = null;
	  
	  function dogrulanacakUrunSec(sIlacAdi, sGTIN, sBatchNo, sExpiryDate, sPackageCode)
	  {
	    IlacAdi = sIlacAdi;
	    GTIN = sGTIN;
	    BatchNo = sBatchNo;
	    ExpiryDate = sExpiryDate;
	    PackageCode = sPackageCode;
	  }
     
    if (!Array.indexOf) {
      Array.prototype.indexOf = function(obj) {
        for (var i = 0; i < this.length; i++) {
          if (this[i] == obj) {
            return i;
          }
        }
        return -1;
      }
    }
         
    var aBilgiler = new Array();
    function mailIcineEkle(cb, bilgi)
    {
      if (cb)
      {
        if (cb.checked) aBilgiler.push(bilgi);
        else aBilgiler.splice(aBilgiler.indexOf(bilgi), 1);
        aBilgiler.sort();
      }            
            
      document.forms[0].edtMail.value = "";
      for (i = 0; i < aBilgiler.length; i++)
      {      
        if (aBilgiler[i] == '1') // eczane bilgileri
        {
          satir = document.getElementById('trListe' + document.forms[0].hidTckId.value);
          eczaneAdi = satir.getElementsByTagName("td")[0].innerHTML;          
          eczaciAdi = satir.getElementsByTagName("td")[1].innerHTML;
          ilceIl = satir.getElementsByTagName("td")[2].innerHTML;
          telefon = satir.getElementsByTagName("td")[3].innerHTML;
          
          document.forms[0].edtMail.value += "Eczane Adı: " + eczaneAdi + "\r\nEczacı Adı, Soyadı: " + eczaciAdi + "\r\nİlçe / İl: " + ilceIl + "\r\nTelefon Numarası: " + telefon + "\r\n\r\n";     
        }
        
        if (aBilgiler[i] == '2') // ürün doğrulama
        {          
          var dogrulama_sonucu = document.getElementById("divUrunDogrulamaSonuclari").innerHTML;   
          if (GTIN != null && dogrulama_sonucu != "")
          {                     
            document.forms[0].edtMail.value += "İlaç Adı: " + IlacAdi + "\r\nGTIN: " + GTIN + "\r\nSeri Numarası: " + BatchNo + "\r\nSon Kullanma Tarihi: " + ExpiryDate + "\r\nAmbalaj Kodu: " + PackageCode + "\r\n\r\n";     
            document.forms[0].edtMail.value += "İlacın durumu İTS sisteminden kontrol edildi.\r\nSonuç: " + dogrulama_sonucu.substring(0, dogrulama_sonucu.length-4) + "\r\n\r\n";            
          }            
        }    
        
        if (aBilgiler[i] == '3') // not
        {
          var not = document.forms[0].edtNot.value;
          if (not != "")
            document.forms[0].edtMail.value += not + "\r\n\r\n";
        }    
      }
    }
    
    function epostaAdresiDegistir()
    {
      var epostaAdresi = document.forms[0].ddlEPostaAdresi;
      if (epostaAdresi.value != "0")
        document.forms[0].edtMailEpostaAdresi.value = document.forms[0].ddlEPostaAdresi.value;
      else document.forms[0].edtMailEpostaAdresi.value = "";
      document.forms[0].edtMailEpostaAdresi.disabled = (epostaAdresi.value != "0");
    }
    
    function eczaneBilgisiDegisti(obj)
    {
      if (obj.value == "")
      {
        document.forms[0].edtEczaneAdi.value = "";
        document.forms[0].hidSDSId.value = "0";
        document.forms[0].edtEczaciAdiSoyadi.value = "";
        document.forms[0].edtIlce.value = "";
        document.forms[0].edtIl.value = "";
        document.forms[0].edtTelefonNumarasi1.value = "";
        document.forms[0].edtEPostaAdresi.value = "";
        document.forms[0].edtBrick.value = "";
        document.forms[0].edtAdresi.value = "";         
      }
    }
  </script>
  
  
</head>
<body>
  <form id="form1" runat="server">
  <div>   
    <table border="0" style="width:100%;"> 
      <tr> 
        <td style="width:46px; padding-left: 10px"> 
          <img src="resimler/image12.gif" alt="icon"/> 
        </td> 
        <td style="font-size:20px"> 
          İTS Eczane Çağrıları Yönetimi
        </td>    
        <td style="text-align:right; padding-right: 10px"> 
          <img src="resimler/logo.jpg" alt="sanovel_logo"/> 
        </td>                               
      </tr> 
   </table>  
   <br />
   
   <div align="center">    
   <div class="main">   
       
    <table style="text-align: left !important; width:100%" id="tblMenu">
      <tr>
        <td>
          <table border="0" cellpadding="2" cellspacing="2" width="100%">
            <tr>
              <td style="border-right: 1px solid #d5d5d5;text-align: center; width:25%"><a href="javascript:KayitGirisAlaniGoster('gtrKayitGirisi', 1, 0)">Yeni Kayıt</a></td>
              <td style="border-right: 1px solid #d5d5d5;text-align: center; width:25%"><a href="javascript:KayitGirisAlaniGoster('gtrUrunSorgulama', 1, 0)">Seçili Eczane İçin Ürün Sorgula</a></td>              
              <td style="border-right: 1px solid #d5d5d5;text-align: center; width:25%"><a href="javascript:KayitGirisAlaniGoster('gtrNotGirisi', 1, 0)">Seçili Eczane İçin Not Gir</a></td>                            
              <td style="text-align: center; width:25%"><a href="javascript:KayitGirisAlaniGoster('gtrMail', 1, 0)">Girilen Bilgileri Mail Gönder</a></td>              
            </tr>
          </table>

        </td>
      </tr>      
      <tr style="visibility:hidden;position:absolute;" id="gtrKayitGirisi">
        <td>
          <!-- kayıt girişi -->
          <table border="0" cellpadding="2" cellspacing="2" width="100%" style="border-top: 1px solid #d5d5d5">
            <tr>
              <td style="height:24px; width: 120px">İl</td>              
              <td>
                <asp:TextBox ID="edtIl" runat="server" Width="150" MaxLength="30" CssClass="inputbox"></asp:TextBox>               
              </td>              
            </tr> 
            <tr>
              <td style="height:24px; width: 120px">Eczane Adı</td>              
              <td>
                <asp:TextBox ID="edtEczaneAdi" runat="server" Width="400" MaxLength="100" CssClass="inputbox ac_input" onchange="eczaneBilgisiDegisti(this)"></asp:TextBox>               
              </td>              
            </tr>
            <tr>
              <td style="height:24px; width: 120px">Eczacı Adı, Soyadı</td>              
              <td>
                <asp:TextBox ID="edtEczaciAdiSoyadi" runat="server" Width="400" MaxLength="100" CssClass="inputbox ac_input" onchange="eczaneBilgisiDegisti(this)"></asp:TextBox>               
              </td>              
            </tr>         
            <tr>
              <td style="height:24px; width: 120px">Adresi</td>              
              <td>
                <asp:TextBox ID="edtAdresi" runat="server" Width="400" MaxLength="100" CssClass="inputbox"></asp:TextBox>               
              </td>              
            </tr>                 
            <tr>
              <td style="height:24px; width: 120px">İlçe</td>              
              <td>
                <asp:TextBox ID="edtIlce" runat="server" Width="150" MaxLength="30" CssClass="inputbox"></asp:TextBox>               
              </td>              
            </tr>
 
            <tr>
              <td style="height:24px; width: 120px">Telefon Numarası 1</td>              
              <td>
                <asp:TextBox ID="edtTelefonNumarasi1" runat="server" Width="150" MaxLength="11" CssClass="inputbox"></asp:TextBox>               
              </td>              
            </tr>    
            <tr>
              <td style="height:24px; width: 120px">Telefon Numarası 2</td>              
              <td>
                <asp:TextBox ID="edtTelefonNumarasi2" runat="server" Width="150" MaxLength="11" CssClass="inputbox"></asp:TextBox>               
              </td>              
            </tr> 
            <tr>
              <td style="height:24px; width: 120px">E-Posta Adresi</td>              
              <td>
                <asp:TextBox ID="edtEPostaAdresi" runat="server" Width="150" MaxLength="50" CssClass="inputbox"></asp:TextBox>               
              </td>              
            </tr>   
            <tr>
              <td style="height:24px; width: 120px">Brick</td>              
              <td>
                <asp:TextBox ID="edtBrick" runat="server" Width="400" MaxLength="50" CssClass="inputbox" Enabled=false></asp:TextBox>               
              </td>              
            </tr>                             
            <tr>
              <td style="height:24px; width: 120px"></td>              
              <td>
                <asp:HiddenField ID="hidSDSId" runat="server" Value="0"  />
                <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="button" 
                  onclick="btnKaydet_Click" />        
              </td>              
            </tr>                                   
          </table>             
          <script type="text/javascript"> 
            function findValue(li) {
  	          if( li == null ) return alert("Kayıt bulunamadı!");
              
              document.forms[0].edtEczaneAdi.value = li.selectValue;
              document.forms[0].hidSDSId.value = li.extra[0];
              document.forms[0].edtEczaciAdiSoyadi.value = li.extra[1];
              document.forms[0].edtIlce.value = li.extra[2];
              document.forms[0].edtIl.value = li.extra[3];
              document.forms[0].edtTelefonNumarasi1.value = li.extra[4];
              document.forms[0].edtEPostaAdresi.value = li.extra[5];
              document.forms[0].edtBrick.value = li.extra[6];
              document.forms[0].edtAdresi.value = li.extra[7];              
            }
           
            function selectItem(li) {
    	        findValue(li);
            }
           
            function formatItem(row) {
    	          return row[0] + " (" + row[3] + "/" + row[4] + ")";
            }
           
            $(document).ready(function() {              $("#edtEczaneAdi").autocomplete(
                "EczaneArama.aspx",
                {
			            delay:10,
			            minChars:4,
			            matchSubset:1,
			            matchContains:1,
			            cacheLength:1,
			            maxItemsToShow:50,
			            onItemSelect:selectItem,
			            onFindValue:findValue,
			            formatItem:formatItem,
			            extraParams: { "c":document.forms[0].edtIl.value  },
			            autoFill:false
		            }
              );
              
              $("#edtEczaciAdiSoyadi").autocomplete(
                "EczaciArama.aspx",
                {
			            delay:10,
			            minChars:4,
			            matchSubset:1,
			            matchContains:1,
			            cacheLength:1,
			            maxItemsToShow:50,
			            onItemSelect:selectItem,
			            onFindValue:findValue,
			            formatItem:formatItem,
			            extraParams: { "c":document.forms[0].edtIl.value },
			            autoFill:false
		            }
              );              
            });
            
          </script>                 
        </td>
      </tr>   
      <tr style="visibility:hidden;position:absolute" id="gtrUrunSorgulama">
        <td>
          <!-- ürün sorgulama -->
          <table border="0" cellpadding="2" cellspacing="2" width="100%" style="border-top: 1px solid #d5d5d5">
            <tr>
              <td style="height:24px; width: 120px">İlaç Adı</td>              
              <td>
                <asp:DropDownList ID="ddlIlacAdi" runat="server" Width="210px" 
                  CssClass="inputbox" DataSourceID="sdsUrunListesi" DataTextField="mmr_item_name" 
                  DataValueField="mmr_gtin">
                  
                </asp:DropDownList>
              </td>              
              <td style="text-align:right; font-size: 16px; font-weight: bold;">İTS Destek Masası: 0 312 218 34 50</td>
            </tr>   
            <tr>
              <td style="height:24px; width: 120px">İlaç GTIN Numarası</td>              
              <td>
                <asp:TextBox ID="edtGTNNumarasi" runat="server" Width="200px" MaxLength="20" CssClass="inputbox"></asp:TextBox>               
              </td>              
              <td style="text-align:right; font-size: 16px; font-weight: bold;">
                <a href="http://itsmc.saglik.gov.tr/its_admin/menu.php" target="_blank">İTS Yönetim Paneli</a>
              </td>
            </tr>  
            <tr>
              <td style="height:24px; width: 120px">Seri (Lot) Numarası</td>              
              <td colspan="2">
                <asp:TextBox ID="edtSeriNumarasi" runat="server" Width="200px" MaxLength="20" CssClass="inputbox"></asp:TextBox>               
              </td>              
            </tr>                                      
            <tr>
              <td style="height:24px; width: 120px">Ambalaj Kodu</td>              
              <td colspan="2">
                <asp:TextBox ID="edtAmbalajKodu" runat="server" Width="200px" MaxLength="20" CssClass="inputbox"></asp:TextBox>               
              </td>              
            </tr>           
            <tr>
              <td style="height:24px; width: 120px"></td>              
              <td>
                <asp:Button ID="btnAra" runat="server" Text="Ara" CssClass="button" OnClientClick="javascript:urunSorgulamaSonuclari(document.forms[0].ddlIlacAdi.value, document.forms[0].edtGTNNumarasi.value, document.forms[0].edtSeriNumarasi.value, document.forms[0].edtAmbalajKodu.value, document.forms[0].hidTckId.value);KayitGirisAlaniGoster('gtrUrunSorgulamaSonuclari', 0, 1);return false;" />        
              </td>  
              <td style="text-align:right !important">
                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                  <tr>
                    <td style="text-align:right"><div id="divUrunDogrulamaSonuclari"></div></td>                    
                    <td style="text-align:right"><asp:Button ID="btnDogrula" runat="server" Text="Seçili Ambalajı Bakanlık Sisteminde Doğrula" CssClass="button" OnClientClick="urunDogrulamaSonuclari(GTIN, BatchNo, ExpiryDate, PackageCode, document.forms[0].hidTckId.value);return false;" /></td>
                  </tr>
                </table>                                
              </td>            
            </tr>                                   
          </table>          
        </td>
      </tr>             
      <tr style="visibility:hidden;position:absolute" id="gtrUrunSorgulamaSonuclari">
        <td>
          <!-- ürün sorgulama sonuçları -->
          <div id="divUrunSorgulamaSonuclari">Arama yapılıyor...</div>         
        </td>
      </tr>  
      <tr style="visibility:hidden;position:absolute" id="gtrNotGirisi">
        <td>
          <!-- not girişi -->
          <table border="0" cellpadding="2" cellspacing="2" width="100%" style="border-top: 1px solid #d5d5d5">
            <tr>
              <td style="height:24px; width: 80px; vertical-align:top">Not</td>              
              <td>             
                <asp:TextBox ID="edtNot" runat="server" Width="500px" MaxLength="2000" 
                  CssClass="inputbox" Rows="8" TextMode="MultiLine"></asp:TextBox>               
              </td>              
            </tr>                 
            <tr>
              <td style="height:24px; width: 80px"></td>              
              <td>                                
                <asp:Button ID="btnNotKaydet" runat="server" Text="Kaydet" CssClass="button" 
                  onclick="btnNotKaydet_Click"  />        
              </td>              
            </tr>    
          </table>
        </td>
      </tr>    
      <tr style="visibility:hidden;position:absolute" id="gtrMail">
        <td>
          <!-- mail -->
          <table border="0" cellpadding="2" cellspacing="2" width="100%" style="border-top: 1px solid #d5d5d5">
            <tr>
              <td style="height:24px; width: 120px; vertical-align:top">Seçenekler</td>              
              <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                  <tr>
                    <td><asp:CheckBox ID="chkEczaneBilgileriniEkle" runat="server" Text="Eczane Bilgilerini Ekle" onclick="mailIcineEkle(this, '1');" /></td>
                  </tr>
                  <tr>
                    <td><asp:CheckBox ID="chkDogrulamaBilgileriniEkle" runat="server" Text="Doğrulama Bilgilerini Ekle" onclick="mailIcineEkle(this, '2');" /></td>
                  </tr>
                  <tr>
                    <td><asp:CheckBox ID="chkNotEkle" runat="server" Text="Notu Ekle" onclick="mailIcineEkle(this, '3');" /></td>
                  </tr>
                </table> 
              </td>             
            </tr>
            <tr>
              <td style="height:24px; vertical-align:top;">Alıcı E-Posta Adresi</td>              
              <td>
                <asp:DropDownList ID="ddlEPostaAdresi" runat="server" Width="210px" 
                  CssClass="inputbox" DataSourceID="sdsEPostaListesi" DataTextField="EM_Name" 
                  DataValueField="EM_Email" onchange="epostaAdresiDegistir()">
                  
                </asp:DropDownList>  
                <br />            
                <asp:TextBox ID="edtMailEpostaAdresi" runat="server" Width="300px" MaxLength="100" CssClass="inputbox"></asp:TextBox>               
              </td>             
            </tr>
            <tr>
              <td style="height:24px; vertical-align:top;">Bilgi</td> 
              <td>
                <asp:CheckBoxList ID="cblMailBilgiler" runat="server" CellPadding="0" CellSpacing="0">
                  <asp:ListItem Value="serafettinogutal@sanovel.com.tr" Selected=True>Şerafettin Öğütal</asp:ListItem>
                  <asp:ListItem Value="ertugrulozdemir@sanovel.com.tr" Selected=True>Ertuğrul Özdemir</asp:ListItem>                  
                  <asp:ListItem Value="burakdurmaz@sanovel.com.tr" Selected=True>Burak Durmaz</asp:ListItem>                                    
                </asp:CheckBoxList>
              </td>
            </tr>
            <tr>
              <td style="height:24px;">Başlık</td>              
              <td>
                <asp:TextBox ID="edtMailBaslik" runat="server" Width="300px" MaxLength="100" CssClass="inputbox"></asp:TextBox>               
              </td>             
            </tr>            
            <tr>
              <td style="height:24px; vertical-align:top">Mail</td>              
              <td>             
                <asp:TextBox ID="edtMail" runat="server" Width="500px" MaxLength="2000" 
                  CssClass="inputbox" Rows="16" TextMode="MultiLine"></asp:TextBox>               
              </td>              
            </tr>                 
            <tr>
              <td style="height:24px;"></td>              
              <td>                                
                <asp:Button ID="btnMailGonder" runat="server" Text="Gönder" CssClass="button" 
                  onclick="btnMailGonder_Click" />        
              </td>              
            </tr>    
          </table>                     
        </td>
      </tr>                     
    </table>
    </div> 
    </div>  
    <br />
    <div align="center"> 
    <div class="main"> 
    <table class="tbBaslik" border="0"> 
	    <tr> 
        <th>
          <table border="0" cellspacing="0" cellpadding="0" width="100%">
            <tr>
              <td>Son Eklenen Kayıtlar</td>
              <td style="text-align:right; font-size: 12px; width:500px">
                <table border="0" cellspacing="2" cellpadding="2" style="width:100%">
                  <tr>
                    <td style="text-align:right">Gösterilecek Kayıt Adedi:</td>
                    <td style="width:30px">
                      <asp:DropDownList ID="ddlKayitAdedi" runat="server" AutoPostBack=true>
                        <asp:ListItem Value="20" Text="20"></asp:ListItem>
                        <asp:ListItem Value="30" Text="30"></asp:ListItem>
                        <asp:ListItem Value="50" Text="50"></asp:ListItem>
                        <asp:ListItem Value="100" Text="100"></asp:ListItem>
                      </asp:DropDownList>
                    </td>
                  </tr>  
                 </table>              
              </td>
            </tr>
          </table>                            
        </th> 
	    </tr> 
    </table> 			
    <asp:HiddenField runat="server" ID="hidTckId" Value="0" />              
    <table class="tbKayitCerceve" style="text-align:left !important"> 
	    <tr> 
		    <td>     
          <table class="tbKayit" >
            <tr>
              <th style="width:20%">Eczane Adı</th>
              <th style="width:20%">Eczacı Adı, Soyadı</th>
              <th style="width:15%">İlçe / İl</th>
              <th style="width:13%">Telefon Numarası</th>
              <th style="width:20%">E-Posta Adresi</th>
              <th style="width:12%">Kayıt Zamanı</th>
            </tr>  
<%
  int i = 0;
  int ilkId = 0;
  foreach (System.Data.DataRow Row in dsEczaneKayitlari.Tables[0].Rows) { 
    if (ilkId == 0) ilkId = Convert.ToInt32(Row["tck_id"]);
%>  
            <tr class="row<%=i % 2 %> <% if (Row["was_sended_email"].ToString() == "1") { %>sended_email<% } %>" onclick="highlight(this, <%=Row["tck_id"].ToString()%>, 1);" id="trListe<%=Row["tck_id"].ToString()%>" onMouseOver="toolTip('<b>Not:</b><br><%=Row["tck_notes"].ToString().Replace(Environment.NewLine, "<br>")%>', 270, 100)" onMouseOut="toolTip()">
              <td><%=Row["tck_customer_name"].ToString()%></td>
              <td><%=Row["tck_pharmacist_name"].ToString()%></td>
              <td><%=Row["tck_province_and_city"].ToString()%></td>
              <td><%=Row["tck_phones"].ToString()%></td>
              <td><%=Row["tck_customer_email_address"].ToString()%></td>
              <td>
                <%=Row["tck_entry_datetime"].ToString()%>
                <span id="not<%=Row["tck_id"].ToString()%>"><%=Row["tck_notes"].ToString().Replace(Environment.NewLine, "<br>")%></span>                
              </td>
            </tr>       
<%
    i++;
  }
%>            
          </table>
<script> 
	highlight(document.getElementById("trListe<%=ilkId %>"), <%=ilkId %>, 1);	
</script>           
        </td>
      </tr>
    </table>
    <br />
    </div> 
    <br />
    © 2010 Sanovel İlaç Sanayi ve Ticaret A.Ş. | Tüm Hakları Saklıdır. | Sanovel Bilgi Sistemleri Tarafından Geliştirilmiştir | <b>v.1.3.0</b>
    </div>       
  </div>
  
    <asp:SqlDataSource ID="sdsUrunListesi" runat="server" 
      ConnectionString="<%$ ConnectionStrings:ITS_CRMConnectionString %>" 
      
    SelectCommand="SELECT '0' AS mmr_gtin, '' AS mmr_item_name
UNION
SELECT mmr_gtin, ITS.dbo.TRK(mmr_item_name) AS mmr_item_name FROM ITS.dbo.Material_Master
ORDER BY mmr_item_name"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsEPostaListesi" runat="server" 
      ConnectionString="<%$ ConnectionStrings:SDSConnectionString %>" 
      SelectCommand="ITS_SBYEMails" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
  </form>
  <script type="text/javascript">        
    document.forms[0].chkEczaneBilgileriniEkle.checked = false;
    document.forms[0].chkEczaneBilgileriniEkle.click();
    document.forms[0].chkNotEkle.checked = false;
    document.forms[0].chkNotEkle.click();    
  </script>      
  <div id="divUyari" runat="server"></div>
</body>
</html>
