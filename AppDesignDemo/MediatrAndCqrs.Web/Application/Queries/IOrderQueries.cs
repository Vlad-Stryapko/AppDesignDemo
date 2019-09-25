using MediatrAndCqrs.Web.Contracts.GetTotal;
using System.Threading.Tasks;

namespace MediatrAndCqrs.Web.Application.Queries
{
    public interface IOrderQueries
    {
        Task<TotalForProduct> GetTotal(string description);
    }
}
