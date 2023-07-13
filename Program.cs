using pobrify.Extensions;
using System;
using pobrify.Utils;
using pobrify.Controllers;
using pobrify.DAO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Win32;
using pobrify.Models;

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
                    // Relacionamento 1:1 - por limitações, um usuário só pode criar uma playlist, e uma playlist só pode ser criada por um usuário.
                    var user = new User("leirdan", "leirdan@hotmail.com");
                    con.Users.Add(user); 
                    con.SaveChanges();
                    var p = new Playlist(title: "wizard music", userId: user.Id);
                    con.Playlist.Add(p);
                    con.SaveChanges();

                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ID de um objeto inexistente. ");
                }
            }
        }
        static void ManyToMany()
        {
            // Relacionamento N:N - Músicas-Playlists
            /* PASSOS PARA CRIAR UM REGISTRO DE UM RELACIONAMENTO N:N
             * 1. criar as songs
             * 2. criar uma instância de uma playlist
             * 3. adicionar cada uma das songs desejadas dentro dessa instância
                * isso se dá a partir de um método que cria um novo objeto PlaylistSong e associa uma música a uma playlist
             * 4. salvar as inserções na playlist newMetal 
             * assim, é esperado que, ao selecionar os registros da tabela "playlistsong" sejam exibidos os registros que as relacionam.
             */
            using (var con = new PobrifyContext())
            {

                var songs = con.Songs.ToList();
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Title);
                }

                var newMetal = con.Playlist.Find(2);
                Console.WriteLine(newMetal.Title);
                foreach (var i in songs)
                {
                    newMetal.AddSongs(i);
                }
                //con.Playlist.Add(newMetal); -gera erro pois newMetal é uma playlist que já existe e o ID não pode mudar
                con.SaveChanges();
            }
        }
        static void Algorithm()
        {
            using (var con = new PobrifyContext())
            {
                if (con.Songs.ToList().Count <= 0)
                {
                    Console.WriteLine("You haven't insert any songs yet.");
                }
                else
                {
                    Console.WriteLine("These are the current songs you have added: ");
                    foreach (var i in con.Songs.ToList())
                    {
                        Console.Write(i.Title + " (ID:" + i.Id + ") | ");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("Do you wanna make an insert on db?");
                var opc = Console.ReadLine().ToLower();
                if (opc == "y" || opc == "yes")
                {

                    Console.WriteLine("How many songs do you wanna insert?");
                    int range = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Insert their info below:");
                    Console.WriteLine("The 1º song: ");
                    for (int i = 0; i < range; i++)
                    {
                        Console.Write("Title: ");
                        var j = Console.ReadLine();
                        Console.Write("Artist: ");
                        var a = Console.ReadLine();
                        Console.Write("Length: ");
                        var l = Console.ReadLine();
                        //Console.Write("");
                        var song = new Song(j, a, l);
                        con.Songs.Add(song);
                        con.SaveChanges();
                        Console.WriteLine($"Now, the {i + 2}º song: ");
                    }
                    Console.WriteLine("Now, there's your database: ");
                    foreach (var i in con.Songs.ToList())
                    {
                        Console.Write(i.Title + " (ID:" + i.Id + ") | ");
                    }
                }
                Console.WriteLine("These are the playlists:");
                foreach (var i in con.Playlist.ToList())
                {
                    Console.WriteLine(i.Title);
                }

                Console.WriteLine("Thanks!");
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

