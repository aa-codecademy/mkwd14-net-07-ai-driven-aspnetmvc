using System.Diagnostics;
using ASP.NET.MVC.Class02.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.MVC.Class02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() // localhost:port/home/index
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
