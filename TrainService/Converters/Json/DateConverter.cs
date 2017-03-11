using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TrainService.Converters.Json
{
    public class DateConverter : DateTimeConverterBase
    {
        private static IsoDateTimeConverter _converter = new IsoDateTimeConverter { DateTimeFormat = "yyyyMMdd" };

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            try
            {
                return _converter.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch
            {
                return existingValue;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            _converter.WriteJson(writer, value, serializer);
        }
    }
}
