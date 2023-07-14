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
        public DbSet<Artist> Artists { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
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

            modelBuilder
                .Entity<Artist>()
                .HasMany(e => e.Songs)
                .WithOne(e => e.Artist)
                .HasForeignKey(e => e.ArtistId)
                .IsRequired();

            modelBuilder
                .Entity<Artist>()
                .HasMany(e => e.Albums)
                .WithOne(e => e.Artist)
                .HasForeignKey(e => e.ArtistId)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
