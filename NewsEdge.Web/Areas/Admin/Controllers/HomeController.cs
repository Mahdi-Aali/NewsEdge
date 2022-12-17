using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NewsEdge.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class HomeController : Controller
{
    
    [Route("/Admin")]
    public IActionResult Index()
    {
        return View(nameof(Index));
    }
}
