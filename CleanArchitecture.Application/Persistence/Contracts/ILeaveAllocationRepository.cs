using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation, int>
    {
    }
}
