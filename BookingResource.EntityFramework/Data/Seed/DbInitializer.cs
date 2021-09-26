using BookingResource.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingResource.EntityFramework.Data.Seed
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<BookingAppDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<BookingAppDbContext>())
                {

                    //add admin user
                    if (!context.Resources.Any())
                    {
                        var resource1 = new Resource
                        {
                            Name = "Printer Hp",
                            Quantity = 10
                        };
                        var resource2 = new Resource
                        {
                            Name = "Printer Samsung",
                            Quantity = 10
                        };
                        var resource3 = new Resource
                        {
                            Name = "Scanner Hp",
                            Quantity = 10
                        };
                        context.Resources.Add(resource1);
                        context.Resources.Add(resource2);
                        context.Resources.Add(resource3);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
