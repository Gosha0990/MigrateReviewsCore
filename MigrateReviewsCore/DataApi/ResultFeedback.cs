using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore.DataApi
{
    [Serializable]
    internal class DataF
    { 
        public Items data { get; set; }
    }
    internal class ItemsFeedback
    { 
        public ResultFeedback[] items { get; set; }
    }
    internal class ResultFeedback
    {
        public DateTime Date { get; set; }
        //public int Amount { get; set; }
        //public string UserId { get; set; }
        //public string UserPhoneNumber { get; set; }
        //public string userName { get; set; }
        //public string userExternalId { get; set; }
        //public string placeId { get; set; }
        //public string placeName { get; set; }
        //public string placeExternaslId { get; set; }
        //public string invoiceId { get; set; }
        //public string layoutId { get; set; }
        public string Comment { get; set; }
        //public string rating { get; set; }
        //public int score { get; set; }
        //public string components { get; set; }
        public string id { get; set; }
        //public string title { get; set; }
        //public bool selected { get; set; }
        //public int transactionId { get; set; }
        //public int totalCount { get; set; }
        //public string succeed { get; set; }
        //public string[] errors { get; set; }
        //public string[] validationErrors { get; set; }
    }
}
