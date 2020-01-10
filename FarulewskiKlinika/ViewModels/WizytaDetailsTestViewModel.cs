using FarulewskiKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.ViewModels
{
    public class WizytaDetailsTestViewModel
    {
        // public Lekarz Lekarz { get; set; }
        public Wizyta Wizyta { get; set; }
        public int LekarzID { get; set; }
        public string UserName { get; set; }
        public DateTime? DataWizyty { get; set; }
    }
}
