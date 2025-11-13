using Entity;
using Repository;
using Zxcvbn;


namespace Service
{
    public class Service
    {
        public Users getUserByID(int id)
        {
            Repository.Repository repository = new Repository.Repository();
            return repository.getUserByID(id);
        }

        public Users addUser(Users user)
        {
            Repository.Repository repository = new Repository.Repository();
            return repository.addUser(user);
        }

        public Users loginUser(LoginUsers loginUser)
        {
            Repository.Repository repository = new Repository.Repository();
            return repository.loginUser(loginUser);
        }
        public void updateUser(int id, Users myUser)
        {
            Repository.Repository repository = new Repository.Repository();
            repository.updateUser(id, myUser);
        }
        public int checlPassword(string pass)
        {
            var result = Zxcvbn.Core.EvaluatePassword(pass);
            return result.Score;
        }



    }
}
