using System.Text.Json;
using BFFRickAndMorty.Models;
using BFFRickAndMorty.Repository.Interfaces;

namespace BFFRickAndMorty.Repository
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly HttpClient _http;
        private readonly ICharacterRepository _characterRepository;

        public EpisodeRepository(HttpClient http, ICharacterRepository characterRepository)
        {
            _http = http;
            _characterRepository = characterRepository;
        }

        public async Task<List<Episode>> GetAllEpisodesAsync()
        {
            var response = await _http.GetFromJsonAsync<EpisodeResponse>("https://rickandmortyapi.com/api/episode");

            if (response?.Results is null)
                return new List<Episode>();

            return response.Results.ToList();
        }

        public async Task<Episode?> GetEpisodeByIdAsync(int id)
        {
            var url = $"https://rickandmortyapi.com/api/episode/{id}";
            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var episode = JsonSerializer.Deserialize<Episode>(json);

            if (episode == null)
                return null;

            var characterIds = episode.CharacterUrls
                .Select(u => u.Split('/').Last())
                .Where(idStr => int.TryParse(idStr, out _))
                .Select(int.Parse);

            episode.Characters = await _characterRepository.GetCharactersByIdsAsync(characterIds);

            return episode;
        }

        public async Task<List<Episode>> GetPagedEpisodesAsync(int page)
        {
            var url = $"https://rickandmortyapi.com/api/episode?page={page}";
            var response = await _http.GetFromJsonAsync<EpisodeResponse>(url);

            if (response?.Results == null) return new List<Episode>();

            return response.Results.ToList();
        }
    }
}

