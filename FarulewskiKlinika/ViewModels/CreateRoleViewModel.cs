using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Rola")]
        public string RoleName { get; set; }
    }
}
