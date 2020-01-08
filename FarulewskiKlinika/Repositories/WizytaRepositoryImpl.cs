using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarulewskiKlinika.Models;

namespace FarulewskiKlinika.Repositories
{
    public class WizytaRepositoryImpl : WizytaRepository
    {
        private List<Wizyta> _wizytaList;

        public WizytaRepositoryImpl()
        {
            _wizytaList = new List<Wizyta>()
            {
                new Wizyta() {WizytaID = 1, LekarzID = 1, UserID = 1, DataWizyty = new DateTime (2013,1,23) }
            };
        }

        public Wizyta GetWizyta(int id)
        {
            return _wizytaList.FirstOrDefault(e => e.WizytaID == id);
        }

        public Wizyta Add(Wizyta wizyta)
        {
            wizyta.WizytaID = _wizytaList.Max(e => e.WizytaID) + 1;

            _wizytaList.Add(wizyta);
            return wizyta;
        }

        public IEnumerable<Wizyta> GetAllWizyta()
        {
            return _wizytaList;
        }

 
    }
}
