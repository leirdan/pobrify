using pobrify.Extensions;
using System;
using pobrify.Utils;
using pobrify.Controllers;
using pobrify.DAO;

namespace pobrify
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var c = new SongDAO())
            {
                try
                {
                    PobrifyContext con = new PobrifyContext();
                    var album = new Album(title: "Speak Now - TV", "Taylor Swift", 2023, "Pop/Rock");
                    con.Albums.Add(album);
                    con.SaveChanges();
                    var song = new Song(title: "Foolish One", artist: album.Artist, "5:01", album.Id);

                    c.Create(song);
                    Console.WriteLine("Added!");
                    Console.ReadLine();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ID de um objeto inexistente. ");
                }
            }

            try
            {
                do
                {
                    Console.Write("Hey there! Will you add songs, an album or create a new playlist? (song / alb / play) ");
                    var opt = Console.ReadLine();

                    switch (opt)
                    {
                        case "song":
                            //SongsController.Start();
                            break;

                        case "album":
                            //AlbumsController.Start();
                            break;

                        case "play":
                            break;

                        default:
                            break;
                    }
                } while (!Exit.ExitProgram());
            }
            catch (Exception)
            {

            }
        }

    }
}

