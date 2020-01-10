using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarulewskiKlinika.Models;
using FarulewskiKlinika.Repositories;
using FarulewskiKlinika.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace FarulewskiKlinika.Controllers
{
    public class WizytaController : Controller
    {

        // atrybut readonly uniemożliwia przypadkowe nadanie nowej wartości polu _wizytaRepository
        private readonly WizytaRepository _wizytaRepository;
        private readonly LekarzRepository _lekarzRepository;
        public WizytaController(WizytaRepository wizytaRepository, LekarzRepository lekarzRepository)
        {
            _wizytaRepository = wizytaRepository;
            _lekarzRepository = lekarzRepository;
        }

        public int Test()
        {
            return _wizytaRepository.GetWizyta(1).WizytaID;
        }

        public ViewResult WizytaDetailsTest()
        {
            //tworzę instancję klasy WizytaDetailsTestViewModel
            WizytaDetailsTestViewModel wizytaDetailsTestViewModel = new WizytaDetailsTestViewModel()
            {
                Wizyta = _wizytaRepository.GetWizyta(1),
            };

            ViewBag.TerazJest = DateTime.Now;


            return View(wizytaDetailsTestViewModel);
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        public ViewResult GetAllWizyta()
        {
            var model = _wizytaRepository.GetAllWizyta();
            ViewBag.TerazJest = DateTime.Now;
            return View(model);
;        }

        //Ta metoda zwraca nam formularz do wypełnienia w celu umówienia wizyty
        [HttpGet]
        public ViewResult CreateWizyta()
        {
            return View();
        }

        [HttpPost]
        // Tworzę wizytę
        public RedirectToActionResult CreateWizyta(Wizyta wizyta)
        {
            Wizyta newWizyta =_wizytaRepository.Add(wizyta);

            return RedirectToAction("GetAllWizyta");
        }


        //[HttpPost]
        public IActionResult Wizyta(int id)
        {
            WizytaViewModel wizytaViewModel = new WizytaViewModel()
            {
                Lekarz = _lekarzRepository.GetLekarz(id),

            };

            return View(wizytaViewModel);
        }
        //[HttpGet]
        public ViewResult WizytaDetails(int id)
        {
            WizytaDetailsViewModel wizytaDetailsViewModel = new WizytaDetailsViewModel()
            {
                Lekarz = _lekarzRepository.GetLekarz(id),
            };

            return View(wizytaDetailsViewModel);
        }

        // Zapisz w PDF
        public ViewResult WizytaPDF(int id)
        {
            WizytaDetailsPdfViewModel wizytaDetailsPdfViewModel = new WizytaDetailsPdfViewModel()
            {
                Lekarz = _lekarzRepository.GetLekarz(id),

            };
            return new ViewAsPdf(wizytaDetailsPdfViewModel);
        }

    }
}
