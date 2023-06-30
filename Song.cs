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

        public static bool VerifyId(int id)
        {
            if (id <= 0)
            {
                return false;
                throw new ArgumentOutOfRangeException("ID não deve ser menor que 1!", nameof(id));
            }
            return true;
        }

    }
}
