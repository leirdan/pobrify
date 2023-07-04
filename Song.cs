using System;

namespace pobrify
{
    class Song
    {
        public int Id { get; }
        public string Title { get; set; }

        public Song(int id, string title)
        {
            Id = id;
            Title = title;
            
        }

    }
}
