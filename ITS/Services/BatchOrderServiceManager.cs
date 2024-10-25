using DevExpress.XtraPrinting.Native.WebClientUIControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Services
{

    [Serializable]
    public class BatchOrderServiceManager : MarshalByRefObject
    {
        public ResponseGetOrderDetail GetOrderDetail(string pOrderId)
        {
            RequestGetOrderDetail requestGetOrderDetail = new RequestGetOrderDetail();
            requestGetOrderDetail.OrderID = pOrderId;
            ResponseGetOrderDetail responseGetOrderDetail = new ResponseGetOrderDetail();
            return GetOrderDetail(requestGetOrderDetail);
        }

        public ResponseGetOrderDetail GetOrderDetail(RequestGetOrderDetail requestGetOrderDetail)
        {
            string requestUriString = "http://qdataservice/api/Order/AddOrder";
            ResponseGetOrderDetail result = new ResponseGetOrderDetail();
            string value = JsonConvert.SerializeObject((object)requestGetOrderDetail);
            string value2 = "Bearer 81dc9bdb52d0a5910de4dc20036dbc5e2bdbd23ed35f0d83124321574d3ed055";
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                httpWebRequest.Headers.Add("Authorization", value2);
                httpWebRequest.ProtocolVersion = HttpVersion.Version11;
                httpWebRequest.ContentType = "application/json;charset=\"utf-8\"";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Method = "POST";
                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    StreamWriter streamWriter = new StreamWriter(stream);
                    streamWriter.Write(value);
                }

                StreamReader streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream());
                string text = streamReader.ReadToEnd();
                result = JsonConvert.DeserializeObject<ResponseGetOrderDetail>(text);
            }
            catch (WebException ex)
            {
                WebResponse response = ex.Response;
                Stream stream2 = response.GetResponseStream();
                StreamReader streamReader2 = new StreamReader(stream2);
                string text2 = streamReader2.ReadToEnd();
            }

            return result;
        }

        public ResponseAddOrder AddOrder(RequestAddOrder requestAddOrder)
        {
            string requestUriString = "http://qdataservice/api/Order/AddOrder";
            ResponseAddOrder result = new ResponseAddOrder();
            string value = JsonConvert.SerializeObject((object)requestAddOrder);
            string value2 = "Bearer 81dc9bdb52d0a5910de4dc20036dbc5e2bdbd23ed35f0d83124321574d3ed055";
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                httpWebRequest.Headers.Add("Authorization", value2);
                httpWebRequest.ProtocolVersion = HttpVersion.Version11;
                httpWebRequest.ContentType = "application/json;charset=\"utf-8\"";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Method = "POST";
                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    StreamWriter streamWriter = new StreamWriter(stream);
                    streamWriter.Write(value);
                }

                StreamReader streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream());
                string text = streamReader.ReadToEnd();
                result = JsonConvert.DeserializeObject<ResponseAddOrder>(text);
            }
            catch (WebException ex)
            {
                WebResponse response = ex.Response;
                Stream stream2 = response.GetResponseStream();
                StreamReader streamReader2 = new StreamReader(stream2);
                string text2 = streamReader2.ReadToEnd();
            }

            return result;
        }

        public ResponseAddWorkOrder AddWorkOrder(RequestAddWorkOrder requestAddWorkOrder)
        {
            string requestUriString = "http://172.16.117.22:4530/Order/AddWorkOrder";
            ResponseAddWorkOrder result = new ResponseAddWorkOrder();
            string value = JsonConvert.SerializeObject((object)requestAddWorkOrder);
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                httpWebRequest.ProtocolVersion = HttpVersion.Version11;
                httpWebRequest.ContentType = "application/json;charset=\"utf-8\"";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Method = "POST";
                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    StreamWriter streamWriter = new StreamWriter(stream);
                    streamWriter.Write(value);
                }

                StreamReader streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream());
                string text = streamReader.ReadToEnd();
                result = JsonConvert.DeserializeObject<ResponseAddWorkOrder>(text);
            }
            catch (WebException ex)
            {
                WebResponse response = ex.Response;
                Stream stream2 = response.GetResponseStream();
                StreamReader streamReader2 = new StreamReader(stream2);
                string text2 = streamReader2.ReadToEnd();
                result = JsonConvert.DeserializeObject<ResponseAddWorkOrder>(text2);
            }

            return result;
        }

        public ResponseGetOrderManufacture GetOrderManufacture(RequestGetOrderManufacture requestGetOrderManufacture)
        {
            string requestUriString = "http://qdataservice/api/Order/AddOrder";
            ResponseGetOrderManufacture result = new ResponseGetOrderManufacture();
            string value = JsonConvert.SerializeObject((object)requestGetOrderManufacture);
            string value2 = "Bearer 81dc9bdb52d0a5910de4dc20036dbc5e2bdbd23ed35f0d83124321574d3ed055";
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                httpWebRequest.Headers.Add("Authorization", value2);
                httpWebRequest.ProtocolVersion = HttpVersion.Version11;
                httpWebRequest.ContentType = "application/json;charset=\"utf-8\"";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Method = "POST";
                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    StreamWriter streamWriter = new StreamWriter(stream);
                    streamWriter.Write(value);
                }

                StreamReader streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream());
                string text = streamReader.ReadToEnd();
                result = JsonConvert.DeserializeObject<ResponseGetOrderManufacture>(text);
            }
            catch (WebException ex)
            {
                WebResponse response = ex.Response;
                Stream stream2 = response.GetResponseStream();
                StreamReader streamReader2 = new StreamReader(stream2);
                string text2 = streamReader2.ReadToEnd();
            }

            return result;
        }
    }
}
