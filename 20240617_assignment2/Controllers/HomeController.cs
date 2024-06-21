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

        [HttpGet]
        public IActionResult Calculator() 
        { 
            ViewBag.Result = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Calculator(CalculatorModel model, string CalculationType)
        {
            if (ModelState.IsValid)
            {
                if (CalculationType.Equals("PV"))
                {
                    double temp = model.CalculateAnnuityPresentValue();
                    ViewBag.Result = (decimal)model.CalculateAnnuityPresentValue();
                }
                else if (CalculationType.Equals("FV"))
                {
                    double temp = model.CalculateAnnuityFutureValue();
                    ViewBag.Result = (decimal)model.CalculateAnnuityFutureValue();
                }
                else
                {
                    ViewBag.Result = 0; //deal with wrong input
                }
            }
            else
            {
                ViewBag.Result = 0; //deal with invalid state
            }

            return View(model);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
