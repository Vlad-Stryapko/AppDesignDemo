using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Order GetOrder(int id)
        {
            return this.context.Orders.Single(_ => _.Id == id);
        }
    }
}
