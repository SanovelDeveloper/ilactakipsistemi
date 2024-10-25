using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Services
{
    [Serializable]
    public class ItemGetOrderDetail
    {
        private string _statusId;

        [JsonProperty("ID")]
        public int? ID { get; set; }

        [JsonProperty("ProcessID")]
        public string ProcessID { get; set; }

        [JsonProperty("PONumber")]
        public object PONumber { get; set; }

        [JsonProperty("POLine")]
        public object POLine { get; set; }

        [JsonProperty("OrderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty("LineNumber")]
        public int? LineNumber { get; set; }

        [JsonProperty("CustomerID")]
        public int? CustomerID { get; set; }

        [JsonProperty("CustomerGLN")]
        public string CustomerGLN { get; set; }

        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("ProductID")]
        public int? ProductID { get; set; }

        [JsonProperty("Quantity")]
        public int? Quantity { get; set; }

        [JsonProperty("IsContent")]
        public bool IsContent { get; set; }

        [JsonProperty("PrintContent")]
        public object PrintContent { get; set; }

        [JsonProperty("StatusID")]
        public string StatusID
        {
            get
            {
                return _statusId.PadLeft(2, '0');
            }
            set
            {
                _statusId = value;
            }
        }

        [JsonProperty("DateScheduled")]
        public object DateScheduled { get; set; }

        [JsonProperty("DateExecuted")]
        public object DateExecuted { get; set; }

        [JsonProperty("DateClosed")]
        public object DateClosed { get; set; }

        [JsonProperty("BatchLotNumber")]
        public string BatchLotNumber { get; set; }

        [JsonProperty("ProductionDate")]
        public DateTime ProductionDate { get; set; }

        [JsonProperty("ExpireDate")]
        public DateTime ExpireDate { get; set; }

        [JsonProperty("MaxPackagingLevelNumber")]
        public int? MaxPackagingLevelNumber { get; set; }

        [JsonProperty("IsTemperEvidence")]
        public bool? IsTemperEvidence { get; set; }

        [JsonProperty("TemperEvidenceSide")]
        public string TemperEvidenceSide { get; set; }

        [JsonProperty("TemperEvidenceVivid")]
        public string TemperEvidenceVivid { get; set; }

        [JsonProperty("Quality")]
        public string Quality { get; set; }

        [JsonProperty("RecordDate")]
        public DateTime? RecordDate { get; set; }

        [JsonProperty("RecordUser")]
        public int? RecordUser { get; set; }

        [JsonProperty("IsActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("ItemLabelID")]
        public object ItemLabelID { get; set; }

        [JsonProperty("CaseLabelID")]
        public object CaseLabelID { get; set; }

        [JsonProperty("PalletLabelID")]
        public object PalletLabelID { get; set; }

        [JsonProperty("ParentOrderNumber")]
        public object ParentOrderNumber { get; set; }
    }
}
