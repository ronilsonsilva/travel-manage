using TravelManage.Domain.Shared.ReportModels;

namespace TravelManage.Domain.Contracts.Repositories
{
    public interface IReportRepository
    {
        Task<IList<VeiculosByViagemReport>> VeiculosByViagem(string placa, DateTime inicio, DateTime fim);
        Task<IList<TopFaturamentoReport>> TopFaturamento(int ano, int mes);
        Task<IList<FaturamentoVeiculoReport>> FaturamentoVeiculo(int ano, int mes);
        Task<IList<MediaMensalViagemReport>> MediaMensalViagemReports();
    }
}
