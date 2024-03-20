using Models;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Interfaces;

namespace SoundSphere.Controllers
{
    public class SongController : Controller
    {
        SongService songService;
        public SongController(ISongRepository songRepository)
        {
            songService = new SongService(songRepository);
        }
        public IActionResult Index()
        {
            List<Song> songs = songService.LoadAllSongs();
            return View(songs);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSong(string title, string artist)
        {
            Song song = new Song();
            song.SetDetails(0, title);
            bool check = songService.AddSong(song);
            return RedirectToAction("Index");
        }
    }
}
