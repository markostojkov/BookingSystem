using BookingSystem.Contracts.Booking;
using BookingSystem.Services.Booking;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookingSystem.Api.Controllers
{
    [Route("api/resources/{resourceUid:guid}/[controller]")]
    [ApiController]
    public class BookingsController : ExtendedApiController
    {
        public BookingsController(BookingService bookingService)
        {
            BookingService = bookingService;
        }

        public BookingService BookingService { get; }

        [HttpPost]
        public async Task<IActionResult> GetResources([FromRoute]Guid resourceUid, [FromBody] BookResourceRequest request)
        {
            var result = await BookingService.BookResourceAsync(resourceUid, request);
            return OkOrError(result);
        }
    }
}
