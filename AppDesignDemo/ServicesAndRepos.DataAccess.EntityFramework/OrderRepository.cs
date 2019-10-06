using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServicesAndRepos.DataAccess.Models;
using ServicesAndRepos.Domain;

namespace ServicesAndRepos.DataAccess.EntityFramework
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ServicesAndReposContext context;

        public OrderRepository(ServicesAndReposContext context)
        {
            this.context = context;
        }

        public void AddOrder(Order order)
        {
            this.context.Orders.Add(order);
        }

        public async Task<OrderTotal> GetTotalAsync(string description)
        {
            var total = await context.OrderItems.Where(_ => _.Description == description).SumAsync(_ => _.Count);
            return new OrderTotal
            {
                TotalCount = total
            };
        }
    }
}
