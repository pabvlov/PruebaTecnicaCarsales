using BFFRickAndMorty.Models;

namespace BFFRickAndMorty.Services.Interfaces
{
    public interface IEpisodeService
    {
        Task<List<Episode>> GetAllEpisodesAsync();
        Task<Episode?> GetEpisodeByIdAsync(int id);
        Task<List<Episode>> GetPagedEpisodesAsync(int page);
    }
}