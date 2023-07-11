using System;
using System.Collections.Generic;
using System.Linq;

namespace pobrify.DAO
{
    internal class AlbumDAO : IDAO<Album>
    {
        protected PobrifyContext con = new PobrifyContext();

        public AlbumDAO() { }

        public List<Album> Index()
        {
            if (con.Albums.ToList().Count <= 0)
            {
                throw new ArgumentNullException("list of albums is null.");
            }
            return con.Albums.ToList();
        }
        public Album GetByID(int id)
        {
            var a = con.Albums.Find(id);
            return a == null ? throw new ArgumentNullException(nameof(id)) : a;
        }
        public void Add(Album a)
        {
            con.Albums.Add(a);
            con.SaveChanges();
        }
        public void AddMany(params Album[] albums)
        {
            con.Albums.AddRange(albums);
            con.SaveChanges();
        }
        public void Delete(Album a)
        {
            con.Albums.Remove(a);
            con.SaveChanges();
        }

        public void Update(Album entity, int id)
        {
            Album a = con.Albums.Find(id);
            a.Genre = entity.Genre;
            a.Artist = entity.Artist;
            a.Year = entity.Year;
            a.Title = entity.Title;
            con.Albums.Update(a);
            con.SaveChanges();
        }

        public void Delete()
        {
            var a = con.Albums.Last();
            con.Albums.Remove(a);
            con.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var a = con.Albums.Find(id);
            con.Albums.Remove(a);
            con.SaveChanges();
        }

        public void DeleteAll()
        {
            List<Album> albums = con.Albums.ToList();
            foreach(var item in albums)
            {
                con.Albums.Remove(item);
            }
            con.SaveChanges();
        }

        public void DeleteMany(params Album[] entities)
        {
            foreach(var item in entities)
            {
                con.Albums.Remove(item);
            }
            con.SaveChanges();
        }
    }
}
