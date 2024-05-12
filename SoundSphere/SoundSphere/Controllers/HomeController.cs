using System.Diagnostics;
using DAL;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using SoundSphere.Models;

namespace SoundSphere.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SongRepository _songRepository;
        private readonly SongService _songService;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _songRepository = new SongRepository();
            _songService = new SongService(_songRepository);
        }

        public IActionResult Index()
        {
            SongModel songModel = _songService.LoadSongById(1);
            SongViewModel songViewModel = new SongViewModel();
            songViewModel.Id = songModel.Id;
            songViewModel.Title = songModel.Title;
            return View(songViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}