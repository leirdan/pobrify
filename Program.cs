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
            var playlist = new PlaylistController();
            PlaylistController.InsertData();

            Console.ReadLine();

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

