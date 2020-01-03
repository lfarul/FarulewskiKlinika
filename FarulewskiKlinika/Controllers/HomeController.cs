using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FarulewskiKlinika.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using FarulewskiKlinika.DataContext;

namespace FarulewskiKlinika.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
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
            /*ViewData["LekarzID"] = new SelectList(_context.Lekarze, "LekarzID", "Email");
            ViewData["PacjentID"] = new SelectList(_context.Pacjenci, "PacjentID", "Email");
            ViewData["LekarzID"] = new SelectList(_context.Lekarze, "LekarzID", "Email");*/
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
