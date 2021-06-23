using BLL.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TEntity>> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Expression<Func<TEntity, bool>> wherePredicate = null)
        {
            return await _repository.GetAll(include, wherePredicate);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<TEntity> GetById(string id)
        {
            return await _repository.GetById(id);
        }

        public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> match,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            return await _repository.GetById(match, include);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<IQueryable<TEntity>> Create(IQueryable<TEntity> entities)
        {
            return await _repository.Create(entities);
        }

        public async Task<TEntity> AddUpdate(int id, TEntity entity)
        {
            return await _repository.AddUpdate(id, entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await _repository.Update(entity);
        }

        public async Task<IQueryable<TEntity>> Update(IQueryable<TEntity> entities)
        {
            return await _repository.Update(entities);
        }

        public async Task<TEntity> Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            return await _repository.Update(entity, properties);
        }

        public async Task<TEntity> Update(int id, params Expression<Func<TEntity, object>>[] properties)
        {
            return await _repository.Update(id, properties);
        }

        public async Task<IQueryable<TEntity>> Update(IQueryable<TEntity> entities, params Expression<Func<TEntity, object>>[] properties)
        {
            return await _repository.Update(entities, properties);
        }

        public async Task<TEntity> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IQueryable<TEntity>> Delete(IQueryable<TEntity> entities)
        {
            return await _repository.Delete(entities);
        }

        public async Task<TEntity> Delete(string id)
        {
            return await _repository.Delete(id);
        }

        public async Task<bool> IsNameExists(Expression<Func<TEntity, bool>> expr)
        {
            return await _repository.IsNameExists(expr);
        }
    }
}
