using System.Text.Json.Serialization;

namespace BFFRickAndMorty.Models
{
    public class EpisodeResponse
    {
        [JsonPropertyName("info")]
        public Info Info { get; set; }
        [JsonPropertyName("results")]
        public List<Episode>? Results { get; set; }
    }

    public class Info
    {
        [JsonPropertyName("count")]
        public long Count { get; set; }

        [JsonPropertyName("pages")]
        public long Pages { get; set; }

        [JsonPropertyName("next")]
        public Uri Next { get; set; }

        [JsonPropertyName("prev")]
        public Uri Prev { get; set; }
    }
}
