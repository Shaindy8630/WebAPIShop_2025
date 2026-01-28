using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Repository.Models;

namespace Service
{
    public interface IOrderService
    {
        Task<OrderDTO> AddOrder(OrderDTO order);

        Task<OrderDTO> GetOrderById(int id);
    }
}
