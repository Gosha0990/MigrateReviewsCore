using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore
{
    internal class TestRecipient
    {
        public string Authorization()
        {
            var rec = new ReviewCloudTips();
            rec.Authorization("https://identity-sandbox.cloudtips.ru/connect/token", "v.piskov@coffeemania.ru", "dkYnjkdkjd77");
            var token = rec._Token;
            token = rec.RefreshToken("https://identity-sandbox.cloudtips.ru/connect/token");
            var value = new Dictionary<string, string>();
            value.Add("phoneName", "openid");
            value.Add("name", "Test");
            value.Add("email", "user@example.com");
            value.Add("type", "0");
            value.Add("placeId", "Cofe");
            value.Add("sendPassword", "true");
            value.Add("verifyPhone", "true");

            string result = "";
            using (var client = new HttpClient())
            {
                
                var httpRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://api-sandbox.cloudtips.ru/api/receivers"),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(value)
                };
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var httpResponse = client.SendAsync(httpRequest).Result;
                var jsonTask = httpResponse.Content.ReadAsStringAsync();
                result = jsonTask.Result.ToString();
                
            }
            return "Autorization";
        }
    }
}
