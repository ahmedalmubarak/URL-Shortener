using Microsoft.EntityFrameworkCore;
using URL_Shortener.Entities;
using URL_Shortener.Services;

namespace URL_Shortener.ApplicationDbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenedUrl>(builder =>
            {
                builder.Property(s => s.Code).HasMaxLength(UrlShorteningService._numberOfCharInShortLink);
                builder.HasIndex(s => s.Code).IsUnique();
            });
        }
    }
}
