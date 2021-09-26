using BookingResource.Application.Booking.Dto;
using BookingResource.Application.BookingValidation.ErrorModel;
using BookingResource.EntityFramework.IData;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookingResource.Application.BookingValidation
{
    public class BookingValidationService : IBookingValidationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingValidationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public BookingValidationResultDto ResourceIsAvailable(BookResourceDto bookResource)
        {
            var listResources = _unitOfWork.Bookings
                                   .Find(b => b.ResourceId == bookResource.ResourceId &&
                                              bookResource.DateFrom >= b.DateFrom     &&
                                              bookResource.DateFrom <= b.DateTo
                                                ).ToList();
            var resource = _unitOfWork.Resources.Get(bookResource.ResourceId);
            BookingValidationResultDto result = new BookingValidationResultDto() { IsValid = true };

            if (listResources.Count == 0 && bookResource.Quantity <= resource.Quantity)
                return new BookingValidationResultDto() { IsValid = true };

            else if(bookResource.Quantity > resource.Quantity)
                return new BookingValidationResultDto() { IsValid = false, ErrorMessage = "Required quantity greater than available quantity" };

            else if (((resource.Quantity - listResources.Sum(r => r.BookedQuantity)) < bookResource.Quantity))
                return new BookingValidationResultDto() { IsValid = false , ErrorMessage = "Required quantity greater than available quantity" };
            return result;
        }
    }
}
