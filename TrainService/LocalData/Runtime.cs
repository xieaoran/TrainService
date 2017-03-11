using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using TrainService.Configs;

namespace TrainService.LocalData
{
    public static class Runtime
    {
        public static X509Certificate2 CaCertificate { get; set; }
        public static IEnumerable<Station> Stations { get; set; }
        public static IEnumerable<PurposeCode> PurposeCodes { get; set; }

        public static void Load()
        {
            using (var stationsReader = new StreamReader("Assets\\Data\\Stations.json"))
            {
                Stations = JsonConvert.DeserializeObject<IEnumerable<Station>>(stationsReader.ReadToEnd(),
                    StaticConfig.JsonSerializeSettings);
            }
            using (var purposeCodesReader = new StreamReader("Assets\\Data\\PurposeCodes.json"))
            {
                PurposeCodes = JsonConvert.DeserializeObject<IEnumerable<PurposeCode>>(purposeCodesReader.ReadToEnd(),
                    StaticConfig.JsonSerializeSettings);
            }
            CaCertificate = new X509Certificate2("Assets\\Data\\Certificate.cer");
        }
    }
}