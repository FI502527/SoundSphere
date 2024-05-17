using Microsoft.AspNetCore.Mvc;
using Logic;
using DAL;
using Logic.Models;
using SoundSphere.Models;

namespace SoundSphere.Controllers
{
    public class SongController : Controller
    {
        SongService _songService;
        public SongController(ISongRepository _songRepository, IArtistRepository _artistRepository, IGenreRepository _genreRepository)
        {
            _songService = new SongService(_songRepository, _artistRepository, _genreRepository);
        }
        public IActionResult Index()
        {
            List<SongModel> songModels = _songService.LoadAllSongs();
            List<SongViewModel> songViewModels = new List<SongViewModel>();
            foreach(SongModel songModel in songModels)
            {
                SongViewModel song = new SongViewModel();
                song.Id = songModel.Id;
                song.Title = songModel.Title;
                ArtistViewModel artist = new ArtistViewModel();
                artist.Id = songModel.Artist.Id;
                artist.Name = songModel.Artist.Name;
                song.Artist = artist;
                GenreViewModel genre = new GenreViewModel();
                genre.Id = songModel.Genre.Id;
                genre.Name = songModel.Genre.Name;
                song.Genre = genre;
                songViewModels.Add(song);
            }
            return View(songViewModels);
        }
        public IActionResult Add()
        {
            return View();
        }
        //public IActionResult AddSong(string title, string artist)
        //{
        //    //Song song = new Song();
        //    //song.SetDetails(0, title);
        //    //bool check = songService.AddSong(song);
        //    //return RedirectToAction("Index");
        //}
    }
}
