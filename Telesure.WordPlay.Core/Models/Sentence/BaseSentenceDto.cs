using System.ComponentModel.DataAnnotations;

namespace Telesure.WordPlay.Core.Models.Sentence
{
    public abstract class BaseSentenceDto
    {
        [Required]
        public string? Phrase { get; set; }
        
    }
}
