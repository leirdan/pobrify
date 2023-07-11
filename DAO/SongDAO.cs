using System;
using System.Collections.Generic;
using System.Linq;

namespace pobrify.DAO
{
    internal class SongDAO : IDisposable, IDAO<Song>
    {
        protected PobrifyContext con = new PobrifyContext();

        public SongDAO() { }

        public List<Song> Index()
        {
            return con.Songs.ToList();
        }
        public void Update(int id, Song n)
        {
            var s = con.Songs.Find(id);
            s.Title = n.Title;
            s.Length = n.Length;
            s.Artist = n.Artist;
            s.AlbumId = n.AlbumId;
            con.Songs.Update(s);
            con.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Song GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Song entity)
        {
            throw new NotImplementedException();
        }

        public void AddMany(params Song[] entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Song entity, int id)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteMany(params Song[] entities)
        {
            throw new NotImplementedException();
        }
    }
}
