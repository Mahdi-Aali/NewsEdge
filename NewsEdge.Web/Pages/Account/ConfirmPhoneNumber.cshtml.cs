using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsEdge.DataAccess.Models;
using NewsEdge.DTOs.Account;
using NewsEdge.Utilities.Google.RecaptchaValidation;

namespace NewsEdge.Web.Pages.Account;

[AutoValidateAntiforgeryToken]
[Authorize]
public class ConfirmPhoneNumberModel : PageModel
{
    private UserManager<NewsEdgeUser> _userManager;

    public ConfirmPhoneNumberModel(UserManager<NewsEdgeUser> userManager)
    {
        _userManager = userManager;
    }


    [BindProperty]
    [FromForm]
    public ConfirmPhoneNumberViewModel ConfirmPhoneNumberViewModel { get; set; } = new();
    public void OnGet()
    {
    }



    public async Task<IActionResult> OnPostAsync()
    {
        if (await RecaptchaValidator.IsValidAsync(Request.Form["g-recaptcha-response"]))
        {
            if (ModelState.IsValid)
            {
                NewsEdgeUser user = await _userManager.FindByNameAsync(User.Identity?.Name);
                bool result = await _userManager
                    .VerifyChangePhoneNumberTokenAsync(user, ConfirmPhoneNumberViewModel.ConfirmCode, user.PhoneNumber);
                if (result)
                {
                    user.PhoneNumberConfirmed = true;
                    await _userManager.UpdateAsync(user);
                    return RedirectToPage("/User");
                }
                ModelState.AddModelError("All", "کد وارد شده اشتباه میباشد");
            }
        }
        else
        {
            ModelState.AddModelError("All", "لطفا من ربات نیستم را تائید کنید.");
        }
        return Page();
    }

    public override async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
    {
        if (!(await _userManager.FindByNameAsync(User.Identity?.Name)).PhoneNumberConfirmed)
        {
            await next();
        }
        else
        {
            context.Result = new RedirectToPageResult("/Errors/NotFound");
        }
    }
}

