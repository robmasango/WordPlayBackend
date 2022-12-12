using System.ComponentModel.DataAnnotations.Schema;

namespace Telesure.WordPlay.Data
{
    public class Word
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [ForeignKey(nameof(WordTypeId))]
        public int WordTypeId { get; set; }
        public WordType? WordType { get; set; }
    }
}
