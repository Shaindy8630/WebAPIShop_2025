using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Repository.Models;

namespace Service
{
    public class ProductService :IProductService
    {
        private readonly IProductRepository _iproductRepository;

        public ProductService(IProductRepository iproductRepository)
        {
            _iproductRepository = iproductRepository;
        }

        public async Task<IEnumerable<Product>> GetProducts(string? name, int[]? categories, int? nimPrice, int? maxPrice, int? limit, string? orderBy, int? offset)
        {
            return await _iproductRepository.GetProducts(name, categories, nimPrice, maxPrice, limit, orderBy, offset);
        }
    }
}
