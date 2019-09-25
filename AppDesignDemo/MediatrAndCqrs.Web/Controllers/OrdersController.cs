using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
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
            //var serviceModel = new AddOrderServiceModel
            //{
            //    OrderItems = order.OrderItems.Select(_ => new AddOrderItemServiceModel
            //    {
            //        Count = _.Count,
            //        Description = _.Description
            //    })
            //};
            //await this.orderService.AddOrderAsync(serviceModel);
            return Ok();
        }
    }
}
