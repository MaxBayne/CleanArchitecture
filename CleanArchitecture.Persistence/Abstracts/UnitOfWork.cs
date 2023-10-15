using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Abstracts;

public class UnitOfWork<TDbContext>:IUnitOfWork where TDbContext:DbContext
{
    #region Properties

    public TDbContext DbContext { get; private set; }

    #endregion

    #region Properties

    public UnitOfWork(TDbContext dbContext)
    {
        DbContext = dbContext;
    }

    #endregion

    #region Methods

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    #endregion
}