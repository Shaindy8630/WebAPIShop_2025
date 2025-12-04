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

        public async Task<Users> getUserByID(int id)
        {
           
            return await _userRepository.getUserByID(id);
        }

        public async Task< Users> addUser(Users user)
        {
           
            return await _userRepository.addUser(user);
        }

        public async Task< Users> loginUser(Users loginUser)
        {
            
            return await _userRepository.loginUser(loginUser);
        }
        public bool UpdateUser(int id, Users myUser)
        {

            var result = Zxcvbn.Core.EvaluatePassword(myUser.UserPassword);
            if (result.Score >= 2)
            {
                _userRepository.updateUser(id, myUser);
                return true;
            }
            return false;
        }
       



    }
}
