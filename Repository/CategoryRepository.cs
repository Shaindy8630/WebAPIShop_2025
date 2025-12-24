using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        UsersContext _usersContext;

        public CategoryRepository( UsersContext usersContext)
        {
            _usersContext = usersContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _usersContext.Categories.ToListAsync();
        }

    }
}
