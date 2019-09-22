using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowsAndCqrs.Web.ViewModels.GetOrder
{
    public class GetOrderViewModel
    {
        public DateTime OrderedOn { get; set; }
        public IEnumerable<GetOrderItemViewModel> OrderItems { get; set; }
    }
}
