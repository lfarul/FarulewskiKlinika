using FarulewskiKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Repositories
{
   public interface WizytaRepository
    {
        Wizyta GetWizyta(int WizytaID);
        IEnumerable<Wizyta> GetAllWizyta();
        Wizyta Add(Wizyta wizyta);

        Wizyta Update(Wizyta wizytaUpdate);
        Wizyta Delete(int id);
    }
}
