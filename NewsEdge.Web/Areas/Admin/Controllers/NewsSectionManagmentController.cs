using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsEdge.DataAccess.Models.PrimaryModels;
using NewsEdge.DataAccess.Repositories.NewsInSectionRepository;
using NewsEdge.DataAccess.Repositories.NewsSectionRepository;

namespace NewsEdge.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
[ViewComponent(Name = "NewsSectionsCountViewComponent")]
[AutoValidateAntiforgeryToken]
public class NewsSectionManagmentController : Controller
{
    private INewsSectionRepository _newsSectionRepository;
    private INewsInSectionRepository _newsInSectionRepository;

    public NewsSectionManagmentController(INewsSectionRepository newsSectionRepository
        , INewsInSectionRepository newsInSectionRepository)
    {
        _newsSectionRepository = newsSectionRepository;
        _newsInSectionRepository = newsInSectionRepository;
    }


    #region Read

    [Route("/Admin/NewsSectionManagment")]
    [HttpGet]
    public IActionResult Index()
    {
        return View(nameof(Index), _newsSectionRepository.GetAll());
    }

    #endregion


    #region Create
    [Route("/Admin/NewsSectionManagment/AddOrDeleteNewsInSection/{sectionId:long}/{newsId:long}")]
    [HttpGet]
    public async Task<bool> AddOrDeleteNewsInSection([FromRoute] long sectionId, [FromRoute] long newsId)
    {
        if (sectionId > 0 && newsId > 0)
        {
            if (!await _newsInSectionRepository.IsNewsInSectionExist(sectionId, newsId))
            {
                return await _newsInSectionRepository.AddAsync(new()
                {
                    NewsId = newsId,
                    NewsSectionId = sectionId
                });
            }
            else
            {
                return await _newsInSectionRepository.DeleteNewsFromSection(sectionId, newsId);
            }
        }
        return false;
    }
    #endregion

    #region Edit

    [Route("/Admin/NewsSectionManagment/EditSectionName/{sectionId:long}")]
    [HttpGet]
    public async Task<IActionResult> EditSectionName(long sectionId)
    {
        NewsSection section = await _newsSectionRepository.FindAsync(sectionId);
        if (section is not null)
        {
            return View(nameof(EditSectionName), section);
        }
        return null!;
    }


    
    [Route("/Admin/NewsSectionManagment/EditSectionName/{sectionId:long}")]
    [HttpPost]
    public async Task<IActionResult> EditSectionName([FromForm]NewsSection section)
    {
        ModelState.Remove("NewsInSections");
        if (ModelState.IsValid)
        {
            await _newsSectionRepository.UpdateAsync(section);
        }
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region ViewComponent
    public async Task<string> InvokeAsync() => (await _newsSectionRepository.CountAsync()).ToString("N0");
    #endregion
}
