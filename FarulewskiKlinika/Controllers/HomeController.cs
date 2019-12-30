using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FarulewskiKlinika.Models;

namespace FarulewskiKlinika.Controllers
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

        public IActionResult Onas()
        {
            return View();
        }

        public IActionResult Personel()
        {
            return View();
        }

        public IActionResult Wizyta()
        {
            //ViewData["LekarzID"] = new SelectList(_context.Pracownik, "PracownikID", "Email");
            //ViewData["PacjentID"] = new SelectList(_context.Pacjent, "PacjentID", "Email");

            return View();
        }

        public IActionResult Kontakt()
        {
            return View();
        }

        // Możliwość umówienia wizyty pojawia się po zalogowaniu
        public IActionResult Spotkanie()
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
