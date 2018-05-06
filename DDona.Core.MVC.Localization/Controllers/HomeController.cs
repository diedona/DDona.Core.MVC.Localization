using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DDona.Core.MVC.Localization.Models;
using Microsoft.Extensions.Localization;

namespace DDona.Core.MVC.Localization.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer _localizer;

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _localizer["Page Description"];

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
