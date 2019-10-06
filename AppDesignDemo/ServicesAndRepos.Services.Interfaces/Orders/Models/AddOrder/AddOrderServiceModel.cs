using System.Collections.Generic;

namespace ServicesAndRepos.Services.Interfaces.Orders.Models.AddOrder
{
    public class AddOrderServiceModel
    {
        public IEnumerable<AddOrderItemServiceModel> OrderItems { get; set; }
    }
}
