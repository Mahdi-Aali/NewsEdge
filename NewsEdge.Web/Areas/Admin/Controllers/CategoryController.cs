using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Models.Context;
using NewsEdge.DataAccess.Models.PrimaryModels;

namespace NewsEdge.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [ViewComponent(Name = "CategoryCountViewComponent")]
    [AutoValidateAntiforgeryToken]
    public class CategoryController : Controller
    {
        private NewsEdgeContext _context;

        public CategoryController(NewsEdgeContext context)
        {
            _context = context;
        }

        #region Read
        [Route("/Admin/Category")]
        public IActionResult Index() => View(nameof(Index), _context.Categories);
        #endregion

        #region Create

        [Route("/Admin/Category/Create/{id?}")]
        [HttpGet]
        public IActionResult Create([FromRoute] long? id) => View(nameof(Create), new Category()
        {
            ParentId = id
        });

        [Route("/Admin/Category/Create/{id?}")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Category category)
        {
            ModelState.Remove("Categories");
            ModelState.Remove("Category1");
            if (ModelState.IsValid)
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit

        [Route("/Admin/Category/Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] long id)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category is not null)
            {
                return View(nameof(Edit), category);
            }
            return null;
        }

        [Route("/Admin/Category/Edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm]Category category)
        {
            ModelState.Remove("Categories");
            ModelState.Remove("Category1");
            if (ModelState.IsValid)
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete
        [Route("/Admin/Category/Delete/{id}")]
        [HttpGet]
        public async Task<bool> Delete([FromRoute]long id)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category is not null)
            {
                try
                {
                    _context.Remove(category);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch
                {

                    return false;
                }
            }
            return false;
        }
        #endregion

        #region ViewComponent
        public async Task<string> InvokeAsync()
        {
            return (await _context.Categories.CountAsync()).ToString();
        }
        #endregion
    }
}
