using System;

namespace pobrify
{
    class Song : IPobrifyObject
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

        public Song(int id, string title)
        {
            Id = id;
            Title = title;
        }

    }
}
