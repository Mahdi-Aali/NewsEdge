using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsEdge.DataAccess.Models;
using NewsEdge.DataAccess.Models.PrimaryModels;
using NewsEdge.DataAccess.Repositories.CategoryRepository;
using NewsEdge.DataAccess.Repositories.NewsCategoryRepository;
using NewsEdge.DataAccess.Repositories.NewsRepositories;
using NewsEdge.DataAccess.Repositories.NewsTagRepository;
using NewsEdge.DTOs.News;
using NewsEdge.Utilities.Image;
using NewsEdge.Utilities.PaginationModels;

namespace NewsEdge.Web.Areas.Admin.Controllers;

[Area("Admin")]
[AutoValidateAntiforgeryToken]
[Authorize(Roles = "Admin")]
[ViewComponent(Name = "NewsCountViewComponent")]
public class NewsController : Controller
{

    private UserManager<NewsEdgeUser> _userManager;
    private INewsRepository _newsRepository;
    private ICategoryRepository _categoryRepository;
    private INewsCategoryRepository _newsCategoryRepository;
    private INewsTagRepository _newsTagRepository;

    public NewsController(INewsRepository newsRepository
        , ICategoryRepository categoryRepository
        , INewsCategoryRepository newsCategoryRepository
        , INewsTagRepository newsTagRepository
        , UserManager<NewsEdgeUser> userManager)
    {
        _newsRepository = newsRepository;
        _newsCategoryRepository = newsCategoryRepository;
        _categoryRepository = categoryRepository;
        _newsTagRepository = newsTagRepository;
        _userManager = userManager;
    }

    #region Read
    [Route("/Admin/News")]
    public async Task<IActionResult> Index([FromForm] int pageId = 1)
    {
        var model = new ItemsWithPageDataViewModel<News>()
        {
            Entities = _newsRepository.GetByPage(pageId, 20, 20),
            PageData = new()
            {
                CurrentPage = pageId,
                ItemPerPage = 20,
                TotalItems = (int)await _newsRepository.CountAsync()
            }
        };
        return View(nameof(Index), model);
    }

    #endregion

    #region Create
    [Route("/Admin/News/Create")]
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = _categoryRepository.GetAll();
		return View(nameof(Create));
	}

    [Route("/Admin/News/Create")]
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] NewsViewModel model, [FromForm] List<long> categories)
    {
        if (categories.Any())
        {
            if (model.Image.IsValid())
            {
                if (ModelState.IsValid)
                {
                    News news = model.ToNews();
                    news.UserId = (await _userManager.FindByNameAsync(User?.Identity?.Name)).Id;

                    await _newsRepository.AddWithCategoriesAndTagesAsync(news, categories, model.Tages);

                    await model.Image.SaveAsync(news.ImagePath, ImageSaverPath.NewsImage);

                    return RedirectToAction(nameof(Index));
                }
            }
            ModelState.AddModelError("All", "لطفا فرمت درست تصویر را وارد فرمائید {.png - .jpg}");
        }
        else
        {
            ModelState.AddModelError("All", "حداقل باید یک دسته بندی را انتخاب کنید");
        }
        ViewBag.Categories = _categoryRepository.GetAll();
        ViewBag.SelectedCategories = categories;
        return View();
    }
    #endregion

    #region Update

    [Route("/Admin/News/ChangeState/{id:long}")]
    [HttpGet]
    public async Task<bool> ChangeState([FromRoute]long id)
    {
        News news = await _newsRepository.FindAsync(id);
        if (news is not null)
        {
            news.State = !news.State;
            return await _newsRepository.UpdateAsync(news);
        }
        return false;
    }

    [Route("/Admin/News/Edit/{id:long}")]
    [HttpGet]
    public async Task<IActionResult> Edit([FromRoute]long id)
    {
        News news = await _newsRepository.FindAsync(id);
        if (news is not null)
        {
            ViewBag.Categories = _categoryRepository.GetAll();
            ViewBag.SelectedCategories = _newsCategoryRepository.GetAll(nc => nc.NewsId.Equals(news.NewsId)).Select(nc => nc.CategoryId);
            ViewBag.ImagePath = news.ImagePath;
            byte[] buffer = System.IO.File.ReadAllBytes($"{Directory.GetCurrentDirectory()}/Images/News/" + news.ImagePath);
            return View(nameof(Edit), new NewsViewModel()
            {
                Id = news.NewsId,
                Description = news.Description,
                Title = news.Title,
                Tages = string.Join("#", _newsTagRepository.GetAll(nt => nt.NewsId.Equals(news.NewsId)).Select(nt => nt.Title)),
                Image = new FormFile(new MemoryStream(buffer), 0, buffer.Length, news.ImagePath, news.ImagePath),
                YouTubeLink = news.YouTubeLink
            });
        }
        return RedirectToPage("/Errors/NotFound");
    }

    [Route("/Admin/News/Edit/{id:long}")]
    [HttpPost]
    public async Task<IActionResult> Edit([FromForm]NewsViewModel model, [FromForm] List<long> categories)
    {
        News news = await _newsRepository.FindAsync(model.Id);
        ViewBag.Categories = _categoryRepository.GetAll();
        ViewBag.SelectedCategories = categories;
        ViewBag.ImagePath = news.ImagePath;
        if (categories.Any())
        {
            if (ModelState.IsValid)
            {
                string currentImage = news.ImagePath;
                model.ToNews(ref news);
                if (model.Image is not null)
                {
                    if (model.Image.IsValid())
                    {
                        ImageSaver.RemoveCurrentImage(ImageSaverPath.NewsImage, currentImage);
                        await model.Image.SaveAsync(news.ImagePath, ImageSaverPath.NewsImage);
                    }
                    else
                    {
                        ModelState.AddModelError("All", "لطفا فرمت درست تصویر را وارد فرمائید {.png - .jpg}");
                    }
                }
                await _newsRepository.UpdateWithCategoriesAndTagesAsync(news, categories, model.Tages);
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            ModelState.AddModelError("All", "لطفا یک دسته بندی را انتخاب کنید");
        }
        return View(nameof(Edit), model);
    }
    #endregion

    #region ViewComponent
    public async Task<string> InvokeAsync()
    {
        return (await _newsRepository.CountAsync()).ToString();
    }
    #endregion
}
