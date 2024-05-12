using DAL;
using DAL.DTO;
using Logic.Models;

namespace Logic
{
    public class SongService
    {
        private readonly ISongRepository songRepository;
        public SongService(ISongRepository songRepository)
        {
            this.songRepository = songRepository;
        }
        public List<SongModel> LoadAllSongs()
        {
            List<SongModel> songModels = new List<SongModel>();
            List<SongDTO> songDTOs = songRepository.LoadAllSongs();
            foreach(SongDTO songDTO in songDTOs)
            {
                SongModel song = new SongModel();
                song.Id = songDTO.Id;
                song.Title = songDTO.Title;
                songModels.Add(song);
            }
            return songModels;
        }
        public bool AddSong(SongDTO song)
        {
            return songRepository.AddSong(song);
        }
    }
}