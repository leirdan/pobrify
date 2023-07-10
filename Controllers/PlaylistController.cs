using System;

namespace pobrify.Controllers
{
    public class PlaylistController
    {
        public static void InsertData()
        {
            var song = new SongContext(title: "I can see you");

            using (var context = new PlaylistContext())
            {
                context.Songs.Add(song);
                context.SaveChanges();
                Console.WriteLine("Added!");
            }
        }

    }
}
