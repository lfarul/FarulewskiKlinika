using FarulewskiKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Repositories
{
    public interface LekarzRepository
    {
        Lekarz GetLekarz(int LekarzID);
        IEnumerable<Lekarz> GetAllLekarz();
        Lekarz Add(Lekarz lekarz);

        Lekarz Update(Lekarz lekarzUpdate);
        Lekarz Delete(int id);
    }
}
