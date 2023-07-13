using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pobrify.Models
{
    public class Artist
    {
        public Artist() { }
        public Artist(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Song> Songs { get; set; }
        public IList<Album> Albums { get; set; }
        


    }
}
