﻿using System;
using System.Collections.Generic;

namespace WorkflowsAndCqrs.Integration.Database.PersistenceModels
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderedOn { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
