using System.Text.Json.Serialization;

namespace BFFRickAndMorty.Models
{
    public class Episode
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("air_date")]
        public string AirDate { get; set; }

        [JsonPropertyName("episode")]
        public string EpisodeCode { get; set; }

        [JsonPropertyName("characters")]
        public List<string> CharacterUrls { get; set; } = new();

        [JsonIgnore]
        public List<Character> Characters { get; set; } = new();

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("created")]
        public DateTimeOffset Created { get; set; }
    }
}
