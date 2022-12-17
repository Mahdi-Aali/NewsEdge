using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewsEdge.Web.Pages.User;

[Authorize]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
