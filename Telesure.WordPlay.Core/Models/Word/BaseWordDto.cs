using System.ComponentModel.DataAnnotations;

namespace Telesure.WordPlay.Core.Models.Word
{
    public abstract class BaseWordDto
    {
        [Required]
        public string? Name { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int WordTypeId { get; set; }
    }
}
