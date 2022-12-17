using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using NewsEdge.DataAccess.Models.PrimaryModels;
using NewsEdge.DataAccess.Repositories.NewsCommentRepository;
using NewsEdge.DataAccess.Repositories.NewsRepositories;
using NewsEdge.DataAccess.Repositories.NewsTagRepository;
using NewsEdge.DataAccess.Repositories.NewsViewRepository;
using NewsEdge.Utilities.Comment;
using NewsEdge.Utilities.Google.RecaptchaValidation;

namespace NewsEdge.Web.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository _newsRepository;
        private INewsTagRepository _newsTagRepository;
        private INewsViewRepository _newsViewRepository;
        private ICommentRepository _newsCommentRepository;

        public NewsController(INewsRepository newsRepository 
            , INewsTagRepository newsTagRepository
            , INewsViewRepository newsViewRepository
            , ICommentRepository newsCommentRepository
            , IConfiguration configuration)
        {
            _newsRepository = newsRepository;
            _newsTagRepository = newsTagRepository;
            _newsViewRepository = newsViewRepository;
            _newsCommentRepository = newsCommentRepository;
        }


        [Route("/News/SingleNews/{id}")]
        public async Task<IActionResult> SingleNews([FromRoute]long id)
        {
            News news = await _newsRepository.FindAsync(id);
            if (news is not null && news.State)
            {
                await _newsViewRepository.AddAsync(new()
                {
                    NewsId = id,
                    IP = HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()
                });
                ViewBag.ViewCount = await _newsViewRepository.GetNewsViewCoungAsync(id);
                List<string> tages = await _newsTagRepository.GetAll(nt => nt.NewsId.Equals(id)).Select(nt => nt.Title).ToListAsync();
                tages.RemoveAt(0);
                ViewBag.Tages = tages;
                ViewBag.CommentCount = (await _newsCommentRepository.GetCommentCountByNewsId(id)).ToString("N0");
                return View(nameof(SingleNews), news);
            }
            return RedirectToPage("/Errors/NotFound");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveComment([FromForm][Bind("Name,Email,WebSite,Text,NewsId")]NewsComment comment)
        {
            if (await RecaptchaValidator.IsValidAsync(Request.Form["g-recaptcha-response"]))
            {
                ModelState.Remove("News");
                if (ModelState.IsValid)
                {
                    comment.CreateDate = DateTime.Now;
                    string badWord = string.Empty;
                    if (!CommentValidator.IsValid(comment.Text, ref badWord))
                    {
                        TempData["Error"] = $"نظر شما حاوی کلمات نامناسبی چون ({badWord}) میباشد \n\n متن پیام شما : {comment.Text}";
                    }
                    else
                    {
                        await _newsCommentRepository.AddAsync(comment);
                        TempData["Success"] = "Success";
                    }
                }
            }
            else
            {
                TempData["Error"] = "لطفا من ربات نیستم را تائید کنید";
            }
            return RedirectToAction(nameof(SingleNews), new { id = comment.NewsId });
        }
    }
}
