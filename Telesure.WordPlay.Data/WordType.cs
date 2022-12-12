namespace Telesure.WordPlay.Data
{
    public class WordType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }


        public virtual IList<Word> Words { get; set; }
    }
}