using CleanArchitecture.Application.Persistence.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Bases;
using CleanArchitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UserRepository : GenericRepository<ApplicationDbContext, User, int>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext) {}

        public async Task<List<User>> GetRoleAdmins()
        {
            return await _dbContext.Users.Where(c=>c.Role=="admins").ToListAsync();
        }

        public async Task<List<User>> GetRoleUsers()
        {
            return await _dbContext.Users.Where(c => c.Role == "users").ToListAsync();
        }

        public async Task<List<User>> GetUsersWithoutEmail()
        {
            return await _dbContext.Users.Where(c=>string.IsNullOrEmpty(c.Email)).ToListAsync();
        }
    }
}
