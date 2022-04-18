using MigrateReviewsCore.DataApi;
using Newtonsoft.Json;
using System;

namespace MigrateReviewsCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var name = "v.piskov@coffeemania.ru";
            var password = "dkYnjkdkjd77";
            var feedback = new MigrateFeedbacks(name, password);
            feedback.GetFeedbackCloudTips();
            var fe = feedback.Feedbacks;

            var result = feedback.SetFeedBacksZendeskAndDb("vjW2dfbHWJWlDBtcNKp8GgaGCIL95WOvLdVDkmws", "a.yakovleva@coffeemania.ru", "https://coffeemania.zendesk.com/api/v2/tickets.json");
            Console.WriteLine(result);

        }
    }
}
