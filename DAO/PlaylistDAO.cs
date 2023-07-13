using pobrify.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace pobrify.Controllers
{
    public class PlaylistDAO : IDisposable, IDAO<Playlist>
    {
        protected PobrifyContext con = new PobrifyContext();

        public PlaylistDAO() { }

        public List<Playlist> Index()
        {
            if (con.Playlist.ToList().Count <= 0) { }
            return con.Playlist.ToList();
        }
        public Playlist GetByID(int id)
        {
            var p = con.Playlist.Find(id);
            return p == null ? throw new ArgumentNullException(nameof(id)) : p;
        }

        public void Add(Playlist entity)
        {
            con.Playlist.Add(entity);
            con.SaveChanges();
        }

        public void AddMany(params Playlist[] plays)
        {
            con.Playlist.AddRange(plays);
            con.SaveChanges();
        }

        public void Update(Playlist entity, int id)
        {
            Playlist p = con.Playlist.Find(id);
            p.Owner = entity.Owner;
            p.Length = entity.Length;
            p.Title = entity.Title;
            con.Playlist.Update(p);
            con.SaveChanges();
        }

        public void Delete()
        {
            Playlist p = con.Playlist.Last();
            con.Playlist.Remove(p);
            con.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Playlist p = con.Playlist.Find(id);
            con.Playlist.Remove(p);
            con.SaveChanges();
        }

        public void DeleteAll()
        {
            List<Playlist> p = con.Playlist.ToList();
            foreach (var item in p)
            {
                con.Playlist.Remove(item);
            }
            con.SaveChanges();
        }

        public void DeleteMany(params Playlist[] entities)
        {
            Playlist[] p = entities;
            foreach (var item in p)
            {
                con.Playlist.Remove(item);
            }
            con.SaveChanges();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
