using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using TrainService.Configs;
using TrainService.Exceptions;

namespace TrainService.NetworkHelpers
{
    public static class ApiHelper
    {
        public static T Get<T>(string apiUrl, IDictionary<string, object> getContent)
        {
            var contentStrings = getContent?.Select(content => $"{content.Key}={content.Value}") ?? new string[0];
            var completeUrl = apiUrl + "?" + string.Join("&", contentStrings);
            var webRequest = (HttpWebRequest) WebRequest.Create(completeUrl);
            webRequest.Timeout = StaticConfig.Timeout;
            webRequest.Method = "GET";
            var webResponse = (HttpWebResponse) webRequest.GetResponse();
            var webResponseStream = webResponse.GetResponseStream();
            if (webResponseStream == null) throw Network.LinkFailed;
            var webResponseReader = new StreamReader(webResponseStream);
            var responseJson = webResponseReader.ReadToEnd();
            webRequest.Abort();
            webResponse.Close();
            webResponseReader.Close();
            return JsonConvert.DeserializeObject<T>(responseJson, StaticConfig.JsonSerializeSettings);
        }

        public static T Post<T>(string apiUrl, object postContent)
        {
            var webRequest = (HttpWebRequest) WebRequest.Create(apiUrl);
            webRequest.ContentType = StaticConfig.PostContentType;
            webRequest.Timeout = StaticConfig.Timeout;
            webRequest.Method = "POST";
            var requestJson = JsonConvert.SerializeObject(postContent, StaticConfig.JsonSerializeSettings);
            var requestJsonBytes = Encoding.UTF8.GetBytes(requestJson);
            webRequest.ContentLength = requestJsonBytes.Length;
            webRequest.GetRequestStream().Write(requestJsonBytes, 0, requestJsonBytes.Length);
            var webResponse = (HttpWebResponse) webRequest.GetResponse();
            var webResponseStream = webResponse.GetResponseStream();
            if (webResponseStream == null) throw Network.LinkFailed;
            var webResponseReader = new StreamReader(webResponseStream);
            var responseJson = webResponseReader.ReadToEnd();
            webRequest.Abort();
            webResponse.Close();
            webResponseReader.Close();
            return JsonConvert.DeserializeObject<T>(responseJson, StaticConfig.JsonSerializeSettings);
        }
    }
}