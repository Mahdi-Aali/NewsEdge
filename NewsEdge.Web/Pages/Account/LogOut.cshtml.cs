using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsEdge.DataAccess.Models;

namespace NewsEdge.Web.Pages.Account;

[Authorize]
public class LogOutModel : PageModel
{

    private SignInManager<NewsEdgeUser> _signInManager;

    public LogOutModel(SignInManager<NewsEdgeUser> signInManager)
    {
        _signInManager = signInManager;
    }


    public async Task<RedirectToActionResult> OnGetAsync()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}