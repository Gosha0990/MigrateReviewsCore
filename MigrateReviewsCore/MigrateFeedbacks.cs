using MigrateReviewsCore.Data;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MigrateReviewsCore
{
    internal class MigrateFeedbacks
    {
        private string _urlAutorization = "https://identity-sandbox.cloudtips.ru/connect/token";
        private string _urlFeedback = "https://api-sandbox.cloudtips.ru/api/feedbacks?Limit=";
        private string _nameAuthorization;
        private string _passwordAuthorization;
        
        public ResultFeedback[] Feedbacks { get; set; }        
        public MigrateFeedbacks(string nameAuthorization, string passwordAuthorization, string limit, string dateFrom)
        {
            _urlFeedback = string.Format($"https://api-sandbox.cloudtips.ru/api/feedbacks?Limit={limit}&DateFrom={dateFrom}");
            _nameAuthorization = nameAuthorization;
            _passwordAuthorization = passwordAuthorization;
        }
        public void GetFeedbackCloudTips()
        {
            var cloudTips = new ApiRequestCloudTips();
            cloudTips.Authorization(_urlAutorization, _nameAuthorization, _passwordAuthorization);
            var jsonfeedbacks = cloudTips.GetRequest(_urlFeedback);            
            Feedbacks = GetArrayFeedbacks(jsonfeedbacks);            
        }
        public string SetFeedBacksZendesk(string token, string email, string url)
        {
            var result = " ";
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
                //zendesk.PostRequest(url, tiket);
            }            
            return result;    
        }
        private ResultFeedback[] GetArrayFeedbacks(string json)
        {
            var dis = JsonConvert.DeserializeObject<DataF>(json);
            ResultFeedback[] res = dis.data.items;            
            return res;
        }
        
    }
}
