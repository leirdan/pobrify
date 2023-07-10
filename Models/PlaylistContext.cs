using Microsoft.EntityFrameworkCore;

namespace pobrify
{
    // Utiliza o Entity framework por meio da classe DbContext
    public class PlaylistContext : DbContext
    {
        public DbSet<SongContext> Songs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=pobrify;Trusted_Connection=true;");
                //.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = pobrify; " +
                //"Integrated Security = True; Connect Timeout = 30; Encrypt = False; " +
                //"Trust Server Certificate = False;" +
                //"Application Intent = ReadWrite; Multi Subnet Failover = False");
            // "Server=(localdb)\\mssqllocaldb;Database=pobrify;Trusted_Connection=true;"
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (VerifyId.Verify(value))
                {
                    _id = value;
                };
            }
        }
        public string Title { get; set; }
    }
}
