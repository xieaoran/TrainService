﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TrainService.Policies
{
    public class CertificatePolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request,
            int certificateProblem)
        {
            return certificate.GetPublicKey() == LocalData.Runtime.CertPublicKey;
        }
    }
}
