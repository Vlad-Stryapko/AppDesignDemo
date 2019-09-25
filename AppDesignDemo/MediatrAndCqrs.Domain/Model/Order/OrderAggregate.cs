using System;
using System.Collections.Generic;

namespace MediatrAndCqrs.Domain.Model.Order
{
    public class OrderAggregate : IAggregateRoot
    {
        public OrderAggregate(DateTime orderedOn, ICollection<OrderItem> orderItems)
        {
            this.OrderedOn = orderedOn;
            this.OrderItems = orderItems;
        }

        public int Id { get; }
        public DateTime OrderedOn { get; }
        public ICollection<OrderItem> OrderItems { get; }
    }
}
