using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DTOs.User;

public class EditProfileViewModel
{
    [Required(ErrorMessage = "نام واقعی نمیتواند خالی باشد.")]
    [MaxLength(50, ErrorMessage = "نام واقعی نمیتواند بیستر از 50 حرف باشد.")]
    [MinLength(5, ErrorMessage = "نام واقعی نمیتواند کمتر از 5 حرف باشد")]
    public string RealName { get; set; } = string.Empty;


    [Required(ErrorMessage = "درباره من نمیتواند خالی باشد.")]
    [MaxLength(800, ErrorMessage = "درباره من نمیتواند بیستر از 800 حرف باشد.")]
    [MinLength(5, ErrorMessage = "نام واقعی نمیتواند کمتر از 5 حرف باشد")]
    public string Bio { get; set; } = string.Empty;

    public IBrowserFile Image { get; set; } = null!;
}
