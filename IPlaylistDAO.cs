using System.Collections.Generic;

namespace pobrify
{
    internal interface IPlaylistDAO
    {
        List<Song> GetSongsOnPlaylist();
        void AddSongsToPlaylist(Song s);
        void DeleteSongOnPlaylist(int id);
    }
}
