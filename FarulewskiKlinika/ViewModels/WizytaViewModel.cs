using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.ViewModels
{
    public class WizytaViewModel
    {
        public int WizytaID { get; set; }

        public string UserName { get; set; }

        public int LekarzID { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Required]
        public string Nazwisko { get; set; }

        [Required]
        public string Specjalizacja { get; set; }

        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać datę wizyty")]
        [Display(Name = "Data wizyty")]
        public DateTime DataWizyty { get; set; }

        public string Zalecenia { get; set; }

    }
}
