namespace BFFRickAndMorty.Models
{
    public class PagedEpisodeDTO
    {
        public List<EpisodeDTO> Results { get; set; } = new();
        public string? Next { get; set; }
        public string? Prev { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}