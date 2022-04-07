using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MigrateReviewsCore
{
    internal class ReviewCloudTips
    {
        private string token;
        public string Authorization()
        {
            var value = new Dictionary<string, string>();
            value.Add("Content-Type", "application/x-www-form-urlencoded");
            value.Add("Grant_type", "password");
            value.Add("Client_id", "Partner");
            value.Add("UserName", "v.piskov@coffeemania.ru");
            value.Add("Password", "dkYnjkdkjd77");

            string uri = "https://identity-sandbox.cloudtips.ru/connect/token";
            string result = "";
            using (var client = new HttpClient())
            { 
                var httpRequest = new HttpRequestMessage()
                { 
                    RequestUri = new Uri(uri),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(value)
                };
                var httpResponse = client.SendAsync(httpRequest).Result;
                var jsonTask = httpResponse.Content.ReadAsStringAsync();
                result = jsonTask.Result.ToString();
                Token? t = JsonConvert.DeserializeObject<Token>(result);
                token = t.access_token.ToString();
            }
                return "Nice";
        }
        public string CreaterRecipient(Recipient recipient)
        {
            var uri = " https://api-sandbox.cloudtips.ru/api/receivers";
            var client = new HttpClient();
            var reqest = JsonConvert.SerializeObject(recipient);
            var httpRequest = new HttpRequestMessage()
            {
                 
            };
            
            return "CreaterRecipient";
        }
    }
}
