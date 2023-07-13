using System;
using Microsoft.EntityFrameworkCore;
using pobrify.Models;

namespace pobrify
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Artist Artist { get; set; }
        public int ArtistId { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public Album() { }
        public Album(string title)
        {
            Title = title;
        }
        public Album(string title, int artistId)
        {
            Title = title;
            ArtistId = artistId;
        }
        public Album(string title, int artistId, int year, string genre)
        {
            Title = title;
            ArtistId = artistId;
            Year = year;
            Genre = genre;
        }

        // Herdado da interface IPobrifyObject, a qual herda a interface IComparable.
        // Útil para definir uma comparação personalizada.
        public int CompareTo(object obj)
        {
            // < 0: instância precede o obj
            // == 0: obj e instância são equivalentes
            // > 0: obj precede a instância
            try
            {
                var album = obj as Album; // conversão por "as" indica que, se a conversão não for possível, "album" será nulo.

                if (album == null)
                {
                    return -1;
                }

                if (this.Id < album.Id)
                {
                    return -1;
                }
                else if (this.Id > album.Id)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Parâmetro com erro", e.ParamName);
            }
            return 0;
        }
    }
}
