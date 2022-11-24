using RestSharp;
using TravelManage.Domain.Shared;
using TravelManage.Domain.Shared.DTO;
using TravelManage.WebApp.VierwModels;

namespace TravelManage.WebApp.Services
{
    public interface ITipoPagamentoServices 
    {
        Task<IList<TipoPagamentoDto>> GetList();
        Task<TipoPagamentoDto> GetById(int id);
        Task<Response<TipoPagamentoDto>> Create(CreateTipoPagamentoDto createTipoPagamentoDto);
        Task<Response<TipoPagamentoDto>> Update(UpdateTipoPagamentoDto updateTipoPagamentoDto);
        Task<Response<bool>> Delete(int id);
    }

    public class TipoPagamentoServices : ITipoPagamentoServices
    {
        private RestClient _restClient;
        private string _rota = "tipopagamento";

        public TipoPagamentoServices(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<Response<TipoPagamentoDto>> Create(CreateTipoPagamentoDto createTipoPagamentoDto)
        {
            return await _restClient.PostJsonAsync<CreateTipoPagamentoDto, Response<TipoPagamentoDto>>(_rota, createTipoPagamentoDto);
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return await _restClient.DeleteAsync<Response<bool>>(new RestRequest($"{_rota}/{id}", Method.Delete));
        }

        public async Task<TipoPagamentoDto> GetById(int id)
        {
            return await _restClient.GetJsonAsync<TipoPagamentoDto>($"{_rota}/{id}");
        }

        public async Task<IList<TipoPagamentoDto>> GetList()
        {
            return await _restClient.GetJsonAsync<TipoPagamentoDto[]>(_rota);
        }

        public async Task<Response<TipoPagamentoDto>> Update(UpdateTipoPagamentoDto updateTipoPagamentoDto)
        {
            return await _restClient.PutJsonAsync<UpdateTipoPagamentoDto, Response<TipoPagamentoDto>>(_rota, updateTipoPagamentoDto);
        }
    }

}
