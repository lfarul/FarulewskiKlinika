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
            modelBuilder.Entity<Pracownik>().HasData(

               // new Pacjent { PacjentID = 1, Pesel = "11111111111", Imie = "Konrad", Nazwisko = "Styczen", Email = "styczen@wp.pl" },
               // new Pacjent { PacjentID = 2, Pesel = "22222222222", Imie = "Agata", Nazwisko = "Luty", Email = "luty@wp.pl" },
               // new Pacjent { PacjentID = 3, Pesel = "33333333333", Imie = "Jan", Nazwisko = "Marzec", Email = "marzec@wp.pl" }

                new Pracownik { PracownikID = 1, Imie = "Konrad", Nazwisko = "Kowalski", Rola = "Lekarz", Specjalizacja = "Internista", Email = "kkowalski@medicover" },
                new Pracownik { PracownikID = 2, Imie = "Agata", Nazwisko = "Nowak", Rola = "Lekarz", Specjalizacja = "Laryngolog", Email = "anowak@medicover" },
                new Pracownik { PracownikID = 3, Imie = "Jan", Nazwisko = "Kujawski", Rola = "Lekarz", Specjalizacja = "Dermatolog", Email = "jkujawski@medicover" },
                new Pracownik { PracownikID = 4, Imie = "Damian", Nazwisko = "Borowicz", Rola = "Lekarz", Specjalizacja = "Stomatolog", Email = "dborowicz@medicover" },
                new Pracownik { PracownikID = 5, Imie = "Karolina", Nazwisko = "Zawadzka", Rola = "Lekarz", Specjalizacja = "Okulista", Email = "kzawadzka@medicover" },
                new Pracownik { PracownikID = 6, Imie = "Magda", Nazwisko = "Montewska", Rola = "Pielęgniarka", Specjalizacja = "Zabiegowa", Email = "mmontewska@medicover" },
                new Pracownik { PracownikID = 7, Imie = "Monika", Nazwisko = "Piotrowska", Rola = "Asystentka", Specjalizacja = "Stomatologia", Email = "mpiotrowska@medicover" }
            );


        }

    }
}
