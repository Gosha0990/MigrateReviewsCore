using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore
{
    internal class Recipient
    {
        public string PhoneName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public string Placeid { get; set; }
        public bool SendPassword { get; set; }
        public bool VerifyPhone { get; set; }
    }
}
