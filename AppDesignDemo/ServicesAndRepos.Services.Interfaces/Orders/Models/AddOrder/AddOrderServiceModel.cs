using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesAndRepos.Services.Interfaces.Orders.Models.AddOrder
{
    public class AddOrderServiceModel
    {
        public IEnumerable<AddOrderItemServiceModel> OrderItems { get; set; }
    }
}
