using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Persistence.Contracts
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
    }
}
