using MigrateReviewsCore.Data;
using System;

namespace MigrateReviewsCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var urlAuthorizatiom = "https://identity-sandbox.cloudtips.ru/connect/token";
            var urlFeed = "https://api-sandbox.cloudtips.ru/api/feedbacks?Limit=5";
            //var test = new TestZendeskApi();
            //test.GenerationToken();
            //test.ztest();
            var name = "v.piskov@coffeemania.ru";
            var password = "dkYnjkdkjd77";
            var f = new Feedbacks()
            {
                //DateFrom = "2022-04-01T13:34:52.086Z",
                //DateTo = "2022-04-30T13:34:52.086Z",
                limit = "222",
                //page = 1
            };
            
            var getFeedback = new MigrateFeedbacks(urlAuthorizatiom, urlFeed, name, password);
            Console.WriteLine(getFeedback.GetFeedbackCloudTips());
            
            var zentesko = new ApiRequestZendesk("vjW2dfbHWJWlDBtcNKp8GgaGCIL95WOvLdVDkmws", "a.yakovleva@coffeemania.ru");

        }
    }
}
