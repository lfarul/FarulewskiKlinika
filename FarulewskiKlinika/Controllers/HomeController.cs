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
using Microsoft.AspNetCore.Authorization;

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

        
        public IActionResult Lekarz()
        {

            List<Lekarz> lekarzeList = new List<Lekarz>();
            Lekarz lekarz = new Lekarz();


            lekarzeList.Add(new Lekarz { LekarzID = 1, Imie = "Konrad", Nazwisko = "Kowalski", Specjalizacja = "Internista", Email = "kkowalski@klinika" });
            lekarzeList.Add(new Lekarz { LekarzID = 2, Imie = "Agata", Nazwisko = "Nowak", Specjalizacja = "Laryngolog", Email = "anowak@klinika" });
            lekarzeList.Add(new Lekarz { LekarzID = 3, Imie = "Jan", Nazwisko = "Kujawski", Specjalizacja = "Dermatolog", Email = "jkujawski@klinika" });
            lekarzeList.Add(new Lekarz { LekarzID = 4, Imie = "Damian", Nazwisko = "Borowicz", Specjalizacja = "Stomatolog", Email = "dborowicz@klinika" });
            lekarzeList.Add(new Lekarz { LekarzID = 5, Imie = "Karolina", Nazwisko = "Zawadzka", Specjalizacja = "Okulista", Email = "kzawadzka@klinika" });
            lekarzeList.Add(new Lekarz { LekarzID = 6, Imie = "Dorota", Nazwisko = "Zimokowska", Specjalizacja = "Reumatolog", Email = "dzimokowska@klinika" });
            
            ViewBag.LekarzeList = lekarzeList;

            return View();
        
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
