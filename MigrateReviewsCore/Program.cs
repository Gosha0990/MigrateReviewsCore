﻿using MigrateReviewsCore.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MigrateReviewsCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var name = "v.piskov@coffeemania.ru";
            var password = "dkYnjkdkjd77";

            var feedback = new MigrateFeedbacks(name, password, "5" , "2022-04-22");
            feedback.GetFeedbackCloudTips();
            var fe = feedback.Feedbacks;
            var result = feedback.SetFeedBacksZendesk("vjW2dfbHWJWlDBtcNKp8GgaGCIL95WOvLdVDkmws", "a.yakovleva@coffeemania.ru", "https://coffeemania.zendesk.com/api/v2/tickets.json");
            
            Console.WriteLine("");
        }
    }
}
