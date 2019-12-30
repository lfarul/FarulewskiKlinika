using FarulewskiKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Repositories
{
    public class PacjentRepositoryImpl : PacjentRepository
    {
        private List<Pacjent> _pacjentList;


        public PacjentRepositoryImpl()
        {
            _pacjentList = new List<Pacjent>()

            {

            new Pacjent() { PacjentID = 1, Pesel = "11111111111", Imie = "Jan", Nazwisko = "Styczen", Email = "styczen@wp.pl" },
            new Pacjent() { PacjentID = 2, Pesel = "22222222222", Imie = "Agata", Nazwisko = "Luty", Email = "luty@wp.pl" },
            new Pacjent() { PacjentID = 3, Pesel = "33333333333", Imie = "Jan", Nazwisko = "Marzec", Email = "marzec@wp.pl" },
            new Pacjent() { PacjentID = 4, Pesel = "44444444444", Imie = "Damian", Nazwisko = "Kwiecien", Email = "kwiecien@wp.pl" },
            new Pacjent() { PacjentID = 5, Pesel = "55555555555", Imie = "Karolina", Nazwisko = "Maj", Email = "maj@wp.pl" },
            new Pacjent() { PacjentID = 6, Pesel = "66666666666", Imie = "Magda", Nazwisko = "Czerwiec", Email = "czerwiec@wp.pl" },
            new Pacjent() { PacjentID = 7, Pesel = "77777777777", Imie = "Monika", Nazwisko = "Lipiec", Email = "lipiec@wp.pl" },
        };
        }

        public Pacjent Add(Pacjent pacjent)
        {
            pacjent.PacjentID = _pacjentList.Max(e => e.PacjentID) + 1;
            _pacjentList.Add(pacjent);
            return pacjent;
        }

        public Pacjent Delete(int id)
        {
            Pacjent pacjent = _pacjentList.FirstOrDefault(e => e.PacjentID == id);
            if (pacjent != null)
            {
                _pacjentList.Remove(pacjent);
            }
            return pacjent;
        }

        public IEnumerable<Pacjent> GetAllPacjent()
        {
            return _pacjentList;
        }


        public Pacjent GetPacjent(int PacjentID)
        {
            return _pacjentList.FirstOrDefault(e => e.PacjentID == PacjentID);
        }

        public Pacjent Update(Pacjent pacjentUpdate)
        {
            Pacjent pacjent = _pacjentList.FirstOrDefault(e => e.PacjentID == pacjentUpdate.PacjentID);
            if (pacjent != null)
            {
                pacjent.Imie = pacjentUpdate.Imie;
                pacjent.Nazwisko = pacjentUpdate.Nazwisko;
                pacjent.Pesel = pacjentUpdate.Pesel;
                pacjent.Email = pacjentUpdate.Email;
            }
            return pacjent;
        }

    }
}

