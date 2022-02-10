using System.Text.Json.Serialization;
using d02_ex00;

namespace d02_ex00.Model
{
    public class Movie : ISearchable
    {
        public MediaType Media { get; set; } = MediaType.Movie;

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("mpaa_rating")]
        public string? Rating { get; set; }

        [JsonPropertyName("critics_pick")]
        public int IsCriticsPick { get; set; }

        [JsonPropertyName("summary_short")]
        public string? SummaryShort { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        public override string ToString()
        {
            string? answer = "- " + Title;
            if (IsCriticsPick == 1)
                answer += $" [NYT critic's pick]";
            answer += $"\n{SummaryShort}\n{Url}\n";
            return answer;
        }
    }
}
