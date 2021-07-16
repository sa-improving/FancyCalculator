using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CalculatorCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineCalculator.Models;

namespace OnlineCalculator.Controllers
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

        [HttpPost]
        public IActionResult Index(string submittedValue)
        {
            Calculator calculator;
            var previousValue = HttpContext.Session.Get<decimal>("LatestValue");

            decimal submission; 
            decimal.TryParse(submittedValue, out submission);

            if(previousValue != 0)
            {
                calculator = new Calculator(submission);
            }
            else
            {
                calculator = new Calculator(0);
            }
            HttpContext.Session.Set("LatestValue", submission);
            return View();
        }

        public IActionResult Privacy()
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
