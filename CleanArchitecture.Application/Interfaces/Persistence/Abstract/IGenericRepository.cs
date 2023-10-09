using System.Linq.Expressions;

namespace CleanArchitecture.Application.Interfaces.Persistence.Abstract
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        #region Select Single

        Task<TEntity?> GetAsync(TKey id);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);


        Task<bool> ExistAsync(TKey id);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Select Multi

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Insert
        Task<TEntity> AddAsync(TEntity entity);
        #endregion

        #region Update

        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(TKey id, TEntity entity);
        #endregion

        #region Delete
        Task DeleteAsync(TKey id);
        Task DeleteAsync(TEntity entity);

        Task DeleteAllAsync();
        Task DeleteAllAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}
