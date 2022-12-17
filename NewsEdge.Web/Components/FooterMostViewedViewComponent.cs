using Microsoft.AspNetCore.Mvc;
using NewsEdge.DataAccess.Repositories.NewsRepositories;

namespace NewsEdge.Web.Components
{
    public class FooterMostViewedViewComponent : ViewComponent
    {
        private INewsRepository _newsRepository;

        public FooterMostViewedViewComponent(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_newsRepository.GetHotNews(3));
        }
    }
}
