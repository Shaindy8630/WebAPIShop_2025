using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        IPasswordService _iPasswordService;

        public PasswordController(IPasswordService passwordService)
        {
            _iPasswordService = passwordService;
        }

        // POST api/<PasswordController>
        [HttpPost]
        public ActionResult<Password> Post([FromBody] Password password)
        {
            Password resPassword = _iPasswordService.CheckPasswordStrong(password);
            if (resPassword == null)
                return NoContent();
            return Ok(resPassword);
        }
    }
}
