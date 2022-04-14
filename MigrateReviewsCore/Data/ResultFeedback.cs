﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore.Data
{
    [Serializable]
    internal class ResultFeedback
    {
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
        [Newtonsoft.Json.JsonProperty("comment")]
        public string Comment { get; set; }
        //public string rating { get; set; }
        //public int score { get; set; }

        [Newtonsoft.Json.JsonProperty("components")]
        public string components { get; set; }
        //public string id { get; set; }
        //public string title { get; set; }
        //public bool selected { get; set; }
        //public int transactionId { get; set; }
        //public int totalCount { get; set; }
        //public string succeed { get; set; }
        //public string[] errors { get; set; }
        //public string[] validationErrors { get; set; }
    }
}