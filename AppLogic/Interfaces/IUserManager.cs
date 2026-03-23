using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic.Interfaces
{
    public interface IUserManager
    {
        User ValidateUser(string username, string password);
        void CreateUser(CreateUserDTO newUser);
    }

}
