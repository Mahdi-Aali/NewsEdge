using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DataAccess.Models.PrimaryModels;

public class News
{
#nullable disable
    [Key]
    public long NewsId { get; set; }
    
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

    [MaxLength(50)]
    [Required]
    public string ImagePath { get; set; } = string.Empty;

    public bool State { get; set; } = false;
    public DateTime CreateDate { get; set; }

    public long UserId { get; set; }
    public NewsEdgeUser NewsEdgeUser { get; set; }



    public ICollection<NewsTag> NewsTags { get; set; }
    public ICollection<NewsCategory> NewsCategories { get; set; }
    public ICollection<NewsView> NewsViews { get; set; }
    public ICollection<NewsComment> NewsComments { get; set; }
    public ICollection<NewsInSection> NewsInSections { get; set; }
}
