using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Text.Json;
using Entity;
using Service;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Repository;

namespace WebAPIShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase, IUserController
    {

        IUserService _iUserService;
        IPasswordService _iPasswordService;
        private readonly ILogger<UsersController> _logger;


        public UsersController(IUserService userService, IPasswordService passwordService)
        {
            _iUserService = userService;
            _iPasswordService = passwordService;
        }

        //GET: api/<UsersController>
        [HttpGet]
        public async Task< IEnumerable<string>> Get()
        {
            return new string[] { "can't show users list:(" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task< ActionResult<IEnumerable<User>>> Get(int id)
        {

            var user = _iUserService.getUserByID(id);
            if (user == null)
                return NotFound();
            return Ok(user);

        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task< ActionResult<User>>Post([FromBody] User user)
        {
            bool isPasswordStrong = _iPasswordService.IsPasswordStrong(user.Password);
            if (!isPasswordStrong)
                return BadRequest("Password is not strong enough.");
             user = await _iUserService.addUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        [HttpPost("login")]
        public async Task< ActionResult<User>> Login([FromBody] User loginUser)
        {
            var user = _iUserService.loginUser(loginUser);
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User myUser)
        {
            bool isUpdateSuccessful = _iUserService.UpdateUser(id, myUser);
            _logger.LogInformation($"login attempted id:{myUser.UserId} email:{myUser.Email} first name:{myUser.FirstName} last name:{myUser.LastName}");

            if (!isUpdateSuccessful)
                return BadRequest("Password is not strong enough");
            return NoContent();
        }

       


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
