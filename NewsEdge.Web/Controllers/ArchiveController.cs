using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using NewsEdge.DataAccess.Repositories.CategoryRepository;
using NewsEdge.DataAccess.Repositories.NewsRepositories;
using NewsEdge.Utilities.TagHelpers;

namespace NewsEdge.Web.Controllers;

public class ArchiveController : Controller
{
    private INewsRepository _newsRepository;
    private ICategoryRepository _categoryRepository;

    public ArchiveController(INewsRepository newsRepository, ICategoryRepository categoryRepository)
    {
        _newsRepository = newsRepository;
        _categoryRepository = categoryRepository; 
    }

    [Route("/Archive")]
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] string selectedCategory = "", [FromQuery]string text = "", [FromQuery]int pageId = 1)
    {
        ViewBag.Text = text;
        ViewBag.Categories = _categoryRepository.GetAll().ToList();
        ViewBag.SelectedCategory = selectedCategory;
        ViewBag.PageId = pageId;
        ViewBag.PageData = new PageData()
        {
            CurrentPage = pageId,
            ItemPerPage = 6,
            TotalItems = (int)(await _newsRepository.CountAsync())
        };
        return View(nameof(Index), await _newsRepository.GetArchive(text, int.TryParse(selectedCategory, out int result) ? result : 0, pageId));
    }
}
