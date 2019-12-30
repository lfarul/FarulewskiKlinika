using FarulewskiKlinika.DataContext;
using FarulewskiKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.Repositories
{
    public class SqlPacjentRepository : PacjentRepository
    {
        private readonly ApplicationDbContext context;

        //ApplicationDbContext class injection by constructor method
        public SqlPacjentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Pacjent Add(Pacjent pacjent)
        {
            context.Pacjenci.Add(pacjent);
            context.SaveChanges();
            return pacjent;
        }

        public Pacjent Delete(int id)
        {
            // before deleting a Pacjent, we need to find them first
            Pacjent pacjent = context.Pacjenci.Find(id);
            if (pacjent != null)
            {
                context.Pacjenci.Remove(pacjent);
                context.SaveChanges();
            }
            return pacjent;
        }

        public IEnumerable<Pacjent> GetAllPacjent()
        {
            return context.Pacjenci;

        }

        public Pacjent GetPacjent(int PacjentID)
        {
            return context.Pacjenci.Find(PacjentID);
        }

        public Pacjent Update(Pacjent pacjentUpdate)
        {
            var pacjent = context.Pacjenci.Attach(pacjentUpdate);
            pacjent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return pacjentUpdate;
        }
    }
}

