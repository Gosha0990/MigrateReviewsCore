using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MigrateReviewsCore
{
    internal class ApiRequestCloudTips
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        #region Autorization Client
        public void Authorization(string uri, string userName, string password)
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
                Token = t.access_token.ToString();
                RefreshToken = t.refresh_token.ToString();
            }
        }
        #endregion
        #region PostRequest
        public string PostRequest(string uri, object data)
        {
            string result = null;
            var request = JsonConvert.SerializeObject(data);
            using (var client = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri(uri),
                    Method = HttpMethod.Post,                   
                    Content = new StringContent(request, Encoding.UTF8, "application/json")           
                };
                httpRequest.Headers.Add("Authorization", $"Bearer {Token}");
                var httpResponse = client.SendAsync(httpRequest).Result;
                var jsonTask = httpResponse.Content.ReadAsStringAsync().Result;
                result = jsonTask;
            }
            return result;
        }
        #endregion
        #region GetRequest
        public string GetRequest(string uri, object data)
        {
            var request = JsonConvert.SerializeObject(data);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
            var httpRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Get,
                Content = new StringContent(request, Encoding.UTF8, "application/json")
            };
            var httpResponse = client.SendAsync(httpRequest).Result;
            var jsonTask = httpResponse.Content.ReadAsStringAsync().Result;
            return jsonTask;
        }
        public string GetRequest(string uri)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
            var httpRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Get              
            };
            var httpResponse = client.SendAsync(httpRequest).Result;
            var jsonTask = httpResponse.Content.ReadAsStringAsync().Result;
            return jsonTask;
        }
        #endregion
        #region RefreshToken
        public string SetRefreshToken(string uri)
        {
            var value = new Dictionary<string, string>();
            value.Add("Content-Type", "application/x-www-form-urlencoded");
            value.Add("Grant_type", "refresh_token");
            value.Add("Client_id", "Partner");
            value.Add("refresh_token", RefreshToken);
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
                Token = t.access_token.ToString();
                RefreshToken = t.refresh_token.ToString();
            }
                return Token;
        }
        #endregion
    }
}
