using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Repository.Models;

namespace Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
    }
}
