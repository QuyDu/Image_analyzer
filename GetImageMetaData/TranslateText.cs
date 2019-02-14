﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GetImageMetaData
{
    class TranslateText
    {
            private Options _options = new Options();
       
            static string host = "https://api.cognitive.microsofttranslator.com";
            static string path = "/translate?api-version=3.0";
            // Translate to German and Italian.
            static string params_ = "&to=de&to=it";

            static string uri = host + path + params_;

            // NOTE: Replace this example key with a valid subscription key.
            static string key = "ENTER KEY HERE";

            static string text = "Hello world!";

            async static void Translate()
            {
                System.Object[] body = new System.Object[] { new { Text = text } };
                var requestBody = JsonConvert.SerializeObject(body);

                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Post;
                    request.RequestUri = new Uri(uri);
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    request.Headers.Add("Ocp-Apim-Subscription-Key", key);

                    var response = await client.SendAsync(request);
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody), Formatting.Indented);

                    Console.OutputEncoding = UnicodeEncoding.UTF8;
                    Console.WriteLine(result);
                }
            }

            
    }
}

