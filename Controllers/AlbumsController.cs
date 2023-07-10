using pobrify.Extensions;
using pobrify.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pobrify.Controllers
{
    public class AlbumsController
    {
        // Utiliza a classe List do .NET
        public static bool Start()
        {
            try
            {
                // Lista que contém valores do tipo Album
                List<AlbumContext> albumsList = new List<AlbumContext>();
                Console.Write("How many albums do you want to store? ");
                var limit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Now, you need to insert the all the albums title, one by one.");

                AlbumContext[] temp = new AlbumContext[limit];

                for (var i = 0; i < limit; i++)
                {
                    var title = Console.ReadLine();
                    temp.SetValue(new AlbumContext(i + 1, title), i);
                }

                // Sem o método de extensão -> ListExtensions.AddMany(albumsList, temp);
                // Com método de extensão; adiciona diretamente na lista.
                albumsList.AddMany(temp);
                // Não é necessário informar o tipo <Album> entre <> após a chamada do método pois o .NET infere que o tipo é o mesmo do objeto que está o chamando. 

                /*
                ORDER BY -
                    Método que itera sobre um conjunto de dados. A expressão passada como argumento, neste caso,
                    entrega ao método um elemento "album", e o método retornará o atributo título desse elemento.
                    O código após a "=>" pode ser tanto uma linha quanto um bloco de código inteiro; a esse conjunto
                    damos o nome "expressão lambda".
                    O método tem a seguinte definição:
                    "static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)"
                    Ou seja, adaptando para nosso caso:
                    - é um método genérico do tipo IOrderedEnumerable (que contém elementos do tipo "Album");
                    - recebe como parâmetros um elemento do tipo Album e retorna uma string (título do Album).
                 
                 * é possível reescrever as duas instruções abaixo:
                    IEnumerable<Album> nonNull = albumsList.Where(i => i != null);
                    IOrderedEnumerable<Album> res = nonNull.OrderBy(album => album.Title);
                    da seguinte forma:
                 */

                var res = albumsList
                    .Where(i => i != null) // Filtragem apenas de álbuns válidos
                    .OrderBy(album => album.Title); // Ordenação por ordem alfabética

                Console.WriteLine("You added the following albums: ");
                foreach (var album in res)
                {
                    Console.WriteLine($"{album.Title}, ID: {album.Id}");
                }
                int r = 0;
                do
                {
                    var ret = Operations(albumsList);
                    if (ret == true)
                    {
                        r = 1;
                        break;
                    }
                } while (Continue.ShouldContinue() && r == 0);
                return true;
            }
            catch (Exception e)
            {

            }
            return true;
        }

        static bool Operations(List<AlbumContext> list)
        {
            do
            {
                Console.WriteLine("Do you wanna edit an album, list one or delete it?");
                var opt = Console.ReadLine().ToLower();
                try
                {

                    switch (opt)
                    {
                        case "list":
                            Console.Write("Insert the title of the album: ");
                            var entry = Console.ReadLine();
                            var album = list.Find(i => i.Title == entry);
                            Console.WriteLine($"The album you're looking have the id {album.Id}! ");
                            break;

                        case "edit":
                            Console.Write("So insert its id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            album = list.Find(i => i.Id == id);
                            Console.Write("Insert the album's new title: ");
                            var title = Console.ReadLine();
                            album.Title = title;
                            Console.WriteLine($"The album is now '{album.Title}'! ");

                            break;

                        case "del":
                            Console.Write("Do you want to delete how many albums?");
                            int l = Convert.ToInt32(Console.ReadLine());
                            if (l > 1)
                            {
                                Console.WriteLine("So insert the ids: ");
                                for (int i = 0; i < l; i++)
                                {
                                    id = Convert.ToInt32(Console.ReadLine());
                                    album = list.Find(a => a.Id == id);
                                    list.Remove(album);
                                }
                            }
                            else
                            {
                                list.RemoveAt(list.Count - 1);
                            }
                            Console.WriteLine("These are the current albums: ");
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.Title}, ID: {item.Id}");
                            }
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception) { }

            } while (Continue.ShouldContinue());
            return true;
        }

    }
}
