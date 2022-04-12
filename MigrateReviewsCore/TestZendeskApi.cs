using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZendeskApi;

namespace MigrateReviewsCore
{
    internal class TestZendeskApi
    {
        public string BasicToken { get; set; }
        public string ztest()
        {
            var content = new Dictionary<string, string>();
            content.Add("name", "anton");
            var json = JsonConvert.SerializeObject(content);
            var client = new HttpClient();
            var httpRequest = new HttpRequestMessage();
            httpRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");
            httpRequest.Method = HttpMethod.Post;
            httpRequest.RequestUri = new Uri(@"https://zendesk.com/api/v2/tickets");
            httpRequest.Headers.Add("Authorization", $"Basic {BasicToken}");
            var response = client.SendAsync(httpRequest).Result;
            var res = response.Content.ReadAsStringAsync().Result;
            return " ";
        }
        public string GenerationToken()
        {
            var email = "a.yakovleva@coffeemania.ru/token:vjW2dfbHWJWlDBtcNKp8GgaGCIL95WOvLdVDkmws";
            var resToken = Encoding.UTF8.GetBytes(email);
            var res = Convert.ToBase64String(resToken);
            BasicToken = res;
            return res;
        }
    }
}
