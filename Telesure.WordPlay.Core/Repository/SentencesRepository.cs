using AutoMapper;
using Telesure.WordPlay.Core.Contracts;
using Telesure.WordPlay.Data;

namespace Telesure.WordPlay.Core.Repository
{
    public class SentencesRepository : GenericRepository<Sentence>, ISentencesRepository
    {
        public SentencesRepository(WordPlayDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
