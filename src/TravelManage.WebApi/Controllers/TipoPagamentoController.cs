using Microsoft.AspNetCore.Mvc;
using TravelManage.Application.Contracts;
using TravelManage.Domain.Entities;
using TravelManage.Domain.Shared.DTO;

namespace TravelManage.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TipoPagamentoController : BaseController<TipoPagamento, TipoPagamentoDto, CreateTipoPagamentoDto, UpdateTipoPagamentoDto, TipoPagamentoDto>
    {
        public TipoPagamentoController(IApplicationServices<TipoPagamento, TipoPagamentoDto, CreateTipoPagamentoDto, UpdateTipoPagamentoDto, TipoPagamentoDto> application) : base(application)
        {
        }
    }
}
