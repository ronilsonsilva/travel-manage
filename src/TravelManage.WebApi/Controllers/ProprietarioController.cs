using Microsoft.AspNetCore.Mvc;
using TravelManage.Application.Contracts;
using TravelManage.Domain.Entities;
using TravelManage.Domain.Shared.DTO;

namespace TravelManage.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProprietarioController : BaseController<Proprietarios, ProprietarioDto, CreateProprietarioDto, UpdateProprietarioDto, ProprietarioDto>
    {
        public ProprietarioController(IApplicationServices<Proprietarios, ProprietarioDto, CreateProprietarioDto, UpdateProprietarioDto, ProprietarioDto> application) : base(application)
        {
        }
    }
}
