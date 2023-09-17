using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest, int>
    {
    }
}
