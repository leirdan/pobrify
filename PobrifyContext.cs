using Microsoft.EntityFrameworkCore;
using pobrify.Models;

namespace pobrify
{
    // Utiliza o Entity framework por meio da classe DbContext
    public class PobrifyContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=pobrify;Trusted_Connection=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PlaylistSong>()
                .HasKey(e => new { e.SongId, e.PlaylistId });

            // Shadow property: UserId não existe na solução mas existe no banco
            modelBuilder
                .Entity<Playlist>()
                .Property<int>("UserId");

            base.OnModelCreating(modelBuilder);
        }
    }
}
