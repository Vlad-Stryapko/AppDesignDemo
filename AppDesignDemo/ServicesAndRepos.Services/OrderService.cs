using ServicesAndRepos.DataAccess;
using ServicesAndRepos.Services.Interfaces.Emails;
using ServicesAndRepos.Services.Interfaces.Orders;
using ServicesAndRepos.Services.Interfaces.Orders.Models;
using ServicesAndRepos.Services.Interfaces.Orders.Models.AddOrder;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesAndRepos.Services
{
    public class OrderService : IOrderService
    {
        private readonly IEmailService emailService;
        private readonly IUnitOfWork unitOfWork;

        public async Task AddOrderAsync(AddOrderServiceModel order)
        {
            this.unitOfWork.OrderRepository.AddOrder(new Domain.Order
            {
                OrderedOn = DateTime.UtcNow,
                OrderItems = order.OrderItems.Select(_ => new Domain.OrderItem
                {
                    Count = _.Count,
                    Description = _.Description
                }).ToList()
            });
            await this.unitOfWork.SaveChangesAsync();

            await this.emailService.SendAsync(new object());            
        }

        public Task<GetOrderServiceModel> GetOrderAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
