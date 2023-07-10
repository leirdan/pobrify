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
            using (var c = new PlaylistController())
            {
                try
                {
                    //var s = new Song(title: "All that", artist: "Zayn", length: "3:21");
                    //var s2 = new Song(title: "Savage", artist: "Megan thee Stallion", length: "2:35");
                    //c.AddSongsToPlaylist(s2);

                    //c.DeleteSongOnPlaylist(3);
                    foreach (Song song in c.GetSongsOnPlaylist())
                    {
                        Console.WriteLine($"ID: {song.Id}, '{song.Title}' by {song.Artist}.");
                    }

                    var s3 = new Song("Conquer all", "Behemoth", "3:55");
                    c.UpdateSong(4, s3);

                    foreach (Song song2 in c.GetSongsOnPlaylist())
                    {
                        Console.WriteLine($"ID: {song2.Id}, '{song2.Title}' by {song2.Artist}.");
                    }

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

