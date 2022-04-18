using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore.DataApi
{
    internal class RequestTransactions
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string PlaceId { get; set; }
        public string LayoutId { get; set; }
        public string PhoneNumber { get; set; }
        public string TransactionId { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
