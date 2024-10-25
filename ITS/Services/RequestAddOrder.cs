using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Services
{
    public class RequestAddOrder
    {
        public string OrderID { get; set; }

        public string CustomerGLN { get; set; }

        public string ProductGTIN { get; set; }

        public string ProcessID { get; set; }

        public string LotNumber { get; set; }

        public DateTime? ExpireDate { get; set; }

        public DateTime? ProductionDate { get; set; }

        public int? Quantity { get; set; }

        public string MaxPackagingLevel { get; set; }
    }
}
