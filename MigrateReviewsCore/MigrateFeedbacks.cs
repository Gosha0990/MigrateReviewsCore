using MigrateReviewsCore.Data;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System;
using MigrateReviewsCore.DataBase;
using Microsoft.EntityFrameworkCore;

namespace MigrateReviewsCore
{
    internal class MigrateFeedbacks
    {
        private string _urlAutorization = "https://identity-sandbox.cloudtips.ru/connect/token";
        private string _urlFeedback = "https://api-sandbox.cloudtips.ru/api/feedbacks?Limit=";
        private string _nameAuthorization;
        private string _passwordAuthorization;
        
        public ResultFeedback[] Feedbacks { get; set; }        
        public MigrateFeedbacks(string nameAuthorization, string passwordAuthorization, string limit)
        {
            _urlFeedback = string.Format($"https://api-sandbox.cloudtips.ru/api/feedbacks?Limit={limit}&DateFrom=");
            _nameAuthorization = nameAuthorization;
            _passwordAuthorization = passwordAuthorization;
        }
        public string GetFeedbackCloudTips()
        {
            var cloudTips = new ApiRequestCloudTips();
            cloudTips.Authorization(_urlAutorization, _nameAuthorization, _passwordAuthorization);
            var lastDateDb = GetLastDataTimeDB();
            if (lastDateDb != DateTime.Now)
            {
                var d = lastDateDb.ToString("yyyy-MM-dd");
                _urlFeedback += d;
            }
            var jsonfeedbacks = cloudTips.GetRequest(_urlFeedback);
            Feedbacks = GetArrayFeedbacks(jsonfeedbacks);
            return " ";

        }
        public string SetFeedBacksZendesk(string token, string email, string url)
        {
            try
            {                
                string result = "";
                var zendesk = new ApiRequestZendesk(token, email);
                var body = new Comment();
                var comment = new Tickets()
                {
                    comment = body,
                };
                var tiket = new CreationTeket()
                {
                    ticket = comment
                };
                foreach (var feedback in Feedbacks)
                {
                    body.body = feedback.Comment;
                    //result += "\n"+ zendesk.PostRequest(url, tiket);
                    var date = DateTime.Parse(feedback.Date);
                    LogginInDB(feedback.id, date, feedback.Comment);
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        private ResultFeedback[] GetArrayFeedbacks(string json)
        {
            var dis = JsonConvert.DeserializeObject<DataF>(json);
            ResultFeedback[] res = dis.data.items;            
            return res;
        }
        private void LogginInDB(string id, DateTime date, string comment)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>()
            .Build();
            using (var context = new StreamingServiceContext(config.GetConnectionString("Default")))
            {               
                context.Database.Migrate();

                context.Add(new FeedbackCloudTips
                {
                    Id = id,
                    Date = date,
                    Comment = comment
                });
                context.SaveChanges();
            }
        }
        private DateTime GetLastDataTimeDB()
        {
            DateTime resDateTime = new DateTime();
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>()
            .Build();
            using (var context = new StreamingServiceContext(config.GetConnectionString("Default")))
            {
                var date = (context.feedbackCloudTips
                    .Select(x => x.Date)).ToList().Last();
                resDateTime = date;
            }
            return resDateTime;
        }
    }
}
