using System.Linq.Expressions;

namespace CleanArchitecture.Application.Persistence.Contracts
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : class
    {
        #region Get
        
        Task<TEntity> GetAsync(TKey id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Insert
        Task<TEntity> AddAsync(TEntity entity);
        #endregion

        #region Update
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> UpdateAsync(TKey id, TEntity entity);
        #endregion

        #region Delete
        Task<bool> DeleteAsync(TKey id);
        Task<bool> DeleteAsync(TEntity entity);

        Task<bool> DeleteAllAsync();
        Task<bool> DeleteAllAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}
