using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsEdge.DataAccess.Models;
using NewsEdge.DTOs.Account;
using NewsEdge.Utilities.Email;
using NewsEdge.Utilities.Google.RecaptchaValidation;
using NewsEdge.Web.Filters.AuthorizationFilters;

namespace NewsEdge.Web.Pages.Account;

[AutoValidateAntiforgeryToken]
[NotAllowedForLoginUser]
public class ForgotPasswordModel : PageModel
{
    private UserManager<NewsEdgeUser> _userManager;

    public ForgotPasswordModel(UserManager<NewsEdgeUser> userManager)
    {
        _userManager = userManager;
    }

    [BindProperty]
    [FromForm]
    public ForgotPasswordViewModel ForgotPasswordViewModel { get; set; } = new();
    public void OnGet()
    {
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (await RecaptchaValidator.IsValidAsync(Request.Form["g-recaptcha-response"]))
        {
            if (ModelState.IsValid)
            {
                NewsEdgeUser user = await _userManager.FindByEmailAsync(ForgotPasswordViewModel.Email);
                if (user != null)
                {
                    string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    string resetLink = Url.Page("/Account/ResetPassword", null, new { user = user.Id, resetToken = token }, Request.Scheme);
                    await EmailSender.SendForgotPasswordEmail(user.Email, resetLink);
                    TempData["Success"] = "Success";
                    return RedirectToPage("/Account/ForgotPassword");
                }
                else
                {
                    ModelState.AddModelError("All", "حسابی  با ایمیل وارد شده در سایت موجود نیست");
                }
            }
        }
        else
        {
            ModelState.AddModelError("All", "لطفا من ربات نیستم را تائید کنید");
        }
        return Page();
    }
}
