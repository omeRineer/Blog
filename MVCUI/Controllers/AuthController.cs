using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
