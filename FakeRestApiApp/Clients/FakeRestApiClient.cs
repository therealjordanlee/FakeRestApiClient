using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FakeRestApiApp.Models;
using Newtonsoft.Json;

namespace FakeRestApiApp.Clients
{
    public class FakeRestApiClient
    {
        private const string BaseUrl = "https://fakerestapi.azurewebsites.net";
        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new FakeRestAPI client
        /// </summary>
        public FakeRestApiClient()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("User-Agent", "jordanlee.net");
        }

        /// <summary>
        /// Returns a list of all Activities
        /// </summary>
        public async Task<List<ActivityModel>> GetActivitiesAsync()
        {
            var url = $"{BaseUrl}/api/Activities";
            var activitiesList = await _client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<List<ActivityModel>>(activitiesList);
            return result;
        }

        /// <summary>
        /// Returns an Activity based on Id
        /// </summary>
        /// <param name="id">The Id of the Activity</param>
        public async Task<ActivityModel> GetActivityAsync(int id)
        {
            var url = $"{BaseUrl}/api/Activities/{id.ToString()}";
            var activity = await _client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<ActivityModel>(activity);
            return result;
        }

        /// <summary>
        /// Creates a new Activity
        /// </summary>
        /// <param name="activity">Activity to create</param>
        public async Task<HttpResponseMessage> PostActivityAsync(ActivityModel activity)
        {
            var url = $"{BaseUrl}/api/Activities";
            var content = new StringContent(activity.ToString(), Encoding.UTF8, "application/json");
            var result = await _client.PostAsync(url, content);
            return result;
        }

        /// <summary>
        /// Deletes an Activity based on Id
        /// </summary>
        /// <param name="id">Id of the Activity to delete</param>
        public async Task<HttpResponseMessage> DeleteActivityAsync(int id)
        {
            var url = $"{BaseUrl}/api/Activities/{id.ToString()}";
            var result = await _client.DeleteAsync(url);
            return result;
        }
    }
}
