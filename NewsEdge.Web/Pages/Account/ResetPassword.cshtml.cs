using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsEdge.DataAccess.Models;
using NewsEdge.DTOs.Account;
using NewsEdge.Utilities.Google.RecaptchaValidation;
using NewsEdge.Web.Filters.AuthorizationFilters;

namespace NewsEdge.Web.Pages.Account;

[NotAllowedForLoginUser]
public class ResetPasswordModel : PageModel
{
    private UserManager<NewsEdgeUser> _userManager;

    public ResetPasswordModel(UserManager<NewsEdgeUser> userManager)
    {
        _userManager = userManager;
    }

    [BindProperty]
    [FromForm]
    public ResetPasswordViewModel ResetPasswordViewModel { get; set; } = new();


    public async Task<IActionResult> OnGetAsync([FromQuery] long user, [FromQuery] string resetToken)
    {
        NewsEdgeUser newsEdgeUser = await FindUserById(user);
        if (newsEdgeUser is null)
        {
            return RedirectToPage("/Errors/NotFound");
        }
        else
        {
            ResetPasswordViewModel.UserId = user;
            ResetPasswordViewModel.Token = resetToken;
            return Page();
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (await RecaptchaValidator.IsValidAsync(Request.Form["g-recaptcha-response"]))
        {
            if (ModelState.IsValid)
            {
                NewsEdgeUser newsEdgeUser = await FindUserById(ResetPasswordViewModel.UserId);
                if (newsEdgeUser is not null)
                {

                    var resetPasswordResult = await _userManager.ResetPasswordAsync(newsEdgeUser, ResetPasswordViewModel.Token, ResetPasswordViewModel.Password);
                    var updateStampResult = await _userManager.UpdateSecurityStampAsync(newsEdgeUser);
                    if (resetPasswordResult.Succeeded && updateStampResult.Succeeded)
                    {
                        TempData["ResetPassword"] = "Success";
                        return RedirectToPage("/Account/Login");
                    }
                    else
                    {
                        foreach(var error in resetPasswordResult.Errors)
                        {
                            ModelState.AddModelError("All", error.Description);
                        }
                    }
                }
                else
                {
                    return RedirectToPage("/Errors/NotFound");
                }
            }
        }
        else
        {
            ModelState.AddModelError("All", "لطفا من ربات نیستم را تائید کنید");
        }
        return Page();
    }

    private async Task<NewsEdgeUser> FindUserById(long id)
    {
        return await _userManager.FindByIdAsync(id.ToString());
    }
}
