using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowsAndCqrs.Integration.Database;
using WorkflowsAndCqrs.Integration.Email;

namespace WorkflowsAndCqrs.Web.Workflows
{
    public class MakeOrderWorkflow : IMakeOrderWorkflow
    {
        private readonly IAddOrderCommand addOrderCommand;
        private readonly ISendEmailCommand sendEmailCommand;

        public MakeOrderWorkflow(IAddOrderCommand addOrderCommand, ISendEmailCommand sendEmailCommand)
        {
            this.addOrderCommand = addOrderCommand;
            this.sendEmailCommand = sendEmailCommand;
        }

        public async Task ExecuteAsync(MakeOrderWorkflowInput input)
        {
            Log.Information("MakeOrder workflow has been started");
            await this.addOrderCommand.ExecuteAsync(new AddOrderCommandInput
                (
                    orderedOn: DateTime.UtcNow,
                    orderItems: input.OrderItems.Select(_ => new AddOrderCommandInput.OrderItem
                    (
                        description: _.Description,
                        count: _.Count
                    )).ToList()
                ));
            await this.sendEmailCommand.ExecuteAsync(new object());
            Log.Information("MakeOrder workflow has finished");
        }
    }

    public interface IMakeOrderWorkflow
    {
        Task ExecuteAsync(MakeOrderWorkflowInput input);
    }

    public sealed class MakeOrderWorkflowInput
    {
        public MakeOrderWorkflowInput(ICollection<OrderItem> orderItems)
        { 
            this.OrderItems = orderItems;
        }

        public ICollection<OrderItem> OrderItems { get; }

        public sealed class OrderItem
        {
            public OrderItem(string description, int count)
            {
                this.Description = description;
                this.Count = count;
            }

            public string Description { get; }
            public int Count { get; }
        }
    }
}
