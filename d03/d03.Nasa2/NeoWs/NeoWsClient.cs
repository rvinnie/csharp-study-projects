using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using d03.Nasa.NeoWs.Models;
using d03.Nasa;

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
                StartDate = DateTime.Parse(startDate),
                EndDate = DateTime.Parse(endDate),
                ResultCount = count
            };
        }

        private string FormUrl(AsteroidRequest input, string urn)
        {
            return $"{urn}?start_date={input.StartDate}&end_date={input.EndDate}&api_key={_apiKey}";
        }
        public async Task<AsteroidLookup[]> GetAsync(AsteroidRequest request)
        {
            string NeoFeedUrl = FormUrl(request, NeoFeedUrn);
            var NeoFeedResponse = await HttpGetAsync< Dictionary<DateTime, AsteroidInfo> >(NeoFeedUrl);
            var asteroidInfoList = NeoFeedResponse?
                                .Values
                                .OrderBy(asteroid => asteroid.CloseData?[0].kilometers)
                                .Take(request.ResultCount)
                                .ToList();
            return await Task.WhenAll(asteroidInfoList.Select(asteroid =>
                            HttpGetAsync<AsteroidLookup>($"{urn}{asteroid.Id}?api_key={_apiKey}")));

        }

    }
}
