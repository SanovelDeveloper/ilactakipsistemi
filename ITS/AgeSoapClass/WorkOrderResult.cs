using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.AgeSoapClass
{
    public class WorkOrderResult
    {
        public string WorkOrderID { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSucceed { get; set; }

    }
}
