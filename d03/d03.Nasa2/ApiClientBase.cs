using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace d03.Nasa
{
    public abstract class ApiClientBase
    {
        private readonly HttpClient _httpClient;

        protected string _apiKey;

        protected ApiClientBase(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
        }

        protected async Task<T?> HttpGetAsync<T>(string url)
        {
            var httpResponse = await _httpClient.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
                return await httpResponse.Content.ReadFromJsonAsync<T>();

            var httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
            throw new HttpRequestException($"GET {url} returned {httpResponse.StatusCode}:\n{httpResponseBody}");
        }
    }
}
