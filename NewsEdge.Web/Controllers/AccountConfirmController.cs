using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsEdge.DataAccess.Models;

namespace NewsEdge.Web.Controllers
{
    public class AccountConfirmController : Controller
    {
        private UserManager<NewsEdgeUser> _userManager;

        public AccountConfirmController(UserManager<NewsEdgeUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("/ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery]long userId, [FromQuery]string token)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null || user.EmailConfirmed)
            {
                return RedirectToPage("/Errors/NotFound");
            }
            IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToPage("/User/Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
