using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DTOs.Account;

public class LoginViewModel
{
    [Required(ErrorMessage = "آدرس ایمیل نمیتواند خالی باشد.")]
    [MaxLength(256, ErrorMessage = "آدرس ایمیل نمیتواند بیشتر از 256 حرف باشد")]
    [MinLength(10, ErrorMessage = "آدرس ایمیل نمیتواند کمتر از 256 حرف باشد")]
    [DataType(DataType.EmailAddress, ErrorMessage = "لطفا آدرس ایمیل معتبر را وارد کنید")]
    [EmailAddress(ErrorMessage = "لطفا آدرس ایمیل معتبر را وارد کنید")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "رمز عبور نمیتواند خالی باشد")]
    [MaxLength(50, ErrorMessage = "رمز عبور نمیتواند بیشتر از 50 حرف باشد")]
    [MinLength(8, ErrorMessage = "رمز عبور نمیتواند کمتر از 8 حرف باشد")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; } = false;
}
