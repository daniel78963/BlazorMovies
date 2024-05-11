using Microsoft.AspNetCore.Mvc;

namespace BlazorMovies.Server.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
