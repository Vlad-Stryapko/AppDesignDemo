using ServicesAndRepos.Services.Interfaces.Orders.Models;
using ServicesAndRepos.Services.Interfaces.Orders.Models.AddOrder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAndRepos.Services.Interfaces.Orders
{
    public interface IOrderService
    {
        Task AddOrderAsync(AddOrderServiceModel order);

        Task<GetOrderServiceModel> GetOrderAsync(int id);
    }
}
