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
            using (var con = new PobrifyContext())
            {
                try
                {
                    var playlist = new Playlist("new metal", "6", "leirdan");
                    //playlist.Songs.Add(new Song());

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

