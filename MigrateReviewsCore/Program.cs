using System;
using System.Text.Json;

namespace MigrateReviewsCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var query = new ReviewCloudTips();
            var recipient = new Recipient()
            {
                PhoneName = "+79998887766",
                Name = "Persona",
                Email = "person@email.ru",
                Type = 0,
                Placeid = "Depo",
                SendPassword = true,
                VerifyPhone = true
            };

            Console.WriteLine(query.Authorization());
            Console.WriteLine(query.CreaterRecipient(recipient));
            Console.WriteLine();
        }
    }
}
