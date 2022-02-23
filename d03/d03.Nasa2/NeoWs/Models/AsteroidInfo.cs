using System.Text.Json.Serialization;

namespace d03.Nasa.NeoWs.Models
{
    public class MissDistance
    {
        [JsonPropertyName("kilometers")]
        public double kilometers { get; set; }
    }

    public class AsteroidInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("close_approach_data")]
        public List<MissDistance>? CloseData { get; set; }
    }
}
