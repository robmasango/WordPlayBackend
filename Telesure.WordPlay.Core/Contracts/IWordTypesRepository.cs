using Telesure.WordPlay.Core.Models.WordType;
using Telesure.WordPlay.Data;

namespace Telesure.WordPlay.Core.Contracts
{
    public interface IWordTypesRepository : IGenericRepository<WordType>
    {
        Task<WordTypeDto> GetDetails(int id);
        Task<WordTypeDto> GetWordTypesByName(string name);
    }
}
