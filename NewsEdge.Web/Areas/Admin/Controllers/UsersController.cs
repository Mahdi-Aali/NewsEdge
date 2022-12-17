using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Models;
using NewsEdge.Utilities.PaginationModels;

namespace NewsEdge.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [ViewComponent(Name = "UsersCountViewComponent")]
    [AutoValidateAntiforgeryToken]
    public class UsersController : Controller
    {
        private UserManager<NewsEdgeUser> _userManager;

        public UsersController(UserManager<NewsEdgeUser> userManager)
        {
            _userManager = userManager;
        }

        //TODO : User edit and delete


        #region Read
        [Route("/Admin/Users/{pageId=1}")]
        public async Task<IActionResult> Index(int pageId = 1)
        {
            return View(nameof(Index), new ItemsWithPageDataViewModel<NewsEdgeUser>()
            {
                PageData = new()
                {
                    CurrentPage = pageId,
                    ItemPerPage = 30,
                    TotalItems = await _userManager.Users.CountAsync()
                },
                Entities = _userManager.Users.Skip((pageId - 1) * 30).Take(30)
            });
        }


        [Route("/Admin/Users/Detail/{id}")]
        public async Task<IActionResult> Detail([FromRoute] long id)
        {
            NewsEdgeUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user is null)
            {
                return RedirectToPage("/Errors/NotFound");
            }
            return View(nameof(Detail), user);
        }
        #endregion

        #region Edit
        [Route("/Admin/Users/Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] long id)
        {
            return View(nameof(Edit), await FindUserByIdAsync(id));
        }


        [Route("/Admin/Users/AddOrDeleteUserFromRole/{role}/{userId}/{isDelete}")]
        [HttpGet]
        public async Task<bool> AddOrDeleteUserFromRole([FromRoute] string role, [FromRoute] long userId, [FromRoute] bool isDelete)
        {
            NewsEdgeUser user = await FindUserByIdAsync(userId);
            return isDelete switch
            {
                true => (await _userManager.RemoveFromRoleAsync(user, role)).Succeeded,
                false => (await _userManager.AddToRoleAsync(user, role)).Succeeded
            };
        }
        #endregion

        #region ViewComponent
        public async Task<string> InvokeAsync()
        {
            return (await _userManager.Users.CountAsync()).ToString();
        }
        #endregion


        #region Tools

        [NonAction]
        private async Task<NewsEdgeUser> FindUserByIdAsync(long id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        #endregion

    }
}
