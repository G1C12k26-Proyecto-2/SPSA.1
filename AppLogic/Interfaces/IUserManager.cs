using DTO;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AppLogic.Interfaces
{
    public interface IUserManager
    {
        User ValidateUser(string username, string password);
        void CreateUser(CreateUserDTO newUser, string rol);
        List<User> RetrieveAllUsers();

        User RetrieveUserById(int id);
        void UpdateUser(UpdateUserDTO updatedUser);

        void DeactivateUser(int id);

        void ActivateUser(int id);

    }

}
