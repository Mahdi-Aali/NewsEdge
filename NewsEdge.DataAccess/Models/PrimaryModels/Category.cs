using System.ComponentModel.DataAnnotations;

namespace NewsEdge.DataAccess.Models.PrimaryModels
{
    public class Category
    {
        #nullable disable
        [Key]
        public long CategoryId { get; set; }

        [Required(ErrorMessage = "عنوان دسته بندی نمیتواند خالی باشد.")]
        [MaxLength(50, ErrorMessage = "عنوان دسته بندی نمیتواند بیشتر از 50 حرف باشد.")]
        [MinLength(2, ErrorMessage = "عنوان دسته بندی نمیتواند کمتر از 3 حرف باشد")]
        public string Title { get; set; } = string.Empty;
        public long? ParentId { get; set; }

        public Category Category1 { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<NewsCategory> NewsCategories { get; set; }
    }
}
