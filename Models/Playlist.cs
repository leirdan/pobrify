using Microsoft.EntityFrameworkCore;
using pobrify.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace pobrify
{
    public class Playlist
    {
        private int _id;

        public Playlist(string title, string length, string owner)
        {
            Title = title;
            Length = length;
            Owner = owner;
        }

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
        public string Length { get; set; }

        public string Owner { get; set; }

        public IList<PlaylistSong> Songs { get; set; }
    }
}
