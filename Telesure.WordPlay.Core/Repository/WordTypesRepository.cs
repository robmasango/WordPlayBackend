using AutoMapper;
using AutoMapper.QueryableExtensions;
using Telesure.WordPlay.Core.Contracts;
using Telesure.WordPlay.Core.Exceptions;
using Telesure.WordPlay.Core.Models.WordType;
using Telesure.WordPlay.Data;
using Microsoft.EntityFrameworkCore;

namespace Telesure.WordPlay.Core.Repository
{
    public class WordTypesRepository : GenericRepository<WordType>, IWordTypesRepository
    {
        private readonly WordPlayDbContext _context;
        private readonly IMapper _mapper;

        public WordTypesRepository(WordPlayDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<WordTypeDto> GetDetails(int id)
        {
            var WordType = await _context.WordTypes.Include(q => q.Words)
                .ProjectTo<WordTypeDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (WordType == null)
            {
                throw new NotFoundException(nameof(GetDetails), id);
            }

            return WordType;
        }

        public async Task<WordTypeDto> GetWordTypesByName(string name)
        {

            var WordType = await _context.WordTypes
                .ProjectTo<WordTypeDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Name == name);

            if (WordType == null)
            {
                throw new NotFoundException(nameof(GetDetails), name);
            }

            return WordType;
        }

    }
}
