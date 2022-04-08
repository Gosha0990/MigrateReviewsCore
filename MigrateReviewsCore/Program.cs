using System;
using System.Text.Json;

namespace MigrateReviewsCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var uri1 = "https://identity-sandbox.cloudtips.ru/connect/token";
            var uri2 = "https://api-sandbox.cloudtips.ru/api/receivers";
            Console.WriteLine("Hello World!");
            var t = new int[] { };
            var query = new ReviewCloudTips();
            var recipient = new Recipient()
            {
                PhoneName = "+79998887766",
                Name = "Persona",
                Email = "person@email.ru",
                Type = "0",
                Placeid = "Depo",
                SendPassword = true,
                VerifyPhone = true
            };
            Console.WriteLine(query.Authorization(uri1, "v.piskov@coffeemania.ru", "dkYnjkdkjd77"));
            Console.WriteLine(query.CreaterRecipient(recipient,uri2));
            Console.WriteLine();
        }
    }
}
