using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingResource.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using BookingResource.Application.Booking;
using Moq;
using BookingResource.Application.BookingValidation;
using BookingResource.Application.Booking.Dto;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using BookingResource.Web;
using System.Reflection;
using System.Linq;
using BookingResource.Application.ServicesRegistration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingResource.Application.BookingValidation.ErrorModel;
using BookingResource.Application.Helper;

namespace Resource.web.Tests
{
    [TestClass()]
    public class BookingControllerTest
    {
        Mock<IBookingService> _bookingService;
        Mock<IBookingValidationService> _bookingValidationService;
        public class EmptyStartup
        {
            public EmptyStartup(IConfiguration _) { }

            public void ConfigureServices(IServiceCollection _) { }

            public void Configure(IApplicationBuilder _) { }
        }
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

        [TestMethod()]
        public void BookResource_WithModelStateError_ReturnBadRequest()
        {

            var controller = new BookingController(_bookingService.Object, _bookingValidationService.Object);
            controller.ModelState.AddModelError("Error ", "Model State Error");
            var result = controller.BookResource(new BookResourceDto()).Result as Microsoft.AspNetCore.Mvc.ObjectResult;

            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);

        }

        [TestMethod()]
        public void BookResource_WithNotAvailableResource_ReturnBadRequest()
        {

            _bookingValidationService.Setup<BookingValidationResultDto>(s => s.ResourceIsAvailable(It.IsAny<BookResourceDto>()))
                 .Returns(new BookingValidationResultDto() { IsValid = false, ErrorMessage = RequestResponse.RequiredNotAvailable });


            var controller = new BookingController(_bookingService.Object, _bookingValidationService.Object);

            var result = controller.BookResource(new BookResourceDto() { ResourceId = 1, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddDays(5), Quantity = 20 }).Result as Microsoft.AspNetCore.Mvc.ObjectResult;

            Assert.AreEqual(RequestResponse.RequiredNotAvailable, result.Value);

        }

        [TestMethod()]
        public void BookResource_WithSuccessBook_ReturnOk()
        {

            _bookingValidationService.Setup<BookingValidationResultDto>(s => s.ResourceIsAvailable(It.IsAny<BookResourceDto>()))
                 .Returns(new BookingValidationResultDto() { IsValid = true });


            _bookingService.Setup(s => s.BookResource(It.IsAny<BookResourceDto>()))
            .Returns(TaskEx.FromResult(true));

            var controller = new BookingController(_bookingService.Object, _bookingValidationService.Object);

            var result = controller.BookResource(new BookResourceDto() { ResourceId = 1, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddDays(5), Quantity = 20 }).Result as Microsoft.AspNetCore.Mvc.ObjectResult;

            Assert.AreEqual(RequestResponse.SuccessBooking, result.Value);

        }

        [TestMethod()]
        public void BookResource_WithNotSuccessBook_ReturnBadRequest()
        {

            _bookingValidationService.Setup<BookingValidationResultDto>(s => s.ResourceIsAvailable(It.IsAny<BookResourceDto>()))
                 .Returns(new BookingValidationResultDto() { IsValid = true });


            _bookingService.Setup(s => s.BookResource(It.IsAny<BookResourceDto>()))
            .Returns(TaskEx.FromResult(false));

            var controller = new BookingController(_bookingService.Object, _bookingValidationService.Object);

            var result = controller.BookResource(new BookResourceDto() { ResourceId = 1, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddDays(5), Quantity = 20 }).Result as Microsoft.AspNetCore.Mvc.ObjectResult;

            Assert.AreEqual(RequestResponse.FailTooBookUnExpected, result.Value);

        }

    }
}