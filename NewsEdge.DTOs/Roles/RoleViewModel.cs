using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DTOs.Roles;

public class RoleViewModel
{

    public long Id { get; set; } = 0;


    [Required(ErrorMessage = "عنوان نقش نمیتواند خالی باشد")]
    [MaxLength(50, ErrorMessage = "عنوان نقش نمیتواند بیشتر از 50 حرف باشد")]
    [MinLength(2, ErrorMessage = "عنوان نقش نمیتواند کمتر از 2 حرف باشد")]
    public string Name { get; set; } = string.Empty;


    public IdentityRole<long> ToIdentityRole()
    {
        if (this.Name.Equals(string.Empty))
        {
            throw new NullReferenceException(nameof(Name));
        }
        else
        {
            return new()
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}
