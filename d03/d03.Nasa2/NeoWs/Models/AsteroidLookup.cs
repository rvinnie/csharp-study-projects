using System.Text;
using System.Text.Json.Serialization;

namespace d03.Nasa.NeoWs.Models
{
    public class OrbitalClass
    {
        [JsonPropertyName("orbit_class_type")]
        public string? Type { get; set; }
        
        [JsonPropertyName("orbit_class_description")]
        public string? Description { get; set; }
    }

    public class OrbitalData
    {
        [JsonPropertyName("orbit_class")]
        public OrbitalClass? OrbitalClass { get; set; }
    }


    public class AsteroidLookup
    {
        [JsonPropertyName("neo_reference_id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("nasa_jpl_url")]
        public string? Url { get; set; }

        [JsonPropertyName("is_potentially_hazardous_asteroid")]
        public bool IsHazardous { get; set; }

        [JsonPropertyName("orbital_data")]
        public OrbitalData? OrbitalData { get; set; }

        public override string ToString()
        {
            string ret = $"- Asteroid {Name}, SPK-ID:{Id}\n";
            if (IsHazardous)
                ret += "IS POTENTIALLY HAZARDOUS!\n";
            ret += $"Classification: {OrbitalData?.OrbitalClass?.Type},\n";
            ret += $"{OrbitalData?.OrbitalClass?.Description}.\nUrl: {Url}\n";
            return ret;
        }
    }
}
