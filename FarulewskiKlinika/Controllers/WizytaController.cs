﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarulewskiKlinika.DataContext;
using FarulewskiKlinika.Models;
using FarulewskiKlinika.Repositories;
using FarulewskiKlinika.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

namespace FarulewskiKlinika.Controllers
{
    public class WizytaController : Controller
    {

        // atrybut readonly uniemożliwia przypadkowe nadanie nowej wartości polu _wizytaRepository
        private readonly WizytaRepository _wizytaRepository;
        private readonly LekarzRepository _lekarzRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        public WizytaController(WizytaRepository wizytaRepository, LekarzRepository lekarzRepository, 
            UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _wizytaRepository = wizytaRepository;
            _lekarzRepository = lekarzRepository;
            this.userManager = userManager;
            this.context = context;
        }

        // Tutaj wyświetlam wszystkie wizyty
        public ViewResult GetAllWizyta()
        {
            var model = _wizytaRepository.GetAllWizyta();
            ViewBag.TerazJest = DateTime.Now;
            return View(model);
;        }

        //Ta metoda zwraca formularz do wypełnienia w celu umówienia wizyty
        [HttpGet]
        public ViewResult CreateWizyta()
        {
            return View();
        }

        // Tutaj Recepcja i Administrator umawia wizytę
        [HttpPost]
        public RedirectToActionResult CreateWizyta(Wizyta wizyta)
        {
            Wizyta newWizyta =_wizytaRepository.Add(wizyta);
    
            return RedirectToAction("GetAllWizyta");
        }


        // Tutaj Pacjent umawia wizytę
        public IActionResult Wizyta(int id)
        {
            WizytaViewModel wizytaViewModel = new WizytaViewModel()
            {
                Lekarz = _lekarzRepository.GetLekarz(id),
            };

            return View(wizytaViewModel);
        }

        // Po umówieniu wizyty, Pacjent przechodzi do Podsumowania wizyty - WizytaDetails
        public ViewResult WizytaDetails(int id)
        {
            WizytaDetailsViewModel wizytaDetailsViewModel = new WizytaDetailsViewModel()
            {
                Lekarz = _lekarzRepository.GetLekarz(id),
            };

            return View(wizytaDetailsViewModel);
        }

        // Po umówieniu wizyty, podsumowanie można zapisać do PDF
        public ViewResult WizytaPDF(int id)
        {
            WizytaDetailsPdfViewModel wizytaDetailsPdfViewModel = new WizytaDetailsPdfViewModel()
            {
                Lekarz = _lekarzRepository.GetLekarz(id),

            };
            return new ViewAsPdf(wizytaDetailsPdfViewModel);
        }

        // Tutaj powinny wyświetlać się wizyty tylko dla zalogowanego lekarza
        public IActionResult MojaWizyta(int id)
        {
            var wizyta = _wizytaRepository.GetAllWizyta();
            ViewBag.TerazJest = DateTime.Now;
            return View(wizyta);
        }

        // Edytuję wizytę
        [HttpGet]
        public ViewResult EditWizyta(int id)
        {
            Wizyta wizyta = _wizytaRepository.GetWizyta(id);
            WizytaEditViewModel wizytaEditViewModel = new WizytaEditViewModel
            {
                WizytaID = wizyta.WizytaID,
                LekarzID = wizyta.LekarzID,
                UserName = wizyta.UserName,
                DataWizyty = wizyta.DataWizyty

            };
            return View(wizytaEditViewModel);
        }

        // Dokonuję zmian w edytowanej wizycie
        [HttpPost]
        public IActionResult EditWizyta(WizytaEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Wizyta wizyta = _wizytaRepository.GetWizyta(model.WizytaID);
                wizyta.LekarzID = model.LekarzID;
                wizyta.UserName = model.UserName;
                wizyta.DataWizyty = model.DataWizyty;

                _wizytaRepository.Update(wizyta);

                return RedirectToAction("GetAllWizyta");
            }
            return View();
        }

        // Pokazuje szczegóły dla wizyty
        public async Task<IActionResult> DetailWizyta(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wizyta = await context.Wizyty
                .FirstOrDefaultAsync(m => m.WizytaID == id);
            if (wizyta == null)
            {
                return NotFound();
            }

            return View(wizyta);
        }

        // Usuwa wizytę
        public ActionResult DeleteWizyta(int id)
        {
            // before deleting a Pacjent, we need to find them first
            Wizyta wizyta = context.Wizyty.Find(id);
            if (wizyta != null)
            {
                context.Wizyty.Remove(wizyta);
                context.SaveChanges();
            }
            return RedirectToAction ("GetAllWizyta");
        }

        private bool WizytaExists(int id)
        {
            return context.Wizyty.Any(e => e.WizytaID == id);
        }
    }
}