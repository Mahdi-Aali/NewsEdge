using NewsEdge.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DTOs.Account;

public class RegisterViewModel
{
    [Required(ErrorMessage = "نام کاربری نمیتواند خالی باشد")]
    [MaxLength(50, ErrorMessage = "نام کاربری نمیتواند بیشتر از 32 حرق باشد")]
    [MinLength(3, ErrorMessage = "نام کاربری نمیتواند کمتر از 3 حرف باشد")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "آدرس ایمیل نمیتواند خالی باشد.")]
    [MaxLength(256, ErrorMessage = "آدرس ایمیل نمیتواند بیشتر از 256 حرف باشد")]
    [MinLength(10, ErrorMessage = "آدرس ایمیل نمیتواند کمتر از 10 حرف باشد")]
    [DataType(DataType.EmailAddress, ErrorMessage = "لطفا آدرس ایمیل معتبر را وارد کنید")]
    [EmailAddress(ErrorMessage = "لطفا آدرس ایمیل معتبر را وارد کنید")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "شماره تلفن همراه نمیتواند خالی باشد")]
    [MaxLength(14, ErrorMessage = "شماره تلفن همراه نمیتواند بیشتر از 14 عدد باشد")]
    [MinLength(11, ErrorMessage = "شماره تلفن همراه نمیتواند کمتر از 11 حرف باشد")]
    public string PhoneNumber { get; set; } = string.Empty;

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



    public NewsEdgeUser ToNewsEdgeUser()
    {
        if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Email) &&
            !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(Password) &&
            !string.IsNullOrEmpty(ConfirmPassword))
        {
            return new()
            {
                UserName = this.UserName,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber
            };
        }
        throw new NullReferenceException("Some of properties in RegisterViewModel DTOs is null or empty!");
    }
}
