using FarulewskiKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Repositories
{
   public interface WizytaRepository
    {
        Wizyta GetWizyta(int id);
        IEnumerable<Wizyta> GetAllWizyta();
        Wizyta Add(Wizyta Wizyta);
    }
}
