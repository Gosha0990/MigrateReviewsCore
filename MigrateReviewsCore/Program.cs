using MigrateReviewsCore.Data;
using System;

namespace MigrateReviewsCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var uriAuthorizatiom = "https://identity-sandbox.cloudtips.ru/connect/token";
            //var uriCreationRecipient = "https://api-sandbox.cloudtips.ru/api/receivers";
            //var uriCreatinPlaces = "https://api-sandbox.cloudtips.ru/api/places";            
            //var uriListRec = "https://api-sandbox.cloudtips.ru/api/receivers/pages";
            //var uriFeed = "https://api-sandbox.cloudtips.ru/api/feedbacks";
            var listRecPlace = "https://api-sandbox.cloudtips.ru/api/places/62543127a84a2c26a9f81788/employees";
            //var uriAttachEmployees = " https://api-sandbox.cloudtips.ru/api/places/62543127a84a2c26a9f81788/employees/attach-one";
            var query = new ApiRequestCloudTips();
            query.Authorization(uriAuthorizatiom, "v.piskov@coffeemania.ru", "dkYnjkdkjd77");
            var places = new Places()
            { 
                Name ="CoffeeTest"
            };
            var recipient = new Recipient()
            {
                PhoneNumber = "+79998882233",
                Name = "Gosha",
            };
            var feedBack = new Feedbacks()
            {
                Limit = 1
            };
            var emp = new Employees()
            {
                PlaceId = "62543127a84a2c26a9f81788"
            };
            Console.WriteLine(query.GetRequest(listRecPlace, emp));
            //Console.WriteLine(query.CreationPostRequest(uriAttachEmployees,attachEmp));
            //Console.WriteLine(query.CreationPostRequest(recipient, uriCreationRecipient));
          }
    }
}
