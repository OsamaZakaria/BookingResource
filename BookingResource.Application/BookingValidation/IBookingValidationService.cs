using BookingResource.Application.Booking.Dto;
using BookingResource.Application.BookingValidation.ErrorModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingResource.Application.BookingValidation
{
    public interface IBookingValidationService
    {
        BookingValidationResultDto ResourceIsAvailable(BookResourceDto bookResource);
    }
}
