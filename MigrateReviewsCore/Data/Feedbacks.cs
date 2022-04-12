using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore.Data
{
    internal class Feedbacks
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string[] PlaceId { get; set; }
        public string PhoneNuber { get; set; }
        public string TransactionId { get; set; }
        public string UserId { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
