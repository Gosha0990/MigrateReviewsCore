using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore
{
    internal class MigrateFeedbacks
    {
        public string UriAutorization { get; set; }
        public string UriEmployees { get; set; }
        public string NameAuthorization { get; set; }
        public string PasswordAuthorization { get; set; }
        public string Migrate()
        {
            var cloudTips = new ApiRequestCloudTips();
            cloudTips.Authorization(UriAutorization,NameAuthorization,PasswordAuthorization);
            cloudTips.PostRequest("", "");
            cloudTips.GetRequest("", UriEmployees);
            var zendesk = new ApiRequestZendesk();
            return "Good";
        }
    }
}
