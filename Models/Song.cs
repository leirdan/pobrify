using System;

namespace pobrify
{
    public class Song : IPobrifyObject
    {
        private int _id;
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
        public string Artist { get; set; }
        public string Length { get; set; }

        // IMPLEMENTAR RELACIONAMENTO
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public Song() { }

        public Song(string title, string artist, string length, int albumId)
        {
            Title = title;
            Artist = artist;
            Length = length;
            AlbumId = albumId;
        }
        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }
        public Song(string title)
        {
            Title = title;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
