using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesAndRepos.Web.ViewModels.AddOrder
{
    public class AddOrderViewModel
    {
        public IEnumerable<AddOrderItemViewModel> OrderItems { get; set; }
    }
}
