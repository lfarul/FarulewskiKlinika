using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Models
{
    public class Pacjent
    {
        // Primary key
        public int PacjentID { get; set; }

        // Pesel
        [Required(ErrorMessage = "Proszę podać 11 cyfrowy pesel")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Pesel musi zawierać 11 cyfr.")]
        public string Pesel { get; set; }

        // Imie
        [Required(ErrorMessage = "Proszę podać imię pacjenta")]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        // Nazwisko
        [Required(ErrorMessage = "Proszę podać nazwisko pacjenta")]
        public string Nazwisko { get; set; }

        // Email
        [Required(ErrorMessage = "Proszę podać email")]
        [RegularExpression(@"^[a-zA-Z0-9_+.-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "To nie jest email")]
        public string Email { get; set; }


        //public string Foto { get; set; }


        // navigation properties czyli określanie związków między encjami w EF
        // pacjent może być zapisany na kilka wizyt
        public virtual ICollection<Wizyta> Wizyty { get; set; }
    }
}
   
