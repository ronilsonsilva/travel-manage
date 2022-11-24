using Microsoft.AspNetCore.Mvc;
using TravelManage.Application.Contracts;
using TravelManage.Domain.Entities;
using TravelManage.Domain.Shared.DTO;

namespace TravelManage.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MotoristaController : BaseController<Motoristas, MotoristaDto, CreateMotoristaDto, UpdateMotoristaDto, MotoristaDto>
    {
        public MotoristaController(IApplicationServices<Motoristas, MotoristaDto, CreateMotoristaDto, UpdateMotoristaDto, MotoristaDto> application) : base(application)
        {
        }
    }
}
