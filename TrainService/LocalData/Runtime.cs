using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using TrainService.Configs;

namespace TrainService.LocalData
{
    public static class Runtime
    {
        public static byte[] CertPublicKey { get; set; }
        public static IList<Station> Stations { get; set; }
        public static IList<PurposeCode> PurposeCodes { get; set; }

        public static void Load()
        {
            using (var stationsReader = new StreamReader("Assets\\Data\\Stations.json"))
            {
                Stations = JsonConvert.DeserializeObject<IList<Station>>(stationsReader.ReadToEnd(),
                    StaticConfig.JsonSerializeSettings);
            }
            using (var purposeCodesReader = new StreamReader("Assets\\Data\\PurposeCodes.json"))
            {
                PurposeCodes = JsonConvert.DeserializeObject<IList<PurposeCode>>(purposeCodesReader.ReadToEnd(),
                    StaticConfig.JsonSerializeSettings);
            }
            var localCertificate = X509Certificate.CreateFromCertFile("Assets\\Data\\Certificate.cer");
            CertPublicKey = localCertificate.GetPublicKey();
        }
    }
}