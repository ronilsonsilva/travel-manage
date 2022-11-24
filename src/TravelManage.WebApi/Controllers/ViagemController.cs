using Microsoft.AspNetCore.Mvc;
using TravelManage.Application.Contracts;
using TravelManage.Domain.Entities;
using TravelManage.Domain.Shared.DTO;

namespace TravelManage.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ViagemController : BaseController<Viagem, ViagemDto, CreateViagemDto, UpdateViagemDto, ListViagemDto>
    {
        public ViagemController(IApplicationServices<Viagem, ViagemDto, CreateViagemDto, UpdateViagemDto, ListViagemDto> application) : base(application)
        {
        }
    }
}
