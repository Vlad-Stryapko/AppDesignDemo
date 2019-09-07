using ServicesAndRepos.Domain;
using System;

namespace ServicesAndRepos.DataAccess
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        Order GetOrder(int id);
    }
}
