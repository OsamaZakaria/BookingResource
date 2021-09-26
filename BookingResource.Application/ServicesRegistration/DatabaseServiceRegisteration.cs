using BookingResource.Application.Booking;
using BookingResource.Application.Resource;
using BookingResource.EntityFramework;
using BookingResource.EntityFramework.Data;
using BookingResource.EntityFramework.Data.Seed;
using BookingResource.EntityFramework.IData;
using BookingResource.EntityFramework.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BookingResource.Application.ServicesRegistration
{
    public class DatabaseServiceRegisteration : IServiceRegisteration
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookingAppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDbInitializer, DbInitializer>();

        }
    }
}
