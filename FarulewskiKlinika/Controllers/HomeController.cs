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
using FarulewskiKlinika.Repositories;
using Microsoft.AspNetCore.Hosting;
using FarulewskiKlinika.ViewModels;
using System.IO;

namespace FarulewskiKlinika.Controllers
{
    public class HomeController : Controller
    {
       
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

        public IActionResult Kontakt()
        {
            return View();
        }

        // Możliwość umówienia wizyty pojawia się po zalogowaniu
        public IActionResult Spotkanie()
        {
            return View();
        }
    }
}
