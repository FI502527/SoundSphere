using Models;

namespace Interfaces
{
    public interface ISongRepository
    {
        public Song LoadSongById(int id);
        public List<Song> LoadAllSongs();
        public bool AddSong(Song song);
    }
}