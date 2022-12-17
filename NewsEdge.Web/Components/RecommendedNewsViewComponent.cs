using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Repositories.NewsInSectionRepository;

namespace NewsEdge.Web.Components
{
    public class RecommendedNewsViewComponent : ViewComponent
    {
        private INewsInSectionRepository _newsInSectionRepository;

        public RecommendedNewsViewComponent(INewsInSectionRepository newsInSectionRepository)
        {
            _newsInSectionRepository = newsInSectionRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sectionName;
            var model = await _newsInSectionRepository.GetNewsBySection(2, 6, out sectionName).ToListAsync();
            ViewBag.SectionName = sectionName;
            return View(model);
        }
    }
}
