using MigrateReviewsCore.Data;
using System;

namespace MigrateReviewsCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var uri1 = "https://identity-sandbox.cloudtips.ru/connect/token";
            var uriCreationRecipient = "https://api-sandbox.cloudtips.ru/api/receivers";
            var uriCreatinPlaces = "https://api-sandbox.cloudtips.ru/api/places";
            var query = new ReviewCloudTips();
            var places = new Places()
            { 
                Name ="CoffeeTest"
            };
            var listrec = new ListRecipient()
            {
                Name = "Gosha"
            };
            var recipient = new Recipient()
            {
                PhoneNumber = "+79998882233",
                Name = "Gosha"
            };
            Console.WriteLine(query.Authorization(uri1, "v.piskov@coffeemania.ru", "dkYnjkdkjd77"));
            Console.WriteLine(query.CreationPostRequest(places, uriCreatinPlaces));
            //Console.WriteLine(query.CreationPostRequest(recipient, uriCreationRecipient));
            Console.WriteLine();
          }
    }
}
