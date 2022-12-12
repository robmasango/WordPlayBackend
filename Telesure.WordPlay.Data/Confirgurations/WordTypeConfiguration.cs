using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Telesure.WordPlay.Data.Confirgurations
{
    public class WordTypeConfiguration : IEntityTypeConfiguration<WordType>
    {
        public void Configure(EntityTypeBuilder<WordType> builder)
        {
            builder.HasData(
                new WordType
                {
                    Id = 1,
                    Name = "Noun",
                },
                new WordType
                {
                    Id = 2,
                    Name = "Verb",
                },
                new WordType
                {
                    Id = 3,
                    Name = "Adjective",
                },
                new WordType
                {
                    Id = 4,
                    Name = "Adverb",
                },
                new WordType
                {
                    Id = 5,
                    Name = "Pronoun",
                },
                new WordType
                {
                    Id = 6,
                    Name = "Preposition",
                } ,
                new WordType
                {
                    Id = 7,
                    Name = "Conjunction",
                },
                new WordType
                {
                    Id = 8,
                    Name = "Determiner",
                },
                new WordType
                {
                    Id = 9,
                    Name = "Exclamation",
                }
            );
        }
    }
}
