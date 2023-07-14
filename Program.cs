using pobrify.Extensions;
using System;
using pobrify.Utils;
using pobrify.Controllers;
using pobrify.DAO;
using System.Linq;
using System.Collections.Generic;
using pobrify.Models;
using Microsoft.EntityFrameworkCore;

namespace pobrify
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var con = new PobrifyContext())
            {
                var tsSongs =
                    con
                    .Songs
                    .Where(e => e.Artist.Name == "Taylor Swift")
                    .ToList();
                foreach (var i in tsSongs)
                {
                    Console.WriteLine(i.Title);
                }
            }
            Console.WriteLine("=========");
            using (var conTwo = new PobrifyContext())
            {
                // Select com Join em um relacionamento 1:N (artista-músicas).
                var behemothSongs =
                    conTwo
                    .Songs
                    // Cada include e thenInclude avançam "um nível para baixo" no relacionamento
                    .Include(
                        e => e.Artist
                    ).Where(e => e.Artist.Id == 1016)
                    .ToList();

                foreach (var i in behemothSongs)
                {
                    Console.WriteLine(i.Title);
                }
            }
            Console.WriteLine("=========");
            using (var conThree = new PobrifyContext())
            {
                // Select com Join em um relacionamento 1:1 (user-playlist)
                var users =
                    conThree
                    .Users
                    .Include(u => u.Playlist)
                    .ToList();
                foreach (var i in users)
                {
                    Console.WriteLine($"user '{i.Name}' is the owner of playlist '{i.Playlist.Title}'.");
                }
            }
            Console.WriteLine("=========");
            using (var conFour = new PobrifyContext())
            {
                // Select com Join em um relacionamento N:N (músicas-playlists)
                var songsPlaylists =
                    conFour
                    .PlaylistSongs
                    .Include(s => s.Song)
                    .ThenInclude(a => a.Artist)
                    .Include(p => p.Playlist)
                    .ThenInclude(u => u.User)
                    .OrderBy(x => x.Song.Title)
                    .ToList();
                
                foreach (var i in songsPlaylists)
                {
                    Console.WriteLine($"The song '{i.Song.Title}' " +
                        $"by the artist '{i.Song.Artist.Name}' " +
                        $"belongs to playlist '{(i.Playlist.Title).ToUpper()}' " +
                        $"created by user '{i.Playlist.User.Name}'!");
                }
            }

        }
        static void Inserts()
        {
            using (var con = new PobrifyContext())
            {
                try
                {
                    var users = new List<User>()
                    {
                        new User("leirdan", "leirdan@hotmail.com"),
                        new User("bridges", "phbridges@outlook.com"),
                        new User("opsgabs", "gabb@gmail.com"),
                    };
                    con.Users.AddRange(users);
                    Console.WriteLine("Added the users.");

                    var artists = new List<Artist>()
                    {
                        new Artist(name: "Taylor Swift", description: "A wonderful composer."),
                        new Artist(name: "Pink Floyd", description: "Shine on you crazy diamonds."),
                        new Artist(name: "Immortal", description: "The sun no longer rises..."),
                        new Artist(name: "Zayn", description: "Nobody's listening"),
                        new Artist(name: "Behemoth", description: "Akephalos, shine through me...")
                    };
                    con.Artists.AddRange(artists);

                    Console.WriteLine("Added the artists.");

                    var albums = new List<Album>()
                    {
                        new Album("Speak Now - Taylor's Version", artists[0].Id, 2023, "Pop/Rock"),
                        new Album("Pure Holocaust", artists[2].Id, 1993, "Black Metal"),
                        new Album("Evangellion", artists[4].Id, 2009, "Blackened Death Metal"),
                        new Album("Icarus Falls", artists[3].Id, 2023, "Pop/R&B")
                    };
                    Console.WriteLine("Added the albums.");
                    con.Albums.AddRange(albums);

                    var songs = new List<Song>
                    {
                        new Song("Mine", artists[0].Id, albums[0].Id),
                        new Song("Long Live", artists[0].Id, albums[0].Id),
                        new Song("Foolish One", artists[0].Id, albums[0].Id),
                        new Song("Daimonos", artists[4].Id, albums[2].Id),
                        new Song("Ov Fire and the Void", artists[4].Id, albums[2].Id),
                        new Song("Defiling Morality ov Black God", artists[4].Id, albums[2].Id),
                        new Song("A Sign for the Norse Hordes to Ride", artists[2].Id, albums[1].Id),
                        new Song("Unsilient Storms in the North Abyss", artists[2].Id, albums[1].Id),
                        new Song("The Sun no Longer Rises", artists[2].Id, albums[1].Id),
                        new Song("Icarus Interlude", artists[3].Id, albums[3].Id),
                        new Song("Stand Still", artists[3].Id, albums[3].Id),
                        new Song("Dusk Till Dawn", artists[3].Id, albums[3].Id),
                    };
                    con.Songs.AddRange(songs);
                    Console.WriteLine("Added the songs.");

                    var playlists = new List<Playlist>
                    {
                        new Playlist(title: "behemothned death metal", userId: users[0].Id),
                        new Playlist("to have some random memories", userId: users[1].Id),
                        new Playlist("ts songs do to anything", userId: users[2].Id),
                    };
                    Console.WriteLine("got the playlists.");
                    con.Playlist.AddRange(playlists);
                    Console.WriteLine("Added the playlists.");

                    var behemothPlay = playlists[0];
                    var randomPlay = playlists[1];
                    var tSwiftPlay = playlists[2];

                    behemothPlay.AddSongs(songs[3]);
                    behemothPlay.AddSongs(songs[4]);
                    randomPlay.AddSongs(songs[11]);
                    randomPlay.AddSongs(songs[8]);
                    tSwiftPlay.AddSongs(songs[0]);
                    tSwiftPlay.AddSongs(songs[1]);
                    tSwiftPlay.AddSongs(songs[2]);

                    con.SaveChanges();

                    Console.WriteLine("Added the songs to playlists. It's working now.");

                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ID de um objeto inexistente. ");
                }
            }
        }
        static void OneToOne()
        {
            //using (var con = new PobrifyContext())
            //{
            //    Relacionamento 1:1 - por limitações, um usuário só pode criar uma playlist, e uma playlist só pode ser criada por um usuário.
            //    var user = new User("leirdan", "leirdan@hotmail.com");
            //    con.Users.Add(user);
            //    con.SaveChanges();
            //    var p = new Playlist(title: "wizard music", userId: user.Id);
            //    con.Playlist.Add(p);
            //    con.SaveChanges();
            //}
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
            //using (var con = new PobrifyContext())
            //{

            //    var songs = con.Songs.ToList();
            //    foreach (var song in songs)
            //    {
            //        Console.WriteLine(song.Title);
            //    }

            //    var newMetal = con.Playlist.Find(2);
            //    Console.WriteLine(newMetal.Title);
            //    foreach (var i in songs)
            //    {
            //        newMetal.AddSongs(i);
            //    }
            //    con.Playlist.Add(newMetal); -gera erro pois newMetal é uma playlist que já existe e o ID não pode mudar
            //    con.SaveChanges();
        }
        static void Algorithm()
        {
            //using (var con = new PobrifyContext())
            //{
            //    if (con.Songs.ToList().Count <= 0)
            //    {
            //        Console.WriteLine("You haven't insert any songs yet.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("These are the current songs you have added: ");
            //        foreach (var i in con.Songs.ToList())
            //        {
            //            Console.Write(i.Title + " (ID:" + i.Id + ") | ");
            //        }
            //        Console.WriteLine("");
            //    }
            //    Console.WriteLine("Do you wanna make an insert on db?");
            //    var opc = Console.ReadLine().ToLower();
            //    if (opc == "y" || opc == "yes")
            //    {

            //        Console.WriteLine("How many songs do you wanna insert?");
            //        int range = Convert.ToInt32(Console.ReadLine());
            //        Console.WriteLine("Insert their info below:");
            //        Console.WriteLine("The 1º song: ");
            //        for (int i = 0; i < range; i++)
            //        {
            //            Console.Write("Title: ");
            //            var j = Console.ReadLine();
            //            Console.Write("Artist: ");
            //            var a = Console.ReadLine();
            //            Console.Write("Length: ");
            //            var l = Console.ReadLine();
            //            Console.Write("");
            //            var song = new Song(j, a, l);
            //            con.Songs.Add(song);
            //            con.SaveChanges();
            //            Console.WriteLine($"Now, the {i + 2}º song: ");
            //        }
            //        Console.WriteLine("Now, there's your database: ");
            //        foreach (var i in con.Songs.ToList())
            //        {
            //            Console.Write(i.Title + " (ID:" + i.Id + ") | ");
            //        }
            //    }
            //    Console.WriteLine("These are the playlists:");
            //    foreach (var i in con.Playlist.ToList())
            //    {
            //        Console.WriteLine(i.Title);
            //    }

            //    Console.WriteLine("Thanks!");
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

