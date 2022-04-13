using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
        public bool CreationTiket(string url, object data)
        {
            GenerationToken();
            var json = JsonConvert.SerializeObject(data);
            using (var client = new HttpClient()) 
            {
                var httpRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Post,
                    Content = new StringContent(json)
                };
                httpRequest.Headers.Add("Authorization", $"Basic {BasicToken}");
                var response = client.SendAsync(httpRequest).Result;
                var jsonTask = JsonConvert.SerializeObject(response);
            }
                return true;
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
