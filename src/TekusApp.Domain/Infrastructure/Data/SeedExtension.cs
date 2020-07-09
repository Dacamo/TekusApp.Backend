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
        }
    }
}
