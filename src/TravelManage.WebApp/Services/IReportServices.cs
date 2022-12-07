using RestSharp;
using TravelManage.Domain.Shared.Inputs;
using TravelManage.Domain.Shared.ReportModels;

namespace TravelManage.WebApp.Services
{
    public interface IReportServices
    {
        Task<IList<VeiculosByViagemReport>> VeiculosByViagem(VeiculoByIntervaloInput input);
        Task<IList<TopFaturamentoReport>> TopFaturamento(PeriodoMesAnoInput periodo);
        Task<IList<FaturamentoVeiculoReport>> FaturamentoVeiculo(PeriodoMesAnoInput periodo);
        Task<IList<MediaMensalViagemReport>> MediaMensalViagemReports();
    }

    public class ReportServices : IReportServices
    {
        private RestClient _restClient;
        private string _rota = "report";

        public ReportServices(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<IList<FaturamentoVeiculoReport>> FaturamentoVeiculo(PeriodoMesAnoInput periodo)
        {
            return await _restClient.PostJsonAsync<PeriodoMesAnoInput, FaturamentoVeiculoReport[]>(_rota+ "/faturamento-veiculo", periodo);
        }

        public async Task<IList<MediaMensalViagemReport>> MediaMensalViagemReports()
        {
            return await _restClient.GetJsonAsync<MediaMensalViagemReport[]>(_rota+ "/media-mensal-viagem");
        }

        public async Task<IList<TopFaturamentoReport>> TopFaturamento(PeriodoMesAnoInput periodo)
        {
            return await _restClient.PostJsonAsync<PeriodoMesAnoInput, TopFaturamentoReport[]>(_rota+ "/top-faturamento", periodo);
        }

        public async Task<IList<VeiculosByViagemReport>> VeiculosByViagem(VeiculoByIntervaloInput input)
        {
            return await _restClient.PostJsonAsync<VeiculoByIntervaloInput, VeiculosByViagemReport[]>(_rota+ "/veiculos-by-viagem",input);
        }
    }
}
