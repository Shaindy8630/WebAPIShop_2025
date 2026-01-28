

using System.Text.Json;
using Entity;
using Repository.Models;
namespace Repository
 
{
    public class UserRepository : IUserRepository
    {
        UsersContext _dbContext;

        public UserRepository(UsersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return _dbContext.Users;
        }
        public async Task<User> GetUserByID(int id)
        {
           
           return await _dbContext.Users.FindAsync(id);
        }
        public async Task<User> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> LoginUser(User loginUser)
        {
            try
            {
                return await _dbContext.Users.FindAsync(loginUser);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async void updateUser(int id, User Myuser)
        {

            _dbContext.Users.Update(Myuser);
            await _dbContext.SaveChangesAsync();
        }

    }
}
