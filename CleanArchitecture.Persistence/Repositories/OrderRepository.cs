using System.Linq.Expressions;
using CleanArchitecture.Application.Contracts.Persistence.Repositories;
using CleanArchitecture.Domain.Aggregates;
using CleanArchitecture.Persistence.Bases;
using CleanArchitecture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<ApplicationDbContext, Order, int>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext) {}


        public async Task<Order?> Get_Order_By_Number(string orderNumber)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(c => c.OrderNumber == orderNumber);
        }

        public async Task<Order?> Get_Order_With_Items_By_Id(int orderId)
        {
            return await _dbContext.Orders.Include(i=>i.OrderItems).FirstOrDefaultAsync(c=>c.Id==orderId);
        }

        public async Task<Order?> Get_Order_With_Items_By_Number(string orderNumber)
        {
            return await _dbContext.Orders.Include(i => i.OrderItems).FirstOrDefaultAsync(c => c.OrderNumber == orderNumber);
        }



        public async Task<List<Order>> Get_All_Orders_With_Items()
        {
            return await _dbContext.Orders.Include(i => i.OrderItems).ToListAsync();
        }

        public async Task<List<Order>> Get_Orders_With_Items(Expression<Func<Order, bool>> predicate)
        {
            return await _dbContext.Orders.Include(i => i.OrderItems).Where(predicate).ToListAsync();
        }
    }
}
