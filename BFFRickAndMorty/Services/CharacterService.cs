using BFFRickAndMorty.Models;
using BFFRickAndMorty.Repository.Interfaces;
using BFFRickAndMorty.Services.Interfaces;

namespace BFFRickAndMorty.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<List<Character>> GetCharactersByIdsAsync(IEnumerable<int> ids)
        {
            return await _characterRepository.GetCharactersByIdsAsync(ids);
        }
    }
}