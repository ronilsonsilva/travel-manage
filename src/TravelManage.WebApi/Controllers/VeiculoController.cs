using Microsoft.AspNetCore.Mvc;
using TravelManage.Application.Contracts;
using TravelManage.Domain.Entities;
using TravelManage.Domain.Shared.DTO;

namespace TravelManage.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class VeiculoController : BaseController<Veiculo, VeiculoDto, CreateVeiculoDto, UpdateVeiculoDto, VeiculoDto>
    {
        public VeiculoController(IApplicationServices<Veiculo, VeiculoDto, CreateVeiculoDto, UpdateVeiculoDto, VeiculoDto> application) : base(application)
        {
        }
    }
}
