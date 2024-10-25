<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UrunSorgulamaSonuclari.aspx.cs" Inherits="ITS_CRM.UrunSorgulamaSonuclari" %>
<table border="0" cellpadding="2" cellspacing="2" width="100%" style="border: 1px solid #d5d5d5" class="tbKayit">
  <tr>
    <th style="height:24px; width:8%">Ü. Emri No</th>              
    <th style="height:24px; width:24%">İlaç Adı</th>              
    <th style="height:24px; width:10%">GTIN Numarası</th>              
    <th style="height:24px; width:10%">Seri Numarası</th>              
    <th style="height:24px; width:10%">S. K. Tarihi</th>              
    <th style="height:24px; width:12%">Ambalaj Kodu</th>    
    <th style="height:24px; width:13%">Bildirim Durumu</th>                           
    <th style="height:24px; width:13%">Geçerlilik Durumu</th>                           
  </tr>  
<%
  if (Request.QueryString["pc"] == null || Request.QueryString["pc"].ToString() == "") return;
  
  int i = 0;  
  foreach (System.Data.DataRow Row in dsUrunSorgulamaSonuclari.Tables[0].Rows)
  { 
%>  
  <tr class="row<%=i % 2 %>" onclick="highlight(this, 0, 2); dogrulanacakUrunSec('<%=Row["mmr_item_name"].ToString()%>', '<%=Row["mmr_gtin"].ToString()%>', '<%=Row["ord_batch_no"].ToString()%>', '<%=Row["expiry_date"].ToString()%>', '<%=Row["pck_code"].ToString()%>')">
    <td><%=Row["ord_order_id"].ToString()%></td>
    <td><%=Row["mmr_item_name"].ToString()%></td>
    <td><%=Row["mmr_gtin"].ToString()%></td>
    <td><%=Row["ord_batch_no"].ToString()%></td>
    <td><%=Row["ord_expiry_date"].ToString()%></td>
    <td><%=Row["pck_code"].ToString()%></td>
    <td><%=Row["status"].ToString()%></td>
    <td><%=Row["pst_description"].ToString()%></td>    
  </tr>       
<%
    i++;
  }
%>                     
</table> 