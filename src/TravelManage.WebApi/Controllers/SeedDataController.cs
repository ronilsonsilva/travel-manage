using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelManage.Application.Contracts;

namespace TravelManage.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {
        private readonly ISeedDataApplication _seedDataApplication;

        public SeedDataController(ISeedDataApplication seedDataApplication)
        {
            _seedDataApplication = seedDataApplication;
        }

        [HttpPost]
        public async Task<IActionResult> Seed()
        {
            await _seedDataApplication.Seed();
            return Ok();
        }
    }
}
