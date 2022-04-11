using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MigrateReviewsCore
{
    internal class ReviewCloudTips
    {
        public string _Token { get; set; }
        public string _RefreshToken { get; set; }

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
                _RefreshToken = t.refresh_token.ToString();
            }
                return "Autorization";
        }
        #endregion
        #region CreaterRecipient
        public string CreaterRecipient(Recipient recipient, string uri)
        {
            var reqest = JsonConvert.SerializeObject(recipient);
            using (var client = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri(uri),
                    Method = HttpMethod.Post,                   
                    Content = new StringContent(reqest, Encoding.UTF8, "application/json")           
                };
                httpRequest.Headers.Add("Authorization", $"Bearer {_Token}");
                var httpResponse = client.SendAsync(httpRequest).Result;
                var jsonTask = httpResponse.Content.ReadAsStringAsync().Result;
            }
            return "Creat";
        }
        #endregion
        #region RefreshToken
        public string RefreshToken(string uri)
        {
            var value = new Dictionary<string, string>();
            value.Add("Content-Type", "application/x-www-form-urlencoded");
            value.Add("Grant_type", "refresh_token");
            value.Add("Client_id", "Partner");
            value.Add("refresh_token", _RefreshToken);
            string res;
            using (var client = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage() 
                { 
                    RequestUri = new Uri(uri),
                    Method= HttpMethod.Post,
                    Content  = new FormUrlEncodedContent(value)
                };
                var httpResponse = client.SendAsync(httpRequest).Result;
                var jsonTask = httpResponse.Content.ReadAsStringAsync().Result;
                res = jsonTask.ToString();
                Token t = JsonConvert.DeserializeObject<Token>(res);
                _Token = t.access_token.ToString();
                _RefreshToken = t.refresh_token.ToString();
            }
                return _Token;
        }
        #endregion
    }
}
