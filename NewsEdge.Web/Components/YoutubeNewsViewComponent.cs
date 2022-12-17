using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Repositories.NewsInSectionRepository;

namespace NewsEdge.Web.Components
{
    public class YoutubeNewsViewComponent : ViewComponent
    {
        private INewsInSectionRepository _newsInSectionRepository;

        public YoutubeNewsViewComponent(INewsInSectionRepository newsInSectionRepository)
        {
            _newsInSectionRepository = newsInSectionRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _newsInSectionRepository.GetNewsBySection(3, 3, out string _).ToListAsync());
        }
    }
}
