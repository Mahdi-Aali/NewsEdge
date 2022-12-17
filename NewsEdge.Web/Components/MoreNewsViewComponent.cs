using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsEdge.DataAccess.Repositories.NewsRepositories;

namespace NewsEdge.Web.Components
{
    public class MoreNewsViewComponent : ViewComponent
    {
        private INewsRepository _newsRepository;

        public MoreNewsViewComponent(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _newsRepository.GetLastNews().ToListAsync());
        }
    }
}
