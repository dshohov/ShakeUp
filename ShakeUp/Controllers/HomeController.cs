using Microsoft.AspNetCore.Mvc;
using ShakeUp.Data.Enum;
using ShakeUp.Helpers;
using ShakeUp.Models;
using System.Diagnostics;

namespace ShakeUp.Controllers
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
            Phrasescs[] allValues = (Phrasescs[])Enum.GetValues(typeof(Phrasescs));
            Random random = new Random();
            Phrasescs randomValue = allValues[random.Next(allValues.Length)];
            string description = randomValue.GetDescription();
            ViewBag.Message = description;

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