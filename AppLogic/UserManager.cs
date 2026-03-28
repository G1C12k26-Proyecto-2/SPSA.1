using AppLogic.Interfaces;
using AppLogic.Templates;
using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic
{
    public class UserManager : IUserManager
    {
        private readonly IEmailService _emailService;

        public UserManager(IEmailService emailService)
        {
            _emailService = emailService;
        }

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

        public List<User> RetrieveAllUsers()
        {
            var crud = new UserCrud();
            return crud.RetrieveAll<User>();
        }

        public void CreateUser(CreateUserDTO newUser, string rol)
        {
            var crud = new UserCrud();

            var user = new User
            {
                UserName = newUser.UserName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
                FullName = newUser.FullName,
                Email = newUser.Email,
                Active = true,
                Rol = rol
            };

            crud.Create(user);

            try
            {
                var emailMessage = AuthEmailTemplateBuilder.BuildUserCreatedEmail(user);

                _emailService.Send(
                    user.Email,
                    emailMessage.Subject,
                    emailMessage.PlainTextBody,
                    emailMessage.HtmlBody
                );
            }
            catch (Exception ex)
            {
                throw new Exception("User created, but email failed: " + ex.Message);
            }
        }

        public void UpdateUser(UpdateUserDTO updatedUser)
        {
            if (updatedUser.Rol != "Admin" &&
                updatedUser.Rol != "Funcionario" &&
                updatedUser.Rol != "Propietario")
            {
                throw new Exception("Invalid role");
            }

            var crud = new UserCrud();

            var user = new User
            {
                Id = updatedUser.Id,
                UserName = updatedUser.UserName,
                FullName = updatedUser.FullName,
                Email = updatedUser.Email,
                Active = updatedUser.Active,
                Rol = updatedUser.Rol
            };

            crud.Update(user);

            try
            {
                var emailMessage = AuthEmailTemplateBuilder.BuildUserUpdatedEmail(user);

                _emailService.Send(
                    user.Email,
                    emailMessage.Subject,
                    emailMessage.PlainTextBody,
                    emailMessage.HtmlBody
                );
            }
            catch (Exception ex)
            {
                throw new Exception("User updated, but email failed: " + ex.Message);
            }
        }
    }
}

