using FarulewskiKlinika.DataContext;
using FarulewskiKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Repositories
{
    public class SqlLekarzRepository : LekarzRepository
    {
        private readonly ApplicationDbContext context;

        //ApplicationDbContext class injection by constructor method
        public SqlLekarzRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Lekarz Add(Lekarz lekarz)
        {
            context.Lekarze.Add(lekarz);
            context.SaveChanges();
            return lekarz;
        }

        public Lekarz Delete(int id)
        {
            // before deleting a Pacjent, we need to find them first
            Lekarz lekarz = context.Lekarze.Find(id);
            if (lekarz != null)
            {
                context.Lekarze.Remove(lekarz);
                context.SaveChanges();
            }
            return lekarz;
        }


        public IEnumerable<Lekarz> GetAllLekarz()
        {
            return context.Lekarze;

        }

        public Lekarz GetLekarz(int LekarzID)
        {
            return context.Lekarze.Find(LekarzID);
        }

        public Lekarz Update(Lekarz lekarzUpdate)
        {
            var lekarz = context.Lekarze.Attach(lekarzUpdate);
            lekarz.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return lekarzUpdate;
        }

    }
}

