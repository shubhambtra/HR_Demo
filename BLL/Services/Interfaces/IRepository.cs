using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            Expression<Func<TEntity, bool>> wherePredicate = null);

        Task<TEntity> GetById(int id);

        Task<TEntity> GetById(string id);
       
        Task<TEntity> GetById(Expression<Func<TEntity, bool>> match,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);

        Task<TEntity> Create(TEntity entity);

        Task<IQueryable<TEntity>> Create(IQueryable<TEntity> entities);

        Task<TEntity> AddUpdate(int id, TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<IQueryable<TEntity>> Update(IQueryable<TEntity> entities);

        Task<TEntity> Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties);

        Task<TEntity> Update(int id, params Expression<Func<TEntity, object>>[] properties);

        Task<IQueryable<TEntity>> Update(IQueryable<TEntity> entity, params Expression<Func<TEntity, object>>[] properties);

        Task<TEntity> Delete(int id);

        Task<IQueryable<TEntity>> Delete(IQueryable<TEntity> entities);

        Task<TEntity> Delete(string id);

        Task<bool> IsNameExists(Expression<Func<TEntity, bool>> expr);
    }
}
