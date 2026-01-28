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

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<User> getUserByID(int id)
        {
           
            return await _userRepository.getUserByID(id);
        }

        public async Task< User> addUser(User user)
        {
           
            return await _userRepository.addUser(user);
        }

        public async Task< User> loginUser(User loginUser)
        {
            
            return await _userRepository.loginUser(loginUser);
        }
        public bool UpdateUser(int id, User myUser)
        {

            var result = Zxcvbn.Core.EvaluatePassword(myUser.Password);
            if (result.Score >= 2)
            {
                _userRepository.updateUser(id, myUser);
                return true;
            }
            return false;
        }
       



    }
}
