using BookingResource.Application.Resource;
using BookingResource.Application.Resource.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<List<ResourceDto>>> GetAll()
        {
           try
            {
                var result = await Task.Run(() => _resourceService.GetAllResources());

                if (result == null)
                    return NotFound();
                return  Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
