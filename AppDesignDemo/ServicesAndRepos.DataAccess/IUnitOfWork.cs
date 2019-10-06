using System.Threading.Tasks;

namespace ServicesAndRepos.DataAccess
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        Task SaveChangesAsync();
    }
}
