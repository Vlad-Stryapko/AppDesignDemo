using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesAndRepos.Services.Interfaces.Orders.Models
{
    public class GetOrderItemServiceModel
    {
        public string Description { get; set; }
        public int Count { get; set; }
    }
}
