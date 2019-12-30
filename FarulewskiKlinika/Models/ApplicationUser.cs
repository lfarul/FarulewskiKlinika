using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Pesel
        [Required(ErrorMessage = "Proszę podać 11 cyfrowy pesel")]
        [RegularExpression(@"^[0-9]{11}$")]
        public string Pesel { get; set; }

        // Imie
        [Required(ErrorMessage = "Proszę podać imię")]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        // Nazwisko
        [Required(ErrorMessage = "Proszę podać nazwisko")]
        public string Nazwisko { get; set; }
    }
}

