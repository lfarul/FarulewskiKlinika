using System;
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

        //Wizytę umawia Pacjent - get
        [HttpGet]
        public ViewResult CreateWizyta(int id)
        {
            WizytaViewModel wizyta = new WizytaViewModel();
            wizyta.LekarzID = _lekarzRepository.GetLekarz(id).LekarzID;
            //parsowanie do int
            wizyta.UserID = userManager.GetUserId(User);
            return View(wizyta);
        }

        // Wizytę umawia Pacjent - post
        [HttpPost]
        public RedirectToActionResult CreateWizyta(WizytaViewModel wizyta)
        {
            if (context.Wizyty.Where(x =>x.DataWizyty == wizyta.DataWizyty && x.Lekarz.LekarzID == wizyta.Lekarz.LekarzID).Any())
            {
                return RedirectToAction("WizytaIstnieje");
            }

            else {
                Models.Wizyta wizytaModel = new Models.Wizyta();

                wizytaModel.Lekarz = context.Lekarze.FirstOrDefault(x => x.LekarzID == wizyta.Lekarz.LekarzID);
                wizytaModel.UserName = userManager.GetUserName(User);
                wizytaModel.DataWizyty = wizyta.DataWizyty;

                Wizyta newWizyta = _wizytaRepository.Add(wizytaModel);
                context.SaveChanges();
            }
            return RedirectToAction("GetAllWizyta");
        }

        //Wizytę umawia Personel - get
        [HttpGet]
        public ViewResult PersonelCreateWizyta(int id)
        {
            WizytaViewModel wizyta = new WizytaViewModel();
            wizyta.LekarzID = _lekarzRepository.GetLekarz(id).LekarzID;
            //parsowanie do int
            wizyta.UserID = userManager.GetUserId(User);
            return View(wizyta);
        }

        // Wizytę umawia Personel - post
        [HttpPost]
        public RedirectToActionResult PersonelCreateWizyta(WizytaViewModel wizyta)
        {
            if (context.Wizyty.Where(x => x.DataWizyty == wizyta.DataWizyty && x.Lekarz.LekarzID == wizyta.Lekarz.LekarzID).Any())
            {
                return RedirectToAction("WizytaIstnieje");
            }

            else
            {
                Models.Wizyta wizytaModel = new Models.Wizyta();

                wizytaModel.Lekarz = context.Lekarze.FirstOrDefault(x => x.LekarzID == wizyta.Lekarz.LekarzID);
                wizytaModel.UserName = userManager.GetUserName(User);
                wizytaModel.DataWizyty = wizyta.DataWizyty;

                Wizyta newWizyta = _wizytaRepository.Add(wizytaModel);
                context.SaveChanges();
            }
            return RedirectToAction("GetAllWizyta");
        }

        public IActionResult WizytaIstnieje()
        {
            return View();
        }

        public IActionResult SpoznionaWizyta()
        {
            ViewBag.TerazJest = DateTime.Now;
            return View();
        }

        // Tutaj Pacjent umawia wizytę
        public IActionResult Wizyta(int id)
        {
            WizytaViewModel wizytaViewModel = new WizytaViewModel()
            {
                UserID = userManager.GetUserId(User),
                Lekarz = _lekarzRepository.GetLekarz(id),
                LekarzID = _lekarzRepository.GetLekarz(id).LekarzID,
            };

            return View(wizytaViewModel);
        }

        // Tutaj Personel umawia wizytę
        public IActionResult PersonelWizyta(int id)
        {
            WizytaViewModel wizytaViewModel = new WizytaViewModel()
            {
                UserID = userManager.GetUserId(User),
                Lekarz = _lekarzRepository.GetLekarz(id),
                LekarzID = _lekarzRepository.GetLekarz(id).LekarzID,
            };

            return View(wizytaViewModel);
        }

        // Po umówieniu wizyty, Pacjent przechodzi do Podsumowania wizyty - WizytaDetails
        public ViewResult WizytaDetails(int id)
        {
            WizytaDetailsViewModel wizytaDetailsViewModel = new WizytaDetailsViewModel()
            {

                UserID = userManager.GetUserId(User),
                Wizyta = _wizytaRepository.GetWizyta(id),
                Lekarz = _lekarzRepository.GetLekarz(id),
            };

            return View(wizytaDetailsViewModel);
        }

        // Po umówieniu wizyty, podsumowanie można zapisać do PDF
        public async Task<IActionResult> WizytaPDF(int? id)
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

            return new ViewAsPdf(wizyta);
        }

        // Tutaj powinny wyświetlać się wizyty tylko dla zalogowanego lekarza
        public ViewResult MojaWizyta(int id)
        {
            var wizyta = _wizytaRepository.GetAllWizyta();
            wizyta = wizyta.Where(p => p.UserName == "jwayne@gmail.com");
            ViewBag.TerazJest = DateTime.Now;
            return View (wizyta);
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
