using Newtonsoft.Json;

namespace TrainService.LocalData
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Station
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "pinyin_initials")]
        public string PinyinInitials { get; set; }
    }
}