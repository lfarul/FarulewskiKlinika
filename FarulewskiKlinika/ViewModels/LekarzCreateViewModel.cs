using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.ViewModels
{
    public class LekarzCreateViewModel
    {
        // Imie
        [Required(ErrorMessage = "Proszę podać imię lekarza")]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        // Nazwisko
        [Required(ErrorMessage = "Proszę podać nazwisko lekarza")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Proszę podać specjalizację")]
        public string Specjalizacja { get; set; }

        // Email
        [Required(ErrorMessage = "Proszę podać email")]
        [RegularExpression(@"^[a-zA-Z0-9_+.-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "To nie jest email")]
        public string Email { get; set; }

        [Display(Name = "Zdjęcie")]
        public IFormFile Foto { get; set; }

        
        [Required(ErrorMessage = "Proszę podać opis")]
        public string Opis { get; set; }

    }
}
