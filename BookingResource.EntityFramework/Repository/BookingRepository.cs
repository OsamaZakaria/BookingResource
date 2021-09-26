using BookingResource.Core;
using BookingResource.EntityFramework.Data;
using BookingResource.EntityFramework.IRepository;
using System;

namespace BookingResource.EntityFramework.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(BookingAppDbContext context) : base(context)
        {
        }
        public BookingAppDbContext BookingAppDbContext
        {
            get { return Context as BookingAppDbContext; }
        }

    }
}