using RestSharp;
using TravelManage.Domain.Shared;
using TravelManage.Domain.Shared.DTO;

namespace TravelManage.WebApp.Services
{
    public interface IVeiculoServices 
    {
        Task<IList<VeiculoDto>> GetList();
        Task<VeiculoDto> GetById(int id);
        Task<Response<VeiculoDto>> Create(CreateVeiculoDto createVeiculoDto);
        Task<Response<VeiculoDto>> Update(UpdateVeiculoDto updateVeiculoDto);
        Task<Response<bool>> Delete(int id);
    }

    public class VeiculoServices : IVeiculoServices
    {
        private RestClient _restClient;
        private string _rota = "veiculo";

        public VeiculoServices(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<Response<VeiculoDto>> Create(CreateVeiculoDto createVeiculoDto)
        {
            try
            {
                return await _restClient.PostJsonAsync<CreateVeiculoDto, Response<VeiculoDto>>(_rota, createVeiculoDto);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return await _restClient.DeleteAsync<Response<bool>>(new RestRequest($"{_rota}/{id}", Method.Delete));
        }

        public async Task<VeiculoDto> GetById(int id)
        {
            return await _restClient.GetJsonAsync<VeiculoDto>($"{_rota}/{id}");
        }

        public async Task<IList<VeiculoDto>> GetList()
        {
            return await _restClient.GetJsonAsync<VeiculoDto[]>(_rota);
        }

        public async Task<Response<VeiculoDto>> Update(UpdateVeiculoDto updateVeiculoDto)
        {
            return await _restClient.PutJsonAsync<UpdateVeiculoDto, Response<VeiculoDto>>(_rota, updateVeiculoDto);
        }
    }

}
