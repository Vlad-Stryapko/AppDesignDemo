using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkflowsAndCqrs.Web.ViewModels.AddOrder;
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

        //[HttpGet("{description}/total")]
        //public async Task<ActionResult<GetTotalViewModel>> Get(string description)
        //{
        //    //Mapping should ideally be separated but it's out of scope for this demo 
        //    //N.B. AutoMapper can be harmful
        //    var total = await orderService.GetTotalAsync(description);
        //    var viewModel = new GetTotalViewModel
        //    {
        //        Description = description,
        //        TotalCount = total.TotalCount
        //    };
        //    return Ok(viewModel);
        //}

        [HttpPost]
        public async Task<ActionResult> Post(AddOrderViewModel order)
        {
            //Mapping should ideally be separated but it's out of scope for this demo 
            //N.B. AutoMapper can be harmful
            var input = new MakeOrderWorkflowInput
                (
                    orderItems: order.OrderItems.Select
                    (
                        _ => new MakeOrderWorkflowInput.OrderItem(description: _.Description, count: _.Count)
                    ).ToList()
                );
            await this.makeOrderWorkflow.ExecuteAsync(input);
            return Ok();
        }
    }
}
