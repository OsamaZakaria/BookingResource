using AutoMapper;
using BookingResource.Application.Resource.Dto;

namespace BookingResource.Application.MappingConfigurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<BookingResource.Core.Resource, ResourceDto>();
        }
    }

}
