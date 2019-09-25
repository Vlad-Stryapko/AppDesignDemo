using MediatrAndCqrs.Domain.Model.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrAndCqrs.Domain.Model
{
    public interface IOrderRepository : IRepository<OrderAggregate>
    {
        void AddOrder(OrderAggregate order);
    }
}
