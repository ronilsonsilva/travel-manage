using TravelManage.Application.Contracts;
using TravelManage.Domain.Contracts.Repositories;
using TravelManage.Domain.Shared.Inputs;
using TravelManage.Domain.Shared.ReportModels;

namespace TravelManage.Application.Services
{
    public class ReportApplicationServices : IReportApplicationServices
    {
        private readonly IReportRepository _reportRepository;

        public ReportApplicationServices(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<IList<FaturamentoVeiculoReport>> FaturamentoVeiculo(PeriodoMesAnoInput periodo)
        {
            return await _reportRepository.FaturamentoVeiculo(periodo.Ano, periodo.Mes);
        }

        public async Task<IList<MediaMensalViagemReport>> MediaMensalViagemReports()
        {
            return await _reportRepository.MediaMensalViagemReports();
        }

        public async Task<IList<TopFaturamentoReport>> TopFaturamento(PeriodoMesAnoInput periodo)
        {
            return await _reportRepository.TopFaturamento(periodo.Ano, periodo.Mes);
        }

        public async Task<IList<VeiculosByViagemReport>> VeiculosByViagem(VeiculoByIntervaloInput input)
        {
            return await _reportRepository.VeiculosByViagem(input.Placa, input.Inicio, input.Fim);
        }
    }
}
