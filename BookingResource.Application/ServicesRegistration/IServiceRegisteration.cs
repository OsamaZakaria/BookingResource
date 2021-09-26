using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingResource.Application.ServicesRegistration
{
    public interface IServiceRegisteration
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
