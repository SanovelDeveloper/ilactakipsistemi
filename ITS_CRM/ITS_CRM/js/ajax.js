function GetXmlHttpObject() {
  var xh = null;
  try {
    // Firefox, Opera 8.0+, Safari
    xh = new XMLHttpRequest();
  }
  catch (e) {
    //Internet Explorer
    try {
      xh = new ActiveXObject("Msxml2.XMLHTTP");
    }
    catch (e) {
      xh = new ActiveXObject("Microsoft.XMLHTTP");
    }
  }
  return xh;
}

function urunSorgulamaSonuclari(ugtin, gtin, batch, pc, tck_id) {
  xmlHttp = GetXmlHttpObject();
  if (xmlHttp == null) {
    alert("Browser does not support HTTP Request");
    return;
  }
  
  xmlHttp.open("POST", "UrunSorgulamaSonuclari.aspx?pc=" + encodeURI(pc) + "&batch=" + encodeURI(batch) + "&ugtin=" + encodeURI(ugtin) + "&gtin=" + encodeURI(gtin) + "&tck_id=" + encodeURI(tck_id) , true);
  xmlHttp.onreadystatechange = urunSorgulamaSonuclariTamamlandi;
  xmlHttp.send(null);   
}

function urunSorgulamaSonuclariTamamlandi() {
  if (xmlHttp.readyState == 4 || xmlHttp.readyState == "complete") {   
    var response = xmlHttp.responseText;
    document.getElementById("divUrunSorgulamaSonuclari").innerHTML = response;         
  }
}

function urunDogrulamaSonuclari(gtin, batch, expiry, pc, tck_id) {
  xmlHttp = GetXmlHttpObject();
  if (xmlHttp == null) {
    alert("Browser does not support HTTP Request");
    return;
  }
  
  xmlHttp.open("POST", "UrunDogrulamaSonuclari.aspx?gtin=" + encodeURI(gtin) + "&batch_no=" + encodeURI(batch) + "&exp_date=" + encodeURI(expiry) + "&pac_code=" + encodeURI(pc) + "&tck_id=" + encodeURI(tck_id), true);
  xmlHttp.onreadystatechange = urunDogrulamaSonuclariTamamlandi;
  xmlHttp.send(null);   
  document.getElementById("divUrunDogrulamaSonuclari").innerHTML = "Doğrulama yapılıyor...";
}

function urunDogrulamaSonuclariTamamlandi() {
  
  if (xmlHttp.readyState == 4 || xmlHttp.readyState == "complete") {   
    var response = xmlHttp.responseText;
    document.getElementById("divUrunDogrulamaSonuclari").innerHTML = response;         
  }
}

function girilmisEczaneBilgileriniGetir(s)
{
  xmlHttp = GetXmlHttpObject();
  if (xmlHttp == null) {
    alert("Browser does not support HTTP Request");
    return;
  }
  
  xmlHttp.open("POST", "GirilmisEczaneBilgileriniGetir.aspx?s=" + encodeURI(s), true);
  xmlHttp.onreadystatechange = girilmisEczaneBilgileriniGetirTamamlandi;
  xmlHttp.send(null);   
}