using BookingResource.Application.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookingResource.Web.Controllers
{
    public class ResourceController : Controller
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }
        [HttpGet("api/Resource")]
        public IActionResult GetAll()
        {
           try
            {
                return Ok(_resourceService.GetAllResources());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
