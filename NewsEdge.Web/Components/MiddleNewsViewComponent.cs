using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Repositories.NewsInSectionRepository;

namespace NewsEdge.Web.Components
{
    public class MiddleNewsViewComponent : ViewComponent
    {
        private INewsInSectionRepository _newsInSectionRepository;

        public MiddleNewsViewComponent(INewsInSectionRepository newsInSectionRepository)
        {
            _newsInSectionRepository = newsInSectionRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int sectionId, string color)
        {
            ViewBag.Color = color;
            string sectionName;
            var model = await _newsInSectionRepository.GetNewsBySection(sectionId, 4, out sectionName).ToListAsync();
            ViewBag.SectionName = sectionName;
			return View(model);
        }
    }
}
