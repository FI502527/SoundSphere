using DAL;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace SoundSphere.Controllers
{
    public class SongController : Controller
    {
        public IActionResult Index()
        {
            SongRepository songRepository = new SongRepository();
            List<Song> songs = songRepository.LoadAllSongs();
            return View(songs);
        }
    }
}
