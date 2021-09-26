using BookingResource.Application.Booking.Dto;
using BookingResource.Application.BookingValidation;
using BookingResource.EntityFramework.IData;
using System.Threading.Tasks;

namespace BookingResource.Application.Booking
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> BookResource(BookResourceDto resource)
        {
           await _unitOfWork.Bookings.AddAsync(new Core.Booking()
           {
               ResourceId = resource.ResourceId,
               DateFrom = resource.DateFrom,
               DateTo = resource.DateTo,
               BookedQuantity = resource.Quantity
           });
           await _unitOfWork.SaveChanges();
            return true;
        }
    }
}
