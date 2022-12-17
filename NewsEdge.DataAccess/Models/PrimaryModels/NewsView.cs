using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DataAccess.Models.PrimaryModels;

public class NewsView
{
#nullable disable
    [Key]
    public long NewsViewId { get; set; }
    [Required]
    [MaxLength(20)]
    public string IP { get; set; } = string.Empty;
    public long NewsId { get; set; }
    public News News { get; set; }
}
