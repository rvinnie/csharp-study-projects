using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using d03.Nasa.Apod;
using d03.Nasa.Apod.Models;

namespace d03.Host
{
    class Program
    {
        public static async Task launchApod(string apiKey, int count)
        {
            var apodClient = new ApodClient(apiKey);
            try
            {
                var medias = await apodClient.GetAsync(count);
                foreach (var media in apodClient.GetAsync(count).Result)
                    Console.WriteLine(media + "\n");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void launchNeoWs(string apiKey, int count)
        {

        }

        public static async Task Main(string[] args)
        {
            if (args.Count() != 2)
            {
                Console.WriteLine("Wrong number of arguments.");
                return;
            }
            if (args[0] != "apod" && args[1] != "neows")
            {
                Console.WriteLine("Wrong first argument.");
                return;
            }
            if (!int.TryParse(args[1], out int count) || count < 1)
            {
                Console.WriteLine("Wrong second argument.");
                return;
            }

            try
            {
                IConfiguration configuration;
                configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json")
                                .Build();
                string apiKey = configuration["ApiKey"];
                if (args[0] == "apod")
                {
                    await launchApod(apiKey, int.Parse(args[1]));
                }
                else
                {
                    //await launchNeoWs(apiKey, int.Parse(args[1]));

                }
            }
            catch (IOException)
            {
                Console.WriteLine("Configuration file is not found");
            }
            
        }
    }
}
