using BookingResource.Core;
using BookingResource.EntityFramework.Data;
using BookingResource.EntityFramework.IRepository;
using System;

namespace BookingResource.EntityFramework.Repository
{
    public class ResourceRepository : Repository<Resource>, IResourceRepository
    {
        public ResourceRepository(BookingAppDbContext context) : base(context)
        {
        }
        public BookingAppDbContext BookingAppDbContext
        {
            get { return Context as BookingAppDbContext; }
        }

    }
}
