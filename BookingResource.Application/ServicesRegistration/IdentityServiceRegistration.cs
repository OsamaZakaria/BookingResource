using BookingResource.EntityFramework.Data;
using BookingResource.EntityFramework.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingResource.Application.ServicesRegistration
{
    public class IdentityServiceRegistration : IServiceRegisteration
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<BookingAppDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, BookingAppDbContext>();
        }
    }
}
