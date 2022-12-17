using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DTOs.Account;

public class ResetPasswordViewModel
{
    public long UserId { get; set; }
    public string Token { get; set; } = string.Empty;

    [Required(ErrorMessage = "رمز عبور نمیتواند خالی باشد")]
    [MaxLength(50, ErrorMessage = "رمز عبور نمیتواند بیشتر از 50 حرف باشد")]
    [MinLength(8, ErrorMessage = "رمز عبور نمیتواند کمتر از 8 حرف باشد")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "تکرار رمز عبور نمیتواند خالی باشد")]
    [MaxLength(50, ErrorMessage = "تکرار رمز عبور نمیتواند بیشتر از 50 حرف باشد")]
    [MinLength(8, ErrorMessage = "تکرار رمز عبور نمیتواند کمتر از 8 حرف باشد")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "رمز های عبور با هم مغایرت دارند.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
