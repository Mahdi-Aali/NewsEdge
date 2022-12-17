using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DTOs.Account;

public class ChangePasswordViewModel
{
    [Required(ErrorMessage = "رمز عبور قبلی نمیتواند خالی باشد")]
    [MaxLength(50, ErrorMessage = "رمز عبور قبلی نمیتواند بیشتر از 50 حرف باشد")]
    [MinLength(8, ErrorMessage = "رمز عبور قبلی نمیتواند کمتر از 8 حرف باشد")]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "رمز عبور جدید نمیتواند خالی باشد")]
    [MaxLength(50, ErrorMessage = "رمز عبور جدید نمیتواند بیشتر از 50 حرف باشد")]
    [MinLength(8, ErrorMessage = "رمز عبور جدید نمیتواند کمتر از 8 حرف باشد")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "تکرار رمز عبور جدید نمیتواند خالی باشد")]
    [MaxLength(50, ErrorMessage = "تکرار رمز عبورجدید نمیتواند بیشتر از 50 حرف باشد")]
    [MinLength(8, ErrorMessage = "تکرار رمز عبور جدید نمیتواند کمتر از 8 حرف باشد")]
    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "رمز های عبور جدید با هم مغایرت دارند.")]
    public string ConfirmNewPassword { get; set; } = string.Empty;
}
