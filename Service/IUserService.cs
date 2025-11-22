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
        Users AddUser(Users user);
        Users GetUserById(int id);
        Users LoginUser(Users loginUser);
        bool UpdateUser(int id, Users user);
    }
}
