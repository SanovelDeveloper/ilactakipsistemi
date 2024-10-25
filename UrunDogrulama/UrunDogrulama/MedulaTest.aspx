<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MedulaTest.aspx.cs" Inherits="UrunDogrulama.MedulaTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script type="text/javascript">
var deg1=0; var deg2=0; var deg3=0; var deg4=0;
function karekodOku(thisObj, thisEvent) {
	if (thisEvent.keyCode==13) {thisEvent.keyCode=9; return thisEvent.keyCode }
	if (thisEvent.keyCode==29 || thisEvent.keyCode==119) { document.getElementById('f:text123').value += '-'; deg1 = 0; deg2 = 0; deg3 = 0; deg4 = 0;		
	} else if(thisEvent.keyCode == 17) { deg1 = 17; deg2 = 0; deg3 = 0; deg4 = 0;
	} else if(thisEvent.keyCode == 18) { deg1 = 18; deg2 = 0; deg3 = 0; deg4 = 0;
	} else if(thisEvent.keyCode == 96 && deg1 == 18) { deg2 = 96; deg3 = 0; deg4 = 0;
	} else if(thisEvent.keyCode == 98 && deg1 == 18 && deg2 == 96) { deg3 = 98;
	} else if(thisEvent.keyCode == 105 && deg1 == 18 && deg2 == 96 && deg3 == 98) { deg4 = 105;
	} else if(thisEvent.keyCode == 221) { if(deg1 == 17) { document.getElementById('f:text123').value += '-';} deg1 = 0; deg2 = 0; deg3 = 0; deg4 = 0; }
	if(deg1 == 18 && deg2 == 96 && deg3 == 98 && deg4 == 105) { document.getElementById('f:text123').value += '-'; deg1 = 0; deg2 = 0; deg3 = 0; deg4 = 0; }
	
	document.getElementById("barkod").value += thisEvent.keyCode + ':';	
}

</script>    
</head>
<body onkeydown="return karekodOku(this, event);">
    <form id="f" method="post">
    <div>
      <input type="hidden" id="barkod" name="barkod" value="" />
      <input type="text" id="f:text123" name="f:text123" style="width:500px" />
      <br />
      <% if (Request.Form.Count > 0) Response.Write(Request.Form["f:text123"].ToString()); %>      
      <br />
      <% if (Request.Form.Count > 0) Response.Write(Request.Form["barkod"].ToString()); %>
    </div>
    </form>
</body>
</html>
