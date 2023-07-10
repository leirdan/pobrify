using Microsoft.EntityFrameworkCore;

namespace pobrify
{
    public class PobrifyContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<Album> Albums { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=pobrify;Trusted_Connection=true;");
        }
    }
}
