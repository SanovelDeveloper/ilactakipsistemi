using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ITS.AgeSoapClass
{
    public static class Repository
    {
        public static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPActiontion:http://tempuri.org/" + action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        public static XmlDocument CreateSoapEnvelope(oGenericWorkOrderInput workOrderInput)
        {
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">
                        <soapenv:Header/>
	                         <soapenv:Body>
		                         <tem:PostWorkOrder>
			                         <tem:oGenericWorkOrderInput>
				                     <tem:WorkOrderID>" + workOrderInput.WorkOrderID.ToString().Trim() + @"</tem:WorkOrderID>
				                     <tem:ProductCode>" + workOrderInput.ProductCode.ToString().Trim() + @"</tem:ProductCode>
				                     <tem:BatchNumber>" + workOrderInput.BatchNumber.ToString().Trim() + @"</tem:BatchNumber>
				                     <tem:ExpiryDate>" + workOrderInput.ExpiryDate.ToString("yyyy-MM-dd") + @"</tem:ExpiryDate>
				                     <tem:MfgDate>" + workOrderInput.MfgDate.ToString("yyyy-MM-dd") + @"</tem:MfgDate>
				                     <tem:Quantity>" + workOrderInput.Quantity.ToString().Trim() + @"</tem:Quantity>
				                     <tem:WorkOrderType>" + workOrderInput.WorkOrderType.ToString().Trim() + @"</tem:WorkOrderType>
				                     <tem:LineID>" + workOrderInput.LineID.ToString().Trim() + @"</tem:LineID>
			                         </tem:oGenericWorkOrderInput>
		                         </tem:PostWorkOrder>
	                         </soapenv:Body>
                    </soapenv:Envelope>");
            return soapEnvelopeXml;
        }

        public static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
