using RestSharp;
using TravelManage.Domain.Shared;
using TravelManage.Domain.Shared.DTO;

namespace TravelManage.WebApp.Services
{
    public interface IViagemServices 
    {
        Task<IList<ListViagemDto>> GetList();
        Task<ViagemDto> GetById(int id);
        Task<Response<ViagemDto>> Create(CreateViagemDto createViagemDto);
        Task<Response<ViagemDto>> Update(UpdateViagemDto updateViagemDto);
        Task<Response<bool>> Delete(int id);
    }

    public class ViagemServices : IViagemServices
    {
        private RestClient _restClient;
        private string _rota = "viagem";

        public ViagemServices(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<Response<ViagemDto>> Create(CreateViagemDto createViagemDto)
        {
            return await _restClient.PostJsonAsync<CreateViagemDto, Response<ViagemDto>>(_rota, createViagemDto);
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return await _restClient.DeleteAsync<Response<bool>>(new RestRequest($"{_rota}/{id}", Method.Delete));
        }

        public async Task<ViagemDto> GetById(int id)
        {
            return await _restClient.GetJsonAsync<ViagemDto>($"{_rota}/{id}");
        }

        public async Task<IList<ListViagemDto>> GetList()
        {
            return await _restClient.GetJsonAsync<ListViagemDto[]>(_rota);
        }

        public  async Task<Response<ViagemDto>> Update(UpdateViagemDto updateViagemDto)
        {
            return await _restClient.PutJsonAsync<UpdateViagemDto, Response<ViagemDto>>(_rota, updateViagemDto);
        }
    }
}
