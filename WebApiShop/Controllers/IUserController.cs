using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIShop.Controllers
{
    public interface IUserController
    {
        Task<ActionResult<Users>> Get(int id);
        Task<ActionResult<Users>> Login([FromBody] Users loginUser);
        Task<ActionResult<Users>> Post([FromBody] Users user);
        Task<IActionResult> Put(int id, [FromBody] Users myUser);
    }
}
