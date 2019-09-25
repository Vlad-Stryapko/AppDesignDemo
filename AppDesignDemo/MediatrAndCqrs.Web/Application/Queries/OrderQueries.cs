using System.Linq;
using System.Threading.Tasks;
using MediatrAndCqrs.Infrastructure.DataAccess;
using MediatrAndCqrs.Web.Contracts.GetTotal;
using Microsoft.EntityFrameworkCore;

namespace MediatrAndCqrs.Web.Application.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private readonly MediatrAndCqrsContext context;

        public OrderQueries(MediatrAndCqrsContext context)
        {
            this.context = context;
        }

        public async Task<TotalForProduct> GetTotal(string description)
        {
            var total = await context.OrderItems.Where(_ => _.Description == description).SumAsync(_ => _.Count);
            return new TotalForProduct
            {
                TotalCount = total,
                Description = description
            };
        }
    }
}
