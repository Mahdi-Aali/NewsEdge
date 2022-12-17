using Microsoft.AspNetCore.Mvc;
using NewsEdge.DataAccess.Models.Context;

namespace NewsEdge.Web.Components;

public class MainMenuNavbarViewComponent : ViewComponent
{
    private NewsEdgeContext _context;

    public MainMenuNavbarViewComponent(NewsEdgeContext context)
    {
        _context = context;
    }


    public IViewComponentResult Invoke()
    {
        return View(_context.Categories);
    }
}
