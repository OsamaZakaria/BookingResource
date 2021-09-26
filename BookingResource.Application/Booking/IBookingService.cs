using BookingResource.Application.Booking.Dto;
using System.Threading.Tasks;

namespace BookingResource.Application.Booking
{
    public interface IBookingService
    {
        Task<bool> BookResource(BookResourceDto resource);
    }
}