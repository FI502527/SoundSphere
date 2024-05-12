using DAL;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using SoundSphere.Models;

namespace SoundSphere.Controllers
{
    public class SongController : Controller
    {
        private readonly SongRepository _songRepository;
        private readonly SongService _songService;
        public SongController(ILogger<HomeController> logger)
        {
            _songRepository = new SongRepository();
            _songService = new SongService(_songRepository);
        }
        public IActionResult Index()
        {
            List<SongModel> allSongModels = _songService.LoadAllSongs();
            List<SongViewModel> allSongs= new List<SongViewModel>();
            foreach(SongModel songModel in allSongModels)
            {
                SongViewModel songViewModel = new SongViewModel();
                songViewModel.Id = songModel.Id;
                songViewModel.Title = songModel.Title;
                allSongs.Add(songViewModel);
            }
            return View(allSongs);
        }
        public IActionResult Add()
        {
            return View();
        }
        
    }
}
