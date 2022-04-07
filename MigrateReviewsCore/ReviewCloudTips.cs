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
        public string Authorization()
        {
            var value = new Dictionary<string, string>();
            value.Add("Grant_type", "password");
            value.Add("Client_id", "Partner");
            value.Add("UserName", "v.piskov@coffeemania.ru");
            value.Add("Password", "dkYnjkdkjd77");
            string uri = "https://identity-sandbox.cloudtips.ru/connect/token";
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "";
            var data = JsonSerializer.Serialize(value);
            var res = client.UploadString(uri, data);
                return res;

        }
        public string CreateUser()
        {
            var recipient = new Recipient()
            {
                PhoneName = "+79998887766",
                Name = "Anna",
                Email = "anna@emaol.ru",
                Type = 0,
                Placeid = "Depo",
                SendPassword = true,
                VerifyPhone = true
            };
            var jsonString = JsonSerializer.Serialize(recipient);
            using (var client = new WebClient())
            { }
                return jsonString;
        }
    }
}
