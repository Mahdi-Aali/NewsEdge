using Microsoft.AspNetCore.Mvc;
using NewsEdge.DataAccess.Repositories.NewsCommentRepository;

namespace NewsEdge.Web.Components
{
    public class NewsCommentsListViewComponent : ViewComponent
    {
        private ICommentRepository _commentRepository;

        public NewsCommentsListViewComponent(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IViewComponentResult Invoke(long newsId)
        {
            return View(_commentRepository.GetAllByNews(newsId));
        }
    }
}
