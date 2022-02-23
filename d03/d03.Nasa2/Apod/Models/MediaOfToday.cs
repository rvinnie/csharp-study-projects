using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace d03.Nasa.Apod.Models
{
    public class MediaOfToday
    {
        [JsonPropertyName("copyright")]
        public string? Copyright { get; set; }

        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("explanation")]
        public string? Explanation { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        public override string ToString()
        {
            return $"{Date}\n'{Title}' by {Copyright}\n{Explanation}\n{Url}";
        }
    }
}
