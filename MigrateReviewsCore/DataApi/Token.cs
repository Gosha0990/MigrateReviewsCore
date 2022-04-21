using System;

namespace MigrateReviewsCore
{
    public class Token
    {
        public object access_token { get; set; }
        public string refresh_token { get; set; }
        public string expires_in { get; set; }
    }
}
