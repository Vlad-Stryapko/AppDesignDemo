using System;
using System.Collections.Generic;

namespace ServicesAndRepos.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderedOn { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
