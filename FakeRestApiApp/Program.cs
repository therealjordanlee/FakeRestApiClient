using System;
using FakeRestApiApp.Clients;
using FakeRestApiApp.Models;

namespace FakeRestApiApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new FakeRestApiClient();
            var activities = client.GetActivitiesAsync().Result;
            activities.ForEach(i =>
            {
                Console.WriteLine($"{i.Id} {i.Title} {i.DueDate} {i.Completed}");
            });

            var dummyActivity = new ActivityModel
            {
                Id = 123,
                Title = "Cool stuff",
                DueDate = DateTime.Now,
                Completed = false
            };

            var postResult = client.PostActivityAsync(dummyActivity).Result;
            Console.WriteLine($"{postResult.StatusCode}");

            var deleteResult = client.DeleteActivityAsync(123).Result;
            Console.WriteLine($"{deleteResult.StatusCode}");

            Console.ReadKey();
        }
    }
}
