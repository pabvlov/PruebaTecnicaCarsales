using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BFFRickAndMorty.Models;
using BFFRickAndMorty.Repository.Interfaces;

namespace BFFRickAndMorty.Repository
{

    public class CharacterRepository : ICharacterRepository
    {
        private readonly HttpClient _http;

        public CharacterRepository(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Character>> GetCharactersByIdsAsync(IEnumerable<int> ids)
        {
            var idList = ids.ToList();

            if (idList.Count == 0)
                return new List<Character>();

            var joinedIds = string.Join(",", idList);
            var url = $"https://rickandmortyapi.com/api/character/{joinedIds}";

            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<Character>();

            var content = await response.Content.ReadAsStringAsync();

            if (content.TrimStart().StartsWith("["))
                return JsonSerializer.Deserialize<List<Character>>(content)!;
            else
                return new List<Character> { JsonSerializer.Deserialize<Character>(content)! };
        }
    }
}