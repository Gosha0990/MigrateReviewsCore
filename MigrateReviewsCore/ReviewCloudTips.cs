using MigrateReviewsCore.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

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
        public string CreationPostRequest(object data, string uri)
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
                httpRequest.Headers.Add("Authorization", $"Bearer {_Token}");
                var httpResponse = client.SendAsync(httpRequest).Result;
                var jsonTask = httpResponse.Content.ReadAsStringAsync().Result;
                result = jsonTask;
            }
            return result;
        }
        #endregion
        public string CreationGetRequest(string uri)
        { 
            string res = null;
            using(var client = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                };
            }
            return " ";
        }
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
