using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Models
{
    public class Lekarz
    {
        public int LekarzID { get; set; }

        // Imie
        [Required(ErrorMessage = "Proszę podać imię lekarza")]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        // Nazwisko
        [Required(ErrorMessage = "Proszę podać nazwisko lekarza")]
        public string Nazwisko { get; set; }

        // Specjalizacja
        [Required(ErrorMessage = "Proszę podać specjalizację")]
        public string Specjalizacja { get; set; }

        // Email
        [Required(ErrorMessage = "Proszę podać email")]
        [RegularExpression(@"^[a-zA-Z0-9_+.-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "To nie jest email")]
        public string Email { get; set; }

        // Opis
        public string Opis { get; set; }

        // Zdjęcie
        [Display(Name = "Zdjęcie")]
        public string PhotoPath { get; set; }

        // navigation properties - lekarz może mieć kilka wizyt
        public virtual ICollection<Wizyta> Wizyty { get; set; }

    }
}


