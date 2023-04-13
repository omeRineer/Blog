using Microsoft.AspNetCore.Mvc;

namespace MVCUI.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
