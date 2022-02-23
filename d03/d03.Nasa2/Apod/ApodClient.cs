using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using d03.Nasa;
using d03.Nasa.Apod.Models;

namespace d03.Nasa.Apod
{
    public class ApodClient : ApiClientBase,
        INasaClient<int, Task<MediaOfToday[]>>
    {
        const string URL = "https://api.nasa.gov/planetary/apod";

        public ApodClient(string apiKey) : base(apiKey) { }

        public async Task<MediaOfToday[]> GetAsync(int ResultCount)
        {
            return await HttpGetAsync<MediaOfToday[]>($"{URL}?count={ResultCount}&api_key={_apiKey}")
                ?? throw new HttpRequestException("Bad ");
        }
    }
}
