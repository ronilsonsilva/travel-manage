using Microsoft.AspNetCore.Mvc;
using TravelManage.Application.Contracts;
using TravelManage.Domain.Shared.Inputs;

namespace TravelManage.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportApplicationServices _reportApplication;

        public ReportController(IReportApplicationServices reportApplication)
        {
            _reportApplication = reportApplication;
        }

        [HttpGet("media-mensal-viagem")]
        public async Task<IActionResult> MediaMensalViagemReports()
        {
            return Ok(await _reportApplication.MediaMensalViagemReports());
        }

        [HttpPost("faturamento-veiculo")]
        public async Task<IActionResult> FaturamentoVeiculo([FromBody]PeriodoMesAnoInput periodo)
        {
            return Ok(await _reportApplication.FaturamentoVeiculo(periodo));
        }

        [HttpPost("top-faturamento")]
        public async Task<IActionResult> TopFaturamento([FromBody]PeriodoMesAnoInput periodo)
        {
            return Ok(await _reportApplication.TopFaturamento(periodo));
        }

        [HttpPost("veiculos-by-viagem")]
        public async Task<IActionResult> VeiculosByViagem([FromBody]VeiculoByIntervaloInput input)
        {
            return Ok(await _reportApplication.VeiculosByViagem(input));
        }
    }
}
