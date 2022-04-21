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
        private string _urlTransactions = "https://api-sandbox.cloudtips.ru/api/transactions";
        readonly string _nameAuthorization;
        readonly string _passwordAuthorization;
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
            _urlTransactions += $"?dateFrom={GetLastDataTimeDb().ToString("yyyy-MM-ddTHH:mm")}";
            Feedbacks = DeserializeAnswerCloudTips(cloudTips.GetRequest(_urlTransactions));
        }
        public void SetFeedBacksZendeskAndDb(string token, string email, string url)
        {
            try
            {
                var creatTiket = new CreationTeket()
                {
                   ticket = new Tickets()
                   { 
                      comment = new Comment(),
                      custom_fields = new CustomFilds()
                   },
                };                                
                foreach (var feedback in Feedbacks)
                {                    
                    if (feedback.Id != GetLastIdDb() && (feedback.Comment != "" || feedback.Rating != null))
                    {
                        creatTiket.ticket.comment.body = feedback.Comment;
                        creatTiket.ticket.priority = "normal";
                        creatTiket.ticket.subject = "Test_CloudTips_Test";
                        creatTiket.ticket.tags = new string[2] {(feedback?.PlaceExternalId ?? ""),"api"};
                        creatTiket.ticket.custom_fields.rating = feedback?.Rating?.Score ?? 0;
                        creatTiket.ticket.custom_fields.NumberPlace = feedback?.PlaceExternalId ?? "";//Добавляет Id заведений 
                        creatTiket.ticket.custom_fields.InvoceId = feedback?.InvoiceId ?? "";// Добавляет номер счёта
                        new ApiRequestZendesk(token, email).PostRequest(url, creatTiket);
                        LogginInDB(feedback.Id, feedback.Date, feedback.Comment);
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
