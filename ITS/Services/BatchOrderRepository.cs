using ITS.TTS;
using LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITS.Services
{
    public static class BatchOrderRepository
    {
        private static string sResult = string.Empty;

        public static void OrderInsert(
          string orderNumber,
          string serialnumber,
          int? lineid,
          string gtinno,
          int quantity,
          DateTime startdate,
          DateTime expirydate,
          int selectedsystem)
        {
            try
            {
                ITSDataContext itsDataContext1 = new ITSDataContext(Global.ITSConnectionString);
                itsDataContext1.CommandTimeout = 120000;
                using (ITSDataContext itsDataContext2 = itsDataContext1)
                    itsDataContext2.Order_Insert(orderNumber, serialnumber, lineid, gtinno, new int?(quantity), new DateTime?(startdate), new DateTime?(expirydate), new int?(selectedsystem));
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static string TTSCreateBatchOrder(
          string pUserName,
          string pPassword,
          string pPackagingOrderId,
          string pLotNumber,
          int pLineEntityId,
          int pInputPriority,
          string pDestCountry,
          DateTime pSchedTimestamp,
          DateTime pExpiryTimestamp,
          string pTargetGTIN,
          string pTargetInternalCode,
          int pTargetQuantity,
          string pLowestGTIN,
          string pLowestInternalCode,
          string pHighestGTIN,
          string pHighestInternalCode,
          string pAdditionalInfos,
          bool pIsPromoted)
        {
            try
            {
                BatchOrderRepository.sResult = new Main().CreateBatchOrder(pUserName, pPassword, pPackagingOrderId, pLotNumber, pLineEntityId, pInputPriority, pDestCountry, pSchedTimestamp, pExpiryTimestamp, pTargetGTIN, pTargetInternalCode, pTargetQuantity, pLowestGTIN, pLowestInternalCode, pHighestGTIN, pHighestInternalCode, pAdditionalInfos, pIsPromoted);
                if (BatchOrderRepository.sResult == "FUNCTION PERFORMED")
                    BatchOrderRepository.OrderInsert(pPackagingOrderId, pLotNumber, new int?(pLineEntityId), pTargetGTIN, pTargetQuantity, pSchedTimestamp, pExpiryTimestamp, 1);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return BatchOrderRepository.sResult;
            }
            return BatchOrderRepository.sResult;
        }

        public static bool FarmakodCreateBatchOrder(
          string orderid,
          string customergln,
          string productgtn,
          string processid,
          string lotnumber,
          DateTime expiredate,
          DateTime productiondate,
          int quantity,
          string maxpackaginglevel,
          int? lineid,
          DateTime startdate)
        {
            try
            {
                RequestAddOrder requestAddOrder1 = new RequestAddOrder();
                RequestAddOrder requestAddOrder2 = new RequestAddOrder();
                requestAddOrder2.OrderID = orderid;
                requestAddOrder2.CustomerGLN = customergln;
                requestAddOrder2.ProductGTIN = productgtn;
                requestAddOrder2.ProcessID = processid;
                requestAddOrder2.LotNumber = lotnumber;
                requestAddOrder2.ExpireDate = new DateTime?(new DateTime(expiredate.Year, expiredate.Month, expiredate.Day));
                requestAddOrder2.ProductionDate = new DateTime?(new DateTime(productiondate.Year, productiondate.Month, productiondate.Day));
                requestAddOrder2.Quantity = new int?(quantity);
                requestAddOrder2.MaxPackagingLevel = maxpackaginglevel;
                ResponseAddOrder responseAddOrder1 = new ResponseAddOrder();
                ResponseAddOrder responseAddOrder2 = new BatchOrderServiceManager().AddOrder(requestAddOrder2);
                if (!responseAddOrder2.IsSuccess)
                {
                    int num = (int)MessageBox.Show("Farmakod sistemine Üretim emri ekleme işleminde bir hata oluştu. Farmakod'un verdiği hata: " + responseAddOrder2.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return responseAddOrder2.IsSuccess;
                }
                BatchOrderRepository.OrderInsert(orderid, lotnumber, lineid, "0" + productgtn, quantity, startdate, expiredate, 2);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool FarmakodYurtIciAddWorkOrderr(
          string OrderId,
          string CustomerGln,
          string ProductGtin,
          string ProcessId,
          string LotNumber,
          DateTime ExpireDate,
          DateTime ProductionDate,
          int Quantity,
          DateTime StartDate)
        {
            try
            {
                RequestAddWorkOrder requestAddWorkOrder1 = new RequestAddWorkOrder();
                RequestAddWorkOrder requestAddWorkOrder2 = new RequestAddWorkOrder();
                requestAddWorkOrder2.OrderID = OrderId;
                requestAddWorkOrder2.CustomerGLN = CustomerGln;
                requestAddWorkOrder2.ProductGTIN = ProductGtin;
                requestAddWorkOrder2.ProcessID = ProcessId;
                requestAddWorkOrder2.LotNumber = LotNumber;
                requestAddWorkOrder2.ExpireDate = new DateTime(ExpireDate.Year, ExpireDate.Month, ExpireDate.Day);
                requestAddWorkOrder2.ProductionDate = new DateTime(ProductionDate.Year, ProductionDate.Month, ProductionDate.Day);
                requestAddWorkOrder2.Quantity = Quantity;
                requestAddWorkOrder2.StartDate = new DateTime?(new DateTime(StartDate.Year, StartDate.Month, StartDate.Day));
                ResponseAddWorkOrder responseAddWorkOrder1 = new ResponseAddWorkOrder();
                ResponseAddWorkOrder responseAddWorkOrder2 = new BatchOrderServiceManager().AddWorkOrder(requestAddWorkOrder2);
                if (!responseAddWorkOrder2.IsSuccess)
                {
                    int num = (int)MessageBox.Show("Farmakod Yurtiçi sistemine Üretim emri ekleme işleminde bir hata oluştu. Farmakod Yurtiçi'nin verdiği hata: " + responseAddWorkOrder2.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return responseAddWorkOrder2.IsSuccess;
                }
                BatchOrderRepository.OrderInsert(OrderId, LotNumber, new int?(), ProductGtin, Quantity, StartDate, ExpireDate, 3);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
