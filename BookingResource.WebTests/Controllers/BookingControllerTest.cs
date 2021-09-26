using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingResource.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using BookingResource.Application.Booking;
using Moq;
using BookingResource.Application.BookingValidation;
using BookingResource.Application.Booking.Dto;

namespace Resource.web.Tests
{
    [TestClass()]
    public class BookingControllerTest
    {
        Mock<IBookingService> _bookingService;
        Mock<IBookingValidationService> _bookingValidationService;

        public BookingControllerTest()
        {
            _bookingService = new Mock<IBookingService>();
            _bookingValidationService = new Mock<IBookingValidationService>();
        }
        [TestMethod()]
        public void BookResource_WithNullParams_ReturnBadRequest()
        {
           
            var controller = new BookingController(_bookingService.Object, _bookingValidationService.Object);
            var result = controller.BookResource(null);

            Assert.IsInstanceOfType(result.Result, typeof(Microsoft.AspNetCore.Mvc.BadRequestResult));
        }
    }
}