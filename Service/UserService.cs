using Entity;
using Repository;
using Zxcvbn;


namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<Users> GetUserByID(int id)
        {
           
            return await _userRepository.GetUserByID(id);
        }

        public async Task<Users> AddUser(Users user)
        {
           
            return await _userRepository.AddUser(user);
        }

        public async Task<Users> LoginUser(Users loginUser)
        {
            
            return await _userRepository.LoginUser(loginUser);
        }
        public async Task<bool> UpdateUser(int id, Users myUser)
        {

            var result = Zxcvbn.Core.EvaluatePassword(myUser.UserPassword);
            if (result.Score >= 2)
            {
                await _userRepository.UpdateUser(id, myUser);
                return true;
            }
            return false;
        }
       



    }
}
