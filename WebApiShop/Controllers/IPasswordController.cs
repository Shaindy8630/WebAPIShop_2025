using Entity;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApiShop.Controllers
{
    public interface IPasswordController
    {
        IActionResult checkPassword([FromBody] Password password);
        void Delete(int id);
        IEnumerable<string> Get();
        string Get(int id);
        void Put(int id, [FromBody] string value);
    }
}
