using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrainService.LocalData;

namespace TrainService.Policies
{
    public static class CertificateValidation
    {
        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            var chain0 = new X509Chain { ChainPolicy = { RevocationMode = X509RevocationMode.NoCheck } };
            chain0.ChainPolicy.ExtraStore.Add(Runtime.CaCertificate);
            chain0.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            return chain0.Build((X509Certificate2)certificate);
        }
    }
}
