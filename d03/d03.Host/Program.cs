using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using d03.Nasa.Apod; 

namespace d03.Host
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {                 
                IConfiguration configuration;
                configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json")
                                .Build();
                string ApiKey = configuration["ApiKey"];

                var apodClient = new ApodClient(ApiKey);

                Console.WriteLine(ApiKey);
            }
            catch (IOException)
            {
                Console.WriteLine("Configuration file is not found");
            }
            
        }
    }
}
