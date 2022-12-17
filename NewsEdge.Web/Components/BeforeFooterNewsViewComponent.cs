using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Repositories.NewsInSectionRepository;

namespace NewsEdge.Web.Components
{
    public class BeforeFooterNewsViewComponent : ViewComponent
    {
        private INewsInSectionRepository _newsInSectionRepository;

        public BeforeFooterNewsViewComponent(INewsInSectionRepository newsInSectionRepository)
        {
            _newsInSectionRepository = newsInSectionRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _newsInSectionRepository.GetNewsBySection(7, 6, out string _).ToListAsync());
        }
    }
}
