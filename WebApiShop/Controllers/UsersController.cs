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

        public UsersController(IUserService userService, IPasswordService passwordService)
        {
            _iUserService = userService;
            _iPasswordService = passwordService;
        }

        //GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "can't show users list:(" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {

            var user = _iUserService.getUserByID(id);
            if (user == null)
                return NoContent();
            return Ok(user);

        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users user)
        {
            bool p = _iPasswordService.isPasswordStrong(user.UserPassword);
            if (!p)
                return BadRequest("Password is not strong enough.");
            var newUser = _iUserService.addUser(user);
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }

        [HttpPost("login")]
        public ActionResult<Users> Login([FromBody] Users loginUser)
        {
            var user = _iUserService.loginUser(loginUser);
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Users myUser)
        {
            bool p = _iUserService.updateUser(id, myUser);
            if (!p)
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
