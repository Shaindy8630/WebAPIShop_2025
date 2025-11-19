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
        Password CheckPasswordStrong(Password password);
        Password CheckPasswordStrong(string password);
        bool IsPasswordStrong(string password, int minStrength = 2);
    }
}
