using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d03.Nasa
{
    abstract class ApiClientBase
    {
        protected string _apiKey;
        protected ApiClientBase(string apiKey)
        {
            _apiKey = apiKey;
        }

        protected void HttpGetAsync<T>(string url)
        {
        }

    }
}
