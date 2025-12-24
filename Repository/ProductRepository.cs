using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository
{
    public class ProductRepository:IProductRepository
    {
        UsersContext _usersContext;

        public ProductRepository(UsersContext usersContext)
        {
            _usersContext = usersContext;
        }

        public async Task<IEnumerable<Product>> GetProducts(string? name, int[]? categories, int? nimPrice, int? maxPrice, int? limit, string? orderBy, int? offset)
        {
            return await _usersContext.Products.ToListAsync();
        }
    }
}
