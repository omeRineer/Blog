using Microsoft.AspNetCore.Mvc;

namespace MVCUI.ViewComponents
{
    public class ContactViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
