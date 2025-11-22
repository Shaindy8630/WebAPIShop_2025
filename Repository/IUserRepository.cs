using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Repository
{
    public interface IUserRepository
    {
        Users AddUser(Users user);
        Users GetUserById(int id);
        Users LoginUser(Users loginUser);
        void UpdateUser(int id, Users myUser);
    }
}
