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

        public string UserName { get; set; }

        public int LekarzID { get; set; }

        [Display(Name = "Data wizyty")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataWizyty { get; set; }

        // public string Zalecenia { get; set; }

        // navigation properties - wizyta może dotyczyć tylko jednego lekarza i pacjenta (lekarz przyjmuje jednego pacjenta)
        // podcza wizyty przyjmuje jeden lekarz
        public virtual Lekarz Lekarz { get; set; }

    }
}

