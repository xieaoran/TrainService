using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrainService.Converters.Json
{
    public class TimeSpanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is TimeSpan))
                throw new JsonSerializationException("Unexpected value when converting timespan.");
            var timeSpan = (TimeSpan)value;
            var str = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}";
            writer.WriteValue(str);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var str = reader.Value.ToString();
            if (string.IsNullOrEmpty(str))
                return null;
            var subStr = str.Split(':');
            if (subStr.Length != 2)
                throw new JsonSerializationException("Unexpected value when converting timespan.");
            return new TimeSpan(int.Parse(subStr[0]), int.Parse(subStr[1]), 0);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TimeSpan);
        }
    }
}
