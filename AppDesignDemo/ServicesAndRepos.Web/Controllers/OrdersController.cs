using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicesAndRepos.Services.Interfaces.Orders;
using ServicesAndRepos.Services.Interfaces.Orders.Models;
using ServicesAndRepos.Services.Interfaces.Orders.Models.AddOrder;
using ServicesAndRepos.Web.ViewModels;
using ServicesAndRepos.Web.ViewModels.AddOrder;
using ServicesAndRepos.Web.ViewModels.GetOrder;

namespace ServicesAndRepos.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetOrderViewModel>> Get(int id)
        {
            var order = await orderService.GetOrderAsync(id);
            //Mapping should ideally be separated but it's out of scope for this demo 
            //N.B. AutoMapper can be harmful
            var viewModel = new GetOrderViewModel
            {
                OrderedOn = order.OrderedOn,
                OrderItems = order.OrderItems.Select(_ => new GetOrderItemViewModel
                {
                    Count = _.Count,
                    Description = _.Description
                }).ToList()
            };
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post(AddOrderViewModel order)
        {
            //Mapping should ideally be separated but it's out of scope for this demo 
            //N.B. AutoMapper can be harmful
            var serviceModel = new AddOrderServiceModel
            {
                OrderItems = order.OrderItems.Select(_ => new AddOrderItemServiceModel
                {
                    Count = _.Count,
                    Description = _.Description
                })
            };
            await this.orderService.AddOrderAsync(serviceModel);
            return Ok();
        }
    }
}
