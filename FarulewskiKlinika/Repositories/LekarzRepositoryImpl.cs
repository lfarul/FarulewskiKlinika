using FarulewskiKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Repositories
{
    public class LekarzRepositoryImpl : LekarzRepository
    {
        private List<Lekarz> _lekarzList;

        public LekarzRepositoryImpl()
        {
            _lekarzList = new List<Lekarz>()

            {

                new Lekarz { LekarzID = 1, Imie = "Konrad", Nazwisko = "Kowalski", Specjalizacja = "Internista", Email = "kkowalski@klinika" },
                new Lekarz { LekarzID = 2, Imie = "Agata", Nazwisko = "Nowak", Specjalizacja = "Laryngolog", Email = "anowak@klinika" },
                new Lekarz { LekarzID = 3, Imie = "Jan", Nazwisko = "Kujawski", Specjalizacja = "Dermatolog", Email = "jkujawski@klinika" },
                new Lekarz { LekarzID = 4, Imie = "Damian", Nazwisko = "Borowicz", Specjalizacja = "Stomatolog", Email = "dborowicz@klinika" },
                new Lekarz { LekarzID = 5, Imie = "Karolina", Nazwisko = "Zawadzka", Specjalizacja = "Okulista", Email = "kzawadzka@klinika" }
        };
        }

        public Lekarz Add(Lekarz lekarz)
        {
            lekarz.LekarzID = _lekarzList.Max(e => e.LekarzID) + 1;
            _lekarzList.Add(lekarz);
            return lekarz;
        }



        public Lekarz Delete(int id)
        {
            Lekarz lekarz = _lekarzList.FirstOrDefault(e => e.LekarzID == id);
            if (lekarz != null)
            {
                _lekarzList.Remove(lekarz);
            }
            return lekarz;
        }

        public IEnumerable<Lekarz> GetAllLekarz()
        {
            return _lekarzList;
        }

        public Lekarz GetLekarz(int LekarzID)
        {
            return _lekarzList.FirstOrDefault(e => e.LekarzID == LekarzID);
        }

        public Lekarz Update(Lekarz lekarzUpdate)
        {
            Lekarz lekarz = _lekarzList.FirstOrDefault(e => e.LekarzID == lekarzUpdate.LekarzID);
            if (lekarz != null)
            {
                lekarz.Imie = lekarzUpdate.Imie;
                lekarz.Nazwisko = lekarzUpdate.Nazwisko;
                lekarz.Specjalizacja = lekarzUpdate.Specjalizacja;
                lekarz.Email = lekarzUpdate.Email;
            }
            return lekarz;
        }

        Lekarz LekarzRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

