using System;
using System.Linq;

namespace pobrify
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome. Will you add songs, an album or create a new playlist? ( 1 / 2 / 3)");
                var opt = Convert.ToInt32(Console.ReadLine());  
                if (opt == 1)
                {
                }
                else if (opt == 2)
                {
                }
                else if (opt == 3)
                {
                }

                Console.Write("Insert the number of songs: ");
                int limit = Convert.ToInt32(Console.ReadLine());
                SongsList songs = new SongsList(limit);
                Console.WriteLine("Now, you need to insert the all the songs title one by one.");

                for (int i = 0; i < limit; i++)
                {
                    string name = Console.ReadLine();
                    // Utiliza o método "set" do indexador.
                    songs[i] = new Song(songs._size + 1, name);
                }

                songs.ListSongs();
                Console.Write("do you wanna edit a song, remove or find one by its id? (options: 1, 2, 3): ");
                var opt = Convert.ToInt32(Console.ReadLine());
                if (opt == 1)
                {
                    Console.Write("Insert an id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    songs.EditSong(id);
                    Console.WriteLine("Wanna list all the current songs?");
                    var op = Console.ReadLine();
                    if (op == "s" || op == "y")
                    {
                        songs.ListSongs();
                    }
                }
                else if (opt == 2)
                {
                    Console.Write("Wanna delete by id or the last one? ");
                    string op = Console.ReadLine();
                    if (op == "id")
                    {
                        Console.WriteLine("How many songs will be deleted?");
                        int l = Convert.ToInt32(Console.ReadLine());    
                        Console.WriteLine("So insert the id(s): ");
                        int[] idens = new int[l];
                        for (int i = 0; i < l; i++)
                        {
                            int id = Convert.ToInt32(Console.ReadLine());
                            idens.SetValue(id, i);
                        }
                        Console.WriteLine(idens[0]);

                        songs.RemoveSong(idens);
                        songs.ListSongs();
                    }
                    else if (op == "last")
                    {
                        songs.RemoveSong();
                        songs.ListSongs();
                    }
                }
                else if (opt == 3)
                {
                    Console.Write("insert the id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var song = songs.FindSong(id);
                    Console.WriteLine($"the song you are looking is '{song.Title}'!");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e) 
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ParamName);
            }

            Console.ReadLine();

            /*
            FirstArray();
            Url(); 
            */
        }

        static void FirstArray()
        {
            // Declara um array com um tamanho fixo
            string[] songs = new string[]
            {
                "in the dark",
                "drugs and love",
                "a blaze in the northern sky",
                "the deathless sun",
                "it's nice to have a friend"
            };
            Console.WriteLine("fav songs:");
            for (int i = 0; i < songs.Length; i++)
            {
                Console.WriteLine(" - " + songs[i]);
            }

            Console.Write("insert the limit of albums: ");
            int limit = Convert.ToInt32(Console.ReadLine());
            string[] albums = new string[limit];
            for (int j = 0; j < limit; j++)
            {
                var a = Console.ReadLine();
                albums[j] = a;
            };
            Console.WriteLine("favorite albums are:");
            for (int k = 0; k < albums.Length; k++)
            {
                Console.WriteLine(albums[k]);
            }
            Console.ReadLine();
        }

        static void Url()
        {
            try
            {
                string url = "https://open.spotify.com/intl-pt/tRaCk/2JWP3EPVXHxnYatwaWkf08&si=36f88f89fcce4fcd";
                var formatter = new URLFormatter(url);
                var id = formatter.GetID(url);
                Console.WriteLine($"O id é: {id}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ParamName);
            }

            Console.ReadLine();
        }
    }
}

