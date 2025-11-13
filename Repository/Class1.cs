

using System.Text.Json;
using Entity;
namespace Repository
 
{
    public class Repository
    {
        string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "usersInfo.txt");
        public Users getUserByID(int id)
        {
            string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "usersInfo.txt");
            using (StreamReader reader = System.IO.File.OpenText(_filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.UserId == id)
                        return user;
                }
            }
            return null;
        }
        public Users addUser(Users user)
        {
            int numberOfUsers = System.IO.File.ReadLines(_filePath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(_filePath, userJson + Environment.NewLine);
            return user;
        }
        public Users loginUser(LoginUsers loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(_filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.UserEmail == loginUser.LoginUserEmail && user.UserPassword == loginUser.LoginUserPassword)
                        return user;
                }
            }
            return null;

        }
        public void updateUser(int id, Users Myuser)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(_filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(_filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(Myuser));
                System.IO.File.WriteAllText(_filePath, text);
            }

        }

    }
}
