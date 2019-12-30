using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Models
{
    public class Pracownik
    {
        public int PracownikID { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string Imie { get; set; }

        [Required]
        public string Nazwisko { get; set; }

        [Required]
        public string Rola { get; set; }

        [Required]
        public string Specjalizacja { get; set; }

        [Required]
        public string Email { get; set; }

        // navigation properties - lekarz może mieć kilka wizyt
        public virtual ICollection<Wizyta> Wizyty { get; set; }
    }
}
