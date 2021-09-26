using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingResource.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using BookingResource.Application.Resource;
using BookingResource.Application.Resource.Dto;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Resource.web.Tests
{
    [TestClass()]
    public class ResourceControllerTest
    {
        [TestMethod]
        public async Task GetAll_WithExistingResource_ReturnListOfResource()
        {
            var _resourceServiceStup = new Mock<IResourceService>();
            _resourceServiceStup.Setup(s => s.GetAllResources()).Returns(MockResources);

            var controller = new ResourceController(_resourceServiceStup.Object);
            var result = await controller.GetAll();

            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public async Task GetAll_WithNullResource_ReturnListOfResource()
        {
            var _resourceServiceStup = new Mock<IResourceService>();
            _resourceServiceStup.Setup(s => s.GetAllResources()).Returns((List<ResourceDto>)null);

            var controller = new ResourceController(_resourceServiceStup.Object);
            var result = await controller.GetAll();

            Assert.IsInstanceOfType(result.Result, typeof(Microsoft.AspNetCore.Mvc.NotFoundResult));
        }

        public List<BookingResource.Application.Resource.Dto.ResourceDto> MockResources()
        {
            return new List<BookingResource.Application.Resource.Dto.ResourceDto>()
            {
                new ResourceDto()
                {
                    Id = 1,
                    Name = "r1"
                },
                new ResourceDto()
                {
                    Id = 2,
                    Name = "r1"
                },
                new ResourceDto()
                {
                    Id = 3,
                    Name = "r1"
                },
                new ResourceDto()
                {
                    Id = 4,
                    Name = "r1"
                },
                new ResourceDto()
                {
                    Id = 5,
                    Name = "r1"
                }

           };
        }

    }
}