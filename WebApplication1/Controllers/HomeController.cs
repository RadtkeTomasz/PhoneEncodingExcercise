using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Dictionary<string, string> _phoneKeyboardMappings = new Dictionary<string, string>() 
        {
            { "a", "2"},
            { "b", "22"},
            { "c", "222" },
            { "d", "3" },
            { "e", "33" },
            { "f", "333" },
            { "g","4" },
            { "h", "44" },
            { "i", "444" },
            { "j", "5" },
            { "k", "55" },
            { "l", "555" },
            { "m", "6"},
            { "n", "66" },
            { "o", "666" },
            { "p", "7" },
            { "q", "77" },
            { "r", "777" },
            { "s", "7777" },
            { "t", "8" },
            { "u", "88" },
            { "v", "888" },
            { "w", "9" },
            { "x", "99" },
            { "y", "999" },
            { "z", "9999" },
        };
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
                var sb = new StringBuilder();
                var inputLetters = input.Text.ToLower().ToArray();

                foreach (var letter in inputLetters)
                {
                    if (_phoneKeyboardMappings.TryGetValue(letter.ToString(), out string value))
                    {
                        sb.Append('[').Append(value).Append(']');
                    }
                }
                var result = sb.ToString();
                var encodedString = new InputString();
                encodedString.Text = result;
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