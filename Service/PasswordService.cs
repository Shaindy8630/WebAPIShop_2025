using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;

namespace Service
{
    public class PasswordService : IPasswordService
    {
        public Password checkPasswordStrong(Password password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password.password);
            password.Strength = result.Score;
            return password;
        }
        public Password checkPasswordStrong(string password)
        {
            return checkPasswordStrong(new Password { password = password });
        }
        public bool isPasswordStrong(string password, int minStrength = 2)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score >= minStrength;
        }
    }
}
