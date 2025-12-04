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
        Task<Users> addUser(Users user);
        Task<Users> getUserByID(int id);
       Task< Users> loginUser(Users loginUser);

        Task<IEnumerable<Users>> GetUsers();
        void updateUser(int id, Users myUser);
    }
}
