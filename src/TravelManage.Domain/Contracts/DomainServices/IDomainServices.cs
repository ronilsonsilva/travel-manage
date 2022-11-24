using TravelManage.Domain.Entities;
using TravelManage.Domain.Shared;

namespace TravelManage.Domain.Contracts.DomainServices
{
    public interface IDomainServices<TEntity> where TEntity : BaseEntity
    {
        Task<Response<TEntity>> Add(TEntity entity);
        Task<Response<TEntity>> Update(TEntity entity);
        Task<Response<bool>> Delete(int id);
        Task<IList<TEntity>> Get();
        Task<TEntity> Get(int id);
    }
}
