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
        private const string _baseUrl = "https://fakerestapi.azurewebsites.net";
        private HttpClient _client;

        public FakeRestApiClient()
        {
            _client = new HttpClient();
        }

        public async Task<List<ActivityModel>> GetActivitiesAsync()
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders
                .Add("User-Agent","jordanlee.net");

            var url = $"{_baseUrl}/api/Activities";
            var activitiesList = await _client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<List<ActivityModel>>(activitiesList);
            return result;
        }

        public async Task<HttpResponseMessage> PostActivityAsync(ActivityModel activity)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders
                .Add("User-Agent", "jordanlee.net");

            var url = $"{_baseUrl}/api/Activities";
            var content = new StringContent(activity.ToString(), Encoding.UTF8, "application/json");
            var result = await _client.PostAsync(url, content);
            return result;
        }

        public async Task<HttpResponseMessage> DeleteActivityAsync(int id)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders
                .Add("User-Agent", "jordanlee.net");

            var url = $"{_baseUrl}/api/Activities/{id.ToString()}";
            var result = await _client.DeleteAsync(url);
            return result;
        }
    }
}
