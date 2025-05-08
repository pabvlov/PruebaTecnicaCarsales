using BFFRickAndMorty.Models;

namespace BFFRickAndMorty.Services.Interfaces
{
    public interface ICharacterService
    {
        Task<List<Character>> GetCharactersByIdsAsync(IEnumerable<int> ids);
    }
}