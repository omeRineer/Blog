using Microsoft.AspNetCore.Mvc;

namespace MVCUI.ViewComponents
{
    public class SubscribeViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
