using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Repositories.NewsInSectionRepository;

namespace NewsEdge.Web.Components
{
    public class TopNewsViewComponent : ViewComponent
    {
        private INewsInSectionRepository _newsInSectionRepository;

        public TopNewsViewComponent(INewsInSectionRepository newsInSectionRepository)
        {
            _newsInSectionRepository = newsInSectionRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _newsInSectionRepository.GetNewsBySection(1, 4, out string _).ToListAsync());
        }
    }
}
