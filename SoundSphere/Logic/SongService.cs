using Interfaces;
using Models;

namespace Logic
{
    public class SongService
    {
        private readonly ISongRepository songRepository;
        public SongService(ISongRepository songRepository)
        {
            this.songRepository = songRepository;
        }
        public List<Song> LoadAllSongs()
        {
            return songRepository.LoadAllSongs();
        }
        public bool AddSong(Song song)
        {
            return songRepository.AddSong(song);
        }
    }
}