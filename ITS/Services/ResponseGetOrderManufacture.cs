using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Services
{
    public class ResponseGetOrderManufacture
    {
        [JsonProperty("IsSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("List")]
        // public List<List> List { get; set; }@bilgehan check this
        public List<string> List { get; set; }

        [JsonProperty("Item")]
        public object Item { get; set; }
    }
}
