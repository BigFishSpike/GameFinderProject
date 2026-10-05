using Microsoft.AspNetCore.Mvc;

namespace GameFinder.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
