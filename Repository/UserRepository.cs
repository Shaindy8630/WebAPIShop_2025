

using System.Text.Json;
using Entity;
using Repository.Models;
namespace Repository
 
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext _dbContext;

        public UserRepository(UsersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<Users> GetUserByID(int id)
        {
           
           return await _dbContext.Users.FindAsync(id);
        }
        public async Task<Users> AddUser(Users user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<Users> LoginUser(Users loginUser)
        {
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == loginUser.UserName && u.UserPassword == loginUser.UserPassword);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task UpdateUser(int id, Users Myuser)
        {

            _dbContext.Users.Update(Myuser);
            await _dbContext.SaveChangesAsync();
        }

    }
}
