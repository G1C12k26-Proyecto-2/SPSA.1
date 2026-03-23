using AppLogic.Interfaces;
using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic
{
    public class UserManager : IUserManager
    {
        public User ValidateUser(string username, string password)
        {
            var userCrud = new UserCrud();

            var user = userCrud.RetrieveByUsername<User>(username);

            if (user == null || !user.Active)
                return null;

            bool valid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!valid)
                return null;

            return user;
        }

        public void CreateUser(CreateUserDTO newUser)
        {
            var userCrud = new UserCrud();

            var user = new User
            {
                UserName = newUser.UserName,
                FullName = newUser.FullName,
                Active = true,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password)
            };

            userCrud.Create(user);
        }
    }
}

