using AutoMapper;
using BookingResource.Application.Booking;
using BookingResource.Application.BookingValidation;
using BookingResource.Application.MappingConfigurations;
using BookingResource.Application.Resource;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingResource.Application.ServicesRegistration
{
    public class AplicationServicesRegistration : IServiceRegisteration
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IResourceService, ResourceService>();
            services.AddTransient<IBookingValidationService, BookingValidationService>();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
