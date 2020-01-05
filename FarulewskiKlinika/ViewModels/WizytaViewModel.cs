using FarulewskiKlinika.Models;
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
        public Lekarz Lekarz { get; set; }
        
        public int PacjentID { get; set; }

        [Required(ErrorMessage = "Proszę podać datę wizyty")]
        [Display(Name = "Data wizyty")]
        public DateTime DataWizyty { get; set; }

        public string Zalecenia { get; set; }

    }
}
