using DAL;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using SoundSphere.Models;

namespace SoundSphere.Controllers
{
    public class ArtistController : Controller
    {
        ArtistService _artistService;
        public ArtistController(IArtistRepository artistRepository)
        {
            _artistService = new ArtistService(artistRepository);
        }
        public IActionResult Index()
        {
            List<ArtistModel> artistModels = _artistService.LoadAllArtists();
            List<ArtistViewModel> artistViewModels = new List<ArtistViewModel>();
            foreach(ArtistModel artistModel in artistModels)
            {
                ArtistViewModel artistViewModel = new ArtistViewModel();
                artistViewModel.Id = artistModel.Id;
                artistViewModel.Name = artistModel.Name;
                artistViewModels.Add(artistViewModel);
            }
            return View(artistViewModels);
        }
    }
}
