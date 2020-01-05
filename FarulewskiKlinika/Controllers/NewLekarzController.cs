using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FarulewskiKlinika.Models;
using FarulewskiKlinika.Repositories;
using FarulewskiKlinika.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FarulewskiKlinika.Controllers
{
    public class NewLekarzController : Controller
    {
        // dependency injection przez konstruktor
        private readonly LekarzRepository _lekarzRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly UserManager<ApplicationUser> userManager;

        public NewLekarzController(LekarzRepository lekarzRepository, IHostingEnvironment hostingEnvironment,
            UserManager<ApplicationUser> userManager)
        {
            _lekarzRepository = lekarzRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
        }

        public ViewResult NewIndex()
        {
            var model = _lekarzRepository.GetAllLekarz();
            return View(model);
        }

        public ViewResult Details(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Lekarz = _lekarzRepository.GetLekarz(id),
                PageTitle = "Lekarz Details"
            };

            return View(homeDetailsViewModel);
        }
        [HttpGet]
        //[Authorize]
        public ViewResult Create()
        {

            return View();
        }

        [HttpGet]
        //[Authorize]
        public ViewResult Edit(int id)
        {
            Lekarz lekarz = _lekarzRepository.GetLekarz(id);
            LekarzEditViewModel lekarzEditViewModel = new LekarzEditViewModel
            {
                LekarzID = lekarz.LekarzID,
                Imie = lekarz.Imie,
                Nazwisko = lekarz.Nazwisko,
                Specjalizacja = lekarz.Specjalizacja,
                Email = lekarz.Email,
                Opis = lekarz.Opis,
                ExistingPhotoPath = lekarz.PhotoPath
            };
            return View(lekarzEditViewModel);
        }


        [HttpPost]
        //[Authorize]
        public IActionResult Edit(LekarzEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Lekarz lekarz = _lekarzRepository.GetLekarz(model.LekarzID);
                lekarz.Imie = model.Imie;
                lekarz.Nazwisko = model.Nazwisko;
                lekarz.Specjalizacja = model.Specjalizacja;
                lekarz.Email = model.Email;
                lekarz.Opis = model.Opis;

                if (model.Foto != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "Images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    lekarz.PhotoPath = ProcessUploadedFile(model);
                }

                _lekarzRepository.Update(lekarz);

                return RedirectToAction("NewIndex");
            }
            return View();
        }

        private string ProcessUploadedFile(LekarzCreateViewModel model)
        {
            string uniqueFileName = null;

            if (model.Foto != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Foto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Foto.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Create(LekarzCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Lekarz newLekarz = new Lekarz
                {
                    Imie = model.Imie,
                    Nazwisko = model.Nazwisko,
                    Specjalizacja = model.Specjalizacja,
                    Email = model.Email,
                    Opis = model.Opis,
                    PhotoPath = uniqueFileName
                };

                _lekarzRepository.Add(newLekarz);

                return RedirectToAction("details", new { id = newLekarz.LekarzID });
            }
            return View();
        }

        public IActionResult Wizyta(int id)
        {
            WizytaViewModel wizytaViewModel = new WizytaViewModel()
            {
                Lekarz = _lekarzRepository.GetLekarz(id),
            };

            return View(wizytaViewModel);
        }

        public ViewResult WizytaDetails(int id)
        {
            WizytaDetailsViewModel wizytaDetailsViewModel = new WizytaDetailsViewModel()
            {
                Lekarz = _lekarzRepository.GetLekarz(id),
                
            };

            return View(wizytaDetailsViewModel);
        }

        public IActionResult ZapiszWizyta(WizytaViewModel model)
        {
            //WizytaViewModel wizytaViewModel = new WizytaViewModel();
            Wizyta wizyta = new Wizyta();

            wizyta.Lekarz = model.Lekarz;
            wizyta.PacjentID = model.PacjentID;
            wizyta.WizytaID = model.WizytaID;
            wizyta.DataWizyty = model.DataWizyty;
          
            return View ("WizytaDetails");
        }
    }
}
 