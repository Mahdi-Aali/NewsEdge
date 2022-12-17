using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DataAccess.Models.PrimaryModels;

public class NewsSection
{
    [Key]
    public long NewsSectionId { get; set; }

    [Required(ErrorMessage = "لطفا عنوان قسمت را وارد نمائید.")]
    [MaxLength(50, ErrorMessage = "عنوان قسمت نیتواند بیشتر از 50 حرف باشد")]
    [MinLength(2, ErrorMessage = "عنوان قسمت نمیتواند کمتر از 2 حرف باشد")]
    public string SectionName { get; set; } = string.Empty;


    public ICollection<NewsInSection> NewsInSections { get; set; }

}
