using System.ComponentModel.DataAnnotations.Schema;

namespace Telesure.WordPlay.Core.Models.Sentence
{
    public class GetSentenceDto : BaseSentenceDto, IBaseDto
    {
        public int Id { get; set; }
    }
}
