using System.Collections.Generic;

namespace MediatrAndCqrs.Web.Contracts.AddOrder
{
    public class AddOrderRequest
    {
        public IEnumerable<AddOrderItemContract> OrderItems { get; set; }
    }
}
