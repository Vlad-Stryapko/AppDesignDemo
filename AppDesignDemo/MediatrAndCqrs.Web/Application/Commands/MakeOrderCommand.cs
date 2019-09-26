using MediatR;
using System.Collections.Generic;

namespace MediatrAndCqrs.Web.Application.Commands
{
    public class MakeOrderCommand : IRequest
    {
        public ICollection<AddOrderItemModel> OrderItems { get; set; }

        public class AddOrderItemModel
        {
            public int Count { get; set; }
            public string Description { get; set; }
        }
    }
}
