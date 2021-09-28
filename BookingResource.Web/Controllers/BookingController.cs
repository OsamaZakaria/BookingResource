using BookingResource.Application.Booking;
using BookingResource.Application.Booking.Dto;
using BookingResource.Application.BookingValidation;
using BookingResource.Application.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingResource.Web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IBookingValidationService _bookingValidationService;
        public BookingController(IBookingService bookingService, IBookingValidationService bookingValidationService)
        {
            _bookingService = bookingService;
            _bookingValidationService = bookingValidationService;
        }
        [HttpPost("api/Booking")]
        public async Task<ActionResult> BookResource([FromBody] BookResourceDto bookResource)
        {
            try
            {
                if (bookResource == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest , string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)));

                var validateAvailability = _bookingValidationService.ResourceIsAvailable(bookResource);

                if (!validateAvailability.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest, $"{validateAvailability.ErrorMessage}");

                var result = await _bookingService.BookResource(bookResource);

                return result ? Ok(RequestResponse.SuccessBooking) : StatusCode(StatusCodes.Status500InternalServerError, RequestResponse.FailTooBookUnExpected);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, RequestResponse.FailTooBookUnExpected);
            }
        }
    }
}
