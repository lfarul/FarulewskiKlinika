using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.ViewModels
{
    public class RegisterViewModel
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

        //Email
        [Required(ErrorMessage = "Proszę podać adres email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // Hasło
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Haslo { get; set; }

        // Potwierdzenie hasła
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Haslo", ErrorMessage = "Podane hasła nie są takie same.")]
        public string PotwierdzHaslo { get; set; }
    }
}
