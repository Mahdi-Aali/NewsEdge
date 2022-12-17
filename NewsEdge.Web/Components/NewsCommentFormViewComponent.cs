using Microsoft.AspNetCore.Mvc;
using NewsEdge.DataAccess.Models.PrimaryModels;

namespace NewsEdge.Web.Components
{
    public class NewsCommentFormViewComponent : ViewComponent
    {
        private IConfiguration _configuration;

        public NewsCommentFormViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IViewComponentResult Invoke(long newsId)
        {
            ViewBag.SiteKey = _configuration["CaptchaSiteKey"];
            return View(new NewsComment()
            {
                NewsId = newsId
            });
        }
    }
}
