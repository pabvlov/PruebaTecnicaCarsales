using BFFRickAndMorty.Models;

namespace BFFRickAndMorty.Repository
{
    public interface IEpisodeRepository
    {
        Task<List<Episode>> GetAllEpisodesAsync();
        Task<Episode?> GetEpisodeByIdAsync(int id);
        Task<List<Episode>> GetPagedEpisodesAsync(int page);
    }
}