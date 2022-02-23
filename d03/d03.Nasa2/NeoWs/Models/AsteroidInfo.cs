using System.Text.Json.Serialization;

namespace d03.Nasa.NeoWs.Models
{
    public class CloseApproach
    {
        [JsonPropertyName("miss_distance")]
        public MissDistance? MissDistance { get; set; }
    }

    public class MissDistance
    {
        [JsonPropertyName("kilometers")]
        public double Kilometers { get; set; }
    }

    public class AsteroidInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        public double? Kilometers => CloseData?[0].MissDistance?.Kilometers;

        [JsonPropertyName("close_approach_data")]
        public List<CloseApproach>? CloseData { get; set; }
    }
}
