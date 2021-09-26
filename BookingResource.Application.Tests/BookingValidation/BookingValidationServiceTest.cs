using BookingResource.Application.BookingValidation;
using BookingResource.EntityFramework.IData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookingResource.Tests
{
    [TestClass()]
    public class BookingValidationServiceTest
    {
        private readonly Mock<BookingResource.EntityFramework.IData.IUnitOfWork> _unitOfWork;
        private readonly BookingValidationService _bookingValidationService;
        public BookingValidationServiceTest()
        {

        }
        [TestMethod()]
        public void ResourceAvailablityTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ResourceAvailablityTest1()
        {
            Assert.Fail();
        }
    }
}