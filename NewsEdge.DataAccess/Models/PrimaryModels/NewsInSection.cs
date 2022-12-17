using System.ComponentModel.DataAnnotations;
#nullable disable
namespace NewsEdge.DataAccess.Models.PrimaryModels;

public class NewsInSection
{
    [Key]
    public long NewsInSectionId { get; set; }

    public long NewsId { get; set; }
    public News News { get; set; }

    public long NewsSectionId { get; set; }
    public NewsSection NewsSection { get; set; }
}
