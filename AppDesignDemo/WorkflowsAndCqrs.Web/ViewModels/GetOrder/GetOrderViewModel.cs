using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesAndRepos.Web.ViewModels.GetOrder
{
    public class GetOrderViewModel
    {
        public DateTime OrderedOn { get; set; }
        public IEnumerable<GetOrderItemViewModel> OrderItems { get; set; }
    }
}
