using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesAndRepos.Services.Interfaces.Orders.Models
{
    public class GetOrderServiceModel
    {
        public DateTime OrderedOn { get; set; }
        public ICollection<GetOrderItemServiceModel> OrderItems { get; set; }
    }
}
