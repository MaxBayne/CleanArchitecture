using CleanArchitecture.Application.Persistence.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Abstract;
using CleanArchitecture.Persistence.Contexts;

namespace CleanArchitecture.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<ApplicationDbContext, LeaveAllocation, int>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(ApplicationDbContext dbContext) : base(dbContext) {}
    }
}
