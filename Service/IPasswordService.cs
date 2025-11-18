using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Service
{
    public interface IPasswordService
    {
        Password checkPasswordStrong(Password password);
        Password checkPasswordStrong(string password);
        bool isPasswordStrong(string password, int minStrength = 2);
    }
}
