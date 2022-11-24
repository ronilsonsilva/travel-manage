﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TravelManage.Domain.Contracts.Repositories;
using TravelManage.Domain.Entities;
using TravelManage.Infra.Data.Context;

namespace TravelManage.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly TravelManageContext _context;

        public RepositoryBase(TravelManageContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            try
            {
                this._context.Set<TEntity>().Add(entity);
                await this._context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
            return entity;
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return this._context.Set<TEntity>().Where(expression).AsQueryable();
        }

        public virtual async Task<TEntity> Get(int id)
        {
            var entity = await this.Get(x => x.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public virtual async Task<IList<TEntity>> Get()
        {
            return await this._context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<bool> Delete(int id)
        {
            var entityRemover = await this.Get(id);
            if (entityRemover == null) return false;
            this._context.Set<TEntity>().Remove(entityRemover);
            return (await this._context.SaveChangesAsync()) > 0;
        }
    }
}
