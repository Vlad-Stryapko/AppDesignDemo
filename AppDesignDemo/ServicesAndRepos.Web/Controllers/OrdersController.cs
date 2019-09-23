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

        [HttpGet("{description}/total")]
        public async Task<ActionResult<GetTotalViewModel>> Get(string description)
        {
            //Mapping should ideally be separated but it's out of scope for this demo 
            //N.B. AutoMapper can be harmful
            var total = await orderService.GetTotalAsync(description);
            var viewModel = new GetTotalViewModel
            {
                Description = description,
                TotalCount = total.TotalCount
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
