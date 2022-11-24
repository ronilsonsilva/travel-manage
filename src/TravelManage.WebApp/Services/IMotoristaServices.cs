using RestSharp;
using TravelManage.Domain.Shared;
using TravelManage.Domain.Shared.DTO;
using TravelManage.WebApp.VierwModels;

namespace TravelManage.WebApp.Services
{
    public interface IMotoristaServices 
    {
        Task<IList<MotoristaDto>> GetList();
        Task<MotoristaDto> GetById(int id);
        Task<Response<MotoristaDto>> Create(CreateMotoristaDto createMotoristaDto);
        Task<Response<MotoristaDto>> Update(UpdateMotoristaDto updateMotoristaDto);
        Task<Response<bool>> Delete(int id);
    }

    public class MotoristaServices : IMotoristaServices
    {
        private RestClient _restClient;

        public MotoristaServices(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<Response<MotoristaDto>> Create(CreateMotoristaDto createMotoristaDto)
        {
            return await _restClient.PostJsonAsync<CreateMotoristaDto, Response<MotoristaDto>>("motorista", createMotoristaDto);
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return await _restClient.DeleteAsync<Response<bool>>(new RestRequest($"motorista/{id}", Method.Delete));
        }

        public async Task<MotoristaDto> GetById(int id)
        {
            return await _restClient.GetJsonAsync<MotoristaDto>($"motorista/{id}");
        }

        public async Task<IList<MotoristaDto>> GetList()
        {
            return await _restClient.GetJsonAsync<MotoristaDto[]>("motorista");
        }

        public async Task<Response<MotoristaDto>> Update(UpdateMotoristaDto updateMotoristaDto)
        {
            return await _restClient.PutJsonAsync<UpdateMotoristaDto, Response<MotoristaDto>>("motorista", updateMotoristaDto);
        }
    }
}
