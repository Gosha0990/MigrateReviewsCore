using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace MigrateReviewsCore
{
    internal class ReviewCloudTips
    {
        public string _Token { get; set; }
        #region Autorization Client
        public string Authorization(string uri, string userName, string password)
        {
            var value = new Dictionary<string, string>();
            value.Add("Content-Type", "application/x-www-form-urlencoded");
            value.Add("Grant_type", "password");
            value.Add("Client_id", "Partner");
            value.Add("UserName", userName);
            value.Add("Password", password);

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
                Token t = JsonConvert.DeserializeObject<Token>(result);
                _Token = t.access_token.ToString();
            }
                return "Autorization";
        }
        #endregion
        public string CreaterRecipient(Recipient recipient, string uri)
        {            
            var reqest = JsonConvert.SerializeObject(recipient);
            var recipientCollection = new List<KeyValuePair<string, string>>()
            { 
                new KeyValuePair<string, string>("json",reqest)
            };
            using (var client = new HttpClient())
            {

                var httpRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri(uri),
                    Method = HttpMethod.Post,
                    
                    Content = new FormUrlEncodedContent(recipientCollection)
                    
                };
                httpRequest.Headers.Add("AuthorizationBearer", _Token);
                var httpResponse = client.Send(httpRequest);
                var jsonTask = httpResponse.Content;
            }
            return "CreaterRecipient";
        }
    }
}
