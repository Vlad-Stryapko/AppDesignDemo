using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatrAndCqrs.Web.Application.Commands;
using MediatrAndCqrs.Web.Application.Queries;
using MediatrAndCqrs.Web.Contracts.AddOrder;
using MediatrAndCqrs.Web.Contracts.GetTotal;
using Microsoft.AspNetCore.Mvc;

namespace MediatrAndCqrs.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderQueries orderQueries;
        private readonly IMediator mediator;

        public OrdersController(IOrderQueries orderQueries, IMediator mediator)
        {
            this.orderQueries = orderQueries;
            this.mediator = mediator;
        }

        [HttpGet("{description}/total")]
        public async Task<ActionResult<TotalForProduct>> Get(string description)
        {
            var total = await orderQueries.GetTotal(description);
            return Ok(total);
        }

        [HttpPost]
        public async Task<ActionResult> Post(AddOrderRequest order)
        {
            await mediator.Send(new MakeOrderCommand { OrderItems = order.OrderItems.Select(ToOrderItem).ToList() });
            return Ok();

            MakeOrderCommand.AddOrderItemModel ToOrderItem(AddOrderItemContract source) => new MakeOrderCommand.AddOrderItemModel
            {
                Count = source.Count,
                Description = source.Description
            };
        }
    }
}
