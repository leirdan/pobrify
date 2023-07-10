using System;

namespace pobrify
{
    public class SongContext : IPobrifyObject
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

        public SongContext(string title)
        {
            Title = title;
        }
        public SongContext(int id, string title)
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
