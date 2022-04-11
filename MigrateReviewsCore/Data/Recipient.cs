using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore
{
    [Serializable]
    internal class Recipient
    {
        //обязательное
        public string PhoneNumber { get; set; }
        //обязательное
        public string Name { get; set; }
        //необязательное
        public string Email { get; set; }
        //необязательное
        public string Type { get; set; }
        //необязательное
        public string Placeid { get; set; }
        //необязательное
        public bool SendPassword { get; set; }
        //необязательное
        public bool VerifyPhone { get; set; }
    }
}
