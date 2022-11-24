using TravelManage.Domain.Contracts.DomainServices;
using TravelManage.Domain.Contracts.Repositories;
using TravelManage.Domain.Entities;
using TravelManage.Domain.Shared;

namespace TravelManage.Domain.DomainServices
{
    public class DomainService<TEntity> : IDomainServices<TEntity> where TEntity : BaseEntity
    {
        #region [Properties]

        protected readonly IRepository<TEntity> _repository;

        #endregion

        #region [Constructors]

        public DomainService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        #endregion

        #region [Public Methods]

        public async Task<Response<TEntity>> Add(TEntity entity)
        {
            if (entity.Invalid)
                return new Response<TEntity>(entity, entity.Validate());

            return new Response<TEntity>(await this._repository.Add(entity));
        }

        public async Task<Response<TEntity>> Update(TEntity entity)
        {
            if (entity.Invalid)
                return new Response<TEntity>(entity, entity.Validate());

            return new Response<TEntity>(await this._repository.Update(entity));
        }

        public async Task<TEntity> Get(int id)
        {
            return await this._repository.Get(id);
        }

        public async Task<IList<TEntity>> Get()
        {
            return await this._repository.Get();
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return new Response<bool>(await this._repository.Delete(id));
        }

        #endregion
    }
}
