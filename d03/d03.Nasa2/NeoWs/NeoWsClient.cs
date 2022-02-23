using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using d03.Nasa.NeoWs.Models;
using d03.Nasa;
using System.Text.Json.Serialization;

namespace d03.Nasa.NeoWs
{
    public class NeoWsClient : ApiClientBase,
        INasaClient<AsteroidRequest, Task<AsteroidLookup[]>>
    {
        const string NeoFeedUrn = "https://api.nasa.gov/neo/rest/v1/feed";
        const string NeoLookupUrn = "https://api.nasa.gov/neo/rest/v1/neo";

        public AsteroidRequest Request { get; set; }

        public NeoWsClient(string apiKey, int count,
                            string startDate, string endDate): base(apiKey)
        {
            Request = new AsteroidRequest()
            {
                StartDate = startDate,
                EndDate = endDate,
                ResultCount = count
            };
        }

        public async Task<AsteroidLookup[]> GetAsync(AsteroidRequest request)
        {
            var NeoFeedResponse = await HttpGetAsync<InfoResponse>
                (
                    $"{NeoFeedUrn}?start_date={request.StartDate}&end_date={request.EndDate}&api_key={_apiKey}"
                );
            var asteroidInfoList = NeoFeedResponse?.Response?
                                .Values
                                .SelectMany(asteroid => asteroid)
                                .OrderBy(asteroid => asteroid.Kilometers)
                                .Take(request.ResultCount)
                                .ToList();
            if (asteroidInfoList == null)
                throw new ArgumentException("List of Asteroids is empty.");
            return await Task.WhenAll(asteroidInfoList.Select(asteroid =>
                            HttpGetAsync<AsteroidLookup>($"{NeoLookupUrn}/{asteroid.Id}?api_key={_apiKey}")));
        }

        public class InfoResponse
        {
            [JsonPropertyName("near_earth_objects")]
            public Dictionary<DateTime, List<AsteroidInfo>>? Response { get; set; }
        }
    }
}
