using Microsoft.AspNetCore.Mvc;
using TravelManage.Application.Contracts;
using TravelManage.Domain.Shared.DTO;

namespace TravelManage.WebApi.Controllers
{
    [ApiController]
    public class BaseController<TEntity, TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntityListDto> : ControllerBase where TEntityDto : BaseDto where TCreateEntityDto : class where TUpdateEntityDto : class where TEntityListDto : class
    {
        protected readonly IApplicationServices<TEntity, TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntityListDto> _application;

        public BaseController(IApplicationServices<TEntity, TEntityDto, TCreateEntityDto, TUpdateEntityDto, TEntityListDto> application)
        {
            _application = application;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TCreateEntityDto createEntityDto)
        {
            var response = await _application.Add(createEntityDto);
            if (response.Ok) return Ok(response);
            return BadRequest(response);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TUpdateEntityDto updateEntityDto)
        {
            var response = await _application.Update(updateEntityDto);
            if (response.Ok) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _application.Get();
            if (response == null) return NoContent();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _application.Get(id);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _application.Delete(id);
            if (response.Ok) return Ok(response);
            return BadRequest(response);
        }
    }
}
