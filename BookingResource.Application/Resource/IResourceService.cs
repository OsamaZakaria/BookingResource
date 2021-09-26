using BookingResource.Application.Resource.Dto;
using System.Collections.Generic;

namespace BookingResource.Application.Resource
{
    public interface IResourceService
    {
        List<ResourceDto> GetAllResources();
        ResourceDto GetResource(int id);
    }
}
