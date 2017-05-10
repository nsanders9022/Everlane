using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Everlane.Models
{
    public class Translator
    {
        public string To { get; set; }
        
        public string Body { get; set; }

        public static  string GetTranslation()
        {
            var client = new RestClient("https://translate.yandex.net/api/v1.5/tr.json/translate?key=trnsl.1.1.20170510T165628Z.21b584f2009fc3b4.1d4d6367957a3e38215789b338f78a5d54c42ecb&text=i%love%chocolate&lang=de&[format=plain]&[options=1]");
            var request = new RestRequest("", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var translation = JsonConvert.DeserializeObject<string>(jsonResponse["text"].ToString());
            return translation;

        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
