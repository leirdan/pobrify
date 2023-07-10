using System;
using System.Collections.Generic;
using System.Linq;

namespace pobrify.Controllers
{
    public class PlaylistController : IDisposable
    {
        protected PobrifyContext Context { get; set; }
        public PlaylistController C { get; }

        public PlaylistController(PobrifyContext context)
        {
            Context = context;
        }

        public PlaylistController(PobrifyContext context, PlaylistController c) : this(context)
        {
            C = c;
        }

        public void AddSongsToPlaylist(Song song)
        {
            this.Context.Songs.Add(song);
            Context.SaveChanges();
            Console.WriteLine("Added!");
        }
        public List<Song> GetSongsOnPlaylist()
        {
            var songs = Context.Songs.ToList();
            if (songs == null || songs.Count == 0)
            {
                Console.WriteLine("the db doesn't have any songs..");
            }
            foreach (Song song in songs)
            {
                Console.WriteLine($"ID: {song.Id}, '{song.Title}' by {song.Artist}.");
            }
            return songs;
        }
        public void DeleteSongOnPlaylist(int id)
        {
            //using (var context = new PobrifyContext())
            var songs = new List<Song>();
            var s = Context.Songs.Find(id);
            songs.Add(s);
            Context.Songs.RemoveRange(songs);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
