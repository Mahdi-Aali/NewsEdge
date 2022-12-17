using Microsoft.AspNetCore.Http;
using News = NewsEdge.DataAccess.Models.PrimaryModels;
using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DTOs.News;

public class NewsViewModel
{
#nullable disable

    public long Id { get; set; }

    [Required(ErrorMessage = "عنوان خبر نمیتواند خالی باشد")]
    [MaxLength(250, ErrorMessage = "عنوان خبر نمیتواند بیشتر از 250 حرف باشد")]
    [MinLength(2, ErrorMessage = "عنوان خبر نمیتواند کمتر از 2 حرف باشد")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "متن خبر نمیتواند خالی باشد")]
    [MinLength(250, ErrorMessage = "عنوان خبر نمیتواند کمتر از 250 حرف باشد")]
    public string Description { get; set; } = string.Empty;

    [Url(ErrorMessage = "لطفا آدرس معتبری را قرار دهید")]
    [DataType(DataType.Url, ErrorMessage = "لطفا آدرس معتبری را قرار دهید. برای مثال (https://google.com)")]
    public string? YouTubeLink { get; set; }

    [Required(ErrorMessage = "تصویر خبر نمیتواند خالی باشد")]
    public IFormFile Image { get; set; }

    [Required(ErrorMessage = "کلمات کلیدی خبر نمیتواند خالی باشد")]
    [MaxLength(250, ErrorMessage = "کلمات کلیدی خبر نمیتواند بیشتر از 250 حرف باشد")]
    [MinLength(2, ErrorMessage = "کلمات کلیدی خبر نمیتواند کمتر از 2 حرف باشد")]
    public string Tages { get; set; } = string.Empty;


    public News::News ToNews()
    {
        return new()
        {
            Title = Title,
            Description = Description,
            State = false,
            CreateDate = DateTime.Now,
            ImagePath = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName),
            YouTubeLink = YouTubeLink
        };
    }

    public void ToNews(ref News::News news)
    {
        news.NewsId = Id;
        news.Title = Title;
        news.Description = Description;
        news.ImagePath = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
        news.YouTubeLink = YouTubeLink;
    }
}
