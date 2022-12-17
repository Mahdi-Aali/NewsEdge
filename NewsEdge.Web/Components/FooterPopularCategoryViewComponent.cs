using Microsoft.AspNetCore.Mvc;
using NewsEdge.DataAccess.Repositories.CategoryRepository;

namespace NewsEdge.Web.Components
{
    public class FooterPopularCategoryViewComponent : ViewComponent
    {
        private ICategoryRepository _categoryRepository;

        public FooterPopularCategoryViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _categoryRepository.GetPopularCategories());
        }
    }
}
