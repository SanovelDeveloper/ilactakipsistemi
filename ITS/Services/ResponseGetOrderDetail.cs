using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Services
{
    [Serializable]
    public class ResponseGetOrderDetail
    {
        [JsonProperty("IsSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }

        [JsonProperty("List")]
        public object List { get; set; }

        [JsonProperty("Item")]
        public ItemGetOrderDetail Item { get; set; }
    }
}
