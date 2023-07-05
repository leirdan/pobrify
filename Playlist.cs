using System;
using System.Security.Cryptography;

namespace pobrify
{
    public class Playlist : IPobrifyObject
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (V.VerifyId(value))
                {
                    _id = value;
                };
            }
        }
        public string Title { get; set; }

        public int NumberOfSongs { get; set; }

        public Playlist(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
