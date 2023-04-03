using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.ViewComponents
{
    public class ArchiveViewComponent:ViewComponent
    {
        readonly IArticleService _articleService;

        public ArchiveViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _articleService.GetAll(0);

            return View(result.Data);
        }
    }
}
