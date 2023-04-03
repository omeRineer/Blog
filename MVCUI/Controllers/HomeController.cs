using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCUI.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            ViewData["LinkActive"] = "Ana Sayfa";
            return View();
        }
    }
}
