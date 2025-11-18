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
        Users addUser(Users user);
        Users getUserByID(int id);
        Users loginUser(Users loginUser);
        bool updateUser(int id, Users user);
    }
}
