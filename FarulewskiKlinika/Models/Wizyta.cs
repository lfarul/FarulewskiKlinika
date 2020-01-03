using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Models
{
    public class Wizyta
    {
        public int WizytaID { get; set; }

        [Display(Name = "Pacjent")]
        public int PacjentID { get; set; }

        [Display(Name = "Lekarz")]
        public int LekarzID { get; set; }

        public string Specjalizacja { get; set; }

        [Required(ErrorMessage = "Proszę podać datę wizyty")]
        [Display(Name = "Data wizyty")]
        public DateTime DataWizyty { get; set; }

        public string Zalecenia { get; set; }

        // navigation properties - wizyta może dotyczyć tylko jednego lekarza i pacjenta (lekarz przyjmuje jednego pacjenta)
        // podcza wizyty przyjmuje jeden lekarz
        public virtual Lekarz Lekarz { get; set; }

        // podczas wizyty obsługiwany jest jeden pacjent
        public virtual Pacjent Pacjent { get; set; }
    }
}

