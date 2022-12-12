using AutoMapper;
using AutoMapper.QueryableExtensions;
using Telesure.WordPlay.Core.Contracts;
using Telesure.WordPlay.Core.Models.Word;
using Telesure.WordPlay.Data;
using Microsoft.EntityFrameworkCore;
using Telesure.WordPlay.Core.Exceptions;

namespace Telesure.WordPlay.Core.Repository
{
    public class WordsRepository : GenericRepository<Word>, IWordsRepository
    {
        private readonly WordPlayDbContext _context;
        private readonly IMapper _mapper;

        public WordsRepository(WordPlayDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }


        public async Task<List<WordDto>> GetWordsByWordTypeId(int id)
        {
            var Words = await _context.Words.Include(q => q.WordType)
                .ProjectTo<WordDto>(_mapper.ConfigurationProvider)
                .Where(x => x.WordTypeId == id)
                .ToListAsync();

            if (Words == null)
            {
                throw new NotFoundException(nameof(GetWordsByWordTypeId), id);
            }

            return Words;
        }

    }
}

