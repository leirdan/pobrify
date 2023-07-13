using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pobrify.Models
{
    public class User
    {
        public User() { }
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public User(string name, string email, Playlist p)
        {
            Name = name;
            Email = email;
            Playlist = p;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Playlist Playlist { get; set; }
    }
}
