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

        public PasswordController(IUserService userService, IPasswordService passwordService)
        {
            _iPasswordService = passwordService;
        }


        // GET: api/<PasswordControler>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PasswordControler>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PasswordControler>
        [HttpPost]
        public ActionResult<Password> Post([FromBody] Password password)
        {
            Password resPassword = _iPasswordService.checkPasswordStrong(password);
            if (resPassword == null)
                return NoContent();
            return Ok(resPassword);
        }

        // PUT api/<PasswordControler>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PasswordControler>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
