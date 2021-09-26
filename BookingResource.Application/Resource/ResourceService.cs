using AutoMapper;
using BookingResource.Application.Resource.Dto;
using BookingResource.EntityFramework.IData;
using System.Collections.Generic;

namespace BookingResource.Application.Resource
{
    public class ResourceService : IResourceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ResourceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<ResourceDto> GetAllResources()
        {
            var resources = _unitOfWork.Resources.GetAll();

            return _mapper.Map<List<ResourceDto>>(resources);
        }

        public ResourceDto GetResource(int id)
        {
            var resource = _unitOfWork.Resources.Get(id);
            return _mapper.Map<ResourceDto>(resource);
        }
    }
}
