using MigrateReviewsCore.Data;
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
            var comment = new Comment()
            {
                Body = "Test"
            };
            var ticket = new CreationTickets()
            {
                Comment = comment,
            };
            var content = new Dictionary<string, string>();
            content.Add("name", "anton");
            var json = JsonConvert.SerializeObject(content);
            using (var client = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://coffeemania.zendesk.com/api/v2/tickets"),
                    Method = HttpMethod.Post,
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
                httpRequest.Headers.Add("Accept", "application/json");
                httpRequest.Headers.Add("Authorization", $"Basic {BasicToken}");
                var httpResponse = client.SendAsync(httpRequest).Result;
                var jsonTask = httpResponse.Content.ReadAsStringAsync().Result;
            }
                return " ";
        }
        public string GenerationToken()
        {
            var email = "a.yakovleva@coffeemania.ru/token:vjW2dfbHWJWlDBtcNKp8GgaGCIL95WOvLdVDkmws";
            var resToken = Encoding.ASCII.GetBytes(email);
            var res = Convert.ToBase64String(resToken);
            BasicToken = res;
            return res;
        }
    }
}
