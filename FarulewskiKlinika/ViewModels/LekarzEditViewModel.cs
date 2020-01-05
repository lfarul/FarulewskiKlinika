using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.ViewModels
{
    // dzidziczymy po klasie LekarzCreateViewModel i otrzymuje dostęp do wybranych pól
    public class LekarzEditViewModel : LekarzCreateViewModel
    {
        public int LekarzID { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
