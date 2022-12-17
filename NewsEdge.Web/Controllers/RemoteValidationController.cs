using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsEdge.DataAccess.Models;
using NewsEdge.DTOs.Account;

namespace NewsEdge.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RemoteValidationController : ControllerBase
{
    private UserManager<NewsEdgeUser> _userManager;

	public RemoteValidationController(UserManager<NewsEdgeUser> userManager)
	{
		_userManager = userManager;
	}


	[HttpGet("forgotPasswordEmailExist")]
	public async Task<bool> ForgotPasswordEmailExist([Bind(Prefix = "ForgotPasswordViewModel")][FromQuery]ForgotPasswordViewModel model)
	{
		return await _userManager.FindByEmailAsync(model.Email) is not null;
	}
}
