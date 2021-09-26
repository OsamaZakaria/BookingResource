using BookingResource.EntityFramework.IData;
using BookingResource.EntityFramework.IRepository;
using BookingResource.EntityFramework.Repository;
using System;
using System.Threading.Tasks;

namespace BookingResource.EntityFramework.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BookingAppDbContext _context;
        public UnitOfWork(BookingAppDbContext context)
        {
            _context = context;

            Bookings = new BookingRepository(_context);
            Resources = new ResourceRepository(_context);
        }
        public IBookingRepository Bookings { get; private set; }
        public IResourceRepository Resources { get; private set; }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
