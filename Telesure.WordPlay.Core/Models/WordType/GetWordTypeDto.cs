using System.ComponentModel.DataAnnotations.Schema;

namespace Telesure.WordPlay.Core.Models.WordType
{
    public class GetWordTypeDto : BaseWordTypeDto, IBaseDto
    {
        public int Id { get; set; }
    }
}
