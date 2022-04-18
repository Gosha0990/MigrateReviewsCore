using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System;
using MigrateReviewsCore.DataBase;
using Microsoft.EntityFrameworkCore;
using MigrateReviewsCore.DataApi;

namespace MigrateReviewsCore
{
    internal class MigrateFeedbacks
    {
        private string _urlAutorization = "https://identity-sandbox.cloudtips.ru/connect/token";
        private string _urlFeedback = "https://api-sandbox.cloudtips.ru/api/transactions";
        private string _nameAuthorization;
        private string _passwordAuthorization;
        private DateTime _lastUpdateTimeDb;
        public Items[] Feedbacks { get; set; }
        
        public MigrateFeedbacks(string nameAuthorization, string passwordAuthorization)
        {
            _nameAuthorization = nameAuthorization;
            _passwordAuthorization = passwordAuthorization;
        }
        public void GetFeedbackCloudTips()
        {
            var cloudTips = new ApiRequestCloudTips();
            cloudTips.Authorization(_urlAutorization, _nameAuthorization, _passwordAuthorization);
            _lastUpdateTimeDb = GetLastDataTimeDb();            
            if (_lastUpdateTimeDb != DateTime.Now)
            {
                var trans = new RequestTransactions()
                { 
                    DateFrom = _lastUpdateTimeDb

                };
                var jsonfeedbacks = cloudTips.GetRequest(_urlFeedback,trans);
                Feedbacks = DeserializeAnswerCloudTips(jsonfeedbacks);
            }                        
        }
        public string SetFeedBacksZendeskAndDb(string token, string email, string url)
        {
            try
            {                
                string result = "";
                var zendesk = new ApiRequestZendesk(token, email);
                var body = new Comment();
                var comment = new Tickets()
                {
                    Comment = body,
                    Subject = "TestCloudTipsTest",
                };
                var tiket = new CreationTeket()
                {
                    Ticket = comment
                };
                foreach (var feedback in Feedbacks)
                {                    
                    if (feedback.Id != GetLastIdDb())
                    {
                        body.Body = feedback.Comment;
                        //result += "\n" + zendesk.PostRequest(url, tiket);
                        var date = feedback.Date;
                        LogginInDB(feedback.Id, date, feedback.Comment);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        private Items[] DeserializeAnswerCloudTips(string json)
        {
            var dis = JsonConvert.DeserializeObject<ResultTransactions>(json);
            var res = dis.data.Items;          
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
        private DateTime GetLastDataTimeDb()
        {
            DateTime resDateTime = new DateTime();
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>()
            .Build();
            using (var context = new StreamingServiceContext(config.GetConnectionString("Default")))
            {
                try
                {
                    var date = (context.feedbackCloudTips
                        .Select(x => x.Date)).ToList().Last();
                    resDateTime = date;
                }
                catch
                {
                    resDateTime = DateTime.Today;
                }
            }
            return resDateTime;
        }
        private string GetLastIdDb()
        {
            string id = "";
            try
            {
                var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .Build();
                using (var context = new StreamingServiceContext(config.GetConnectionString("Default")))
                {
                    id = (context.feedbackCloudTips
                        .Select(x => x.Id)).ToList().Last();
                    
                }
                return id;
            }
            catch 
            {
                id = "0000";
                return id;
            }
        }        
    }
}
