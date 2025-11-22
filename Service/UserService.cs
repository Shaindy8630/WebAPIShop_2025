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
        public Users GetUserById(int id)
        {
           
            return _userRepository.GetUserById(id);
        }

        public Users AddUser(Users user)
        {
           
            return _userRepository.AddUser(user);
        }

        public Users LoginUser(Users loginUser)
        {
            
            return _userRepository.LoginUser(loginUser);
        }
        public bool UpdateUser(int id, Users myUser)
        {

            var result = Zxcvbn.Core.EvaluatePassword(myUser.UserPassword);
            if (result.Score >= 2)
            {
                _userRepository.UpdateUser(id, myUser);
                return true;
            }
            return false;
        }
       



    }
}
