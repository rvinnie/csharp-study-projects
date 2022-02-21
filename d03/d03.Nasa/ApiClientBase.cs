using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;

namespace d03.Nasa
{
    public abstract class ApiClientBase
    {
        private static readonly HttpClient HttpClient;

        static ApiClientBase()
        {
            HttpClient = new HttpClient();
        }

        protected string _apiKey;

        protected ApiClientBase(string apiKey)
        {
            _apiKey = apiKey;
        }
        
        protected async Task<T> HttpGetAsync<T>(string url)
        {
            var httpResponse = await HttpClient.GetAsync($"{url}api_key={_apiKey}");
            httpResponse.EnsureSuccessStatusCode();
            T? desirializedObject = JsonSerializer.Deserialize<T>(httpResponse.ToString());
            if (desirializedObject == null)
                throw new HttpRequestException();
            return desirializedObject;
        }
    }
}
