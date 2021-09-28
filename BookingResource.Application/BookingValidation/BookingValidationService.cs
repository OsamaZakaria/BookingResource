using BookingResource.Application.Booking.Dto;
using BookingResource.Application.BookingValidation.ErrorModel;
using BookingResource.Application.Helper;
using BookingResource.EntityFramework.IData;
using Microsoft.EntityFrameworkCore;
using System;
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
        public BookingValidationResultDto ValidateBookingObject(BookResourceDto bookResource)
        {
            BookingValidationResultDto result = new BookingValidationResultDto() { IsValid = true };

            if (bookResource.DateFrom >= bookResource.DateTo)
            {
                result.ErrorMessage= "Date To must be greater Than Date From.";
                return result;
            }

            if (bookResource.DateFrom < DateTime.Now)
            {
                result.ErrorMessage = "Date To must be greater Now.";
                return result;
               
            }
            if (bookResource.Quantity <= 0)
            {
                result.ErrorMessage = "Quantity must be greater Than 0.";
                return result;
            }
            return result;
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
                return new BookingValidationResultDto() { IsValid = false, ErrorMessage = RequestResponse.RequiredNotAvailable };

            else if (((resource.Quantity - listResources.Sum(r => r.BookedQuantity)) < bookResource.Quantity))
                return new BookingValidationResultDto() { IsValid = false , ErrorMessage = RequestResponse.RequiredNotAvailable };
            return result;
        }
    }
}
