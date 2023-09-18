using CleanArchitecture.Application.Persistence.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Bases;
using CleanArchitecture.Persistence.Contexts;

namespace CleanArchitecture.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<ApplicationDbContext, LeaveRequest, int>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(ApplicationDbContext dbContext) : base(dbContext) {}
    }
}
