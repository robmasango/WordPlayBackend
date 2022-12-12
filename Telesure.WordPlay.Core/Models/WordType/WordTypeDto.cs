using Telesure.WordPlay.Core.Models.Word;

namespace Telesure.WordPlay.Core.Models.WordType
{
    public class WordTypeDto : BaseWordTypeDto, IBaseDto
    {
        public int Id { get; set; }

        public List<WordDto>? Words { get; set; }
    }
}
