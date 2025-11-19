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
        public Password CheckPasswordStrong(Password password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password.PasswordValue);
            password.Strength = result.Score;
            return password;
        }
        public Password CheckPasswordStrong(string password)
        {
            return CheckPasswordStrong(new Password { PasswordValue = password });
        }
        public bool IsPasswordStrong(string password, int minStrength = 2)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score >= minStrength;
        }
    }
}
