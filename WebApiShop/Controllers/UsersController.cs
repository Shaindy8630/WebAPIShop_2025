using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Text.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using Entity;
using Repository;
using Service;
namespace WebAPIShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "usersInfo.txt");
        private readonly Service.Service _service = new Service.Service();
        // GET: api/<UsersController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "can't show users list:(" };
        //}

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {
            
            var user = _service.getUserByID(id);
            if (user == null)
                return NotFound();

            return Ok(user);
           
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users user)
        {
            var result = _service.addUser(user);
            return CreatedAtAction(nameof(Get), new { id = result.UserId }, result);

        }

        [HttpPost("login")]
        public ActionResult<Users> Login([FromBody] LoginUsers loginUser)
        {
            var result = _service.loginUser(loginUser);
            return result == null ? Unauthorized() : Ok(result);
           
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users myUser)
        {
            _service.updateUser(id, myUser);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
