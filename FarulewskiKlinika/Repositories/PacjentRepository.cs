using FarulewskiKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Repositories
{
    interface PacjentRepository
    {
        Pacjent GetPacjent(int PacjentID);
        IEnumerable<Pacjent> GetAllPacjent();
        Pacjent Add(Pacjent pacjent);

        Pacjent Update(Pacjent pacjentUpdate);
        Pacjent Delete(int id);
    }
}
