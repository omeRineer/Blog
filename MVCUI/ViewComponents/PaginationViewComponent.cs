using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MVCUI.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(int count)
        {
            var paginationCount = Convert.ToInt32(Math.Ceiling(Decimal.Divide(count, 5)));

            return View(paginationCount);
        }
    }
}
