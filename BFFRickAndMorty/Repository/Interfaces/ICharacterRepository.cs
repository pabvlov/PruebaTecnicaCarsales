using BFFRickAndMorty.Models;

namespace BFFRickAndMorty.Repository.Interfaces
{
    public interface ICharacterRepository
    {
        Task<List<Character>> GetCharactersByIdsAsync(IEnumerable<int> ids);
    }

}