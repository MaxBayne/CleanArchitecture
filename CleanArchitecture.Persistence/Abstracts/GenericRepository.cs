using System.Linq.Expressions;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Abstracts
{
    public abstract class GenericRepository<TContext,TEntity, TKey> :IGenericRepository<TEntity, TKey> where TContext : DbContext where TEntity : class
    {
        protected readonly TContext _dbContext;

        protected GenericRepository(TContext dbContext)
        {
            _dbContext= dbContext;
        }

        #region Select Single

        public async Task<TEntity?> GetAsync(TKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        
        public async Task<bool> ExistAsync(TKey id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }
        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await GetAsync(predicate);
            return entity != null;
        }

        #endregion

        #region Select Multi

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }


        #endregion

        #region Insert

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        #endregion

        #region Update

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TKey id,TEntity entity)
        {
            var original = await GetAsync(id);

            _dbContext.Entry(original!).CurrentValues.SetValues(entity);
          
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region Delete

        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);

            _dbContext.Set<TEntity>().Remove(entity!);

            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            var entities = await GetAllAsync();
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public async Task DeleteAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await GetAllAsync(predicate);
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        #endregion
    }
}
