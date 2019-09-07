using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesAndRepos.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int Count { get; set; }
        public string Description { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
