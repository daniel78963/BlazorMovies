using Microsoft.AspNetCore.Mvc;

namespace BlazorMovies.Server.Controllers
{
    public class GendersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
