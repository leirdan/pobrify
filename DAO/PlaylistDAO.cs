using System;
using System.Collections.Generic;
using System.Linq;

namespace pobrify.Controllers
{
    public class PlaylistController : IDisposable, IPlaylistDAO
    {
        protected PobrifyContext Context { get; set; }

        public PlaylistController()
        {
            Context = new PobrifyContext();
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
            return songs;
        }
        // não faz parte daqui, deve ser implementado em outro controller
        public void UpdateSong(int id, Song newSong)
        {
            var s = Context.Songs.Find(id);
            s.Length = newSong.Length;
            s.Title = newSong.Title;
            s.Artist = newSong.Artist;
            Context.Songs.Update(s);
            Context.SaveChanges();
        }

        public void DeleteSongOnPlaylist(int id)
        {
            try
            {
                var songs = new List<Song>();
                var s = Context.Songs.Find(id);
                songs.Add(s);
                Context.Songs.RemoveRange(songs);
                Context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("ID.");
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
