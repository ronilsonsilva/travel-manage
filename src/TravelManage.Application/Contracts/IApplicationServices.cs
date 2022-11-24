using TravelManage.Domain.Shared;

namespace TravelManage.Application.Contracts
{
    public interface IApplicationServices<TEntity, TEntityDto, CreateDto, UpdateDto, ListDto>
    {
        Task<Response<TEntityDto>> Add(CreateDto dto);
        Task<Response<TEntityDto>> Update(UpdateDto dto);
        Task<Response<bool>> Delete(int id);
        Task<TEntityDto> Get(int id);
        Task<IList<ListDto>> Get();
    }
}
