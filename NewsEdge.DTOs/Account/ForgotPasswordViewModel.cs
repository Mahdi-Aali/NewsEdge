using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DTOs.Account;

public class ForgotPasswordViewModel
{
    [Required(ErrorMessage = "آدرس ایمیل نمیتواند خالی باشد.")]
    [MaxLength(256, ErrorMessage = "آدرس ایمیل نمیتواند بیشتر از 256 حرف باشد")]
    [MinLength(10, ErrorMessage = "آدرس ایمیل نمیتواند کمتر از 256 حرف باشد")]
    [DataType(DataType.EmailAddress, ErrorMessage = "لطفا آدرس ایمیل معتبر را وارد کنید")]
    [EmailAddress(ErrorMessage = "لطفا آدرس ایمیل معتبر را وارد کنید")]
    [Remote("ForgotPasswordEmailExist", "RemoteValidation", ErrorMessage = "حسابی با این ایمیل در سایت موجود نمیباشد")]
    public string Email { get; set; } = string.Empty;
}
