using Newtonsoft.Json;

namespace TrainService.LocalData
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PurposeCode
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}