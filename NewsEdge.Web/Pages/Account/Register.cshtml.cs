using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsEdge.DataAccess.Models;
using NewsEdge.DTOs.Account;
using NewsEdge.Utilities.Google.RecaptchaValidation;
using NewsEdge.Web.Filters.AuthorizationFilters;

namespace NewsEdge.Web.Pages.Account
{
    [NotAllowedForLoginUser]
    [AutoValidateAntiforgeryToken]
    public class RegisterModel : PageModel
    {
        private UserManager<NewsEdgeUser> _userManager;

        public RegisterModel(UserManager<NewsEdgeUser> userManager)
        {
            _userManager = userManager;
        }

        [FromForm]
        [BindProperty]
        public RegisterViewModel Register { get; set; } = new();


        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (await RecaptchaValidator.IsValidAsync(Request.Form["g-recaptcha-response"]))
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        NewsEdgeUser user = Register.ToNewsEdgeUser();
                        IdentityResult result = await _userManager.CreateAsync(user, Register.Password);
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, "User");
                            TempData["Success"] = "Success";
                            return RedirectToPage("/Account/Login");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.TryAddModelError("All", error.Description);
                            }
                        }
                    }
                    catch
                    {
                        return RedirectToPage("/Error");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("All", "لطفا من ربات نیستم را تائید کنید.");
            }
            return Page();
        }
    }
}
