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

        public SongController(ISongRepository _songRepository)
        {
            _songService = new SongService(_songRepository);
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
