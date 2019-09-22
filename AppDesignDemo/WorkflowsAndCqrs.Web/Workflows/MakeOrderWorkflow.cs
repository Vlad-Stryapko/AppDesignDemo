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

        public async Task ExecuteAsync(IMakeOrderWorkflowInput input)
        {
            await this.addOrderCommand.ExecuteAsync(new AddOrderCommandInput());
            await this.sendEmailCommand.ExecuteAsync(new object());
        }
    }

    public interface IMakeOrderWorkflow
    {
        Task ExecuteAsync(IMakeOrderWorkflowInput input);
    }

    public sealed class IMakeOrderWorkflowInput
    {
        public IMakeOrderWorkflowInput(string orderedBy, ICollection<OrderItem> orderItems)
        {
            this.OrderedBy = orderedBy;
            this.OrderItems = orderItems;
        }

        public string OrderedBy { get; }
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
