using RestSharp;
using TravelManage.Domain.Shared;
using TravelManage.Domain.Shared.DTO;

namespace TravelManage.WebApp.Services
{
    public interface IPassageiroServices 
    {
        Task<IList<PassageiroDto>> GetList();
        Task<PassageiroDto> GetById(int id);
        Task<Response<PassageiroDto>> Create(CreatePassageiroDto createPassageiroDto);
        Task<Response<PassageiroDto>> Update(UpdatePassageiroDto updatePassageiroDto);
        Task<Response<bool>> Delete(int id);
    }

    public class PassageiroServices : IPassageiroServices
    {
        private RestClient _restClient;

        public PassageiroServices(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<Response<PassageiroDto>> Create(CreatePassageiroDto createPassageiroDto)
        {
            return await _restClient.PostJsonAsync<CreatePassageiroDto, Response<PassageiroDto>>("passageiro", createPassageiroDto);
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return await _restClient.DeleteAsync<Response<bool>>(new RestRequest($"passageiro/{id}", Method.Delete));
        }

        public async Task<PassageiroDto> GetById(int id)
        {
            return await _restClient.GetJsonAsync<PassageiroDto>($"passageiro/{id}");
        }

        public async Task<IList<PassageiroDto>> GetList()
        {
            return await _restClient.GetJsonAsync<PassageiroDto[]>("passageiro");
        }

        public async Task<Response<PassageiroDto>> Update(UpdatePassageiroDto updatePassageiroDto)
        {
            return await _restClient.PutJsonAsync<UpdatePassageiroDto, Response<PassageiroDto>>("passageiro", updatePassageiroDto);
        }
    }
}
