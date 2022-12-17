using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using NewsEdge.DTOs.Roles;

namespace NewsEdge.Web.Areas.Admin.Controllers
{
    [Area("/Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    [ViewComponent(Name = "RolesCountViewComponent")]
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole<long>> _roleManager;

        public RolesController(RoleManager<IdentityRole<long>> roleManager)
        {
            _roleManager = roleManager;
        }

        #region Read
        [Route("/Admin/Roles")]
        public ViewResult Index()
        {
            return View(nameof(Index));
        }

        [Route("/Admin/Roles/GetRoles")]
        public ViewResult GetRoles()
        {
            return View(nameof(GetRoles), _roleManager.Roles);
        }
        #endregion

        #region Create
        [Route("/Admin/Roles/Create")]
        [HttpGet]
        public ViewResult Create() => View(nameof(Create));

        [Route("/Admin/Roles/Create")]
        [HttpPost]
        public async Task<RedirectToActionResult> Create([FromForm] RoleViewModel role)
        {
            role.Id = 0;
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(role.ToIdentityRole());
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Update
        [HttpGet]
        [Route("/Admin/Roles/Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] long id)
        {
            IdentityRole<long> role = await GetRoleById(id);
            if (role is not null)
            {
                return View(nameof(Edit), new RoleViewModel() { Id = id, Name = role.Name });
            }
            return RedirectToPage("/Errors/NotFound");
        }


        [HttpPost]
        [Route("/Admin/Roles/Edit")]
        public async Task<IActionResult> Edit([FromForm] RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole<long> role = await GetRoleById(model.Id);
                role.Name = model.Name;
                await _roleManager.UpdateAsync(role);
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        [HttpGet]
        [Route("/Admin/Roles/Delete/{id}")]
        public async Task<bool> Delete([FromRoute] long id)
        {
            IdentityRole<long> role = await GetRoleById(id);
            if (role is not null)
            {
                return (await _roleManager.DeleteAsync(role)).Succeeded;
            }
            return false;
        }
        #endregion

        #region ViewCompoent
        public async Task<string> InvokeAsync()
        {
            return (await _roleManager.Roles.CountAsync()).ToString();
        }
        #endregion

        #region Tools
        [NonAction]
        private async Task<IdentityRole<long>> GetRoleById(long id)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }
        #endregion



    }
}
