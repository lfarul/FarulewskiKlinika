using FarulewskiKlinika.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarulewskiKlinika.DataSeed
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacjent>().HasData(

                new Pacjent { PacjentID = 1, Pesel = "11111111111", Imie = "Konrad", Nazwisko = "Styczen", Email = "styczen@wp.pl" },
                new Pacjent { PacjentID = 2, Pesel = "22222222222", Imie = "Agata", Nazwisko = "Luty", Email = "luty@wp.pl" },
                new Pacjent { PacjentID = 3, Pesel = "33333333333", Imie = "Jan", Nazwisko = "Marzec", Email = "marzec@wp.pl" }
            );
        }

    }
}
