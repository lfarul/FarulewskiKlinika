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
               new Wizyta() {WizytaID = 1, LekarzID = 1, UserName = "lfarulewski@yahoo.com" , DataWizyty = new DateTime (2020,1,20) },
               new Wizyta() {WizytaID = 2, LekarzID = 2, UserName = "jwayne@gmail.com" , DataWizyty = new DateTime (2020,1,23) },
               new Wizyta() {WizytaID = 3, LekarzID = 3, UserName = "rlewandowski@gmail.com" , DataWizyty = new DateTime (2020,1,30) },
               new Wizyta() {WizytaID = 4, LekarzID = 4, UserName = "rkubica@hotmail.com" , DataWizyty = new DateTime (2020,1,15) },
               new Wizyta() {WizytaID = 5, LekarzID = 4, UserName = "jbravo@gmail.com" , DataWizyty = new DateTime (2020,1,10) },
               new Wizyta() {WizytaID = 6, LekarzID = 3, UserName = "rkubica@gmail.com" , DataWizyty = new DateTime (2020,4,12) }
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

        public Wizyta Update(Wizyta wizytaUpdate)
        {
            Wizyta wizyta = _wizytaList.FirstOrDefault(e => e.WizytaID == wizytaUpdate.WizytaID);
            if (wizyta != null)
            {
                wizyta.LekarzID = wizytaUpdate.LekarzID;
                wizyta.UserName = wizytaUpdate.UserName;
                wizyta.DataWizyty = wizytaUpdate.DataWizyty;
            }
            return wizyta;
        }

        public Wizyta Delete(int id)
        {
            Wizyta wizyta = _wizytaList.FirstOrDefault(e => e.WizytaID == id);
            if (wizyta != null)
            {
                _wizytaList.Remove(wizyta);
            }
            return wizyta;
        }
    }
}
