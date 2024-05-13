using DAL;
using DAL.DTO;
using Logic.Models;

namespace Logic
{
    public class SongService
    {
        private readonly ISongRepository songRepository;
        private readonly IArtistRepository artistRepository;
        private readonly ArtistService artistService;
        public SongService(ISongRepository songRepository, IArtistRepository artistRepository)
        {
            this.songRepository = songRepository;
            this.artistRepository = artistRepository;
            artistService = new ArtistService(artistRepository);
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
                SongArtist songArtist = songRepository.GetSongArtist(song.Id);
                ArtistModel artist = artistService.LoadArtistById(songArtist.Artist_Id);
                song.Artist = artist;
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