using ServicesAndRepos.DataAccess.Models;
using ServicesAndRepos.Domain;
using System.Threading.Tasks;

namespace ServicesAndRepos.DataAccess
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        Task<OrderTotal> GetTotalAsync(string description);
    }
}
