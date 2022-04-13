using MigrateReviewsCore.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore
{
    internal class MigrateFeedbacks
    {
        private string _urlAutorization;
        private string _urlFeedback;
        private string _nameAuthorization;
        private string _passwordAuthorization;
        private object _request;
        public MigrateFeedbacks(string uriAutorization, string uriFeedbac, string nameAuthorization, string passwordAuthorization)
        { 
            _urlAutorization = uriAutorization;
            _urlFeedback = uriFeedbac;
            _nameAuthorization = nameAuthorization;
            _passwordAuthorization = passwordAuthorization;
            //_request = request;

        }
        public string GetFeedbackCloudTips()
        {
            var cloudTips = new ApiRequestCloudTips();
            cloudTips.Authorization(_urlAutorization, _nameAuthorization, _passwordAuthorization);
            var jsonfeedbacks = cloudTips.GetRequest(_urlFeedback);
            var listFeedback = JsonConvert.DeserializeObject<List<ResultFeedback>>(jsonfeedbacks);
            return jsonfeedbacks;
        }
        
    }
}
