using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarulewskiKlinika.DataContext;
using FarulewskiKlinika.Models;

namespace FarulewskiKlinika.Repositories
{
    public class SqlWizytaRepository : WizytaRepository
    {
        private readonly ApplicationDbContext context;

        //ApplicationDbContext class injection by constructor method
        public SqlWizytaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Wizyta Add(Wizyta wizyta)
        {
            context.Wizyty.Add(wizyta);
            context.SaveChanges();
            return wizyta;
        }

        public Wizyta Delete(int id)
        {
            // before deleting Wizyta, we need to find them first
            Wizyta wizyta = context.Wizyty.Find(id);
            if (wizyta != null)
            {
                context.Wizyty.Remove(wizyta);
                context.SaveChanges();
            }
            return wizyta;
        }

        public IEnumerable<Wizyta> GetAllWizyta()
        {
            return context.Wizyty;
        }

        public Wizyta GetWizyta(int WizytaID)
        {
            return context.Wizyty.Find(WizytaID);
        }

        public Wizyta Update(Wizyta wizytaUpdate)
        {
            var wizyta = context.Wizyty.Attach(wizytaUpdate);
            wizyta.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return wizytaUpdate;
        }
    }
}
