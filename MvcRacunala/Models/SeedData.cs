using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcRacunala.Data;
using System;
using System.Linq;

namespace MvcRacunala.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcRacunalaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcRacunalaContext>>()))
            {
                // Trazi bilo koje racunalo.
                if (context.Racunala.Any())
                {
                    return;   // DB je napunjena
                }

                context.Racunala.AddRange(
                    new Racunala
                    {
                        Naziv = "Vostro 1234",
                        DatumIzdavanja = DateTime.Parse("2020-2-12"),
                        Vrsta = "DELL",
                        Cijena = 1000,
                        Stanje = "Dobro"
                    },

                     new Racunala
                     {
                         Naziv = "Vostro 4321",
                         DatumIzdavanja = DateTime.Parse("2020-3-14"),
                         Vrsta = "DELL",
                         Cijena = 1500,
                         Stanje = "OK"
                     },

                    new Racunala
                    {
                        Naziv = "Vostro 3241",
                        DatumIzdavanja = DateTime.Parse("2020-4-15"),
                        Vrsta = "DELL",
                        Cijena = 2000,
                        Stanje ="Dobro"
                    },

                   new Racunala
                   {
                       Naziv = "Vostro 6542",
                       DatumIzdavanja = DateTime.Parse("2020-6-17"),
                       Vrsta = "DELL",
                       Cijena = 2500,
                       Stanje = "Dobro"
                   }
                ) ;
                context.SaveChanges();
            }
        }
    }
}