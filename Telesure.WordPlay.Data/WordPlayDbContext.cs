using Telesure.WordPlay.Data.Confirgurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Telesure.WordPlay.Data
{
    public class WordPlayDbContext : DbContext
    {
        public WordPlayDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Word> Words { get; set; }
        public DbSet<WordType> WordTypes { get; set; }
        public DbSet<Sentence> Sentences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new WordTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WordConfiguration());
            //modelBuilder.ApplyConfiguration(new SentenceConfiguration());
        }
    }
}
