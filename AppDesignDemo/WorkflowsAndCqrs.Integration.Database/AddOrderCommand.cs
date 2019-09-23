using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowsAndCqrs.Integration.Database
{
    public sealed class AddOrderCommand : IAddOrderCommand
    {
        private readonly WorkflowAndCqrsContext context;

        public AddOrderCommand(WorkflowAndCqrsContext context)
        {
            this.context = context;
        }

        public async Task ExecuteAsync(AddOrderCommandInput input)
        {
            var order = new PersistenceModels.Order
            {
                OrderedOn = input.OrderedOn,
                OrderItems = input.OrderItems.Select(_ => new PersistenceModels.OrderItem
                {
                    Count = _.Count,
                    Description = _.Description
                }).ToList()
            };

            await context.SaveChangesAsync();
        }
    }

    public sealed class AddOrderCommandInput
    {
        public AddOrderCommandInput(DateTime orderedOn, ICollection<OrderItem> orderItems)
        {
            this.OrderedOn = orderedOn;
            this.OrderItems = orderItems;
        }

        public DateTime OrderedOn { get; }

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

    public interface IAddOrderCommand
    {
        Task ExecuteAsync(AddOrderCommandInput input);
    }
}
