using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAndRepos.DataAccess
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        Task SaveChangesAsync();
    }
}
