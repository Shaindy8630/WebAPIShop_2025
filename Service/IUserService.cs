using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Service
{
    public interface IUserService
    {
        Task<Users> AddUser(Users user);
        Task<Users> GetUserByID(int id);
        Task<Users> LoginUser(Users loginUser);
        Task<IEnumerable<Users>> GetUsers();
        Task<bool> UpdateUser(int id, Users user);
    }
}
