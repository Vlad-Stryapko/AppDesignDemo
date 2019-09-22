using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorkflowsAndCqrs.Integration.Database
{
    public interface IAddOrderCommand
    {
        Task ExecuteAsync(AddOrderCommandInput input);
    }

    public sealed class AddOrderCommandInput
    {
        public DateTime OrderedOn { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public sealed class OrderItem
        {
            public string Description { get; set; }
            public int Count { get; set; }
        }
    }

    public sealed class AddOrderCommand : IAddOrderCommand
    {
        public async Task ExecuteAsync(AddOrderCommandInput input)
        {
            //use db context 
            //calls saveChanges
        }
    }
}
