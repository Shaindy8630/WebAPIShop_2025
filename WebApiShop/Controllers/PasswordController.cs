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
        IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        // POST api/<PasswordController>
        [HttpPost]
        public ActionResult<Password> Post([FromBody] Password password)
        {
            Password resPassword = _passwordService.CheckPasswordStrong(password);
            if (resPassword == null)
                return NoContent();
            return Ok(resPassword);
        }
    }
}
