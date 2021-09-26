using BookingSystem.Services.Booking;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ExtendedApiController
    {
        public ResourcesController(ResourceService resourceService)
        {
            ResourceService = resourceService;
        }

        public ResourceService ResourceService { get; }

        [HttpGet]
        public async Task<IActionResult> GetResources()
        {
            var resources = await ResourceService.GetResourcesAsync();
            return OkOrError(resources);
        }
    }
}
