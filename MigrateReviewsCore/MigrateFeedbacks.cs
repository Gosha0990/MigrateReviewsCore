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
        readonly string _urlAutorization = "https://identity-sandbox.cloudtips.ru/connect/token";
        readonly string _urlFeedback = "https://api-sandbox.cloudtips.ru/api/transactions";
        readonly string _nameAuthorization;
        readonly string _passwordAuthorization;
        private DateTime lastUpdateTimeDb;
        public Items[] Feedbacks { get; set; }
        
        public MigrateFeedbacks(string nameAuthorization, string passwordAuthorization)
        {
            this._nameAuthorization = nameAuthorization;
            this._passwordAuthorization = passwordAuthorization;
        }
        public void GetFeedbackCloudTips()
        {
            var cloudTips = new ApiRequestCloudTips();
            cloudTips.Authorization(_urlAutorization, _nameAuthorization, _passwordAuthorization);
            lastUpdateTimeDb = GetLastDataTimeDb();            
            if (lastUpdateTimeDb != DateTime.Now)
            {
                var trans = new RequestTransactions()
                { 
                    DateFrom = lastUpdateTimeDb

                };
                var jsonfeedbacks = cloudTips.GetRequest(_urlFeedback,trans);
                Feedbacks = DeserializeAnswerCloudTips(jsonfeedbacks);
            }                        
        }
        public void SetFeedBacksZendeskAndDb(string token, string email, string url)
        {
            try
            {
                string[] array = new string[2];
                var zendesk = new ApiRequestZendesk(token, email);
                var cust = new CustomFilds();
                var body = new Comment();
                var comment = new Tickets()
                {
                    Comment = body,
                    Subject = "TestCloudTipsTest",
                    custom_fields = cust
                };
                var tiket = new CreationTeket()
                {
                    Ticket = comment
                };
                
                foreach (var feedback in Feedbacks)
                {                    
                    var lastIdDb = GetLastIdDb();
                    if (feedback.Id != lastIdDb)
                    {
                        if (feedback.Comment != "" || feedback.Rating != null)
                        {
                            if (feedback.Rating == null)
                            {
                                body.Body = feedback.Comment;
                                array[0] = feedback.PlaceExternalId;
                                array[1] = "api";
                                comment.Tags = array;
                                cust.rating = 0;
                                cust.NumberPlace = feedback.PlaceExternalId;
                                zendesk.PostRequest(url, tiket);
                                var date = feedback.Date;
                                LogginInDB(feedback.Id, date, feedback.Comment);
                            }
                            else
                            {
                                body.Body = feedback.Comment;
                                array[0] = feedback.PlaceExternalId;
                                array[1] = "api";
                                comment.Tags = array;
                                cust.rating = feedback.Rating.Score;
                                cust.NumberPlace = feedback.PlaceExternalId.ToString();
                                zendesk.PostRequest(url, tiket);
                                var date = feedback.Date;
                                LogginInDB(feedback.Id, date, feedback.Comment);
                            }
                        }
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Items[] DeserializeAnswerCloudTips(string json)
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
