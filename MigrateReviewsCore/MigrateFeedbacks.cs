using MigrateReviewsCore.Data;
using System.Collections.Generic;

namespace MigrateReviewsCore
{
    internal class MigrateFeedbacks
    {
        private string _urlAutorization = "https://identity-sandbox.cloudtips.ru/connect/token";
        private string _urlFeedback = "https://api-sandbox.cloudtips.ru/api/feedbacks?Limit=";
        private string _nameAuthorization;
        private string _passwordAuthorization;
        public List<string> Feedbacks { get; set; }        
        public MigrateFeedbacks(string nameAuthorization, string passwordAuthorization, int limit)
        {   
            
           _urlFeedback = _urlFeedback + limit.ToString();
            _nameAuthorization = nameAuthorization;
            _passwordAuthorization = passwordAuthorization;
        }
        public void GetFeedbackCloudTips()
        {
            var cloudTips = new ApiRequestCloudTips();
            cloudTips.Authorization(_urlAutorization, _nameAuthorization, _passwordAuthorization);
            var jsonfeedbacks = cloudTips.GetRequest(_urlFeedback);
            Feedbacks = GetListFeedbacks(jsonfeedbacks);            
        }
        public string SetFeedBacksZendesk(string token, string email, string url)
        {
            var zendesk = new ApiRequestZendesk(token, email);
            var body = new Comment();             
            var comment = new Tickets()
            {
                comment = body,
                priority = "urgent",
                subject = "Test"
            };
            var tiket = new CreationTeket() 
            {
                ticket = comment
            };
            foreach (var feedback in Feedbacks)
            {
                body.body = feedback;
                //zendesk.CreationPostRequest(url, tiket);                
            }
            return "";    
        }
        private List<string> GetListFeedbacks(string json)
        {
            string[] arrayJson = json.Split('"');
            List<string> list = new List<string>();
            for (int i = 0; i < arrayJson.Length; i++)
            {
                if (arrayJson[i] == "comment")
                {
                    i += +2;
                    list.Add(arrayJson[i]);
                }
            }
            return list;
        }
        
    }
}
