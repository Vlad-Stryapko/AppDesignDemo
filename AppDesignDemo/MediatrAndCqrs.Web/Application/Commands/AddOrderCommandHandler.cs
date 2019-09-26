using MediatR;
using MediatrAndCqrs.Domain.Model;
using MediatrAndCqrs.Domain.Model.Order;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrAndCqrs.Web.Application.Commands
{
    public class AddOrderCommandHandler : AsyncRequestHandler<AddOrderCommand>
    {
        private readonly IOrderRepository orderRepository;

        public AddOrderCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        protected override async Task Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new OrderAggregate(DateTime.UtcNow, orderItems: request.OrderItems.Select(ToOrderItem).ToList());
            orderRepository.AddOrder(order);
            await orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            OrderItem ToOrderItem(AddOrderCommand.AddOrderItemModel source) => new OrderItem(source.Count, source.Description);
        }
    }
}
