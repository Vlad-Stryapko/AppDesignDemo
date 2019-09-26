using Serilog;
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

        public OrderService(IEmailService emailService, IUnitOfWork unitOfWork)
        {
            this.emailService = emailService;
            this.unitOfWork = unitOfWork;
        }

        public async Task MakeOrderAsync(AddOrderServiceModel order)
        {
            Log.Information("Make order service method has been called");

            Log.Information("Order will be saved to the database");
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
            Log.Information("Order has been saved");

            await this.emailService.SendAsync(new object());
            Log.Information("Make order service method has finished");
        }

        public async Task<GetTotalServiceModel> GetTotalAsync(string description)
        {
            var total = await unitOfWork.OrderRepository.GetTotalAsync(description);
            return new GetTotalServiceModel
            {
                TotalCount = total.TotalCount
            };
        }
    }
}
