using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        ICategoryService _icategoryService;

        public CategoriesController(ICategoryService icategoryService)
        {
            _icategoryService = icategoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            return await _icategoryService.GetCategories();
        }
    }
}
