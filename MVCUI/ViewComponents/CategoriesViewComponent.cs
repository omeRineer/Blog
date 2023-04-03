using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        readonly ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _categoryService.GetAllByCategoryReadDto();

            return View(result.Data);
        }
    }
}
