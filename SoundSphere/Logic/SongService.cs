using DAL;
using DAL.DTO;
using Logic.Models;
using System.Net.Http;

namespace Logic
{
    public class SongService
    {
        private readonly ISongRepository songRepository;
        private readonly IArtistRepository artistRepository;
        private readonly IGenreRepository genreRepository;
        private readonly ArtistService artistService;
        private readonly GenreService genreService;
		HttpClient client = new HttpClient();
		public SongService(ISongRepository songRepository, IArtistRepository artistRepository, IGenreRepository genreRepository)
        {
            this.songRepository = songRepository;
            this.artistRepository = artistRepository;
            this.genreRepository = genreRepository;
            artistService = new ArtistService(artistRepository);
            genreService = new GenreService(genreRepository);
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
                SongGenre songGenre = songRepository.GetSongGenre(song.Id);
                GenreModel genre = genreService.LoadGenreById(songGenre.Genre_Id);
                song.Genre = genre;
				songModels.Add(song);
			}
            return songModels;
        }
        public bool AddSong(SongDTO song)
        {
            return songRepository.AddSong(song);
        }
   //     public string GetSongImage()
   //     {
			//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://api.spotify.com/v1/artists/0TnOYISbd1XYRBk9myaseg");
			//request.Headers.Add("Authorization", "Bearer 1POdFZRZbvb...qqillRxMr2z");
			//HttpResponseMessage response = await client.SendAsync(request);
			//string responseBody =
			//await response.Content.ReadAsStringAsync();

			//response.EnsureSuccessStatusCode();
			//return "Abc";
   //     }
    }
}