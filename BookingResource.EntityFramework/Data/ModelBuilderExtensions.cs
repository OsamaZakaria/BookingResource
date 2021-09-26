using BookingResource.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingResource.EntityFramework.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().HasData(
                new Resource
                {
                    Id= 1,
                    Name = "Printer Hp",
                    Quantity = 10
                },
                new Resource
                {
                    Id = 2,
                    Name = "Printer Samsung",
                    Quantity = 10
                },
                new Resource
                {
                    Id = 3,
                    Name = "Scanner Hp",
                    Quantity = 10
                }
            );
        }
    }
}
