using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalKsiazkowy.Models;

namespace PortalKsiazkowy.Controllers
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
            if (User.Identity.IsAuthenticated)
            {
                // Jeœli u¿ytkownik jest zalogowany, przekieruj na stronê g³ówn¹ dla zalogowanych
                return RedirectToAction("Welcome");
            }
            else
            {
                // Jeœli u¿ytkownik nie jest zalogowany, wyœwietl widok domyœlny
                return View();
            }
        }

        // Widok dla zalogowanych u¿ytkowników
        public IActionResult Welcome()
        {
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
