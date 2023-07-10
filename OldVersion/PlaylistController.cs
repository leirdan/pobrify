/*
using System;
using System.Collections.Generic;
using System.Linq;

    public class PlaylistController : IDisposable, IPlaylistDAO
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
*/