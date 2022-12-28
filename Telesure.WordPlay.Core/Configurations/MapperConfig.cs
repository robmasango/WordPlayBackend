using AutoMapper;
using Telesure.WordPlay.Data;
using Telesure.WordPlay.Core.Models.WordType;
using Telesure.WordPlay.Core.Models.Word;
using Telesure.WordPlay.Core.Models.Sentence;

namespace Telesure.WordPlay.Core.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<WordType, CreateWordTypeDto>().ReverseMap();
            CreateMap<WordType, GetWordTypeDto>().ReverseMap();
            CreateMap<WordType, WordTypeDto>().ReverseMap();
            CreateMap<WordType, UpdateWordTypeDto>().ReverseMap();

            CreateMap<Word, CreateWordDto>().ReverseMap();
            CreateMap<Word, GetWordDto>().ReverseMap();
            CreateMap<Word, WordDto>().ReverseMap();
            CreateMap<Word, UpdateWordDto>().ReverseMap();

            CreateMap<Sentence, CreateSentenceDto>().ReverseMap();
            CreateMap<Sentence, GetSentenceDto>().ReverseMap();
            CreateMap<Sentence, SentenceDto>().ReverseMap();
            CreateMap<Sentence, UpdateSentenceDto>().ReverseMap();
        }
    }
}
