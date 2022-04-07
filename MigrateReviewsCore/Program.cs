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
            Console.WriteLine(query.Authorization());
            Console.WriteLine(query.CreateUser());
        }
    }
}
