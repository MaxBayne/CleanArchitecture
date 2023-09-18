using CleanArchitecture.Application.Persistence.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Abstract;
using CleanArchitecture.Persistence.Contexts;

namespace CleanArchitecture.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<ApplicationDbContext, LeaveType, int>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext dbContext) : base(dbContext) {}
    }
}
