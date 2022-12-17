using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsEdge.DataAccess.Models;

namespace NewsEdge.Web.Components;

public class AdminUserSettingViewComponent : ViewComponent
{
    private UserManager<NewsEdgeUser> _userManager;

	public AdminUserSettingViewComponent(UserManager<NewsEdgeUser> userManager)
	{
		_userManager = userManager;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var user = await _userManager.FindByNameAsync(User.Identity.Name);
		return View(nameof(InvokeAsync), user);
	}
}
