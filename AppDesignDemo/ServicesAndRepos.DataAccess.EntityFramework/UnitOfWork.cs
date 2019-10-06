using System.Threading.Tasks;

namespace ServicesAndRepos.DataAccess.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServicesAndReposContext context;
        private readonly IOrderRepository orderRepository;

        public UnitOfWork(ServicesAndReposContext context, IOrderRepository orderRepository)
        {
            this.context = context;
            this.orderRepository = orderRepository;
        }

        public IOrderRepository OrderRepository => this.orderRepository;

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
