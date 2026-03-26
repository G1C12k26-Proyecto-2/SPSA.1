using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic.Interfaces
{
    public interface IAuthManager
    {
        void ForgotPassword(string email);
        void ResetPassword(string token, string newPassword);
    }
}
