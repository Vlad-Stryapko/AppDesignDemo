using System.Collections.Generic;

namespace WorkflowsAndCqrs.Web.ViewModels.AddOrder
{
    public class AddOrderViewModel
    {
        public IEnumerable<AddOrderItemViewModel> OrderItems { get; set; }
    }
}
