using Microsoft.AspNetCore.Mvc;

namespace NewsEdge.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View(nameof(Index));
        }
    }
}
