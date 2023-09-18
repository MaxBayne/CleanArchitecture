using CleanArchitecture.Application.Persistence.Abstract;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Persistence.Repositories
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation, int>
    {
    }
}
