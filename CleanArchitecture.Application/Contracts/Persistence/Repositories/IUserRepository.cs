using CleanArchitecture.Application.Contracts.Persistence.Abstract;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts.Persistence.Repositories
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        Task<List<User>> GetRoleAdmins();
        Task<List<User>> GetRoleUsers();
        Task<List<User>> GetUsersWithoutEmail();
    }
}
