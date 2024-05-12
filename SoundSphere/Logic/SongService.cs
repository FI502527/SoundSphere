using DAL;
using DAL.DTO;
using Logic.Models;

namespace Logic
{
    public class SongService
    {
        private readonly ISongRepository _repo;
        public SongService(ISongRepository repo)
        {
            _repo = repo;
        }
        public SongModel LoadSongById(int id)
        {
            SongDTO songDTO = _repo.LoadSongById(id);
            SongModel song = new SongModel();
            song.Id = songDTO.Id;
            song.Title = songDTO.Title;
            return song;
        }
        public List<SongModel> LoadAllSongs()
        {
            List<SongDTO> allSongDTOs = _repo.LoadAllSongs();
            List<SongModel> allSongs = new List<SongModel>();
            foreach(SongDTO songDTO in allSongDTOs)
            {
                SongModel song = new SongModel();
                song.Id = songDTO.Id;
                song.Title = songDTO.Title;
                allSongs.Add(song);
            }
            return allSongs;
        }
    }
}