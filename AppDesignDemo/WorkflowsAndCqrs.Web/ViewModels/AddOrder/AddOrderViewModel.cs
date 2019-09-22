using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowsAndCqrs.Web.ViewModels.AddOrder
{
    public class AddOrderViewModel
    {
        public IEnumerable<AddOrderItemViewModel> OrderItems { get; set; }
    }
}
