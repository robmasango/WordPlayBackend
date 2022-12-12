using Telesure.WordPlay.Core.Models.Word;
using Telesure.WordPlay.Data;

namespace Telesure.WordPlay.Core.Contracts
{
    public interface IWordsRepository : IGenericRepository<Word>
    {
        Task<List<WordDto>> GetWordsByWordTypeId(int wordtype);
    }
}
