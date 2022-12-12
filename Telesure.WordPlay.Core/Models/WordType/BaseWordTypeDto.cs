using System.ComponentModel.DataAnnotations;

namespace Telesure.WordPlay.Core.Models.WordType
{
    public abstract class BaseWordTypeDto
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
