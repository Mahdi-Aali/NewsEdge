using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DTOs.Account;

public class ConfirmPhoneNumberViewModel
{
    [Required(ErrorMessage = "کد تائید نمیتواند خالی باشد")]
    [MinLength(6, ErrorMessage = "کد تائید نمیتواند کمتر از 6 عدد باشد.")]
    [MaxLength(6, ErrorMessage = "کد تائید نمیتواند بیشتر از 6 عدد باشد.")]
    public string ConfirmCode { get; set; } = string.Empty;
}
