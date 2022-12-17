using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DataAccess.Models.PrimaryModels;

public class NewsCategory
{
#nullable disable
    [Key]
    public long NewsCategoryId { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }

    public long NewsId { get; set; }
    public News News { get; set; }
}
