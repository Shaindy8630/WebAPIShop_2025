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

        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public UsersController(IUserService userService, IPasswordService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
        {

            var user = await _userService.GetUserByID(id);
            if (user == null)
                return NotFound();
            return Ok(user);

        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<Users>> Post([FromBody] Users user)
        {
            bool isPasswordStrong = _passwordService.IsPasswordStrong(user.UserPassword);
            if (!isPasswordStrong)
                return BadRequest("Password is not strong enough.");
            var newUser = await _userService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Users>> Login([FromBody] Users loginUser)
        {
            var user = await _userService.LoginUser(loginUser);
            if (user != null)
                return Ok(user);
            return Unauthorized("Invalid credentials.");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Users myUser)
        {
            bool isUpdateSuccessful = await _userService.UpdateUser(id, myUser);
            if (!isUpdateSuccessful)
                return BadRequest("Password is not strong enough");
            return NoContent();
        }
    }
}
