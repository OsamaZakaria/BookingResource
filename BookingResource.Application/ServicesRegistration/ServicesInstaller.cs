using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookingResource.Application.ServicesRegistration
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IServiceCollection services, IConfiguration Configuration)
        {
            var installers = typeof(ServicesInstaller).Assembly.ExportedTypes.Where(t => !t.IsAbstract && !t.IsInterface && typeof(IServiceRegisteration).IsAssignableFrom(t)).Select(Activator.CreateInstance).Cast<IServiceRegisteration>().ToList();
            
            installers.ForEach(installer => installer.InstallServices(services, Configuration));
        }
    }
}
