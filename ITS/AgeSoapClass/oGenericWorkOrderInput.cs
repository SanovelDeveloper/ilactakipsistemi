using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.AgeSoapClass
{
    public class oGenericWorkOrderInput
    {
        public string WorkOrderID { get; set; }
        public string ProductCode { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime MfgDate { get; set; }
        public int Quantity { get; set; }
        public int WorkOrderType { get; set; }
        public string LineID { get; set; }
    }
}
