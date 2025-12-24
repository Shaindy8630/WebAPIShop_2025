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
       Task<User> addUser(User user);
       Task< User> getUserByID(int id);
       Task< User> loginUser(User loginUser);

       Task <IEnumerable<User>> GetUsers();
       bool UpdateUser(int id, User user);
    }
}
