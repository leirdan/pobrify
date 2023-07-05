using System;
using System.Collections.Generic;

namespace pobrify
{
    class Program
    {
        static void Main(string[] args)
        {
            // IMPLEMENTAR OS METODOS DE MANIPULACAO DE ALBUM, MUSICA E PLAYLIST
            try
            {
                Console.Write("Hey there! Will you add songs, an album or create a new playlist? (song / alb / play) ");
                var opt = Console.ReadLine();
                do
                {
                    if (opt == "song")
                    {
                        SongsAlg();
                    }
                    else if (opt == "alb")
                    {
                        AlbumsAlg();
                    }
                    else if (opt == "play")
                    {
                    }
                } while (!ExitProgram());
            }
            catch (Exception)
            {

            }
        }
        public static bool ShouldContinue()
        {
            Console.WriteLine("Do you want to continue? (yes / no)");
            string res = Console.ReadLine();
            return res.ToLower() == "yes";
        }
        public static bool ExitProgram()
        {
            Console.WriteLine("Do you want to finish this program? (yes / no)");
            string res = Console.ReadLine();
            return res.ToLower() == "yes";
        }

        // Utiliza a classe List do .NET
        public static bool AlbumsAlg()
        {
            try
            {
                // Lista que contém valores do tipo Album
                List<Album> albumsList = new List<Album>();
                Console.WriteLine("Insert how many albums will be stored: ");
                int limit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Now, you need to insert the all the albums title one by one.");
                
                Album[] temp = new Album[limit];

                for (int i = 0; i < limit; i++)
                {
                    var title = Console.ReadLine();
                    temp.SetValue(new Album(i + 1, title), i);
                }

                // Sem o método de extensão -> ListExtensions.AddMany(albumsList, temp);
                albumsList.AddMany(temp); // Com método de extensão; adiciona diretamente na lista.
                foreach (var album in albumsList)
                {
                    Console.WriteLine(album.Title);
                }
            }
            catch (Exception e)
            {

            }
            return true;
        }
        // Utiliza uma classe personalizada, PobrifyList
        public static bool SongsAlg()
        {
            try
            {
                PobrifyList<Song> songsList = new PobrifyList<Song>();
                Console.Write("Insert the amount of songs you will add: ");
                int limit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Now, you need to insert the all the songs title one by one.");
                for (int i = 0; i < limit; i++)
                {
                    var title = Console.ReadLine();
                    songsList[i] = new Song(songsList._size + 1, title);
                }
                Console.WriteLine("You added the following songs: ");
                songsList.Index();
                int ret = 0;
                do
                {
                    bool res = SongsOperations(songsList);
                    if (res == true)
                    {
                        ret = 1;
                        break;
                    };
                } while (ShouldContinue() && ret == 0);
                return true;
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
            return true;
        }
        protected static bool SongsOperations(PobrifyList<Song> list)
        {
            do
            {
                Console.Write("Do you wanna edit a song, delete or find one by its id? (edit / del / find): ");
                var opt = Console.ReadLine();
                switch (opt)
                {
                    case "edit":
                        Console.Write("Insert the id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var oldSong = list.FindById(id);
                        Console.Write($"You will alter the song '{oldSong.Title}'. Insert the new title: ");
                        var title = Console.ReadLine();
                        list.Edit(id, title);
                        break;
                    case "del":
                        Console.Write("How many songs do you want to delete by id? ");
                        int limit = Convert.ToInt32(Console.ReadLine());
                        int[] idens = new int[limit];
                        if (limit.ToString() == "" || limit.ToString() == " " || limit.Equals(null) || limit == 0)
                        {
                            // Remove o último da lista
                            // Está falhando!!
                            //idens.SetValue(0, 0);
                            //list.Delete(idens);
                        }
                        else
                        {
                            Console.Write("So insert the id(s): ");
                            for (int i = 0; i < limit; i++)
                            {
                                int currentId = Convert.ToInt32(Console.ReadLine());
                                idens.SetValue(currentId, i);
                            }
                            list.Delete(idens);
                        }
                        break;
                    case "find":
                        Console.Write("Insert the id: ");
                        int idF = Convert.ToInt32(Console.ReadLine());
                        var s = list.FindById(idF);
                        Console.WriteLine($"the song you are looking for is '{s.Title}'!");
                        break;

                    default:
                        break;
                }
            } while (ShouldContinue());

            // Diz que os procedimentos já foram concluídos aqui.
            return true;
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

