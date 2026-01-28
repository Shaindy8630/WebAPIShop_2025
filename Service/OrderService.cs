using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Repository;
using Repository.Models;
using DTO;

namespace Service
{
    public  class OrderService:IOrderService
    {
        private readonly IOrderRepository _iorderRepository;
        private readonly IMapper _imapper;
        public OrderService (IOrderRepository iorderRepository,IMapper mapper)
        {
            _iorderRepository = iorderRepository;
            _imapper = mapper;
        }

        public async Task<OrderDTO> AddOrder(OrderDTO order)
        {
            Order ord = _imapper.Map<OrderDTO, Order>(order);
            Order res =await _iorderRepository.AddOrder(ord);
            OrderDTO orderDTO = _imapper.Map<Order, OrderDTO>(res);
            return orderDTO;

        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            Order order =await _iorderRepository.GetOrderById(id);
            OrderDTO orderDTO = _imapper.Map<Order, OrderDTO>(order);
            return orderDTO;
        }
    }
}
