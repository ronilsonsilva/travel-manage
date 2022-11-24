using Microsoft.AspNetCore.Mvc;
using TravelManage.Application.Contracts;
using TravelManage.Domain.Entities;
using TravelManage.Domain.Shared.DTO;

namespace TravelManage.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PassageiroController : BaseController<Passageiros, PassageiroDto, CreatePassageiroDto, UpdatePassageiroDto, PassageiroDto>
    {
        public PassageiroController(IApplicationServices<Passageiros, PassageiroDto, CreatePassageiroDto, UpdatePassageiroDto, PassageiroDto> application) : base(application)
        {
        }
    }
}
