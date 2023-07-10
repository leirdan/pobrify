using pobrify.Extensions;
using System;
using pobrify.Utils;
using pobrify.Controllers;

namespace pobrify
{
    class Program
    {
        static void Main(string[] args)
        {
            PobrifyContext context = new PobrifyContext();
            using (var c = new PlaylistController(context))
            {
                //var s = new Song(title: "All that", artist: "Zayn", length: "3:21");
                //var s2 = new Song(title: "Savage", artist: "Megan thee Stallion", length: "2:35");
                //c.AddSongsToPlaylist(s2);

                c.GetSongsOnPlaylist();
                c.DeleteSongOnPlaylist(3);
                c.GetSongsOnPlaylist();

                Console.ReadLine();
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
                            SongsController.Start();
                            break;

                        case "album":
                            AlbumsController.Start();
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

