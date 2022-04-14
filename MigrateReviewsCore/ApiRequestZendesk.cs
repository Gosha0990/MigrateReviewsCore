using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace MigrateReviewsCore
{
    internal class ApiRequestZendesk
    {
        public string BasicToken { get; set; }
        private string ApiToken { get; set; }
        private string Email { get; set; }

        public ApiRequestZendesk(string apiToken, string email)
        { 
            ApiToken = apiToken;
            Email = email;
        }
        public string PostRequest(string url, object data)
        {
            GenerationToken();
            string result = null; 
            var json = JsonConvert.SerializeObject(data);
            using (var client = new HttpClient()) 
            {
                var httpRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Post,
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
                httpRequest.Headers.Add("Authorization", $"Basic {BasicToken}");//{BasicToken}
                var response = client.SendAsync(httpRequest).Result;
                var jsonTask = JsonConvert.SerializeObject(response);
                result = jsonTask;
            }
            return result;
        }
        #region GenerationToken
        private void GenerationToken()
        { 
            var token = Email + "/token:"+ ApiToken;
            var arrayBytesToken = Encoding.ASCII.GetBytes(token);
            var res = Convert.ToBase64String(arrayBytesToken);
            BasicToken = res;
        }
        #endregion
    }
}
