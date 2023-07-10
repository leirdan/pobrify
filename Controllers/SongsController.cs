using pobrify.Utils;
using System;

namespace pobrify.Controllers
{
    public class SongsController
    {
        public static bool Start()
        {
            try
            {
                PobrifyList<SongContext> songsList = new PobrifyList<SongContext>();
                Console.Write("Insert the amount of songs you will add: ");
                int limit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Now, you need to insert the all the songs title one by one.");
                for (int i = 0; i < limit; i++)
                {
                    var title = Console.ReadLine();
                    songsList[i] = new SongContext(songsList._size + 1, title);
                }
                Console.WriteLine("You added the following songs: ");
                songsList.Index();
                int ret = 0;
                do
                {
                    bool res = Operations(songsList);
                    if (res == true)
                    {
                        ret = 1;
                        break;
                    };
                } while (Continue.ShouldContinue() && ret == 0);
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

        static bool Operations(PobrifyList<SongContext> list)
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
            } while (Continue.ShouldContinue());

            // Diz que os procedimentos já foram concluídos aqui.
            return true;
        }
    }
}
