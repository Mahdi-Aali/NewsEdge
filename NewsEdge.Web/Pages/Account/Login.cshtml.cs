using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsEdge.DataAccess.Models;
using NewsEdge.DTOs.Account;
using NewsEdge.Utilities.Google.RecaptchaValidation;
using NewsEdge.Web.Filters.AuthorizationFilters;

namespace NewsEdge.Web.Pages.Account;

[NotAllowedForLoginUser]
[AutoValidateAntiforgeryToken]
public class LoginModel : PageModel
{
    private UserManager<NewsEdgeUser> _userManager;
    private SignInManager<NewsEdgeUser> _signInManager;

    public LoginModel(UserManager<NewsEdgeUser> userManager, SignInManager<NewsEdgeUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [FromForm]
    [BindProperty]
    public LoginViewModel LoginViewModel { get; set; } = new();
    public void OnGet()
    {

    }


    public async Task<IActionResult> OnPostAsync()
    {
        if(await RecaptchaValidator.IsValidAsync(Request.Form["g-recaptcha-response"]))
        {
            if (ModelState.IsValid)
            {
                NewsEdgeUser user = await _userManager.FindByEmailAsync(LoginViewModel.Email);
                if (user is not null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, LoginViewModel.Password, LoginViewModel.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("All", "ایمیل یا رمز عبور اشتباه است.");
                    }
                }
                else
                {
                    ModelState.AddModelError("All", $"حسابی با ایمیل {LoginViewModel.Email} در سایت موجود نمیباشد.");
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
