﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UrunDogrulama._Default" EnableViewState="true" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDataView" tagprefix="dxdv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>İTS Ürün Doğrulama</title>
  <link href="styles.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript">
    function keyPressHandler(e) {  
      if (e == null) {  
          return;
      }  
      
      var keynum;
      var keychar;
      
      if(window.event) // IE
        keynum = e.keyCode;
      else if(e.which) // Netscape/Firefox/Opera
        keynum = e.which;
  
      keychar = String.fromCharCode(keynum);      
                  
      if (keynum != 13 && keynum != 10)
        document.getElementById("hidAmbalajBarkoduHazirlik").value += keychar; 
      else 
      {         
        document.getElementById("hidAmbalajBarkodu").value = document.getElementById("hidAmbalajBarkoduHazirlik").value;
        document.getElementById("hidAmbalajBarkoduHazirlik").value = "";
        //alert(document.getElementById("hidAmbalajBarkodu").value);
      }
    } 

  </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="width: 100%">
      <tr>
        <td style="width: 250px"><img src="logo.jpg" /></td>
        <td style="font-weight:bold; font-family: Arial, Helvetica, sans-serif; font-size:x-large; vertical-align:middle">Karekod Sorgulama Sayfası</td>
      </tr>
      <tr style="height: 30px">
        <td colspan="2"></td>
      </tr>
    </table>
    <input type="hidden" id="hidAmbalajBarkoduHazirlik" runat="server" value="" />
    <input type="hidden" id="hidAmbalajBarkodu" runat="server" value="" />
    <div>
    
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          <table border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td colspan="2" class="baslik" style="height:30px; vertical-align:top">
                Lütfen sorgulanacak ambalajın 2D barkodunu okutun ya da bilgileri kutulara elle 
                girin...</td>
            </tr>
            <tr style="height:25px">
              <td style="width:200px;">Ambalaj Barkodu (KeyPress)</td>
              <td>
                <dxe:ASPxTextBox ID="edtAmbalajBarkodu" runat="server" Width="600px" 
                  CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                  onvaluechanged="edtAmbalajBarkodu_ValueChanged">
                  <ValidationSettings>
                    <ErrorImage Height="14px" Url="~/App_Themes/Glass/Editors/edtError.png" />
                    <ErrorFrameStyle ImageSpacing="4px">
                      <ErrorTextPaddings PaddingLeft="4px" />
                    </ErrorFrameStyle>
                  </ValidationSettings>
                  <ClientSideEvents KeyPress="function(s, e) { keyPressHandler(e.htmlEvent); }" />
                </dxe:ASPxTextBox>
              </td>
            </tr>
            <tr style="height:25px">
              <td style="width:200px;">Ambalaj Barkodu (KeyDown)</td>
              <td>
                <dxe:ASPxTextBox ID="edtAmbalajBarkoduKD" runat="server" Width="600px" 
                  CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                  onvaluechanged="edtAmbalajBarkoduKD_ValueChanged" >
                  <ValidationSettings>
                    <ErrorImage Height="14px" Url="~/App_Themes/Glass/Editors/edtError.png" />
                    <ErrorFrameStyle ImageSpacing="4px">
                      <ErrorTextPaddings PaddingLeft="4px" />
                    </ErrorFrameStyle>
                  </ValidationSettings>
                  <ClientSideEvents KeyDown="function(s, e) { keyPressHandler(e.htmlEvent); }" />
                </dxe:ASPxTextBox>
              </td>
            </tr>            
            <tr style="height:25px">
              <td>GTIN Numarası (01)</td>
              <td>
                <dxe:ASPxTextBox ID="edtGTINNumarasi" runat="server" 
                  CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                  Width="200px">
                  <ValidationSettings>
                    <ErrorImage Height="14px" Url="~/App_Themes/Glass/Editors/edtError.png" />
                    <ErrorFrameStyle ImageSpacing="4px">
                      <ErrorTextPaddings PaddingLeft="4px" />
                    </ErrorFrameStyle>
                  </ValidationSettings>
                </dxe:ASPxTextBox>
              </td>
            </tr>
            <tr style="height:25px">
              <td>Seri Numarası (10)</td>
              <td>
                <dxe:ASPxTextBox ID="edtSeriNumarasi" runat="server" 
                  CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                  Width="200px">
                  <ValidationSettings>
                    <ErrorImage Height="14px" Url="~/App_Themes/Glass/Editors/edtError.png" />
                    <ErrorFrameStyle ImageSpacing="4px">
                      <ErrorTextPaddings PaddingLeft="4px" />
                    </ErrorFrameStyle>
                  </ValidationSettings>
                </dxe:ASPxTextBox>
              </td>
            </tr>
            <tr style="height:25px">
              <td>Son Kullanma Tarihi (17)</td>
              <td>
                <dxe:ASPxTextBox ID="edtSonKullanmaTarihi" runat="server" 
                  CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                  Width="200px">
                  <ValidationSettings>
                    <ErrorImage Height="14px" Url="~/App_Themes/Glass/Editors/edtError.png" />
                    <ErrorFrameStyle ImageSpacing="4px">
                      <ErrorTextPaddings PaddingLeft="4px" />
                    </ErrorFrameStyle>
                  </ValidationSettings>
                </dxe:ASPxTextBox>
              </td>
            </tr>
            <tr style="height:25px">
              <td>Ambalaj Kodu (21)</td>
              <td>
                <dxe:ASPxTextBox ID="edtAmbalajKodu" runat="server" 
                  CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                  Width="200px">
                  <ValidationSettings>
                    <ErrorImage Height="14px" Url="~/App_Themes/Glass/Editors/edtError.png" />
                    <ErrorFrameStyle ImageSpacing="4px">
                      <ErrorTextPaddings PaddingLeft="4px" />
                    </ErrorFrameStyle>
                  </ValidationSettings>
                </dxe:ASPxTextBox>
              </td>
            </tr>
            <tr>
              <td></td>
              <td>
                <table style="width:100%">
                  <tr>
                    <td style="width:95px">
                      <dxe:ASPxButton ID="btnEkle" runat="server" 
                        CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" Text="Ekle" 
                        Width="95px" onclick="btnEkle_Click">
                      </dxe:ASPxButton>
                    </td>
                    <td style="width:95px">
                      <dxe:ASPxButton ID="btnTemizle" runat="server" 
                        CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                        Text="Temizle" Width="95px" onclick="btnTemizle_Click">
                      </dxe:ASPxButton>
                    </td>
                    <td align="right">
                      <table>
                        <tr>
                          <td style="width:120px">
                            <dxe:ASPxButton ID="btnSatirSil" runat="server" 
                              CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" Text="Seçili Satırı Sil" 
                              Width="120px" Enabled="False" onclick="btnSatirSil_Click">
                            </dxe:ASPxButton>
                          </td>
                          <td style="width:120px">
                            <dxe:ASPxButton ID="btnListeyiTemizle" runat="server" 
                              CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                              Text="Listeyi Temizle" Width="120px" Enabled="False" 
                              onclick="btnListeyiTemizle_Click">
                            </dxe:ASPxButton>
                          </td>
                          <td align="right">
                            <table>
                            </table>
                          </td>                    
                        </tr>
                      </table>
                    </td>                    
                  </tr>
                </table>
              </td>
            </tr>
            <tr>
              <td></td>
              <td></td>
            </tr>                                                            
            <tr>
              <td>
                &nbsp;</td>
              <td>
                <dxe:ASPxListBox ID="lsbAmbalajlar" runat="server" 
                  CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                  ImageFolder="~/App_Themes/Glass/{0}/" Width="600px" Height="186px">
                  <ValidationSettings>
                    <ErrorImage Height="14px" Url="~/App_Themes/Glass/Editors/edtError.png" />
                    <ErrorFrameStyle ImageSpacing="4px">
                      <ErrorTextPaddings PaddingLeft="4px" />
                    </ErrorFrameStyle>
                  </ValidationSettings>
                </dxe:ASPxListBox>
              </td>
            </tr>
            <tr>
              <td>
                &nbsp;</td>
              <td>
                <table style="width: 100%;">
                  <tr>
                    <td style="width:200px">
                      <dxe:ASPxButton ID="btnDogrula" runat="server" 
                        CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" 
                        Text="Listedeki Ürünleri Doğrula" Width="200px" onclick="btnDogrula_Click" 
                        Enabled="False">
                      </dxe:ASPxButton>
                    </td>
                    <td>
                      <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                          Doğrulama yapılıyor...
                        </ProgressTemplate>
                      </asp:UpdateProgress>
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr>
              <td></td>
              <td>
                <asp:Literal ID="litSonuclar" runat="server"></asp:Literal>
              </td>
            </tr>            
          </table>
        </ContentTemplate>
      </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
