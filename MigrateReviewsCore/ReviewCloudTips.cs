using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MigrateReviewsCore
{
    internal class ReviewCloudTips
    {
        public async void GetToken()
        {
            var client = new HttpClient();
            var value = new Dictionary<string, string>();
            value.Add("Grant_type", "password");
            value.Add("Client_id", "Partner");
            value.Add("UserName", "v.piskov@coffeemania.ru");
            value.Add("Password", "dkYnjkdkjd77");
            var content = new FormUrlEncodedContent(value);
            var response = await client.PostAsync("https://identity-sandbox.cloudtips.ru/connect/token", content);
            var responsString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responsString);
        }
        public string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjA3NkMyQ0Q2Rjk3REFBRERCNkFFMkVFOUY0Njc5RURENkFDQjA2QzAiLCJ0eXAiOiJhdCtqd3QiLCJ4NXQiOiJCMndzMXZsOXF0MjJyaTdwOUdlZTNXckxCc0EifQ.eyJuYmYiOjE2NDkyMzU5NTYsImV4cCI6MTY0OTIzNzc1NiwiaXNzIjoiaHR0cHM6Ly9pZGVudGl0eS1zYW5kYm94LmNsb3VkdGlwcy5ydSIsImF1ZCI6WyJBcGkiLCJJZGVudGl0eUFQSSJdLCJjbGllbnRfaWQiOiJQYXJ0bmVyIiwic3ViIjoiODQyOWRiYzctZDUwNy00OGNjLWI4YzktNzEwY2U0OTE5NDA5IiwiYXV0aF90aW1lIjoxNjQ5MjM1OTU2LCJpZHAiOiJsb2NhbCIsInJvbGUiOiJNQU5BR0VSIiwiRnVsbE5hbWUiOiLQn9C40YHQutC-0LIg0JLQu9Cw0LTQuNC80LjRgCDQutC-0YTQtdC80LDQvdC40Y8iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidi5waXNrb3ZAY29mZmVlbWFuaWEucnUiLCJNYW5hZ2VyVHlwZSI6IkFnZW50Iiwic2NvcGUiOlsiZW1haWwiLCJvcGVuaWQiLCJwaG9uZSIsInByb2ZpbGUiLCJyb2xlcyIsImFwaSIsIklkZW50aXR5QVBJIiwib2ZmbGluZV9hY2Nlc3MiXSwiYW1yIjpbInB3ZCJdfQ.rMqWyDlGokXQRKhQ4rEEUc6W5fCHCqbXXU98mN05mxRnJyus_3IbktzuAQJHqcJQGJrZV2CEd6C4YU764tQNyrimgl6SqAzEO5l-wdRG0mi0lD_nKm0TbpUobtNf1E29qK-RhCZtxAej11DInXqtFGdQRstw-lOecDZPn1EPyiOjvks9_889Wn3JueB6HYDdih4Ff4yf9ZnHUNVhXDEWRAofWYsgkFtJgN4cv8K9a2lvFdDolejUzzUHIek8wyMWt29yy9ANNGLPFGFQ9sb_GDz3SdqHfmemUe4xY7_6nmiy4SvrSKSaRJqq7jdf0GKIt6MqYFMFWQPt7J8BTMDnnA";
        public async void CreateUser()
        {
            var client = new WebClient();

        }
    }
}
