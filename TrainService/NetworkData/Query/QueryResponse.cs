using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrainService.NetworkData.Query
{
    [JsonObject(MemberSerialization.OptIn)]
    public class QueryResponse
    {
        [JsonProperty(PropertyName = "status")]
        public bool Status { get; set; }

        [JsonProperty(PropertyName = "httpstatus")]
        public int HttpStatus { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public IList<string> Messages { get; set; }

        [JsonProperty(PropertyName = "data")]
        public TrainDatas Data { get; set; }
    }
}