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
            var url = $"{_baseUrl}/api/Activities";
            var activitiesList = await _client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<List<ActivityModel>>(activitiesList);
            return result;
        }
    }
}
