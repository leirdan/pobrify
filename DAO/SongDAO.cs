using System.Collections.Generic;
using System.Linq;

namespace pobrify.DAO
{
    internal class SongDAO
    {
        protected PobrifyContext Context { get; }

        public SongDAO()
        {
            Context = new PobrifyContext();
        }

        public List<Song> Index()
        {
            return Context.Songs.ToList();
        }
        public void Create(Song s)
        {
            Context.Songs.Add(s);
            Context.SaveChanges();
        }
        public void Update(int id, Song n)
        {
            var s = Context.Songs.Find(id);
            s.Title = n.Title;
            s.Length = n.Length;
            s.Artist = n.Artist;
            Context.Songs.Update(n);
            Context.SaveChanges();
        }

    }
}
