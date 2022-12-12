using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Telesure.WordPlay.Data.Confirgurations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasData(
                new Word
                {
                    Id = 1,
                    Name = "He",
                    WordTypeId = 5,
                },
                new Word
                {
                    Id = 2,
                    Name = "Grudgingly",
                    WordTypeId = 4,
                },
                new Word
                {
                    Id = 3,
                    Name = "1Life",
                    WordTypeId = 1,
                }
            );
        }
    }
}
