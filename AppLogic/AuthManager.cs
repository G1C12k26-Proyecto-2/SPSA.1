using AppLogic.Interfaces;
using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AppLogic
{
    public class AuthManager : IAuthManager
    {
        public void ForgotPassword(string email)
        {
            // TODO: Implement ForgotPassword logic
            throw new NotImplementedException("ForgotPassword is not implemented yet.");

            /*
            var userCrud = new UserCrud();
            var tokenCrud = new PasswordResetTokenCrudFactory();

            var user = userCrud.RetrieveByEmail<User>(email);

            // Do NOT reveal if user exists
            if (user == null || !user.Active)
                return;

            // 1. Generate token
            var token = GenerateToken();

            // 2. Hash token
            var tokenHash = HashToken(token);

            // 3. Save in DB
            var resetToken = new PasswordResetToken
            {
                UserId = user.Id,
                TokenHash = tokenHash,
                Expiration = DateTime.UtcNow.AddMinutes(30),
                Used = false
            };

            tokenCrud.Create(resetToken);

            // 4. Send email (you already have Azure email working)
            var resetLink = $"http://localhost:4200/reset-password?token={token}";

            EmailService.Send(user.Email, "Reset Password", resetLink);
            */
        }

        public void ResetPassword(string token, string newPassword)
        {
            // TODO: Implement ResetPassword logic
            throw new NotImplementedException("ResetPassword is not implemented yet.");

            /*
            var tokenCrud = new PasswordResetTokenCrudFactory();
            var userCrud = new UserCrud();

            // 1. Hash incoming token
            var tokenHash = HashToken(token);

            // 2. Get token from DB
            var storedToken = tokenCrud.RetrieveByHash(tokenHash);

            if (storedToken == null)
                throw new Exception("Invalid or expired token");

            // 3. Get user
            var user = userCrud.RetrieveById<User>(storedToken.UserId);

            // 4. Update password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            userCrud.Update(user);

            // 5. Mark token as used
            tokenCrud.Update(storedToken);
            */
        }

        // 🔐 Helpers (keep these if you plan to reuse later)
        private string GenerateToken()
        {
            var bytes = RandomNumberGenerator.GetBytes(32);
            return Convert.ToBase64String(bytes);
        }

        private string HashToken(string token)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(token);
            return Convert.ToBase64String(sha256.ComputeHash(bytes));
        }
    }
}
