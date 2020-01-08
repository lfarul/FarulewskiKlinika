using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }

        public string Id { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }

        public string Email{ get; set; }

        public string UserName { get; set; }

        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }


    }
}
