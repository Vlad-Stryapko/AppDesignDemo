using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkflowsAndCqrs.Web.ViewModels.AddOrder;
using WorkflowsAndCqrs.Web.ViewModels.GetOrder;
using WorkflowsAndCqrs.Web.Workflows;

namespace WorkflowsAndCqrs.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMakeOrderWorkflow makeOrderWorkflow;

        public OrdersController(IMakeOrderWorkflow makeOrderWorkflow)
        {
            this.makeOrderWorkflow = makeOrderWorkflow;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetOrderViewModel>> Get(int id)
        {
            //var order = await orderService.GetOrderAsync(id);
            ////Mapping should ideally be separated but it's out of scope for this demo 
            ////N.B. AutoMapper can be harmful
            //var viewModel = new GetOrderViewModel
            //{
            //    OrderedOn = order.OrderedOn,
            //    OrderItems = order.OrderItems.Select(_ => new GetOrderItemViewModel
            //    {
            //        Count = _.Count,
            //        Description = _.Description
            //    }).ToList()
            //};
            //return Ok(viewModel);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Post(AddOrderViewModel order)
        {
            //Mapping should ideally be separated but it's out of scope for this demo 
            //N.B. AutoMapper can be harmful
            var input = new IMakeOrderWorkflowInput
                (
                    orderedBy: User.Identity.Name,
                    orderItems: order.OrderItems.Select
                    (
                        _ => new IMakeOrderWorkflowInput.OrderItem(description: _.Description, count: _.Count)
                    ).ToList()
                );
           
            await this.makeOrderWorkflow.ExecuteAsync(input);
            return Ok();
        }
    }
}
