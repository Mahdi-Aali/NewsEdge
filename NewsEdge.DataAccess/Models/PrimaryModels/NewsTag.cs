using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DataAccess.Models.PrimaryModels;

public class NewsTag
{
#nullable disable
    [Key]
    public long NewsTagId { get; set; }

    public long NewsId { get; set; }
    public News News { get; set; }

    [Required(ErrorMessage = "عنوان برچسب نمیتواند خالی باشد")]
    [MaxLength(25, ErrorMessage = "عنوان برچسب نمیتواند بیشتر از 25 حرف باشد")]
    [MinLength(2, ErrorMessage = "عنوان برچسب نمیتواند کمتر از 2 حرف باشد")]
    public string Title { get; set; } = string.Empty;
}
