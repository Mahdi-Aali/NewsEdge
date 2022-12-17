using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DataAccess.Models.PrimaryModels;
#nullable disable
public class NewsComment
{
    [Key]
    public long NewsCommentId { get; set; }

    [Required(ErrorMessage = "نام نمیتواند خالی باشد")]
    [MaxLength(50, ErrorMessage = "نام نمیتواند بیشتر از 50 حرف باشد")]
    [MinLength(2, ErrorMessage = "متن نظر نمیتواند کمتر از 2 حرف باشد")]
    public string Name { get; set; } = string.Empty;


    [Required(ErrorMessage = "آدرس ایمیل نمیتواند خالی باشد.")]
    [MaxLength(256, ErrorMessage = "آدرس ایمیل نمیتواند بیشتر از 256 حرف باشد")]
    [MinLength(10, ErrorMessage = "آدرس ایمیل نمیتواند کمتر از 10 حرف باشد")]
    [DataType(DataType.EmailAddress, ErrorMessage = "لطفا آدرس ایمیل معتبر را وارد کنید")]
    [EmailAddress(ErrorMessage = "لطفا آدرس ایمیل معتبر را وارد کنید")]
    public string Email { get; set; }

    [MaxLength(256, ErrorMessage = "آدرس وب سایت نمیتواند بیشتر از 256 حرف باشد")]
    [MinLength(10, ErrorMessage = "آدرس وب سایت نمیتواند کمتر از 256 حرف باشد")]
    [DataType(DataType.Url, ErrorMessage = "لطفا آدرس وب سایت معتبری را وارد کنید")]
    [Url(ErrorMessage = "لطفا آدرس وب سایت معتبری را وارد کنید")]
    public string WebSite { get; set; }

    [Required(ErrorMessage = "متن نظر نمیتواند خالی باشد")]
    [MaxLength(255, ErrorMessage = "متن نظر نمیتواند بیشتر از 255 حرف باشد")]
    [MinLength(2, ErrorMessage = "متن نظر نمیتواند کمتر از 2 حرف باشد")]
    public string Text { get; set; } = string.Empty;

    public long NewsId { get; set; }
    public News News { get; set; }

    public DateTime CreateDate { get; set; }    
}
