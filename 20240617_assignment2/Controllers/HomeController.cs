using _20240617_assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _20240617_assignment2.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CurrencyConverter()
        {
 //           ViewBag.Rate = 1.10; //Canadian Dollar to Australian Dollar
            ViewBag.Converted = 0; 
            return View();
        }

        [HttpPost]
        public IActionResult CurrencyConverter(ConverterModel model)
        {
            ViewBag.Converted = model.ConvertAmount();
            return View();
        }

        public IActionResult Calculator()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
