using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository
{
    public class OrderRepository:IOrderRepository
    {
        UsersContext _usersContext;

        public OrderRepository( UsersContext usersContext)
        {
            _usersContext = usersContext;
        }

        public async Task<Order> AddOrder(Order order)
        {
            _usersContext.Orders.AddAsync(order);
            await _usersContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _usersContext.Orders.FindAsync(id);
        }
    }
}
