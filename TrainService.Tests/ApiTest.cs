using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainService.Configs;
using TrainService.NetworkData.Query;
using TrainService.NetworkHelpers;

namespace TrainService.Tests
{
    [TestClass]
    public class ApiTest
    {
        [TestMethod]
        public void QueryTest()
        {
            var queryRequest = new QueryRequest()
            {
                FromStation = StaticConfig.DefaultFromStation,
                ToStation = StaticConfig.DefaultToStation,
                QueryDate = DateTime.Today
            };
            var result = QueryHelper.Query(queryRequest);
        }
    }
}
