using Microsoft.AspNetCore.Mvc;

namespace SoundSphere.Controllers
{
	public class GenreController : Controller
	{
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddGenre(string? genre)
		{

			return View();
		}
	}
}
