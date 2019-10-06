using MediatrAndCqrs.Domain.Model.Order;

namespace MediatrAndCqrs.Domain.Model
{
    public interface IOrderRepository : IRepository<OrderAggregate>
    {
        void AddOrder(OrderAggregate order);
    }
}
