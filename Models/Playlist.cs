using Microsoft.EntityFrameworkCore;
using System;

namespace pobrify
{
    public class Playlist
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
        public string Length
        {
            get { return Length; }

            set {
                // this.Length += value;
            }
        }

        public string Owner { get; set; }
    }
}
