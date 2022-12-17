using Microsoft.AspNetCore.Mvc;
using NewsEdge.DataAccess.Repositories.NewsRepositories;

namespace NewsEdge.Web.Components;

public class LastNewsViewComponent : ViewComponent
{
    private INewsRepository _newsRepository;

    public LastNewsViewComponent(INewsRepository newsRepository)
    {
        _newsRepository = newsRepository;
    }

    public IViewComponentResult Invoke(int take = 4)
    {
        return View(_newsRepository.GetLastNews(take));
    }
}
