using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TekusApp.Domain.Models;

namespace TekusApp.Domain.Infrastructure.Data
{
    public static class SeedExtension
    {
        public static void Seed (this ModelBuilder modelBuilder)
        {
            //Countries
            modelBuilder.Entity<Country>().HasData(

                new Country
                {
                    Id = 1,
                    Name= "Argentina"
                },
                new Country
                {
                    Id = 2,
                    Name = "Colombia"
                },
                new Country
                {
                    Id = 3,
                    Name = "Peru"
                },
                new Country
                {
                    Id = 4,
                    Name = "Ecuador"
                },
                new Country
                {
                    Id = 5,
                    Name = "Mexico"
                }

                );

            //Clients
            modelBuilder.Entity<Client>().HasData(

                new Client
                {
                    Id = 1,
                    Name = "Importaciones Tekus S.A",
                    Email= "importaciones@gmail.com",
                    NIT="123"
                    
                },
                new Client
                {
                    Id = 2,
                    Name = "MIJL",
                    Email = "mijl@gmail.com",
                    NIT = "124"
                },
                new Client
                {
                    Id = 3,
                    Name = "Parque Soft",
                    Email = "parquesoft@gmail.com",
                    NIT = "125"
                },
                new Client
                {
                    Id = 4,
                    Name = "VIsion Marketing",
                    Email = "importaciones@gmail.com",
                    NIT = "121"
                },
                new Client
                {
                    Id = 5,
                    Name = "Internexa",
                    Email = "internexa@gmail.com",
                    NIT = "120"
                }

                );



            //Clients
            modelBuilder.Entity<Service>().HasData(

                new Service
                {
                    Id = 1,
                    Name = "Descarga espacial de contenidos",
                    HourValue ="1000",
                    ClientId= 1

                },
                new Service
                {
                    Id = 2,
                    Name = "Desaparición forzada de bytes",
                    HourValue = "850",
                    ClientId = 1
                },
                new Service
                {
                    Id = 3,
                    Name = "Bussiness Development Support",
                    HourValue = "3200",
                    ClientId = 2
                },
                new Service
                {
                    Id = 4,
                    Name = "Talent training & Improvement",
                    HourValue = "5020",
                    ClientId = 2
                },
                new Service
                {
                    Id = 5,
                    Name = "Cloud services",
                    HourValue = "30",
                    ClientId = 5
                }

                );

            //Clients
            modelBuilder.Entity<ServiceCountry>().HasData(

                new ServiceCountry
                {
                    Id = 1,
                    ServiceId= 1,
                    CountryId=2
                    
                },
                new ServiceCountry
                {
                    Id = 2,
                    ServiceId = 1,
                    CountryId = 3
                },
                new ServiceCountry
                {
                    Id = 3,
                    ServiceId = 1,
                    CountryId = 5
                },
                new ServiceCountry
                {
                    Id = 4,
                    ServiceId = 2,
                    CountryId = 2
                },
                new ServiceCountry
                {
                    Id = 5,
                    ServiceId = 4,
                    CountryId = 2
                }
                );
        }
    }
}
