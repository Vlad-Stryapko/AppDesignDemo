using System.Collections.Generic;

namespace ServicesAndRepos.Web.ViewModels.AddOrder
{
    public class AddOrderViewModel
    {
        public IEnumerable<AddOrderItemViewModel> OrderItems { get; set; }
    }
}
