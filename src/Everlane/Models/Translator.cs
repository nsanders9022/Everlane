﻿using System;
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
        public string Language { get; set; }
        
        public string Translation { get; set; }

        public static string GetTranslation(string text, string lang)
        {
            var client = new RestClient("https://translate.yandex.net/api/v1.5/tr.json/translate?key=" + EnvironmentVariables.YandaxKey + "&text=" + text + "&lang=" + lang +"&[format=html]&[options=1]");
            var request = new RestRequest("", Method.POST);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            //var translation = JsonConvert.DeserializeObject<string>(jsonResponse["text"].ToString());
            //return translation;
            return jsonResponse.GetValue("text").ToString();
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
