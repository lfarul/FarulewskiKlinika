using FarulewskiKlinika.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.ViewModels
{
    public class WizytaDetailsPdfViewModel

    {
        public Wizyta Wizyta { get; set; }

        public Lekarz Lekarz { get; set; }

        public DateTime DataWizyty { get; set; }
    }
}
