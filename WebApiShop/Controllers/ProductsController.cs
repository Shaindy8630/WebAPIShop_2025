using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _iproductService;

        public ProductsController(IProductService iproductService)
        {
            _iproductService = iproductService;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> Get(string? name, int[]? categories, int? minPrice, int? maxPrice, int? limit, string? orderBy, int? offset)
        {
            return await _iproductService.GetProducts(name, categories, minPrice, maxPrice, limit, orderBy, offset);
        }
       


    }
}
