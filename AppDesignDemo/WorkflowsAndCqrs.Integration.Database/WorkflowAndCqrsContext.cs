using Microsoft.EntityFrameworkCore;
using WorkflowsAndCqrs.Integration.Database.PersistenceModels;

namespace WorkflowsAndCqrs.Integration.Database
{
    public class WorkflowAndCqrsContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
