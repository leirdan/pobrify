﻿using Microsoft.EntityFrameworkCore;
using pobrify.Models;
using System.Collections.Generic;

namespace pobrify
{
    public class Playlist
    {
        public Playlist()
        {
            this.Songs = new List<PlaylistSong>();
        }
        public Playlist(string title, int userId)
        {
            Title = title;
            UserId = userId;

            this.Songs = new List<PlaylistSong>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public IList<PlaylistSong> Songs { get; set; }

        public void AddSongs(Song s)
        {
            this.Songs.Add(new PlaylistSong() { Song = s });
            Length++;
        }
    }
}
