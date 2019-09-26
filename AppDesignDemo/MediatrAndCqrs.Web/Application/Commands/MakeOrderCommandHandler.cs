using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrAndCqrs.Web.Application.Commands
{
    public class MakeOrderCommandHandler : AsyncRequestHandler<MakeOrderCommand>
    {
        private readonly IMediator mediator;

        public MakeOrderCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected override async Task Handle(MakeOrderCommand request, CancellationToken cancellationToken)
        {
            Log.Information("Make order handler has been called");
            await mediator.Send(new AddOrderCommand { OrderItems = request.OrderItems.Select(ToAddOrderItem).ToList() });
            await mediator.Send(new SendEmailCommand());
            Log.Information("Make order handler has finished");


            AddOrderCommand.AddOrderItemModel ToAddOrderItem(MakeOrderCommand.AddOrderItemModel source) => new AddOrderCommand.AddOrderItemModel
            {
                Count = source.Count,
                Description = source.Description
            };
        }
    }
}
