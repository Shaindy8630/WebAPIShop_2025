using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _iorderService;

        public OrdersController(IOrderService iorderService)
        {
            _iorderService = iorderService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetById(int id)
        {
            OrderDTO orderRes=await _iorderService.GetOrderById(id);
            if(orderRes == null) 
                return NoContent();
            return Ok(orderRes);

        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO order)
        {
            OrderDTO orderRes=await _iorderService.AddOrder(order);
            return CreatedAtAction(nameof(GetById),new {id=orderRes.OrderId }, orderRes);
        } 
    }
}
