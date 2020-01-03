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
            modelBuilder.Entity<Lekarz>().HasData(

               // new Pacjent { PacjentID = 1, Pesel = "11111111111", Imie = "Konrad", Nazwisko = "Styczen", Email = "styczen@wp.pl" },
               // new Pacjent { PacjentID = 2, Pesel = "22222222222", Imie = "Agata", Nazwisko = "Luty", Email = "luty@wp.pl" },
               // new Pacjent { PacjentID = 3, Pesel = "33333333333", Imie = "Jan", Nazwisko = "Marzec", Email = "marzec@wp.pl" }

                new Lekarz { LekarzID = 1, Imie = "Konrad", Nazwisko = "Kowalski", Specjalizacja = "Internista", Email = "kkowalski@klinika" },
                new Lekarz { LekarzID = 2, Imie = "Agata", Nazwisko = "Nowak", Specjalizacja = "Laryngolog", Email = "anowak@klinika" },
                new Lekarz { LekarzID = 3, Imie = "Jan", Nazwisko = "Kujawski", Specjalizacja = "Dermatolog", Email = "jkujawski@klinika" },
                new Lekarz { LekarzID = 4, Imie = "Damian", Nazwisko = "Borowicz", Specjalizacja = "Stomatolog", Email = "dborowicz@klinika" },
                new Lekarz { LekarzID = 5, Imie = "Karolina", Nazwisko = "Zawadzka", Specjalizacja = "Okulista", Email = "kzawadzka@klinika" }           
            );


        }

    }
}
