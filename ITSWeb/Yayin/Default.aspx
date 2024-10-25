<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITSWeb._Default" %>

<%@ Register assembly="DevExpress.Web.ASPxTreeList.v19.2, Version=19.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.v19.2, Version=19.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>İTS Bildirim Raporlama Platformu</title>

  <link href="style.css" rel="stylesheet" type="text/css" />
  <script src="AnimatedCollapsiblePanel.js" type="text/javascript"></script>
  <style type="text/css">

.dxpControl
{
	font: 9pt Tahoma;
	color: black;
}
.dxpSummary
{
	font: 9pt Tahoma;
	color: black;
	white-space: nowrap;
	text-align: center;
	vertical-align: middle;
	padding: 1px 4px 0px 4px;
}
.dxpDisabled
{
	color: #acacac;
	border-color: #808080;
	cursor: default;
}

.dxpDisabledButton
{
	font: 9pt Tahoma;
	color: black;
	text-decoration: none;
}
.dxpButton
{
	font: 9pt Tahoma;
	color: #394EA2;
	text-decoration: underline;
	white-space: nowrap;
	text-align: center;
	vertical-align: middle;
}
.dxpCurrentPageNumber
{
	font: 9pt Tahoma;
	color: black;
	font-weight: bold;
	text-decoration: none;
	padding: 1px 3px 0px 3px;
}
.dxpPageNumber
{
	font: 9pt Tahoma;
	color: #394EA2;
	text-decoration: underline;
	text-align: center;
	vertical-align: middle;
	padding: 1px 5px 0px 5px;
}
  </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
      <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>
    
      <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
          <td>
            <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
              <tr>
                <td style="width:46px">
                  <img src="Resimler/image12.gif" alt="icon"/>
                </td>
                <td class="baslik">
                  İTS Bildirim Raporlama Platformu
                </td>    
                <td style="text-align:right">
                  <img src="Resimler/logo.jpg" alt="sanovel_logo"/>
                </td>                               
              </tr>
           </table>          
          </td>
        </tr>
        <tr>
          <td style="height:10px">
          </td>
        </tr>
        <tr>
          <td>
            <table style="width: 100%">
              <tr>
                <td>
                  <table style="width: 100%">
                    <tr>
                      <td style="vertical-align:top">
                        <table style="width: 100%">
                          <tr>
                            <td>
                              <div style="width:100%;">
                                <div class="squarebox">
                                  <div class="squareboxgradientcaption" style="height:20px; cursor: pointer;" onclick="togglePannelStatus(divBekleyenUretimEmirleri)">
                                    <div style="float: left; vertical-align: middle; font-weight:bold">Bildirilmeyi 
                                      Bekleyen Üretim Emirleri</div>
                                    <div style="float: right; vertical-align: middle">
                                      <img src="resimler/collapse.gif" width="13" height="14" border="0" alt="Show/Hide" title="Show/Hide" />
                                    </div>
                                  </div>
                                  <div class="squareboxcontent" id="divBekleyenUretimEmirleri">
                                    <dxwtl:ASPxTreeList ID="ASPxTreeList1" runat="server" 
                                      AutoGenerateColumns="False" DataSourceID="sdsBildirilmeyiBekleyenUretimEmirleri" 
                                      KeyFieldName="ord_order_id" Width="100%" DataCacheMode="Enabled">
                                      <Styles>
                                        <Header>
                                          <BackgroundImage ImageUrl="~/Resimler/panel_basligi.png" Repeat="RepeatX" />
                                        </Header>
                                        <FocusedNode BackColor="#A7C9F8" ForeColor="Black">
                                        </FocusedNode>
                                        <LoadingPanel BackColor="#F3DFC1">
                                        </LoadingPanel>
                                      </Styles>
                                      <SettingsText LoadingPanelText="Yükleniyor&amp;hellip;" />
                                      <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
                                      <SettingsPager PageSize="30">
                                      </SettingsPager>
                                      <Settings ShowRoot="False" ShowTreeLines="False" />
                                      <SettingsBehavior AllowFocusedNode="True" />
                                      <Columns>
                                        <dxwtl:TreeListTextColumn Caption="Üretim Emri Numarası" 
                                          FieldName="ord_order_id" VisibleIndex="0">
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="Malzeme Kodu" FieldName="mmr_item_no" 
                                          VisibleIndex="1">
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="Malzeme Adı" FieldName="mmr_item_name" 
                                          ReadOnly="True" VisibleIndex="2">
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="Seri Numarası" FieldName="ord_batch_no" 
                                          VisibleIndex="3">
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="Bildirilecek Miktar" 
                                          FieldName="unsent_quantity" ReadOnly="True" VisibleIndex="4">
                                        </dxwtl:TreeListTextColumn>
                                      </Columns>
                                      <Paddings Padding="2px" />
                                    </dxwtl:ASPxTreeList>
                                  </div>
                                </div>                      
                              </div>                                                                    
                            </td>
                          </tr>
                          <tr>
                            <td style="height:10px"></td>
                          </tr>                          
                          <tr>
                            <td style="vertical-align:top;height:20px">
                              <div style="width:100%;">
                                <div class="squarebox">
                                  <div class="squareboxgradientcaption" style="height:20px; cursor: pointer;" onclick="togglePannelStatus(divBildirilenUretimEmirleri)">
                                    <div style="float: left; vertical-align: middle; font-weight:bold">Üretim Bildirimi Yapılmış Üretim Emirleri</div>
                                    <div style="float: right; vertical-align: middle">
                                      <img src="resimler/expand.gif" width="13" height="14" border="0" alt="Show/Hide" title="Show/Hide" />
                                    </div>
                                  </div>
                                  <div class="squareboxcontent" style="display:none" id="divBildirilenUretimEmirleri">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                      <ContentTemplate>
                                        <table  border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                          <tr> 
                                            <td>                                
                                              <table border="0" cellpadding="2" cellspacing="0"  style="width: 100%">
                                                <tr>
                                                  <td style="width: 133px" align="right">
                                                    Üretim Emri Numarası:</td>
                                                  <td>
                                                    <dxe:ASPxTextBox ID="edtUretimEmriNumarasi" runat="server" Width="100px" 
                                                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                                                      <ValidationSettings>
                                                        <ErrorImage Height="14px" Url="~/App_Themes/Aqua/Editors/edtError.png" />
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                          <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                      </ValidationSettings>
                                                    </dxe:ASPxTextBox>
                                                  </td>
                                                </tr>
                                                <tr>
                                                  <td align="right" style="width: 133px">
                                                    Malzeme Adı:</td>
                                                  <td>
                                                    <dxe:ASPxTextBox ID="edtMalzemeAdi" runat="server" Width="400px" 
                                                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                                                      <ValidationSettings>
                                                        <ErrorImage Height="14px" Url="~/App_Themes/Aqua/Editors/edtError.png" />
                                                        <ErrorFrameStyle ImageSpacing="4px">
                                                          <ErrorTextPaddings PaddingLeft="4px" />
                                                        </ErrorFrameStyle>
                                                      </ValidationSettings>
                                                    </dxe:ASPxTextBox>
                                                  </td>
                                                </tr>
                                                <tr>
                                                  <td align="right" style="width: 133px">
                                                    Tarih Aralığı:</td>
                                                  <td>
                                                    <table border="0" cellpadding="0" cellspacing="0" >
                                                      <tr>
                                                        <td>
                                                          <dxe:ASPxDateEdit ID="dteBaslangicTarihi" runat="server" 
                                                            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                                                            ImageFolder="~/App_Themes/Aqua/{0}/" ShowShadow="False">
                                                            <ValidationSettings>
                                                              <ErrorImage Height="14px" Url="~/App_Themes/Aqua/Editors/edtError.png" />
                                                              <ErrorFrameStyle ImageSpacing="4px">
                                                                <ErrorTextPaddings PaddingLeft="4px" />
                                                              </ErrorFrameStyle>
                                                            </ValidationSettings>
                                                            <DropDownButton>
                                                              <Image Height="7px" Url="~/App_Themes/Aqua/Editors/edtDropDown.png" 
                                                                UrlDisabled="~/App_Themes/Aqua/Editors/edtDropDownDisabled.png" 
                                                                UrlHottracked="~/App_Themes/Aqua/Editors/edtDropDownHottracked.png" 
                                                                UrlPressed="~/App_Themes/Aqua/Editors/edtDropDownHottracked.png" />
                                                            </DropDownButton>
                                                            <CalendarProperties ClearButtonText="Temizle" FirstDayOfWeek="Monday" 
                                                              TodayButtonText="Bugün">
                                                              <HeaderStyle Spacing="1px" />
                                                              <FooterStyle Spacing="17px" />
                                                            </CalendarProperties>
                                                          </dxe:ASPxDateEdit>
                                                        </td>
                                                        <td style="width:10px"></td>
                                                        <td>
                                                          <dxe:ASPxDateEdit ID="dteBitisTarihi" runat="server" 
                                                            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                                                            ImageFolder="~/App_Themes/Aqua/{0}/" ShowShadow="False">
                                                            <ValidationSettings>
                                                              <ErrorImage Height="14px" Url="~/App_Themes/Aqua/Editors/edtError.png" />
                                                              <ErrorFrameStyle ImageSpacing="4px">
                                                                <ErrorTextPaddings PaddingLeft="4px" />
                                                              </ErrorFrameStyle>
                                                            </ValidationSettings>
                                                            <DropDownButton>
                                                              <Image Height="7px" Url="~/App_Themes/Aqua/Editors/edtDropDown.png" 
                                                                UrlDisabled="~/App_Themes/Aqua/Editors/edtDropDownDisabled.png" 
                                                                UrlHottracked="~/App_Themes/Aqua/Editors/edtDropDownHottracked.png" 
                                                                UrlPressed="~/App_Themes/Aqua/Editors/edtDropDownHottracked.png" />
                                                            </DropDownButton>
                                                            <CalendarProperties ClearButtonText="Temizle" FirstDayOfWeek="Monday" 
                                                              TodayButtonText="Bugün">
                                                              <HeaderStyle Spacing="1px" />
                                                              <FooterStyle Spacing="17px" />
                                                            </CalendarProperties>
                                                          </dxe:ASPxDateEdit>
                                                        </td>
                                                      </tr>
                                                    </table>
                                                  </td>
                                                </tr>
                                                <tr>
                                                  <td align="right" style="width: 133px">
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                      <ProgressTemplate>
                                                        Rapor çalıştırılıyor...
                                                      </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                  </td>
                                                  <td>
                                                    <dxe:ASPxButton ID="ASPxButton1" runat="server" 
                                                      onclick="ASPxButton1_Click" Text="Raporu Çalıştır" 
                                                      CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                                                    </dxe:ASPxButton>
                                                  </td>
                                                </tr>

                                              </table>
                                            </td>
                                          </tr>                            
                                          <tr> 
                                            <td>                                
                                              <dxwtl:ASPxTreeList ID="trlUretimBildirimiYapilmisUretimEmirleri" runat="server" 
                                            AutoGenerateColumns="False" DataSourceID="sdsUretimiBildirilmisUretimEmirleri" 
                                            KeyFieldName="ord_order_id" Width="100%" DataCacheMode="Enabled">
                                                <Styles>
                                                  <Header>
                                                    <BackgroundImage ImageUrl="~/Resimler/panel_basligi.png" Repeat="RepeatX" />
                                                  </Header>
                                                  <FocusedNode BackColor="#A7C9F8" ForeColor="Black">
                                                  </FocusedNode>
                                                  <LoadingPanel BackColor="#F3DFC1">
                                                  </LoadingPanel>
                                                </Styles>
                                                <SettingsText LoadingPanelText="Yükleniyor&amp;hellip;" />
                                                <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
                                                <SettingsPager PageSize="20" Mode="ShowPager">
                                                </SettingsPager>
                                                <Settings ShowRoot="False" ShowTreeLines="False" />
                                                <SettingsBehavior AllowFocusedNode="True" />
                                                <Columns>
                                                  <dxwtl:TreeListTextColumn Caption="Üretim Emri Numarası" 
                                                FieldName="ord_order_id" VisibleIndex="0">
                                                  </dxwtl:TreeListTextColumn>
                                                  <dxwtl:TreeListTextColumn Caption="Malzeme Kodu" FieldName="mmr_item_no" 
                                                VisibleIndex="1">
                                                  </dxwtl:TreeListTextColumn>
                                                  <dxwtl:TreeListTextColumn Caption="Malzeme Adı" FieldName="mmr_item_name" 
                                                ReadOnly="True" VisibleIndex="2">
                                                  </dxwtl:TreeListTextColumn>
                                                  <dxwtl:TreeListTextColumn Caption="Seri Numarası" FieldName="ord_batch_no" 
                                                VisibleIndex="3">
                                                  </dxwtl:TreeListTextColumn>
                                                  <dxwtl:TreeListTextColumn Caption="S.K. Tarihi" 
                                                FieldName="ord_expiry_date" VisibleIndex="4">
                                                  </dxwtl:TreeListTextColumn>
                                                  <dxwtl:TreeListTextColumn Caption="Bildirilen Adet" 
                                                    FieldName="count_of_package" ReadOnly="True" VisibleIndex="5">
                                                  </dxwtl:TreeListTextColumn>
                                                  <dxwtl:TreeListDateTimeColumn Caption="Bildirim Zamanı" FieldName="datetime" 
                                                ReadOnly="True" VisibleIndex="5">
                                                  </dxwtl:TreeListDateTimeColumn>
                                                </Columns>
                                                <Paddings Padding="2px" />
                                              </dxwtl:ASPxTreeList>
                                            </td>
                                          </tr>
                                        </table>                                  
                                      </ContentTemplate>
                                    </asp:UpdatePanel>
                                  </div>
                                </div>                      
                              </div>                           
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td align="right" valign="top" style="width:327px">
                        <asp:Chart ID="Chart1" runat="server" Width="327px" BackColor="243, 223, 193" 
                          BackGradientStyle="TopBottom" DataSourceID="sdsGunlukUretimBildirimAdetleri" 
                          Height="236px">
                          <BorderSkin SkinStyle="Emboss" />
                          <Titles>
                            <asp:Title Font="Microsoft Sans Serif, 12pt" Name="Title1" 
                              Text="Bir Haftalık Üretim Bildirim Adetleri">
                            </asp:Title>
                          </Titles>
                          <Series>
                            <asp:Series ChartType="Line" Name="GunlukBildirimAdetleri" 
                              BorderColor="180, 26, 59, 105" BorderWidth="3" Color="220, 65, 140, 240" 
                              MarkerSize="8" MarkerStyle="Circle" ShadowColor="Black" ShadowOffset="2" 
                              XValueType="Double" YValueType="Double" Legend="Legend1" XValueMember="GUN" 
                              YValueMembers="ADET">
                            </asp:Series>
                          </Series>
                          <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                          </ChartAreas>
                        </asp:Chart>
                        <br />
                        <asp:Chart ID="Chart2" runat="server" Width="327px" BackColor="243, 223, 193" 
                          BackGradientStyle="TopBottom" DataSourceID="sdsGunlukUretimBildirimMiktarlari" 
                          Height="236px">
                          <BorderSkin SkinStyle="Emboss" />
                          <Titles>
                            <asp:Title Font="Microsoft Sans Serif, 12pt" Name="Title1" 
                              Text="Bir Haftalık Üretim Bildirim Miktarları">
                            </asp:Title>
                          </Titles>
                          <Series>
                            <asp:Series ChartType="Line" Name="GunlukBildirimAdetleri" 
                              BorderColor="180, 26, 59, 105" BorderWidth="3" Color="220, 224, 64, 10" 
                              MarkerSize="8" MarkerStyle="Circle" ShadowColor="Black" ShadowOffset="2" 
                              XValueType="Double" YValueType="Double" Legend="Legend1" XValueMember="GUN" 
                              YValueMembers="ADET">
                            </asp:Series>
                          </Series>
                          <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                          </ChartAreas>
                        </asp:Chart>
                        <br />
                        <asp:Chart ID="Chart3" runat="server" Width="327px" BackColor="243, 223, 193" 
                          BackGradientStyle="TopBottom" DataSourceID="sdsMalzemelerinToplamBildirimleri" 
                          Height="417px" 
                          PaletteCustomColors="DarkSalmon; Orange; Khaki; PaleGreen; MediumTurquoise; PowderBlue; MediumPurple; HotPink; LightSteelBlue; LightCoral; DeepSkyBlue">
                          <Legends>
                            <asp:Legend BackColor="Transparent" BorderColor="Transparent" Docking="Bottom" 
                              Font="Trebuchet MS, 8pt" Name="Legend1">
                            </asp:Legend>
                          </Legends>
                          <BorderSkin SkinStyle="Emboss" />
                          <Titles>
                            <asp:Title Font="Microsoft Sans Serif, 12pt" Name="Title1" 
                              Text="Malzeme Grubu Bazında Bildirim Yüzdeleri">
                            </asp:Title>
                          </Titles>
                          <Series>
                            <asp:Series ChartType="Pie" Name="MalzemelerinToplamAdetleri" 
                              BorderColor="Gray" Legend="Legend1" XValueMember="mmr_drug_group" 
                              YValueMembers="count_of_order_id" 
                              CustomProperties="PieDrawingStyle=Concave, CollectedLegendText=, CollectedLabel=" 
                              Label="#PERCENT{P1}" LegendText="#VALX (#PERCENT{P1})">
                            </asp:Series>
                          </Series>
                          <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BackColor="Transparent" 
                              ShadowColor="Transparent">
                              <AxisY LineColor="64, 64, 64, 64">
                              </AxisY>
                              <AxisX LineColor="64, 64, 64, 64">
                              </AxisX>
                              <Area3DStyle Enable3D="True" Inclination="40" LightStyle="Realistic" />
                            </asp:ChartArea>
                          </ChartAreas>
                        </asp:Chart>                        
                      </td>
                    </tr>


                  </table>
                </td>
              </tr>

            </table>
          </td>
        </tr>
        <tr>
          <td style="height:10px"></td>
        </tr>
        <tr>
          <td style="padding-left:10px">
            Copyright © 2010 Toksöz Bilgi Sistemleri<br />
            Tüm Hakları Saklıdır.           
          </td>
        </tr>        
      </table>
    
    </div>
    <asp:SqlDataSource ID="sdsGunlukUretimBildirimAdetleri" runat="server" 
      ConnectionString="<%$ ConnectionStrings:ITSConnectionString %>" 
      SelectCommand="Daily_Declaration_Report" SelectCommandType="StoredProcedure">
      <SelectParameters>
        <asp:Parameter DefaultValue="U" Name="type" Type="String" />
      </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsGunlukUretimBildirimMiktarlari" runat="server" 
      ConnectionString="<%$ ConnectionStrings:ITSConnectionString %>" 
      SelectCommand="Daily_Declaration_Report" SelectCommandType="StoredProcedure">
      <SelectParameters>
        <asp:Parameter DefaultValue="A" Name="type" Type="String" />
      </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsUretimiBildirilmisUretimEmirleri" runat="server" 
      ConnectionString="<%$ ConnectionStrings:ITSConnectionString %>" 
      SelectCommand="Declared_Detail_Report" SelectCommandType="StoredProcedure" 
      CacheDuration="120" 
      onselecting="sdsUretimiBildirilmisUretimEmirleri_Selecting" 
      EnableCaching="True">
      <SelectParameters>
        <asp:Parameter Name="ord_order_id" Type="String" />
        <asp:Parameter Name="mmr_item_name" Type="String" />
        <asp:Parameter DbType="Date" Name="begin_date" />
        <asp:Parameter DbType="Date" Name="end_date" />
      </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsBildirilmeyiBekleyenUretimEmirleri" runat="server" 
      ConnectionString="<%$ ConnectionStrings:ITSConnectionString %>" 
      SelectCommand="Undeclared_Detail_Report" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsMalzemelerinToplamBildirimleri" runat="server" 
      ConnectionString="<%$ ConnectionStrings:ITSConnectionString %>" 
      SelectCommand="All_Production_Declaration_Report" 
      SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </form>
</body>
</html>
