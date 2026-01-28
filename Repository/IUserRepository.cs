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
        Task<User> addUser(User user);
        Task<User> getUserByID(int id);
       Task< User> loginUser(User loginUser);

        Task<IEnumerable<User>> GetUsers();
        void updateUser(int id, User myUser);
    }
}
