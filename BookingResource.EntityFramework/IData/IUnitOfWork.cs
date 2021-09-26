using BookingResource.EntityFramework.IRepository;
using System;
using System.Threading.Tasks;

namespace BookingResource.EntityFramework.IData
{
    public interface IUnitOfWork: IDisposable
    {
        IBookingRepository Bookings { get; }
        IResourceRepository Resources { get; }
        Task SaveChanges();
    }
}
