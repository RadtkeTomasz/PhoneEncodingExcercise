using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Models.Helpers;

namespace WebApplication1.Controllers
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
            var inputString = new InputString();
            return View(inputString);
        }
        [HttpPost]
        public IActionResult CodeMyInput(InputString input)
        {
            if (ModelState.IsValid)
            {
                var encodedString = PhoneEncoder.EncodeStringToPhoneInput(input);
                return View("Encoded", encodedString);
            }
            else
            {
                return View();
            }
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