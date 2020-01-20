using FarulewskiKlinika.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.ViewModels
{
    public class WizytaDetailsViewModel

    {
        public Wizyta Wizyta { get; set; }

        public Lekarz Lekarz { get; set; }
        public int LekarzID { get; set; }
        public int WizytaID { get; set; }
        public string UserID { get; set; }

        public string UserName { get; set; }
        public DateTime? DataWizyty { get; set; }
    }
}
