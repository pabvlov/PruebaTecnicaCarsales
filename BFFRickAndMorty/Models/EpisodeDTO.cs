namespace BFFRickAndMorty.Models
{
    public class EpisodeDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AirDate { get; set; }
        public string EpisodeCode { get; set; }
        public List<Character> Characters { get; set; } = new();
        public string Url { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}