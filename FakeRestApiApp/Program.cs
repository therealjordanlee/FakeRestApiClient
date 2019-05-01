using System;
using FakeRestApiApp.Clients;

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
        }
    }
}
