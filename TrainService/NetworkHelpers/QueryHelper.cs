using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TrainService.Configs;
using TrainService.NetworkData.Query;

namespace TrainService.NetworkHelpers
{
    public static class QueryHelper
    {
        public static IList<TrainData> Query(QueryRequest request)
        {
            var queryDictionary = request.ToDictionary();
            var result = ApiHelper.Get<QueryResponse>(StaticConfig.QueryApi, queryDictionary);
            if (!result.Status) throw new IOException(result.Messages.FirstOrDefault());
            if (!result.Data.Flag) throw new InvalidOperationException(result.Data.Message);
            return result.Data.Datas;
        }
    }
}