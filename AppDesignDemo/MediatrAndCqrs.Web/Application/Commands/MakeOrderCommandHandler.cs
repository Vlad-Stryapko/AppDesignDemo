using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrAndCqrs.Web.Application.Commands
{
    public class MakeOrderCommandHandler : AsyncRequestHandler<MakeOrderCommand>
    {
        private readonly IMediator _mediator;

        public MakeOrderCommandHandler(IMediator mediator)
        {
            this._mediator = mediator;
        }

        protected override async Task Handle(MakeOrderCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AddOrderCommand { OrderItems = request.OrderItems.Select(ToAddOrderItem).ToList() });


            AddOrderCommand.AddOrderItemModel ToAddOrderItem(MakeOrderCommand.AddOrderItemModel source) => new AddOrderCommand.AddOrderItemModel
            {
                Count = source.Count,
                Description = source.Description
            };
        }
    }
}
