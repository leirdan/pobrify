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
            using (var c = new PobrifyContext())
            {
                try
                {
                    var album = c.Albums.Find(1);
                    var song = new Song(title: "Better Than Revenge", artist: album.Artist, "3:37", album.Id);

                    c.Songs.Add(song);
                    c.SaveChanges();
                    Console.WriteLine("Added!");
                    Console.ReadLine();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ID de um objeto inexistente. ");
                }
            }
        }
        static void Old()
        {

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

