using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using d03.Nasa.Apod;
using d03.Nasa.Apod.Models;
using System.Globalization;
using d03.Nasa.NeoWs;
using d03.Nasa.NeoWs.Models;

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
                {
                    Console.WriteLine(media);
                    Console.WriteLine();
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task launchNeoWs(string apiKey, int count, string startDate, string endDate)
        {
            try
            {
                var neoWsClient = new NeoWsClient(apiKey, count, startDate, endDate);
                var asteroids = await neoWsClient.GetAsync(neoWsClient.Request);
                foreach (var asteroid in asteroids)
                {
                    Console.WriteLine(asteroid);
                    Console.WriteLine();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong dates in configuration.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }

        public static async Task Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-GB", useUserOverride: false);

            if (args.Count() != 2)
            {
                Console.WriteLine("Wrong number of arguments.");
                return;
            }
            if (args[0] != "apod" && args[0] != "neows")
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
                string startDate = configuration["NeoWs:StartDate"];
                string endDate = configuration["NeoWs:EndDate"];
                string apiKey = configuration["ApiKey"];
                if (args[0] == "apod")
                {
                    await launchApod(apiKey, int.Parse(args[1]));
                }
                else
                {
                    await launchNeoWs(apiKey, int.Parse(args[1]), startDate, endDate);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Configuration file is not found");
            }
            
        }
    }
}
