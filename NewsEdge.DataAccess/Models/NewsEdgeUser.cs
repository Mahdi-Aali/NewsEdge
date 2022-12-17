using Microsoft.AspNetCore.Identity;
using NewsEdge.DataAccess.Models.PrimaryModels;
using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DataAccess.Models;

public class NewsEdgeUser : IdentityUser<long>
{
#nullable disable
    [Required]
    [MaxLength(800)]
    public string Bio { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string ImagePath { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string RealName { get; set; } = string.Empty;
    public ICollection<News> News { get; set; }
}
