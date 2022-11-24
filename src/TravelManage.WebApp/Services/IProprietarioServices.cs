using RestSharp;
using TravelManage.Domain.Shared;
using TravelManage.Domain.Shared.DTO;
using TravelManage.WebApp.VierwModels;

namespace TravelManage.WebApp.Services
{
    public interface IProprietarioServices 
    {
        Task<IList<ProprietarioDto>> GetList();
        Task<ProprietarioDto> GetById(int id);
        Task<Response<ProprietarioDto>> Create(CreateProprietarioDto CreateProprietarioDto);
        Task<Response<ProprietarioDto>> Update(UpdateProprietarioDto updateProprietarioDto);
        Task<Response<bool>> Delete(int id);
    }

    public class ProprietarioServices : IProprietarioServices
    {
        private RestClient _restClient;
        private string _rota = "proprietario";

        public ProprietarioServices(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<Response<ProprietarioDto>> Create(CreateProprietarioDto CreateProprietarioDto)
        {
            return await _restClient.PostJsonAsync<CreateProprietarioDto, Response<ProprietarioDto>>(_rota, CreateProprietarioDto);
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return await _restClient.DeleteAsync<Response<bool>>(new RestRequest($"{_rota}/{id}", Method.Delete));
        }

        public async Task<ProprietarioDto> GetById(int id)
        {
            return await _restClient.GetJsonAsync<ProprietarioDto>($"{_rota}/{id}");
        }

        public async Task<IList<ProprietarioDto>> GetList()
        {
            return await _restClient.GetJsonAsync<ProprietarioDto[]>(_rota);
        }

        public async Task<Response<ProprietarioDto>> Update(UpdateProprietarioDto updateProprietarioDto)
        {
            return await _restClient.PutJsonAsync<UpdateProprietarioDto, Response<ProprietarioDto>>(_rota, updateProprietarioDto);
        }
    }
}
