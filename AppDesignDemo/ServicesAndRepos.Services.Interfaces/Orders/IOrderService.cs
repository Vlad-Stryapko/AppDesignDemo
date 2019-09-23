using ServicesAndRepos.Services.Interfaces.Orders.Models;
using ServicesAndRepos.Services.Interfaces.Orders.Models.AddOrder;
using System.Threading.Tasks;

namespace ServicesAndRepos.Services.Interfaces.Orders
{
    public interface IOrderService
    {
        Task AddOrderAsync(AddOrderServiceModel order);

        Task<GetTotalServiceModel> GetTotalAsync(string description);
    }
}
