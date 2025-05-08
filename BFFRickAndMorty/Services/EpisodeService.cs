using BFFRickAndMorty.Models;
using BFFRickAndMorty.Repository;
using BFFRickAndMorty.Services.Interfaces;

namespace BFFRickAndMorty.Services
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;

        public EpisodeService(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        public async Task<List<Episode>> GetAllEpisodesAsync()
        {
            return await _episodeRepository.GetAllEpisodesAsync();
        }

        public async Task<Episode?> GetEpisodeByIdAsync(int id)
        {
            return await _episodeRepository.GetEpisodeByIdAsync(id);
        }

        public async Task<List<Episode>> GetPagedEpisodesAsync(int page)
        {
            return await _episodeRepository.GetPagedEpisodesAsync(page);
        }
    }
}