using BLL.Services.Interfaces;
using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly HrDemoDbContext _dbContext;

        public Repository(HrDemoDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<TEntity>> GetAll(
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            Expression<Func<TEntity, bool>> wherePredicate = null)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking();

            if (include != null)
            {
                query = include(query);
            }

            if (wherePredicate != null)
            {
                query = query.Where(wherePredicate);
            }

            return await query.ToListAsync();
        }

     
        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> match, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking();

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(match);
        }

        public async Task<TEntity> GetById(string id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return entity;
        }

        public async Task<IQueryable<TEntity>> Create(IQueryable<TEntity> entities)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddRangeAsync(entities);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return entities;
        }

        public async Task<TEntity> AddUpdate(int id, TEntity entity)
        {
            _dbContext.Entry(entity).State = id == 0 ?
                EntityState.Added :
                EntityState.Modified;

            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<TEntity>> Update(IQueryable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> Update(TEntity entity, params Expression<Func<TEntity, object>>[] properties)
        {
            try
            {
                var entry = _dbContext.Entry(entity);
                _dbContext.Set<TEntity>().Attach(entity);
                foreach (var property in properties)
                    entry.Property(property).IsModified = true;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UpdateDbEntryAsync exception: " + ex.Message);
                return null;
            }
        }

        public async Task<TEntity> Update(int id, params Expression<Func<TEntity, object>>[] properties)
        {
            try
            {
                var entity = await GetById(id);
                var entry = _dbContext.Entry(entity);
                _dbContext.Set<TEntity>().Attach(entity);
                foreach (var property in properties)
                    entry.Property(property).IsModified = true;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UpdateDbEntryAsync exception: " + ex.Message);
                return null;
            }
        }

        public async Task<IQueryable<TEntity>> Update(IQueryable<TEntity> entities, params Expression<Func<TEntity, object>>[] properties)
        {
            try
            {
                _dbContext.Set<TEntity>().AttachRange(entities);
                await _dbContext.SaveChangesAsync();
                return entities;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UpdateDbEntryAsync exception: " + ex.Message);
                return null;
            }
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IQueryable<TEntity>> Delete(IQueryable<TEntity> entities)
        {
            if (entities == null) return null;
            _dbContext.Set<TEntity>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> Delete(string id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> IsNameExists(Expression<Func<TEntity, bool>> expr)
        {
            return await _dbContext.Set<TEntity>().AnyAsync(expr);
        }
    }
}
