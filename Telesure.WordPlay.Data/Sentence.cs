using System.ComponentModel.DataAnnotations.Schema;

namespace Telesure.WordPlay.Data
{
    public class Sentence
    {
        public int Id { get; set; }
        public string? Phrase { get; set; }
    }
}
