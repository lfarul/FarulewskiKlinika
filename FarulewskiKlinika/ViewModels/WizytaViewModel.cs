﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.ViewModels
{
    public class WizytaViewModel
    {
        [Required]
        [Display(Name = "Użytkownik")]
        public string UserName { get; set; }


    }
}