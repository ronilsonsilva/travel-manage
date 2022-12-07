using TravelManage.Domain.Shared.Inputs;
using TravelManage.Domain.Shared.ReportModels;

namespace TravelManage.Application.Contracts
{
    public interface IReportApplicationServices
    {
        Task<IList<VeiculosByViagemReport>> VeiculosByViagem(VeiculoByIntervaloInput input);
        Task<IList<TopFaturamentoReport>> TopFaturamento(PeriodoMesAnoInput periodo);
        Task<IList<FaturamentoVeiculoReport>> FaturamentoVeiculo(PeriodoMesAnoInput periodo);
        Task<IList<MediaMensalViagemReport>> MediaMensalViagemReports();
    }
}
