using System.ComponentModel.DataAnnotations.Schema;

namespace Telesure.WordPlay.Core.Models.Word
{
    public class GetWordDto : BaseWordDto, IBaseDto
    {
        public int Id { get; set; }
    }
}
