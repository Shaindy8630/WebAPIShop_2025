using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO;
using Repository;
using Repository.Models;

namespace Service
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _icategoryRepository;
        private readonly IMapper _imapper;
        public CategoryService (ICategoryRepository icategoryRepository,IMapper mapper)
        {
            _icategoryRepository = icategoryRepository;
            _imapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            IEnumerable<Category> c= await _icategoryRepository.GetCategories();
            IEnumerable<CategoryDTO> categoryDTOs=_imapper.Map<IEnumerable<Category> ,IEnumerable<CategoryDTO>>(c);
            return categoryDTOs;

        }
    }
}
