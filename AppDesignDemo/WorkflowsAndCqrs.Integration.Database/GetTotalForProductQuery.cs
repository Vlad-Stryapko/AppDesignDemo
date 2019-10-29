using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowsAndCqrs.Integration.Database
{
    public sealed class GetTotalForProductQuery : IGetTotalForProductQuery
    {
        private readonly WorkflowAndCqrsContext context;

        public GetTotalForProductQuery(WorkflowAndCqrsContext context)
        {
            this.context = context;
        }

        public async Task<TotalForProduct> ExecuteAsync(string description)
        {
            var total = await context.OrderItems.Where(_ => _.Description == description).SumAsync(_ => _.Count);
            return new TotalForProduct
            (
                totalCount: total,
                description: description
            );
        }
    }

    public interface IGetTotalForProductQuery
    {
        Task<TotalForProduct> ExecuteAsync(string description);
    }

    public sealed class TotalForProduct
    {
        public TotalForProduct(int totalCount, string description)
        {
            this.TotalCount = totalCount;
            this.Description = description;
        }

        public int TotalCount { get; }
        public string Description { get; }
    }
}
