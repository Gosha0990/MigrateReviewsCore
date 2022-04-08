using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore
{
    public class Token
    {
        public object access_token { get; set; }
        public string refresg_token { get; set; }
        public string expires_in { get; set; }
    }
}
