using System;
using FakeRestApiApp.Clients;
using FakeRestApiApp.Models;
using Newtonsoft.Json;

namespace FakeRestApiApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new FakeRestApiClient();

            Console.WriteLine("Listing all Activities");
            Console.WriteLine("=====================");
            var activities = client.GetActivitiesAsync().Result;
            activities.ForEach(i =>
            {
                Console.WriteLine($"{i.Id} {i.Title} {i.DueDate} {i.Completed}");
            });

            Console.WriteLine("");
            Console.WriteLine("Getting Activity with Id 1");
            Console.WriteLine("=====================");
            var activity1 = client.GetActivityAsync(1).Result;
            Console.WriteLine($"{JsonConvert.SerializeObject(activity1)}");


            Console.WriteLine("");
            Console.WriteLine("Creating new Activity");
            Console.WriteLine("=====================");
            var dummyActivity = new ActivityModel
            {
                Id = 123,
                Title = "Cool stuff",
                DueDate = DateTime.Now,
                Completed = false
            };

            var postResult = client.PostActivityAsync(dummyActivity).Result;
            Console.WriteLine($"Result: {postResult.StatusCode}");

            Console.WriteLine("");
            Console.WriteLine("Deleting Activity with Id 1");
            Console.WriteLine("=====================");
            var deleteResult = client.DeleteActivityAsync(1).Result;
            Console.WriteLine($"Result: {deleteResult.StatusCode}");

            Console.ReadKey();
        }
    }
}
