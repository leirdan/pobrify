using pobrify.Models;
using System;
using System.Collections.Generic;

namespace pobrify
{
    public class Song
    {
        public Song() { }

        public Song(string title, int artistId, int albumId, string length)
        {
            Title = title;
            ArtistId = artistId;
            Length = length;
            AlbumId = albumId;
        }
        public Song(string title, int artistId, int albumId)
        {
            Title = title;
            ArtistId = artistId;
            AlbumId = albumId;
        }
        public Song(string title, int artistId)
        {
            Title = title;
            ArtistId = artistId;
        }
        public Song(string title)
        {
            Title = title;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public string Length { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public IList<PlaylistSong> Playlists { get; set; }

    }
}
