using BookingResource.Core;
using BookingResource.EntityFramework.User;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace BookingResource.EntityFramework.Data
{
    public class BookingAppDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public BookingAppDbContext(
            DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }

      
    }
}
