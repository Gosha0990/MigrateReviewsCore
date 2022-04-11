using System;
using System.Collections.Generic;

namespace MigrateReviewsCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var uri1 = "https://identity-sandbox.cloudtips.ru/connect/token";
            var uri2 = "https://api-sandbox.cloudtips.ru/api/receivers";
            var query = new ReviewCloudTips();
            var type = new Dictionary<int, string>();
            type.Add(0, "Официант");
            var recipient = new Recipient()
            {
                PhoneNumber = "+79998882233",
                Name = "Gosha"
            };
            Console.WriteLine(query.Authorization(uri1, "v.piskov@coffeemania.ru", "dkYnjkdkjd77"));
            Console.WriteLine(query.CreaterRecipient(recipient, uri2));
            Console.WriteLine();
          }
    }
}
